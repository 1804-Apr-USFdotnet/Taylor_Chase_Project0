using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;

namespace CodingChallengeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] args =
                { "racecar", "1221", "1234321", "never Odd, or Even" };
            Class1.main(args);
        }
    }
}
