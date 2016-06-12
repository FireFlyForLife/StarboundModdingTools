using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void CastTypeTest() {
            Assert.IsTrue(notCasted("heello"));
        }

        bool notCasted(Object o) {
            return o.GetType().Equals(typeof(String));
        }
    }
}
