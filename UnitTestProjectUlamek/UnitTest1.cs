using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UlamekLib;

namespace UnitTestProjectUlamek
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void KonstruktorDomyslny_LicznikZero_MianownikJeden()
        {
            //AAA:

            //Arange
            var u = new Ulamek();
            //Act

            //Assert
            Assert.AreEqual(0, u.Licznik);
            Assert.AreEqual(1, u.Mianownik);



        }

        [DataTestMethod]
        [DataRow(2, 3, 2, 3)]
        [DataRow(-2, 3, -2, 3)]
        [DataRow(0, 5, 0, 1)]
        public void KonstruktorDwuargumentowy_Ok( long l, long m, long ul, long um)
        {
            var u = new Ulamek(l,m);

            Assert.AreEqual(ul, u.Licznik);
            Assert.AreEqual(um, u.Mianownik);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void KonstruktorDwuargumentowy_MianownikZero_ZgaszamyWyjatekDivideByZero()
        {
            var u = new Ulamek(5, 0);
        }

        [DataTestMethod]
        [DataRow(2, 3, 2, 3)]
        [DataRow(-2, 3, -2, 3)]
        [DataRow(2, -3, -2, 3)]
        [DataRow(-2, -3, 2, 3)]
        public void KonstruktorDwuargumentowy_ZnakUlamkaWLiczniku(long l, long m, long ul, long um)
        {
            var u = new Ulamek(l, m);

            Assert.IsTrue(u.Mianownik > 0);
            Assert.IsTrue(Math.Sign(l * m) == Math.Sign(u.Licznik));
            Assert.IsTrue(l * u.Mianownik == m * u.Licznik);
        }

    }
}
