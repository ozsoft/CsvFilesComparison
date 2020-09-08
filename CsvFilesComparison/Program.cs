using System;
using System.Collections.Generic;

namespace CsvFilesComparison
{
    class Program
    {

        static void Main(string[] args)
        {


            //  ASSUMES
            //      1. Composite key is unique
            //      2. Mismatch line tolerence 1 line


            // TODO : import from csv can convert to csv object
            // TODO : weighted system for pricing
            // TODO : make mismtching line tolerence configurable
            // TODO : make price tolerance configurable
            // TODO : write report to text file




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


        }






    }
}
