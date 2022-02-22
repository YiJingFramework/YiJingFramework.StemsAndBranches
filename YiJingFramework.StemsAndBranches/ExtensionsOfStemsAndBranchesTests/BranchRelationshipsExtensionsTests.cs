using Microsoft.VisualStudio.TestTools.UnitTesting;
using YiJingFramework.StemsAndBranches;

namespace ExtensionsOfStemsAndBranches.Tests
{
    [TestClass()]
    public class BranchRelationshipsExtensionsTests
    {
        [TestMethod()]
        public void Usage()
        {
            var zi = new EarthlyBranch(1);
            var mao = new EarthlyBranch(4);
            var wu = new EarthlyBranch(7);
            var you = new EarthlyBranch(10);
            var wei = new EarthlyBranch(8);
            var chou = new EarthlyBranch(2);

            Assert.AreEqual(mao, zi.Xing());
            Assert.AreEqual(mao, zi.XingBy());
            Assert.AreEqual(wu, zi.Chong());
            Assert.AreEqual(you, zi.Po());
            Assert.AreEqual(wei, zi.Hai());
            Assert.AreEqual(chou, zi.LiuHe());
        }

        [TestMethod()]
        public void LiuHeTest()
        {
            EarthlyBranch 子 = new EarthlyBranch(1);
            EarthlyBranch 丑 = new EarthlyBranch(2);
            EarthlyBranch 寅 = new EarthlyBranch(3);
            EarthlyBranch 卯 = new EarthlyBranch(4);
            EarthlyBranch 辰 = new EarthlyBranch(5);
            EarthlyBranch 巳 = new EarthlyBranch(6);
            EarthlyBranch 午 = new EarthlyBranch(7);
            EarthlyBranch 未 = new EarthlyBranch(8);
            EarthlyBranch 申 = new EarthlyBranch(9);
            EarthlyBranch 酉 = new EarthlyBranch(10);
            EarthlyBranch 戌 = new EarthlyBranch(11);
            EarthlyBranch 亥 = new EarthlyBranch(12);

            Assert.AreEqual(丑, 子.LiuHe());
            Assert.AreEqual(子, 丑.LiuHe());
            Assert.AreEqual(亥, 寅.LiuHe());
            Assert.AreEqual(戌, 卯.LiuHe());
            Assert.AreEqual(酉, 辰.LiuHe());
            Assert.AreEqual(申, 巳.LiuHe());
            Assert.AreEqual(未, 午.LiuHe());
            Assert.AreEqual(午, 未.LiuHe());
            Assert.AreEqual(巳, 申.LiuHe());
            Assert.AreEqual(辰, 酉.LiuHe());
            Assert.AreEqual(卯, 戌.LiuHe());
            Assert.AreEqual(寅, 亥.LiuHe());
        }

        [TestMethod()]
        public void ChongTest()
        {
            EarthlyBranch 子 = new EarthlyBranch(1);
            EarthlyBranch 丑 = new EarthlyBranch(2);
            EarthlyBranch 寅 = new EarthlyBranch(3);
            EarthlyBranch 卯 = new EarthlyBranch(4);
            EarthlyBranch 辰 = new EarthlyBranch(5);
            EarthlyBranch 巳 = new EarthlyBranch(6);
            EarthlyBranch 午 = new EarthlyBranch(7);
            EarthlyBranch 未 = new EarthlyBranch(8);
            EarthlyBranch 申 = new EarthlyBranch(9);
            EarthlyBranch 酉 = new EarthlyBranch(10);
            EarthlyBranch 戌 = new EarthlyBranch(11);
            EarthlyBranch 亥 = new EarthlyBranch(12);

            Assert.AreEqual(午, 子.Chong());
            Assert.AreEqual(未, 丑.Chong());
            Assert.AreEqual(申, 寅.Chong());
            Assert.AreEqual(酉, 卯.Chong());
            Assert.AreEqual(戌, 辰.Chong());
            Assert.AreEqual(亥, 巳.Chong());
            Assert.AreEqual(子, 午.Chong());
            Assert.AreEqual(丑, 未.Chong());
            Assert.AreEqual(寅, 申.Chong());
            Assert.AreEqual(卯, 酉.Chong());
            Assert.AreEqual(辰, 戌.Chong());
            Assert.AreEqual(巳, 亥.Chong());
        }

        [TestMethod()]
        public void HaiTest()
        {
            EarthlyBranch 子 = new EarthlyBranch(1);
            EarthlyBranch 丑 = new EarthlyBranch(2);
            EarthlyBranch 寅 = new EarthlyBranch(3);
            EarthlyBranch 卯 = new EarthlyBranch(4);
            EarthlyBranch 辰 = new EarthlyBranch(5);
            EarthlyBranch 巳 = new EarthlyBranch(6);
            EarthlyBranch 午 = new EarthlyBranch(7);
            EarthlyBranch 未 = new EarthlyBranch(8);
            EarthlyBranch 申 = new EarthlyBranch(9);
            EarthlyBranch 酉 = new EarthlyBranch(10);
            EarthlyBranch 戌 = new EarthlyBranch(11);
            EarthlyBranch 亥 = new EarthlyBranch(12);

            Assert.AreEqual(未, 子.Hai());
            Assert.AreEqual(午, 丑.Hai());
            Assert.AreEqual(巳, 寅.Hai());
            Assert.AreEqual(辰, 卯.Hai());
            Assert.AreEqual(卯, 辰.Hai());
            Assert.AreEqual(寅, 巳.Hai());
            Assert.AreEqual(丑, 午.Hai());
            Assert.AreEqual(子, 未.Hai());
            Assert.AreEqual(亥, 申.Hai());
            Assert.AreEqual(戌, 酉.Hai());
            Assert.AreEqual(酉, 戌.Hai());
            Assert.AreEqual(申, 亥.Hai());
        }

