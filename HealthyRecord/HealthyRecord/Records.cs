using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;

namespace HealthyRecord
{
    public class Records
    {
        private Dictionary<long, Record> recordDictionary = new Dictionary<long, Record>();
        public bool Add(Record newRecord)
        {
            return recordDictionary.TryAdd(newRecord.GIN, newRecord);
        }
        public bool Delete(long GIN)
        {
            return recordDictionary.Remove(GIN);
        }
        public bool Update(Record newRecord)
        {
            Record replaceRecord = null;
            bool result = recordDictionary.TryGetValue(newRecord.GIN, out replaceRecord);
            replaceRecord = newRecord;
            return result;
        }
        public Record Query(long GIN)
        {
            Record newRecord = null;
            recordDictionary.TryGetValue(GIN, out newRecord);
            return newRecord;
        }
        public Dictionary<long, Record> QuerySuspicious()
        {
            Dictionary<long, Record> newRecord = new Dictionary<long, Record>();
            foreach (var element in recordDictionary)
            {
                if (element.Value.IsSuspicous())
                {
                    newRecord.Add(element.Key, element.Value);
                }
            }
            return newRecord;
        }
        public List<string[]> ReturnContents()
        {
            List<string[]> outputList = new List<string[]>();
            foreach (var element in recordDictionary)
            {
                outputList.Add(element.Value.ReturnContent());
            }
            return outputList;
        }
    }
}
