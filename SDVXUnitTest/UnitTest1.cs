using NUnit.Framework;
using SDVXStarter;
using System;


namespace SDVXUnitTest
{
    
    public class Tests
    {
        public const string D_PATH = "D:\\ea3-config.xml";
        public const string C_PATH = "C:\\MUG\\SDVX\\" +
            "HH\\KFC-2019020600\\contents\\prop\\ea3-config.xml";

        [Test]
        /// <summary>
        /// Test to EA3Compiler.
        /// </summary>
        public void EA3ComplierVersionReadTest1()
        {
            EA3Compiler config = new EA3Compiler("D:\\ea3-config.xml");
            string ver = config.getVersion();
            string expected = "KFC:J:A:A:2020011500";
            string[] teared = config.decomposeVersion(ver);
            string[] tearedExpected = {"KFC","J","A","A","2020011500"};
            Assert.AreEqual(ver, expected);
            Assert.AreEqual(teared, tearedExpected);
        }

        [Test]
        public void EA3ComplierVersionReadTest2()
        {
            EA3Compiler config = new EA3Compiler(C_PATH);
            string ver = config.getVersion();
            string expected = "KFC:J:A:A:2019020600";
            string[] teared = config.decomposeVersion(ver);
            string[] tearedExpected = { "KFC", "J", "A", "A", "2020011500" };
            Assert.AreEqual(ver, expected);
            Assert.AreEqual(teared, tearedExpected);
        }
    }
}