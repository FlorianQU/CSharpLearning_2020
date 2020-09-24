using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;

namespace OrganisedStatusRecording
{
    class Records
    {
        private List<Record> recordsList = new List<Record>();
        public bool Add(Record newRecord)
        {
            if (recordsList.Exists(record => record.GIN == newRecord.GIN))
            {
                return false;
            }
            else
            {
                recordsList.Add(newRecord);
                return true;
            }
        }
        public bool Delete(long GIN)
        {
            int result = recordsList.RemoveAll(record => record.GIN == GIN);
            return (result > 0);
        }
        public void Update(Record newRecord)
        {
            int searchResult = recordsList.FindIndex(record => record.GIN == newRecord.GIN);
            recordsList[searchResult] = newRecord;
            #region
            //int searchResult = recordsList.FindIndex(record => record.GIN == GIN);
            //if (searchResult < 0)
            //{
            //    return false;
            //}
            //else
            //{
            //    string[] content = recordsList[searchResult].ReturnContent();
            //    content[Index] = replaceContent;
            //    recordsList[searchResult] = new Record(content);
            //    return true;
            //}
            #endregion
        }
        public Record Query(long GIN)
        {
            int searchResult = recordsList.FindIndex(record => record.GIN == GIN);
            if (searchResult < 0)
            {
                return null;
            }
            else
            {
                return recordsList[searchResult];
            }
        }
        public List<Record> QuerySuspicious()
        {
            return recordsList.FindAll(record => record.IsSuspicous());
        }
        public List<string[]> ReturnContents()
        {
            List<string[]> outputList = new List<string[]>();
            foreach (Record element in recordsList)
            {
                outputList.Add(element.ReturnContent());
            }
            return outputList;
        }
    }
}
