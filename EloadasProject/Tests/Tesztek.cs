using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace EloadasProject.Tests
{
   
        [TestFixture]
        class Tesztek
        {
            Eloadas e;
            [SetUp]
            public void SetUp()
            {
                e = new Eloadas(10, 10);
            }

            [TestCase]
            public void UjEloadasOsszesHelySzabad()
            {
            Assert.AreEqual(100, e.SzabadHelyek, "A szabad helyek száma hibás!");
            }

            [TestCase]
            public void HelyFoglalasHelyekSzamaMinus()
            {
                e.Lefoglal();
                e.Lefoglal();
            Assert.AreEqual(98, e.SzabadHelyek, "A szabad helyek nem csökkentek!");
            }

            [TestCase]
            public void EloadasNincsTele()
            {
                Assert.IsFalse(e.Teli, "Üres előadás tele van!");
            }

            [TestCase]
            public void EloadasTele()
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        e.Lefoglal();
                    }
                }
                Assert.IsTrue(e.Teli, "Teli előadás mégsincs tele!");
            }

            [TestCase]
            public void TeleEloadasraNemLehetLefoglalni()
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        e.Lefoglal();
                    }
                }
                bool sikerult = e.Lefoglal();
                Assert.AreEqual(0, e.SzabadHelyek);
                Assert.IsTrue(e.Teli);
                Assert.IsFalse(sikerult);
            }

            [TestCase]
            public void SorokSzamaEsHelyekSzamaNemLehetNegativ()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    var eloadas = new Eloadas(-2, -2);
                });
            }

            [TestCase]
            public void FoglaltNemLehetKisebbMintEgy()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    e.Foglalt(0, 0);
                });
            }

            [TestCase]
            public void FoglaltNemLehetNagyobbMintMax()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    e.Foglalt(11, 11);
                });
            }


    }

    
}
