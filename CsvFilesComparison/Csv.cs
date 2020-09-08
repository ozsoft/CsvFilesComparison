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

        public void AddLine(int index, string composite, string payload)
        {
            lines.Add(new CsvLine { Index = index, CompositeField = composite, PayLoad = payload });
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
