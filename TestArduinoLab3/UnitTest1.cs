using System;
using Xunit;

namespace TestArduinoLab3
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Program.xmlBuffer = "</movemant>";
            bool result = Program.CheckXMLbuffer();
            Assert.True(result);
        }

        [Fact]
        public void Test2()
        {   
            Program.xmlBuffer = "<movemant>45</movemant>";
            string result = Program.GetDistanceSTR();
            Assert.True(result == "45");
        }
    }
}
