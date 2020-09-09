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
                    Console.WriteLine("({0},{1}) CSV1 and  CSV2 match", csv1Index, csv2Index, Console.ForegroundColor);


                }


                Console.ForegroundColor = ConsoleColor.Red;

                //Check if composite field maches and payload does NOT match 
                if (csv1.GetLine(i).CompositeField == csv2.GetLine(i).CompositeField && csv1.GetLine(i).PayLoad != csv2.GetLine(i).PayLoad)
                {
                    Console.WriteLine("({0},{1}) Composite Key for CSV1 and CSV2 match BUT payload does NOT match CSV1 ({2}) and CSV2 ({3})", csv1Index, csv2Index, csv1.GetLine(i).PayLoad, csv2.GetLine(i).PayLoad, Console.ForegroundColor);

                }


                //composite fields do NOT match
                if (csv1.GetLine(i).CompositeField != csv2.GetLine(i).CompositeField)
                {

                    try
                    {

                        if (i == count - 1)
                        {
                            Console.WriteLine("({0},{1}) CSV1 ({2}) and CSV2 ({3}) composite keys do not match", csv1Index, csv2Index, csv1.GetLine(i).CompositeField, csv2.GetLine(i).CompositeField);

                        }


                        //to avoid comparing i+1=null at the end of the for loop
                        if (i != count - 1)
                        {




                            //check for test 8
                            if (csv1.GetLine(i).CompositeField == csv2.GetLine(i + 1).CompositeField && csv1.GetLine(i + 1).CompositeField == csv2.GetLine(i).CompositeField)
                            {
                                int csv2IndexPlusOne = csv1Index + 1;
                                int csv1IndexPlusOne = csv1Index + 1;

                                if (csv1.GetLine(i).PayLoad == csv2.GetLine(i + 1).PayLoad)
                                {
                                    Console.WriteLine("({0},{1}) Old and New programs printed csv files with incorrect index. CSV 1 index: {0} and CSV 2 index: {1}", csv1Index, csv2IndexPlusOne);
                                }


                                //compare payloads match
                                if (csv1.GetLine(i + 1).PayLoad == csv2.GetLine(i).PayLoad)
                                {
                                    Console.WriteLine("({0},{1}) Old and New programs printed csv files with incorrect index. CSV 1 index: {0} and CSV 2 index: {1}", csv1IndexPlusOne, csv2Index);

                                }

                                i++;

                                continue;
                            }




                            bool foundMismatchingLine = false;
                            //find multiple missing lines
                            if (csv1.GetLine(i).CompositeField != csv2.GetLine(i + 1).CompositeField && csv1.GetLine(i + 1).CompositeField != csv2.GetLine(i).CompositeField)
                            {

                                //find multple lines missing in csv1
                                int countOfMissingLines = 0;

                                try
                                {

                                    for (int j = i; j < count - 1; j++)
                                    {
                                        countOfMissingLines++;

                                        if (csv1.GetLine(i).CompositeField == csv2.GetLine(j + 1).CompositeField)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Blue;

                                            Console.WriteLine("CSV1 is missing this many lines: {0}", countOfMissingLines);
                                            foundMismatchingLine = true;

                                            //check payload matches
                                            if (csv1.GetLine(i).PayLoad == csv2.GetLine(j + 1).PayLoad)
                                            {
                                                Console.WriteLine("({0},{1}) lines payload matches between CSV1 and CSV2}", i, j + 1);

                                            }
                                            else
                                            {
                                                Console.WriteLine("({0},{1}) lines payload does NOT matches between CSV1 and CSV2}", i, j + 1);

                                            }

                                            //established that we are missing lines in csv1, so shift the index so we can continue comparing the remaining lines
                                            var item = csv1.GetLine(i);
                                            var oldIndex = csv1Index;
                                            csv1.GetList().Insert(oldIndex + (j + 1), item);

                                        }

                                    }
                                }
                                catch (Exception e)
                                {

                                }



                                //find multple lines missing in csv2
                                countOfMissingLines = 0;

                                try
                                {
                                    for (int j = i; j < count - 1; j++)
                                    {
                                        countOfMissingLines++;

                                        if (csv1.GetLine(j + 1).CompositeField == csv2.GetLine(i).CompositeField)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Blue;

                                            Console.WriteLine("CSV2 is missing this many lines: {0}", countOfMissingLines);

                                            foundMismatchingLine = true;

                                            //check payload matches
                                            if (csv1.GetLine(j + 1).PayLoad == csv2.GetLine(i).PayLoad)
                                            {
                                                Console.WriteLine("({0},{1}) Payload matches between CSV2 currentline: {1} and CSV1 currentline: {0}", j + 1, i);

                                            }
                                            else
                                            {
                                                Console.WriteLine("({0},{1}) Payload does NOT matches between CSV1 and CSV2}", j + 1, i);

                                            }
                                            Console.WriteLine("({0},{1}) Composite Key matches between CSV1 currentline: {0}, CSV2 currentline: {1}", csv1.GetLine(j + 1).CompositeField, csv2.GetLine(i).CompositeField);


                                            //established that we are missing lines in csv2, so shift the index so we can continue comparing the remaining lines
                                            var item = csv2.GetLine(i);
                                            var oldIndex = csv2Index;
                                            csv2.GetList().Insert(oldIndex + (j + 1), item);


                                        }

                                    }
                                }
                                catch (Exception e)
                                {

                                }


                                if (!foundMismatchingLine)
                                {
                                    Console.WriteLine("({0},{1}) CSV1 ({2}) and CSV2 ({3}) composite keys do not match", csv1Index, csv2Index, csv1.GetLine(i).CompositeField, csv2.GetLine(i).CompositeField);

                                }

                                foundMismatchingLine = false;
                            }






                            //csv1 composite key on currentline matches csv2 composite in currentline+1
                            if (csv1.GetLine(i).CompositeField == csv2.GetLine(i + 1).CompositeField)
                            {

                                Console.WriteLine("({0},{1}) CSV1 ({2}) and CSV2 ({3}) composite keys do not match", csv1Index, csv2Index, csv1.GetLine(i).CompositeField, csv2.GetLine(i).CompositeField);

                                var matchingCsv2Line = csv2Index + 1;
                                Console.ForegroundColor = ConsoleColor.Blue;

                                //declare csv1 line at i is missing
                                Console.WriteLine("CSV1 missing at line: " + csv1Index);
                                Console.WriteLine("({0},{1}) CSV1 composite key at {0}  matches the CSV2 composite key in next line at {1}", csv1Index, matchingCsv2Line);
                                Console.WriteLine("Adding + 1 to csv1 index to compare remaining composite key lines");

                                //check payload matches
                                if (csv1.GetLine(i).PayLoad == csv2.GetLine(i + 1).PayLoad)
                                {
                                    Console.WriteLine("({0},{1}) Payload matches between csv1 currentline and csv2 currentline+1", csv1Index, matchingCsv2Line);
                                }

                                //established that we are missing a line in csv1, so shift the index so we can continue comparing the remaining lines
                                var item = csv1.GetLine(i);
                                var oldIndex = csv1Index;
                                csv1.GetList().Insert(oldIndex + 1, item);

                            }

                            //check if csv2 is missing line, composite keys at csv1.currentline=1 matches csv2.currentline
                            if (csv1.GetLine(i + 1).CompositeField == csv2.GetLine(i).CompositeField)
                            {
                                Console.WriteLine("({0},{1}) CSV1 ({2}) and CSV2 ({3}) composite keys do not match", csv1Index, csv2Index, csv1.GetLine(i).CompositeField, csv2.GetLine(i).CompositeField);

                                Console.ForegroundColor = ConsoleColor.Blue;

                                var matchingCsv1Line = csv1Index + 1;
                                //declare csv2 line at i is missing
                                Console.WriteLine("CSV2 missing at line: " + csv2Index);
                                Console.WriteLine("({0},{1}) CSV2 composite key matches the CSV1 composite key in next line", matchingCsv1Line, csv2Index);
                                Console.WriteLine("Adding + 1 to CSV2 index to compare remaining composite key lines");

                                //check payload matches
                                if (csv1.GetLine(i + 1).PayLoad == csv2.GetLine(i).PayLoad)
                                {
                                    Console.WriteLine("({0},{1}) Payload matches between csv1 currentline+1 and csv2 currentline", matchingCsv1Line, csv2Index);
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
