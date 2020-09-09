using System;
namespace CsvFilesComparison
{
    public class CsvLine
    {
        public CsvLine()
        {
        }


        private double price;
        private string compositeField;
        private string payload;


        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
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
