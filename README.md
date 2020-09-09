# CsvFilesComparison


            /*
                        composite key is unique, order is relevant
                        composite key is unique, order is not relevant
                        composite key is not unique, order is relevant 
                        composite key is not unique, order is not relevant

             */


            //      ASSUMPTION 1: (DEVELOPED)
            //      composite key is unique, order is relevant
            //      handle mismatching with tolenrence of 1 line, so if line missing compare with next line in other csv file and continue comparing thereafter
            //          1. if composite keys match, check payload matches and report result
            //          2. if composite keys do not match, report that composite keys do not match and the line of mistmatch
            //          3. if we notice that either csv 1 or csv 2 are missing a single line (i.e. composite key matches in the next line) then report a missing line in csv and continue comparing
            //          4. does not handle multiple line missing



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
            //          1. find the first matching composite key in csv files and report match, any odd ones left report on which csv (can get a bit complicated if price weight is different in multiple matches)
            //          2. report on any non matching composite keys at all
            //          3. report on matching keys
