using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testUsers
{
    [TestFixture]
    public class FunctionTests
    {
        [Test]
        public void CountUsers()
        {
            var function = new Function();
            int result = function.CountUsers();
            Assert.That(Equals(2, result));
        }
    }
}
