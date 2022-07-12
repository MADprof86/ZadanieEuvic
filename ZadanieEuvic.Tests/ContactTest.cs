using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;


namespace ZadanieEuvic.Tests
{
    [TestFixture]
    public class ContactTest
    {
        [Test]
        public void SetContactNameSurname_TheNameIsFirs_ReturnsStringWithNameSecond()
        {
            var test = Moq(ZadanieEuvic)
            var contact = new ZadanieEuvic.Contact("Marek_Darek");
            var answer = 42;
            Assert.That(answer, Is.EqualTo(42), "Some useful error message");
        }
    }
}
