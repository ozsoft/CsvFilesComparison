﻿using System;
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

            if (csv1.sizeOfCsv() > csv2.sizeOfCsv())
            {
                count = csv1.sizeOfCsv();
            }
            else
            {
                count = csv2.sizeOfCsv();
            }



            for (int i = 0; i < count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                int csv2Index = csv2.GetList().IndexOf(csv2.GetLine(i));
                int csv1Index = csv1.GetList().IndexOf(csv1.GetLine(i));


                if (csv1.GetLine(i).CompositeField == csv2.GetLine(i).CompositeField && csv1.GetLine(i).PayLoad == csv2.GetLine(i).PayLoad)
                {
                    Console.WriteLine("CSV1 on Line: " + csv1Index + " matches " + "CSV2 on Line: " + csv2Index, Console.ForegroundColor);

                }


                Console.ForegroundColor = ConsoleColor.Red;

                if (csv1.GetLine(i).CompositeField == csv2.GetLine(i).CompositeField && csv1.GetLine(i).PayLoad != csv2.GetLine(i).PayLoad)
                {
                    Console.WriteLine("CSV1 composite key on Line: " + csv1Index + " matches " + "CSV2 composite key on Line: " + csv2Index +
                        "but the payload does not match", Console.ForegroundColor);

                }



                if (csv1.GetLine(i).CompositeField != csv2.GetLine(i).CompositeField)
                {
                    Console.WriteLine("CSV 1 composite key in line {0} and CSV 2 composite key in line {1} does not match", csv1Index, csv2Index);

                    try
                    {

                        if (i != count - 1)
                        {
                            if (csv1.GetLine(i).CompositeField == csv2.GetLine(i + 1).CompositeField)
                            {
                                var matchingCsv2Line = csv2Index + 1;
                                Console.ForegroundColor = ConsoleColor.Blue;

                                //declare csv1 line at i is missing
                                Console.WriteLine("CSV1 missing at line: " + csv1Index);
                                Console.WriteLine("CSV1 composite key at " + csv2Index + " matches the CSV2 composite key in next line at " + matchingCsv2Line);
                                Console.WriteLine("Adding + 1 to csv1 index to compare matching composite key lines");


                                var item = csv1.GetLine(i);

                                var oldIndex = csv1Index;


                                csv1.GetList().Insert(oldIndex + 1, item);

                            }

                            if (csv1.GetLine(i + 1).CompositeField == csv2.GetLine(i).CompositeField)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;

                                var matchingCsv1Line = csv1Index + 1;
                                //declare csv2 line at i is missing
                                Console.WriteLine("CSV2 missing at line: " + csv2Index);
                                Console.WriteLine("CSV2 composite key at " + csv2Index + " matches the CSV1 composite key in next line at " + matchingCsv1Line);
                                Console.WriteLine("Adding + 1 to csv2 index to compare matching composite key lines");


                                var item = csv2.GetLine(i);

                                var oldIndex = csv2Index;


                                csv2.GetList().Insert(oldIndex + 1, item);




                            }
                        }


                    }
                    catch (Exception e)
                    {
                        int lineNumber = csv2Index;
                        lineNumber++;

                        Console.WriteLine("Composite field is null for either CSV1 or CSV2 in line: " + lineNumber);

                        break;
                    }





                }



            }
        }
    }
}