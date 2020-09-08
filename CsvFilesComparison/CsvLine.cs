using System;
namespace CsvFilesComparison
{
    public class CsvLine
    {
        public CsvLine()
        {
        }


        private int index;
        private string compositeField;
        private string payload;


        public int Index
        {
            get
            {
                return index;
            }

            set
            {
                index = value;
            }
        }

        public string CompositeField
        {
            get
            {
                return compositeField;
            }

            set
            {
                compositeField = value;
            }
        }


        public string PayLoad
        {
            get
            {
                return payload;
            }

            set
            {
                payload = value;
            }
        }
    }
}
