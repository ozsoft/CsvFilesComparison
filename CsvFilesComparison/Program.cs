using System;
using System.Collections.Generic;

namespace CsvFilesComparison
{
    class Program
    {

        public enum FailureLevel
        {
            Low,
            Medium,
            High
        }





        static void Main(string[] args)
        {


            //  ASSUMES
            //      1. Composite key is unique
            //      2. Mismatch line tolerence 1 line


            // TODO : import from csv can convert to csv object
            // TODO : make mismtching line tolerence configurable
            // TODO : write report to text file


            // DONE : make price tolerance configurable
            // DONE : weighted system for pricing


            //Pricing discrepancy
            Program p = new Program();

            FailureLevel f1 = p.PricingDiscrepancy(43.33, 41.43);

            Console.WriteLine(f1);

            FailureLevel f2 = p.PricingDiscrepancy(42.33, 42.42);

            Console.WriteLine(f2);


            FailureLevel f3 = p.PricingDiscrepancy(42.331, 42.322);

            Console.WriteLine(f3);






            DateTime now = DateTime.Now;

            Console.WriteLine("Test start tie: {0}", now);
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("--------TEST 1---------");
            //Missing line in CSV 2
            /*
                    scenario 1:  
                    ln    csv1    csv2
                    0    ABC    DDS
                    1    DDS    SAA
                    2    SAA


            Transform to this and continue comparing
                    ln    csv1    csv2
                    0    ABC    DDS
                    1    DDS    DDS
                    2    SAA    SAA
             
             */

            Csv test1_csv1 = new Csv();
            test1_csv1.AddLine(0, "ABC", "GBP,233232,London");
            test1_csv1.AddLine(1, "DDS", "GBP,233232,London");
            test1_csv1.AddLine(2, "SAA", "GBP,233232,London");


            Csv test1_csv2 = new Csv();
            test1_csv2.AddLine(0, "DDS", "GBP,233232,London");
            test1_csv2.AddLine(1, "SAA", "GBP,233232,London");



            CompareCsvFiles test1 = new CompareCsvFiles();
            test1.CompareCsvs(test1_csv1, test1_csv2);







            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("--------TEST 2---------");
            //entire csvs match
            Csv test2_csv1 = new Csv();
            test2_csv1.AddLine(0, "ABC", "GBP,233232,London");
            test2_csv1.AddLine(1, "DDS", "GBP,233232,London");
            test2_csv1.AddLine(2, "SAA", "GBP,233232,London");


            Csv test2_csv2 = new Csv();
            test2_csv2.AddLine(0, "ABC", "GBP,233232,London");
            test2_csv2.AddLine(1, "DDS", "GBP,233232,London");
            test2_csv2.AddLine(2, "SAA", "GBP,233232,London");



            CompareCsvFiles test2 = new CompareCsvFiles();
            test2.CompareCsvs(test2_csv1, test2_csv2);




            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------TEST 3---------");
            //payload does not match but composite key matches

            Csv test3_csv1 = new Csv();
            test3_csv1.AddLine(0, "ABC", "GBP,233232,London");
            test3_csv1.AddLine(1, "DDS", "YYY,233232,London");
            test3_csv1.AddLine(2, "SAA", "GBP,233232,London");


            Csv test3_csv2 = new Csv();
            test3_csv2.AddLine(0, "ABC", "GBP,233232,London");
            test3_csv2.AddLine(1, "DDS", "ZZZ,233232,London");
            test3_csv2.AddLine(2, "SAA", "GBP,233232,London");




            CompareCsvFiles test3 = new CompareCsvFiles();
            test3.CompareCsvs(test3_csv1, test3_csv2);




            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------TEST 4---------");
            //not matching at all on every line of csvs


            Csv test4_csv1 = new Csv();
            test4_csv1.AddLine(0, "ABC", "GBP,233232,London");
            test4_csv1.AddLine(1, "DDS", "YYY,233232,London");
            test4_csv1.AddLine(2, "SAA", "GBP,233232,London");


            Csv test4_csv2 = new Csv();
            test4_csv2.AddLine(0, "FFF", "GBP,233232,London");
            test4_csv2.AddLine(1, "SSS", "ZZZ,233232,London");
            test4_csv2.AddLine(2, "CCC", "GBP,233232,London");




            CompareCsvFiles test4 = new CompareCsvFiles();
            test4.CompareCsvs(test4_csv1, test4_csv2);




            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------TEST 5---------");
            //missing line in CSV 1


            /*
             
                scenario 2:
                ln   csv1    csv2
                0    DDS    ABC
                1    SAA    DDS
                2           SAA

             
             */

            Csv test5_csv1 = new Csv();
            test5_csv1.AddLine(0, "DDS", "GBP,233232,London");
            test5_csv1.AddLine(1, "SAA", "GBP,233232,London");


            Csv test5_csv2 = new Csv();
            test5_csv2.AddLine(0, "ABC", "GBP,233232,London");
            test5_csv2.AddLine(1, "DDS", "GBP,233232,London");
            test5_csv2.AddLine(2, "SAA", "GBP,233232,London");




            CompareCsvFiles test5 = new CompareCsvFiles();
            test5.CompareCsvs(test5_csv1, test5_csv2);


            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------TEST 6---------");
            //some matching first and then some lines that are not matching



            Csv test6_csv1 = new Csv();
            test6_csv1.AddLine(0, "ABC", "GBP,233232,London");
            test6_csv1.AddLine(1, "SAA", "GBP,233232,London");
            test6_csv1.AddLine(2, "AAA", "GBP,233232,London");
            test6_csv1.AddLine(3, "BBB", "GBP,233232,London");


            Csv test6_csv2 = new Csv();
            test6_csv2.AddLine(0, "ABC", "GBP,233232,London");
            test6_csv2.AddLine(1, "SAA", "GBP,233232,London");
            test6_csv2.AddLine(2, "XXX", "GBP,233232,London");
            test6_csv2.AddLine(3, "YYY", "GBP,233232,London");


            CompareCsvFiles test6 = new CompareCsvFiles();
            test6.CompareCsvs(test6_csv1, test6_csv2);




            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("--------TEST 7---------");
            //missing line after a successful matching line
            /*
             scenario 3:
                ln   csv1    csv2
                0    ABC    ABC
                1    SAA    DDS
                2    GBP    SAA
                3    TDD    GBP
                4    ..     TDD

            Transform to:
                ln   csv1    csv2
                0    ABC    ABC
                1    SAA    DDS
                2    SAA    SAA
                3    GBP    GBP

             */

            Csv test7_csv1 = new Csv();
            test7_csv1.AddLine(0, "ABC", "GBP,233232,London");
            test7_csv1.AddLine(1, "SAA", "GBP,233232,London");
            test7_csv1.AddLine(2, "GBP", "GBP,233232,London");
            test7_csv1.AddLine(3, "TDD", "GBP,233232,London");


            Csv test7_csv2 = new Csv();
            test7_csv2.AddLine(0, "ABC", "GBP,233232,London");
            test7_csv2.AddLine(1, "DDS", "GBP,233232,London");
            test7_csv2.AddLine(2, "SAA", "GBP,233232,London");
            test7_csv2.AddLine(3, "GBP", "GBP,233232,London");


            CompareCsvFiles test7 = new CompareCsvFiles();
            test7.CompareCsvs(test7_csv1, test7_csv2);







            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("--------TEST 8---------");
            //program 1 and program 2 spits out output to csv files in different orders
            //i.e. index 1 in csv 1 is index 2 in csv 2
            //and index 2 in csv 1 is index 1 in csv 2



            Csv test8_csv1 = new Csv();
            test8_csv1.AddLine(0, "ABC", "GBP,233232,London");
            test8_csv1.AddLine(1, "SAA", "GBP,233232,London");
            test8_csv1.AddLine(2, "DDS", "GBP,233232,London");
            test8_csv1.AddLine(3, "TDD", "GBP,233232,London");


            Csv test8_csv2 = new Csv();
            test8_csv2.AddLine(0, "ABC", "GBP,233232,London");
            test8_csv2.AddLine(1, "DDS", "GBP,233232,London");
            test8_csv2.AddLine(2, "SAA", "GBP,233232,London");
            test8_csv2.AddLine(3, "TDD", "GBP,233232,London");


            CompareCsvFiles test8 = new CompareCsvFiles();
            test8.CompareCsvs(test8_csv1, test8_csv2);


        }



        public FailureLevel PricingDiscrepancy(double priceCsv1, double priceCsv2)
        {
            double priceDiscrepancy = priceCsv1 - priceCsv2;
            priceDiscrepancy = Math.Abs(priceDiscrepancy);

            if (priceDiscrepancy < 0.01)
            {
                return FailureLevel.Low;

            }
            else if (priceDiscrepancy < 0.1)
            {
                return FailureLevel.Medium;

            }
            else
            {
                return FailureLevel.High;

            }



        }


    }
}
