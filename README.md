# CsvFilesComparison


            /*
                        composite key is unique, order is relevant
                        composite key is unique, order is not relevant
                        composite key is not unique, order is relevant 
                        composite key is not unique, order is not relevant

             */



            //      ASSUMPTION 1: (DEVELOPED)
            //      composite key is unique, order is relevant
            //      1. Composite key is unique
            //      2. Mismatch line tolerence 1 line
            //      3. Order of line is relevant



            //      ASSUMPTION 2:
            //      composite key is unique, order is NOT relevant
            //      then we can find matching composite key in other csv file and compare payload
            //      and report 
            //          1. Payload of matching composite keys are the same or different
            //          2. If there are no matches at all for composite key on each csv file   




            //      ASSUMPTION 3:
            //      composite key is NOT unique, order is relevant
            //      strictly fail on line mismatch on composite key, to avoid false positive (comparing successfully two lines we shouldnt have)
            //      and report 
            //          1. Payload of matching composite keys are the same on the same line



            //      ASSUMPTION 4:
            //      composite key is NOT unique, order is NOT relevant,
            //          find the first matching composite key in csv files and report match, any odd ones left report on which csv (can get a bit complicated if price weight is different in multiple matches)
            //          report on any non matching composite keys at all
            //          report on matching keys

