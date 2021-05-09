using Microsoft.VisualStudio.TestTools.UnitTesting;
using YiJingFramework.StemsAndBranches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiJingFramework.Core;
using YiJingFramework.FiveElements;

namespace YiJingFramework.StemsAndBranches.Tests
{
    [TestClass()]
    public class HeavenlyStemTests
    {
        [TestMethod()]
        public void ConvertingTest()
        {
            Assert.AreEqual(1, (int)new HeavenlyStem(1));
            Assert.AreEqual(4, (int)new HeavenlyStem(4));
            Assert.AreEqual(2, (int)new HeavenlyStem(12));

            Assert.AreEqual("Bing", new HeavenlyStem(3).ToString());
            Assert.AreEqual("辛", new HeavenlyStem(8).ToString("C"));
            Assert.AreEqual("8", new HeavenlyStem(8).ToString("N"));

            Assert.AreEqual("Gui", new HeavenlyStem(0).ToString());
            Assert.AreEqual("Xin", new HeavenlyStem(-2).ToString());

            for (int i = -999, j = 1; i < 1000; i++)
            {
                Assert.AreEqual(new HeavenlyStem(j), (HeavenlyStem)i);
                j++;
                if (j == 11)
                    j = 1;
            }
        }

        [TestMethod()]
        public void GetAttributesTest()
        {
            Assert.AreEqual((FiveElement.Wood, YinYang.Yang), new HeavenlyStem(1).Attributes);
            Assert.AreEqual((FiveElement.Wood, YinYang.Yin), new HeavenlyStem(2).Attributes);
            Assert.AreEqual((FiveElement.Fire, YinYang.Yang), new HeavenlyStem(3).Attributes);
            Assert.AreEqual((FiveElement.Fire, YinYang.Yin), new HeavenlyStem(4).Attributes);
            Assert.AreEqual((FiveElement.Earth, YinYang.Yang), new HeavenlyStem(5).Attributes);
            Assert.AreEqual((FiveElement.Earth, YinYang.Yin), new HeavenlyStem(6).Attributes);
            Assert.AreEqual((FiveElement.Metal, YinYang.Yang), new HeavenlyStem(7).Attributes);
            Assert.AreEqual((FiveElement.Metal, YinYang.Yin), new HeavenlyStem(8).Attributes);
            Assert.AreEqual((FiveElement.Water, YinYang.Yang), new HeavenlyStem(9).Attributes);
            Assert.AreEqual((FiveElement.Water, YinYang.Yin), new HeavenlyStem(10).Attributes);
        }

        [TestMethod()]
        public void ComparingTest()
        {
            Random r = new Random();
            for (int i = 0; i < 20000; i++)
            {
                var fir = r.Next(1, 11);
                var sec = r.Next(1, 11);
                var firF = (HeavenlyStem)fir;
                var secF = (HeavenlyStem)sec;
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