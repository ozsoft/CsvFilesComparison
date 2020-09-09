using System;
using System.Collections.Generic;


namespace CsvFilesComparison
{
    public class Csv
    {
        public Csv()
        {
        }


        List<CsvLine> lines = new List<CsvLine>();

        public void AddLine(string composite, string payload, double price)
        {
            lines.Add(new CsvLine { CompositeField = composite, PayLoad = payload, Price = price });
        }



        public int sizeOfCsv()
        {

            return lines.Count;

        }

        public CsvLine GetLine(int index)
        {
            return lines[index];
        }

        public List<CsvLine> GetList()
        {
            return lines;
        }

    }
}
