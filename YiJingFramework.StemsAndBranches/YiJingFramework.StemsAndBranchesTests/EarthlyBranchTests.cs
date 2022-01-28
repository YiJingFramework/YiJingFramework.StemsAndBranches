using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

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
            Assert.AreEqual("8", new EarthlyBranch(8).ToString("N"));

            Assert.AreEqual("Hai", new EarthlyBranch(0).ToString());
            Assert.AreEqual("You", new EarthlyBranch(-2).ToString());

            for (int i = -1007, j = 1; i < 1000; i++)
            {
                Assert.AreEqual(new EarthlyBranch(j), (EarthlyBranch)i);
                j++;
                if (j == 13)
                    j = 1;
            }

            var dic = EarthlyBranch.BuildStringBranchTable().ToDictionary(
                (item) => item.s, (item) => item.branch);
            var dicG = EarthlyBranch.BuildStringBranchTable("G").ToDictionary(
                (item) => item.s, (item) => item.branch);
            var dicC = EarthlyBranch.BuildStringBranchTable("C").ToDictionary(
                (item) => item.s, (item) => item.branch);
            var dicN = EarthlyBranch.BuildStringBranchTable("N").ToDictionary(
                (item) => item.s, (item) => item.branch);
            for (int i = -1007, j = 1; i < 1000; i++)
            {
                Assert.AreEqual(dic[new EarthlyBranch(j).ToString()], (EarthlyBranch)i);
                Assert.AreEqual(dicG[new EarthlyBranch(j).ToString("G")], (EarthlyBranch)i);
                Assert.AreEqual(dicC[new EarthlyBranch(j).ToString("C")], (EarthlyBranch)i);
                Assert.AreEqual(dicN[new EarthlyBranch(j).ToString("N")], (EarthlyBranch)i);
                j++;
                if (j == 13)
                    j = 1;
            }

            Assert.AreEqual(new EarthlyBranch(1).Next(12 + 11), new EarthlyBranch(12));
            Assert.AreEqual(new EarthlyBranch(1).Next(-2), new EarthlyBranch(11));
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
    }
}