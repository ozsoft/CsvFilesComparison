using System;
namespace CsvFilesComparison
{
    public class CompareCsvFiles
    {
        public CompareCsvFiles()
        {
        }


        public void CompareCsvs(Csv csv1, Csv csv2)
        {
            int count = 0;

            //compare of the line size of csvs and get the csv with largest line count
            if (csv1.sizeOfCsv() > csv2.sizeOfCsv())
            {
                count = csv1.sizeOfCsv();
            }
            else
            {
                count = csv2.sizeOfCsv();
            }


            //we have taken the line size of the largest csv file and compare that many times 
            for (int i = 0; i < count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                int csv2Index = csv2.GetList().IndexOf(csv2.GetLine(i));
                int csv1Index = csv1.GetList().IndexOf(csv1.GetLine(i));


                //Check if composite field and payload matches 
                if (csv1.GetLine(i).CompositeField == csv2.GetLine(i).CompositeField && csv1.GetLine(i).PayLoad == csv2.GetLine(i).PayLoad)
                {
                    Console.WriteLine("CSV1 on Line: " + csv1Index + " matches " + "CSV2 on Line: " + csv2Index, Console.ForegroundColor);


                }


                Console.ForegroundColor = ConsoleColor.Red;

                //Check if composite field maches and payload does NOT match 
                if (csv1.GetLine(i).CompositeField == csv2.GetLine(i).CompositeField && csv1.GetLine(i).PayLoad != csv2.GetLine(i).PayLoad)
                {
                    Console.WriteLine("CSV1 composite key on Line: " + csv1Index + " matches " + "CSV2 composite key on Line: " + csv2Index +
                        " however the payload does not match", Console.ForegroundColor);
                    Console.WriteLine("CSV1 payload is: {0} and the CSV2 payload is: {1}", csv1.GetLine(i).PayLoad, csv2.GetLine(i).PayLoad);

                }


                //composite fields do NOT match
                if (csv1.GetLine(i).CompositeField != csv2.GetLine(i).CompositeField)
                {

                    try
                    {

                        if (i != count - 1)
                        {
                            //check for test 8
                            if (csv1.GetLine(i).CompositeField == csv2.GetLine(i + 1).CompositeField && csv1.GetLine(i + 1).CompositeField == csv2.GetLine(i).CompositeField)
                            {
                                int csv2IndexPlusOne = csv1Index + 1;
                                int csv1IndexPlusOne = csv1Index + 1;

                                if (csv1.GetLine(i).PayLoad == csv2.GetLine(i + 1).PayLoad)
                                {
                                    Console.WriteLine("Old and New programs printed csv files with incorrect index. CSV 1 index: {0} and CSV 2 index: {1}", csv1Index, csv2IndexPlusOne);
                                }


                                //compare payloads match
                                if (csv1.GetLine(i + 1).PayLoad == csv2.GetLine(i).PayLoad)
                                {
                                    Console.WriteLine("Old and New programs printed csv files with incorrect index. CSV 1 index: {0} and CSV 2 index: {1}", csv1IndexPlusOne, csv2Index);

                                }

                                i++;

                                continue;
                            }

                            Console.WriteLine("CSV 1 composite key on line {0} and CSV 2 composite key on line {1} does not match", csv1Index, csv2Index);
                            Console.WriteLine("CSV1 Composite: {0}, CSV2 Composite: {1}", csv1.GetLine(i).CompositeField, csv2.GetLine(i).CompositeField);


                            //csv1 composite key on currentline matches csv2 composite in currentline+1
                            if (csv1.GetLine(i).CompositeField == csv2.GetLine(i + 1).CompositeField)
                            {


                                var matchingCsv2Line = csv2Index + 1;
                                Console.ForegroundColor = ConsoleColor.Blue;

                                //declare csv1 line at i is missing
                                Console.WriteLine("CSV1 missing at line: " + csv1Index);
                                Console.WriteLine("CSV1 composite key at " + csv2Index + " matches the CSV2 composite key in next line at " + matchingCsv2Line);
                                Console.WriteLine("Adding + 1 to csv1 index to compare matching composite key lines");

                                //check payload matches
                                if (csv1.GetLine(i).PayLoad == csv2.GetLine(i + 1).PayLoad)
                                {
                                    Console.WriteLine("Payload matches between csv1 currentline and csv2 currentline+1");
                                }

                                //established that we are missing a line in csv1, so shift the index so we can continue comparing the remaining lines
                                var item = csv1.GetLine(i);
                                var oldIndex = csv1Index;
                                csv1.GetList().Insert(oldIndex + 1, item);

                            }

                            //check if csv2 is missing line, composite keys at csv1.currentline=1 matches csv2.currentline
                            if (csv1.GetLine(i + 1).CompositeField == csv2.GetLine(i).CompositeField)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;

                                var matchingCsv1Line = csv1Index + 1;
                                //declare csv2 line at i is missing
                                Console.WriteLine("CSV2 missing at line: " + csv2Index);
                                Console.WriteLine("CSV2 composite key at " + csv2Index + " matches the CSV1 composite key in next line at " + matchingCsv1Line);
                                Console.WriteLine("Adding + 1 to csv2 index to compare matching composite key lines");

                                //check payload matches
                                if (csv1.GetLine(i + 1).PayLoad == csv2.GetLine(i).PayLoad)
                                {
                                    Console.WriteLine("Payload matches between csv1 currentline+1 and csv2 currentline");
                                }


                                //established that we are missing a line in csv2, so shift the index so we can continue comparing the remaining lines
                                var item = csv2.GetLine(i);
                                var oldIndex = csv2Index;
                                csv2.GetList().Insert(oldIndex + 1, item);


                            }
                        }


                    }
                    catch (Exception e)
                    {


                        Console.WriteLine("Exception occured during comparison of CSV1 and CSV2: " + e);

                        break;
                    }





                }



            }
        }
    }
}
