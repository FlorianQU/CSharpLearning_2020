using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace HealthyRecord.Test
{
    public class TestRecords
    {
        [Theory]
        [InlineData(123, "jerry", 37.1, false, "No symptoms", false)]
        [InlineData(456, "jerry", 37.1, false, "No symptoms", false)]
        public void Add_RecordsNotEmpty(long GIN, string name, float temperature, bool riskArea, string symptom, bool expectedResult)
        {
            Record newRecord = new HealthyRecord.Record(123, "Tom", float.Parse((37.1).ToString()), false, "No symptoms");
            Records records = new Records();
            records.Add(newRecord);
            Record recordToAdd = new HealthyRecord.Record(GIN, name, temperature, riskArea, symptom);
            Assert.Equal(expectedResult, records.Add(newRecord));
        }
        [Fact]
        public void Add_RecordsEmpty()
        {
            Record newRecord = new HealthyRecord.Record(123, "Tom", float.Parse((37.1).ToString()), false, "No symptoms");
            Records records = new Records();
            Assert.True(records.Add(newRecord));
        }
        [Theory]
        [InlineData(123, true)]
        [InlineData(456, false)]
        public void Delete_NotEmpty(long GIN, bool expectedResult)
        {
            Record newRecord = new HealthyRecord.Record(123, "Tom", float.Parse((37.1).ToString()), false, "No symptoms");
            Records records = new Records();
            records.Add(newRecord);
            Assert.Equal(expectedResult, records.Delete(GIN));
        }
        [Fact]
        public void Delete_Empty()
        {
            Records records = new Records();
            Assert.False(records.Delete(123));
        }
        [Theory]
        [InlineData(123, true)]
        [InlineData(456, false)]
        public void Update_Should(long GIN, bool expectedResult)
        {
            Record newRecord = new HealthyRecord.Record(123, "Tom", float.Parse((37.1).ToString()), false, "No symptoms");
            Records records = new Records();
            records.Add(newRecord);
            Record recordUpdateWith = new HealthyRecord.Record(GIN, "Tom", float.Parse((36.5.ToString())), false, "No symptoms");
            Assert.Equal(expectedResult, records.Update(recordUpdateWith));
        }
        [Fact]
        public void Query_RecordsNotEmptyRecordExists()
        {
            Record newRecord = new HealthyRecord.Record(123, "Tom", float.Parse((37.1).ToString()), false, "No symptoms");
            Records records = new Records();
            records.Add(newRecord);
            Assert.Equal(newRecord, records.Query(123));
        }
        [Fact]
        public void Query_RecordsNotEmptyRecordNotExists()
        {
            Record newRecord = new HealthyRecord.Record(123, "Tom", float.Parse((37.1).ToString()), false, "No symptoms");
            Records records = new Records();
            records.Add(newRecord);
            Assert.Null(records.Query(456));
        }
        [Fact]
        public void Query_RecordsEmpty()
        {
            Records records = new Records();
            Assert.Null(records.Query(123));
        }
        [Fact]
        public void QuerySuspicious_Suspicous()
        {
            Record newRecord1 = new HealthyRecord.Record(123, "Tom", float.Parse((38.0).ToString()), false, "No symptoms");
            Record newRecord2 = new HealthyRecord.Record(456, "Jerry", float.Parse((37.1).ToString()), true, "No symptoms");
            Records records = new Records();
            records.Add(newRecord1);
            records.Add(newRecord2);
            Assert.True(records.QuerySuspicious().ContainsKey(123));
            Assert.True(records.QuerySuspicious().ContainsKey(456));
            Assert.True(records.QuerySuspicious().ContainsValue(newRecord1));
            Assert.True(records.QuerySuspicious().ContainsValue(newRecord2));
        }
        [Fact]
        public void QuerySuspicious_NoSuspicous()
        {
            Record newRecord1 = new HealthyRecord.Record(123, "Tom", float.Parse((36.5).ToString()), false, "No symptoms");
            Record newRecord2 = new HealthyRecord.Record(456, "Jerry", float.Parse((37.1).ToString()), false, "No symptoms");
            Records records = new Records();
            records.Add(newRecord1);
            records.Add(newRecord2);
            Assert.True(records.QuerySuspicious().Count == 0);
        }
        [Fact]
        public void ReturnContents_Empty()
        {
            Records records = new Records();
            Assert.True(records.ReturnContents().Count == 0);
        }
        [Fact]
        public void ReturnContents_NotEmpty()
        {
            Record newRecord1 = new HealthyRecord.Record(123, "Tom", float.Parse((36.5).ToString()), false, "No symptoms");
            Record newRecord2 = new HealthyRecord.Record(456, "Jerry", float.Parse((37.1).ToString()), false, "No symptoms");
            Records records = new Records();
            records.Add(newRecord1);
            records.Add(newRecord2);
            string[] str1 = new string[] { "123", "Tom", "36.5", "False", "No symptoms" };
            string[] str2 = new string[] { "456", "Jerry", "37.1", "False", "No symptoms" };
            Assert.Contains(str1, records.ReturnContents());
            Assert.Contains(str2, records.ReturnContents());
        }
    }
}
