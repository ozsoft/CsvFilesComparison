using System;
using System.Collections.Generic;

namespace CsvFilesComparison
{
    class Program
    {

        static void Main(string[] args)
        {

            /*
                        composite key is unique, order is relevant
                        composite key is unique, order is not relevant
                        composite key is not unique, order is relevant 
                        composite key is not unique, order is not relevant

             



                   ASSUMPTION SET 1: (DEVELOPED)
                   composite key is unique, order is relevant
                   handle mismatching with tolenrence of 1 line, so if line missing compare with next line in other csv file and continue comparing thereafter
                       1. if composite keys match, check payload matches and report result
                       2. if composite keys do not match, report that composite keys do not match and the line of mistmatch
                       3. if we notice that either csv 1 or csv 2 are missing a single line (i.e. composite key matches in the next line) then report a missing line in csv and continue comparing
                       4. does not handle multiple line missing
             
             
             
                   ASSUMPTION SET 2:
                   composite key is unique, order is NOT relevant
                   then we can find matching composite key in other csv file and compare payload
                   and report 
                       1. Payload of matching composite keys are the same or different
                       2. If there are no matches at all for composite key on each csv file   
             
             
             
             
                   ASSUMPTION SET 3:
                   composite key is NOT unique, order is relevant
                   strictly fail on line mismatch on composite key, to avoid false positive (comparing successfully two lines we shouldnt have)
                   and report 
                       1. Payload of matching composite keys are the same on the same line
             
             
             
                   ASSUMPTION SET 4:
                   composite key is NOT unique, order is NOT relevant,
                       1. find the first matching composite key in csv files and report match, any odd ones left report on which csv (can get a bit complicated if price weight is different in multiple matches)
                       2. report on any non matching composite keys at all
                       3. report on matching keys
             
             
             
             
             
             
             
             
              TODO : import from csv can convert to csv object
              TODO : make mismtching line tolerence configurable
              TODO : write report to text file


              DONE : make price tolerance configurable

            */


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


            Csv test1_csv1 = new Csv();
            test1_csv1.AddLine("ABC", "GBP,233232,London", 123.56);
            test1_csv1.AddLine("DDS", "GBP,233232,London", 123.56);
            test1_csv1.AddLine("SAA", "GBP,233232,London", 123.56);


            Csv test1_csv2 = new Csv();
            test1_csv2.AddLine("DDS", "GBP,233232,London", 123.56);
            test1_csv2.AddLine("SAA", "GBP,233232,London", 123.56);



            CompareCsvFiles test1 = new CompareCsvFiles();
            test1.CompareCsvs(test1_csv1, test1_csv2);







            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("--------TEST 2---------");
            //entire csvs match
            Csv test2_csv1 = new Csv();
            test2_csv1.AddLine("ABC", "GBP,233232,London", 123.56);
            test2_csv1.AddLine("DDS", "GBP,233232,London", 123.56);
            test2_csv1.AddLine("SAA", "GBP,233232,London", 123.56);


            Csv test2_csv2 = new Csv();
            test2_csv2.AddLine("ABC", "GBP,233232,London", 123.56);
            test2_csv2.AddLine("DDS", "GBP,233232,London", 123.56);
            test2_csv2.AddLine("SAA", "GBP,233232,London", 123.56);



            CompareCsvFiles test2 = new CompareCsvFiles();
            test2.CompareCsvs(test2_csv1, test2_csv2);




            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------TEST 3---------");
            //payload does not match but composite key matches

            Csv test3_csv1 = new Csv();
            test3_csv1.AddLine("ABC", "GBP,233232,London", 123.56);
            test3_csv1.AddLine("DDS", "YYY,233232,London", 123.56);
            test3_csv1.AddLine("SAA", "GBP,233232,London", 123.56);

            Csv test3_csv2 = new Csv();
            test3_csv2.AddLine("ABC", "GBP,233232,London", 123.56);
            test3_csv2.AddLine("DDS", "ZZZ,233232,London", 123.56);
            test3_csv2.AddLine("SAA", "GBP,233232,London", 123.56);




            CompareCsvFiles test3 = new CompareCsvFiles();
            test3.CompareCsvs(test3_csv1, test3_csv2);




            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------TEST 4---------");
            //not matching at all on every line of csvs


            Csv test4_csv1 = new Csv();
            test4_csv1.AddLine("ABC", "GBP,233232,London", 123.56);
            test4_csv1.AddLine("DDS", "YYY,233232,London", 123.56);
            test4_csv1.AddLine("SAA", "GBP,233232,London", 123.56);


            Csv test4_csv2 = new Csv();
            test4_csv2.AddLine("FFF", "GBP,233232,London", 123.56);
            test4_csv2.AddLine("SSS", "ZZZ,233232,London", 123.56);
            test4_csv2.AddLine("CCC", "GBP,233232,London", 123.56);




            CompareCsvFiles test4 = new CompareCsvFiles();
            test4.CompareCsvs(test4_csv1, test4_csv2);




            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------TEST 5---------");

            Csv test5_csv1 = new Csv();
            test5_csv1.AddLine("DDS", "GBP,233232,London", 123.56);
            test5_csv1.AddLine("SAA", "GBP,233232,London", 123.56);

            Csv test5_csv2 = new Csv();
            test5_csv2.AddLine("ABC", "GBP,233232,London", 123.56);
            test5_csv2.AddLine("DDS", "GBP,233232,London", 123.56);
            test5_csv2.AddLine("SAA", "GBP,233232,London", 123.56);




            CompareCsvFiles test5 = new CompareCsvFiles();
            test5.CompareCsvs(test5_csv1, test5_csv2);


            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------TEST 6---------");
            //some matching first and then some lines that are not matching



            Csv test6_csv1 = new Csv();
            test6_csv1.AddLine("ABC", "GBP,233232,London", 123.56);
            test6_csv1.AddLine("SAA", "GBP,233232,London", 123.56);
            test6_csv1.AddLine("AAA", "GBP,233232,London", 123.56);
            test6_csv1.AddLine("BBB", "GBP,233232,London", 123.56);


            Csv test6_csv2 = new Csv();
            test6_csv2.AddLine("ABC", "GBP,233232,London", 123.56);
            test6_csv2.AddLine("SAA", "GBP,233232,London", 123.56);
            test6_csv2.AddLine("XXX", "GBP,233232,London", 123.56);
            test6_csv2.AddLine("YYY", "GBP,233232,London", 123.56);


            CompareCsvFiles test6 = new CompareCsvFiles();
            test6.CompareCsvs(test6_csv1, test6_csv2);




            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("--------TEST 7---------");
            //missing line after a successful matching line


            Csv test7_csv1 = new Csv();
            test7_csv1.AddLine("ABC", "GBP,233232,London", 123.56);
            test7_csv1.AddLine("SAA", "GBP,233232,London", 123.56);
            test7_csv1.AddLine("GBP", "GBP,233232,London", 123.56);
            test7_csv1.AddLine("TDD", "GBP,233232,London", 123.56);


            Csv test7_csv2 = new Csv();
            test7_csv2.AddLine("ABC", "GBP,233232,London", 123.56);
            test7_csv2.AddLine("DDS", "GBP,233232,London", 123.56);
            test7_csv2.AddLine("SAA", "GBP,233232,London", 123.56);
            test7_csv2.AddLine("GBP", "GBP,233232,London", 123.56);


            CompareCsvFiles test7 = new CompareCsvFiles();
            test7.CompareCsvs(test7_csv1, test7_csv2);







            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("--------TEST 8---------");
            //program 1 and program 2 spits out output to csv files in different orders
            //i.e. index 1 in csv 1 is index 2 in csv 2
            //and index 2 in csv 1 is index 1 in csv 2



            Csv test8_csv1 = new Csv();
            test8_csv1.AddLine("ABC", "GBP,233232,London", 123.56);
            test8_csv1.AddLine("SAA", "GBP,233232,London", 123.56);
            test8_csv1.AddLine("DDS", "GBP,233232,London", 123.56);
            test8_csv1.AddLine("TDD", "GBP,233232,London", 123.56);


            Csv test8_csv2 = new Csv();
            test8_csv2.AddLine("ABC", "GBP,233232,London", 123.56);
            test8_csv2.AddLine("DDS", "GBP,233232,London", 123.56);
            test8_csv2.AddLine("SAA", "GBP,233232,London", 123.56);
            test8_csv2.AddLine("TDD", "GBP,233232,London", 123.56);


            CompareCsvFiles test8 = new CompareCsvFiles();
            test8.CompareCsvs(test8_csv1, test8_csv2);




            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------TEST 9---------");
            //no records in csvs

            Csv test9_csv1 = new Csv();
            Csv test9_csv2 = new Csv();

            CompareCsvFiles test9 = new CompareCsvFiles();
            test9.CompareCsvs(test9_csv1, test9_csv2);




            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("--------TEST 10---------");

            Csv test10_csv1 = new Csv();
            test10_csv1.AddLine("AAA", "GBP,233232,London", 123.56);
            test10_csv1.AddLine("BBB", "GBP,233232,London", 123.56);
            test10_csv1.AddLine("CCC", "GBP,233232,London", 123.56);
            test10_csv1.AddLine("DDD", "GBP,233232,London", 123.56);
            test10_csv1.AddLine("EEE", "GBP,233232,London", 123.56);
            test10_csv1.AddLine("FFF", "GBP,233232,London", 123.56);
            test10_csv1.AddLine("GGG", "GBP,233232,London", 123.56);
            test10_csv1.AddLine("HHH", "GBP,233232,London", 123.56);
            test10_csv1.AddLine("III", "GBP,233232,London", 123.56);
            test10_csv1.AddLine("JJJ", "GBP,233232,London", 123.56);


            Csv test10_csv2 = new Csv();
            test10_csv2.AddLine("AAA", "GBP,233232,London", 123.56);
            test10_csv2.AddLine("BBB", "GBP,233232,London", 123.56);
            test10_csv2.AddLine("CCC", "GBP,233232,London", 123.56);
            test10_csv2.AddLine("HHH", "GBP,233232,London", 123.56);
            test10_csv2.AddLine("III", "GBP,233232,London", 123.56);
            test10_csv2.AddLine("JJJ", "GBP,233232,London", 123.56);
            test10_csv2.AddLine("KKK", "GBP,233232,London", 123.56);
            test10_csv2.AddLine("LLL", "GBP,233232,London", 123.56);
            test10_csv2.AddLine("MMM", "GBP,233232,London", 123.56);
            test10_csv2.AddLine("NNN", "GBP,233232,London", 123.56);


            CompareCsvFiles test10 = new CompareCsvFiles();
            test10.CompareCsvs(test10_csv1, test10_csv2);


        }

        public enum FailureLevel
        {
            Low,
            Medium,
            High
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
