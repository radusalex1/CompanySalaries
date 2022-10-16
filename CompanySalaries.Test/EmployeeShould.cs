using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySalaries.Test
{
    [TestFixture]
    public class EmployeeShould
    {
        [Test]
        public void NameShould()
        {
            int value1 = 12;
            int value2 = 12;
            Assert.That(value1, Is.EqualTo(value2));
        }
    }
}
