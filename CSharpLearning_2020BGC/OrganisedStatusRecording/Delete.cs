using System;
using System.Collections.Generic;
using System.Text;

namespace OrganisedStatusRecording
{
    class Delete : Operation
    {
        public Delete(Records records) : base(records) { }
        protected override void CustomizedOperation()
        {
            Console.WriteLine("Please enter GIN that you want to delete.");
            string GINString = Console.ReadLine();
            long GINNumber = 0;
            while (!long.TryParse(GINString, out GINNumber))
            {
                Console.WriteLine("Input is not a number, please try again.");
                GINString = Console.ReadLine();
            }
            if (!records.Delete(GINNumber))
            {
                Console.WriteLine("GIN not exist in records.");
            }
            else
            {
                Console.WriteLine("Record deleted.");
            }

        }
    }
}