        [TestMethod()]
        public void XingByTest()
        {
            EarthlyBranch 子 = new EarthlyBranch(1);
            EarthlyBranch 丑 = new EarthlyBranch(2);
            EarthlyBranch 寅 = new EarthlyBranch(3);
            EarthlyBranch 卯 = new EarthlyBranch(4);
            EarthlyBranch 辰 = new EarthlyBranch(5);
            EarthlyBranch 巳 = new EarthlyBranch(6);
            EarthlyBranch 午 = new EarthlyBranch(7);
            EarthlyBranch 未 = new EarthlyBranch(8);
            EarthlyBranch 申 = new EarthlyBranch(9);
            EarthlyBranch 酉 = new EarthlyBranch(10);
            EarthlyBranch 戌 = new EarthlyBranch(11);
            EarthlyBranch 亥 = new EarthlyBranch(12);

            Assert.AreEqual(卯, 子.XingBy());
            Assert.AreEqual(未, 丑.XingBy());
            Assert.AreEqual(申, 寅.XingBy());
            Assert.AreEqual(子, 卯.XingBy());
            Assert.AreEqual(辰, 辰.XingBy());
            Assert.AreEqual(寅, 巳.XingBy());
            Assert.AreEqual(午, 午.XingBy());
            Assert.AreEqual(戌, 未.XingBy());
            Assert.AreEqual(巳, 申.XingBy());
            Assert.AreEqual(酉, 酉.XingBy());
            Assert.AreEqual(丑, 戌.XingBy());
            Assert.AreEqual(亥, 亥.XingBy());
        }

        [TestMethod()]
        public void XingTest()
        {
            EarthlyBranch 子 = new EarthlyBranch(1);
            EarthlyBranch 丑 = new EarthlyBranch(2);
            EarthlyBranch 寅 = new EarthlyBranch(3);
            EarthlyBranch 卯 = new EarthlyBranch(4);
            EarthlyBranch 辰 = new EarthlyBranch(5);
            EarthlyBranch 巳 = new EarthlyBranch(6);
            EarthlyBranch 午 = new EarthlyBranch(7);
            EarthlyBranch 未 = new EarthlyBranch(8);
            EarthlyBranch 申 = new EarthlyBranch(9);
            EarthlyBranch 酉 = new EarthlyBranch(10);
            EarthlyBranch 戌 = new EarthlyBranch(11);
            EarthlyBranch 亥 = new EarthlyBranch(12);

            Assert.AreEqual(卯, 子.Xing());
            Assert.AreEqual(戌, 丑.Xing());
            Assert.AreEqual(巳, 寅.Xing());
            Assert.AreEqual(子, 卯.Xing());
            Assert.AreEqual(辰, 辰.Xing());
            Assert.AreEqual(申, 巳.Xing());
            Assert.AreEqual(午, 午.Xing());
            Assert.AreEqual(丑, 未.Xing());
            Assert.AreEqual(寅, 申.Xing());
            Assert.AreEqual(酉, 酉.Xing());
            Assert.AreEqual(未, 戌.Xing());
            Assert.AreEqual(亥, 亥.Xing());
        }

        [TestMethod()]
        public void PoTest()
        {
            EarthlyBranch 子 = new EarthlyBranch(1);
            EarthlyBranch 丑 = new EarthlyBranch(2);
            EarthlyBranch 寅 = new EarthlyBranch(3);
            EarthlyBranch 卯 = new EarthlyBranch(4);
            EarthlyBranch 辰 = new EarthlyBranch(5);
            EarthlyBranch 巳 = new EarthlyBranch(6);
            EarthlyBranch 午 = new EarthlyBranch(7);
            EarthlyBranch 未 = new EarthlyBranch(8);
            EarthlyBranch 申 = new EarthlyBranch(9);
            EarthlyBranch 酉 = new EarthlyBranch(10);
            EarthlyBranch 戌 = new EarthlyBranch(11);
            EarthlyBranch 亥 = new EarthlyBranch(12);

            Assert.AreEqual(酉, 子.Po());
            Assert.AreEqual(辰, 丑.Po());
            Assert.AreEqual(亥, 寅.Po());
            Assert.AreEqual(午, 卯.Po());
            Assert.AreEqual(丑, 辰.Po());
            Assert.AreEqual(申, 巳.Po());
            Assert.AreEqual(卯, 午.Po());
            Assert.AreEqual(戌, 未.Po());
            Assert.AreEqual(巳, 申.Po());
            Assert.AreEqual(子, 酉.Po());
            Assert.AreEqual(未, 戌.Po());
            Assert.AreEqual(寅, 亥.Po());
        }
    }
}