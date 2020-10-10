using System;
using System.Collections.Generic;
using System.Text;

namespace OrganisedStatusRecording
{
    class Insert : Operation
    {
        public Insert(Records records) : base(records) { }
        Record newRecord;
        protected override void CustomizedOperation()
        {
            newRecord = InputGIN();
            InputName(newRecord);
            InputTemperature(newRecord);
            InputRiskArea(newRecord);
            InputSymptom(newRecord);
            records.Add(newRecord);
            Console.WriteLine("Record added is shown as below:");
            Console.WriteLine(String.Join(',', newRecord.ReturnContent()));
        }
        private Record InputGIN()
        {
            Console.WriteLine("Please type your GIN (numeric input only) then press Enter.");
            string GIN = Console.ReadLine();
            long GINNumber = 0;
            if (long.TryParse(GIN, out GINNumber))
            {
                return new Record(GINNumber);
            }
            else
            {
                Console.WriteLine("Input is not a number, please try again.");
                return InputGIN();
            }
        }

    }
}
