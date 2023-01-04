using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Text.Json;

namespace YiJingFramework.StemsAndBranches.Tests
{
    [TestClass()]
    public class EarthlyBranchTests
    {
        [TestMethod()]
        public void ConvertingTest()
        {
            Assert.AreEqual(1, (int)new EarthlyBranch(1));
            Assert.AreEqual(4, (int)new EarthlyBranch(4));
            Assert.AreEqual(2, (int)new EarthlyBranch(14));

            Assert.AreEqual("Yin", new EarthlyBranch(3).ToString());
            Assert.AreEqual("未", new EarthlyBranch(8).ToString("C"));
            Assert.AreEqual("8", EarthlyBranch.Wei.ToString("N"));

            Assert.AreEqual("Hai", new EarthlyBranch(0).ToString());
            Assert.AreEqual("You", new EarthlyBranch(-2).ToString());

            for (int i = -1007, j = 1; i < 1000; i++)
            {
                Assert.AreEqual(new EarthlyBranch(j), (EarthlyBranch)i);
                j++;
                if (j == 13)
                    j = 1;
            }

            T Parse<T>(string s) where T : IParsable<T>
            {
                return T.Parse(s, null);
            }

            bool TryParse<T>(string s, out T result) where T : IParsable<T>
            {
                return T.TryParse(s, null, out result);
            }

            Assert.AreEqual(EarthlyBranch.Zi, EarthlyBranch.Parse("zI"));
            Assert.AreEqual(EarthlyBranch.Yin, Parse<EarthlyBranch>("寅"));
            _ = TryParse<EarthlyBranch>("8", out var p);
            Assert.AreEqual(EarthlyBranch.Wei, p);

            Assert.AreEqual(EarthlyBranch.Hai, EarthlyBranch.Zi.Next(12 + 11));
            Assert.AreEqual(new EarthlyBranch(11), EarthlyBranch.Zi.Next(-2));

            Assert.AreEqual(new EarthlyBranch(1) + 15, new EarthlyBranch(4));
            Assert.AreEqual(new EarthlyBranch(1) - 15, new EarthlyBranch(10));
        }

        [TestMethod()]
        public void ComparingTest()
        {
            Random r = new Random();
            for (int i = 0; i < 20000; i++)
            {
                var fir = r.Next(1, 13);
                var sec = r.Next(1, 13);
                var firF = (EarthlyBranch)fir;
                var secF = (EarthlyBranch)sec;
                if (fir == sec)
                {
                    Assert.AreEqual(0, firF.CompareTo(secF));
                    Assert.AreEqual(0, secF.CompareTo(firF));
                    Assert.AreEqual(true, firF.Equals(secF));
                    Assert.AreEqual(true, secF.Equals(firF));
                    Assert.AreEqual(true, firF.Equals((object)secF));
                    Assert.AreEqual(true, secF.Equals((object)firF));
                    Assert.AreEqual(firF.GetHashCode(), secF.GetHashCode());
                    Assert.AreEqual(true, firF == secF);
                    Assert.AreEqual(true, secF == firF);
                    Assert.AreEqual(false, firF != secF);
                    Assert.AreEqual(false, secF != firF);
                }

                else if (fir < sec)
                {
                    Assert.AreEqual(-1, firF.CompareTo(secF));
                    Assert.AreEqual(1, secF.CompareTo(firF));
                    Assert.AreEqual(false, firF.Equals(secF));
                    Assert.AreEqual(false, secF.Equals(firF));
                    Assert.AreEqual(false, firF.Equals((object)secF));
                    Assert.AreEqual(false, secF.Equals((object)firF));
                    Assert.AreNotEqual(firF.GetHashCode(), secF.GetHashCode());
                    Assert.AreEqual(false, firF == secF);
                    Assert.AreEqual(false, secF == firF);
                    Assert.AreEqual(true, firF != secF);
                    Assert.AreEqual(true, secF != firF);
                }

                else // fir > sec
                {
                    Assert.AreEqual(1, firF.CompareTo(secF));
                    Assert.AreEqual(-1, secF.CompareTo(firF));
                    Assert.AreEqual(false, firF.Equals(secF));
                    Assert.AreEqual(false, secF.Equals(firF));
                    Assert.AreEqual(false, firF.Equals((object)secF));
                    Assert.AreEqual(false, secF.Equals((object)firF));
                    Assert.AreNotEqual(firF.GetHashCode(), secF.GetHashCode());
                    Assert.AreEqual(false, firF == secF);
                    Assert.AreEqual(false, secF == firF);
                    Assert.AreEqual(true, firF != secF);
                    Assert.AreEqual(true, secF != firF);
                }
                Assert.AreEqual(false, firF.Equals(null));
                Assert.AreEqual(false, secF.Equals(new object()));
            }
        }

        [TestMethod()]
        public void SerializationTest()
        {
            for (int i = 0; i < 12; i++)
            {
                var element = (EarthlyBranch)i;
                var s = JsonSerializer.Serialize(element);
                var d = JsonSerializer.Deserialize<EarthlyBranch>(s);
                Assert.AreEqual(element, d);
            }
        }
    }
}