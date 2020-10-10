using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyRecord
{
    class Query : Operation
    {
        public Query(Records records) : base(records) { }
        protected override void CustomizedOperation()
        {
            Console.WriteLine("Choose between 0 and 1, corresponding to [Query by GIN] and [Query suspicious].");
            string choiceString = Console.ReadLine();
            while (choiceString != "0" && choiceString != "1")
            {
                Console.WriteLine("Wrong input, try again.");
                choiceString = Console.ReadLine();
            }
            Dictionary<long, Record> queryList = new Dictionary<long, Record>();
            if (choiceString == "0")
            {
                Record record = QueryByGIN();
                if(record != null)
                {
                    queryList.Add(record.GIN, record);
                }
            }
            else
            {
                queryList = records.QuerySuspicious();
            }
            if (queryList.Count > 0)
            {
                Console.WriteLine("Record(s) found as below:");
                foreach (var element in queryList)
                {
                    Console.WriteLine(string.Join(',', element.Value.ReturnContent()));
                }
            }
            else
            {
                Console.WriteLine("No record found.");
            }
        }
        private Record QueryByGIN()
        {
            Console.WriteLine("Please enter GIN that you want to query.");
            string GINString = Console.ReadLine();
            long GINNumber = 0;
            while (!long.TryParse(GINString, out GINNumber))
            {
                Console.WriteLine("Input is not a number, please try again.");
                GINString = Console.ReadLine();
            }
            return records.Query(GINNumber);
        }

    }
}
