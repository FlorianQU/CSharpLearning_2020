using System;
using System.Collections.Generic;
using System.Text;

namespace OrganisedStatusRecording
{
    class Record
    {
        private Dictionary<string, int> title = new Dictionary<string, int>() { { "GIN", 0 }, { "Name", 1 }, { "Temperature", 2 }, { "RiskArea", 3 }, { "Symptom", 4 } };
        public long GIN { get; }
        public string Name { get; set; }
        public float Temperature { get; set; }
        public bool RiskArea { get; set; }
        public string Symptom { get; set; }
        public Record(long GIN)
        {
            this.GIN = GIN;
        }
        public Record(string[] inputString)
        {
            GIN = long.Parse(inputString[title["GIN"]]);
            Name = inputString[title["Name"]];
            Temperature = float.Parse(inputString[title["Temperature"]]);
            RiskArea = Convert.ToBoolean(inputString[title["RiskArea"]]);
            Symptom = inputString[title["Symptom"]];
        }
        public bool IsSuspicous()
        {
            return (Temperature > 37.3 || RiskArea || Symptom != "No symptoms");
        }
        public string[] ReturnContent()
        {
            return new string[] { GIN.ToString(), Name, Temperature.ToString(), RiskArea.ToString(), Symptom };
        }
    }
}
