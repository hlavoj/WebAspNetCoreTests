using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebAspNetCoreTests.Test2
{
    [TestClass]
    public class UniteTest
    {
        [TestMethod]
        public void TestMethodPassing()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethodFailing()
        {
            Assert.IsTrue(false);
        }
    }
}
