using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyRecord
{
    class Insert : Operation
    {
        public Insert(Records records) : base(records) { }
        Record newRecord;
        protected override void CustomizedOperation()
        {
            long GINNumber = InputGIN();
            string name = InputName();
            float temperature = InputTemperature();
            bool isRiskArea = InputRiskArea();
            string symptom = InputSymptom();
            newRecord = new Record(GINNumber, name, temperature, isRiskArea, symptom);
            if (records.Add(newRecord))
            {
                Console.WriteLine("Record added is shown as below:");
                Console.WriteLine(String.Join(',', newRecord.ReturnContent()));
            }
            else
            {
                Console.WriteLine("Record already exists, pleas check your GIN.");
            }
        }
        private long InputGIN()
        {
            Console.WriteLine("Please type your GIN (numeric input only) then press Enter.");
            string GIN = Console.ReadLine();
            long GINNumber = 0;
            if (long.TryParse(GIN, out GINNumber))
            {
                return GINNumber;
            }
            else
            {
                Console.WriteLine("Input is not a number, please try again.");
                return InputGIN();
            }
        }
    }
}
