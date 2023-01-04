using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Text.Json;

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

            T Parse<T>(string s) where T : IParsable<T>
            {
                return T.Parse(s, null);
            }

            bool TryParse<T>(string s, out T result) where T : IParsable<T>
            {
                return T.TryParse(s, null, out result);
            }

            Assert.AreEqual(HeavenlyStem.Jia, HeavenlyStem.Parse("jIa"));
            Assert.AreEqual(HeavenlyStem.Gui, Parse<HeavenlyStem>("癸"));
            _ = TryParse<HeavenlyStem>("4", out var p);
            Assert.AreEqual(HeavenlyStem.Ding, p);


            Assert.AreEqual(new HeavenlyStem(1).Next(10 + 3), new HeavenlyStem(4));
            Assert.AreEqual(new HeavenlyStem(1).Next(-2), new HeavenlyStem(9));

            Assert.AreEqual(new HeavenlyStem(1) + 15, new HeavenlyStem(6));
            Assert.AreEqual(new HeavenlyStem(1) - 15, new HeavenlyStem(6));
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
        [TestMethod()]
        public void SerializationTest()
        {
            for (int i = 0; i < 10; i++)
            {
                var element = (HeavenlyStem)i;
                var s = JsonSerializer.Serialize(element);
                var d = JsonSerializer.Deserialize<HeavenlyStem>(s);
                Assert.AreEqual(element, d);
            }
        }
    }
}