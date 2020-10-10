using System;
using Xunit;
using HealthyRecord;

namespace HealthyRecord.Test
{
    public class TestRecord
    {
        [Theory]
        [InlineData(123, "Tom", 37.1, false, "No symptoms", false)]
        [InlineData(456, "Jerry", 38.2, true, "fever", true)]
        public void IsSuspicious_Should(long GIN, string name, float temperature, bool riskArea, string symptom, bool expectedResult)
        {
            Record newRecord = new HealthyRecord.Record(GIN, name, temperature, riskArea, symptom);
            Assert.Equal(expectedResult, newRecord.IsSuspicous());
        }
        [Theory]
        [InlineData(123, "Tom", 37.1, false, "No symptoms", new string[] { "123", "Tom", "37.1", "False", "No symptoms" })]
        public void ReturnContent_Should(long GIN, string name, float temperature, bool riskArea, string symptom, string[] expectedResult)
        {
            Record newRecord = new HealthyRecord.Record(GIN, name, temperature, riskArea, symptom);
            Assert.Equal(expectedResult, newRecord.ReturnContent());
        }
        [Fact]
        public void Record_String()
        {
            Record newRecord = new HealthyRecord.Record(new string[] { "123", "Tom", float.Parse((37.2).ToString()).ToString(), "False", "No symptoms" });
            Assert.Equal(123, newRecord.GIN);
            Assert.Equal("Tom", newRecord.Name);
            Assert.Equal(float.Parse((37.2).ToString()), newRecord.Temperature);
            Assert.False(newRecord.RiskArea);
            Assert.Equal("No symptoms", newRecord.Symptom);

        }
    }
}
