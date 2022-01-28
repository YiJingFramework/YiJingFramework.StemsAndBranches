using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExtensionsOfStemsAndBranches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiJingFramework.StemsAndBranches;
using YiJingFramework.FiveElements;
using YiJingFramework.Core;

namespace ExtensionsOfStemsAndBranches.Tests
{
    [TestClass()]
    public class AttributesTests
    {
        [TestMethod()]
        public void Usage()
        {
            YinYang yinYangOfYi = new HeavenlyStem(2).GetYinYang();
            FiveElement fiveElementOfChou = new EarthlyBranch(2).GetFiveElement();

            Assert.AreEqual(YinYang.Yin, yinYangOfYi);
            Assert.AreEqual(FiveElement.Earth, fiveElementOfChou);
        }

        [TestMethod()]
        public void GetFiveElementTest()
        {
            var stems = HeavenlyStem.BuildStringStemTable("C")
                .ToDictionary(item => item.s, item => item.stem);
            Assert.AreEqual(FiveElement.Wood, stems["甲"].GetFiveElement());
            Assert.AreEqual(FiveElement.Wood, stems["乙"].GetFiveElement());
            Assert.AreEqual(FiveElement.Fire, stems["丙"].GetFiveElement());
            Assert.AreEqual(FiveElement.Fire, stems["丁"].GetFiveElement());
            Assert.AreEqual(FiveElement.Earth, stems["戊"].GetFiveElement());
            Assert.AreEqual(FiveElement.Earth, stems["己"].GetFiveElement());
            Assert.AreEqual(FiveElement.Metal, stems["庚"].GetFiveElement());
            Assert.AreEqual(FiveElement.Metal, stems["辛"].GetFiveElement());
            Assert.AreEqual(FiveElement.Water, stems["壬"].GetFiveElement());
            Assert.AreEqual(FiveElement.Water, stems["癸"].GetFiveElement());

            var branches = EarthlyBranch.BuildStringBranchTable("C")
                .ToDictionary(item => item.s, item => item.branch);
            Assert.AreEqual(FiveElement.Water, branches["子"].GetFiveElement());
            Assert.AreEqual(FiveElement.Earth, branches["丑"].GetFiveElement());
            Assert.AreEqual(FiveElement.Wood, branches["寅"].GetFiveElement());
            Assert.AreEqual(FiveElement.Wood, branches["卯"].GetFiveElement());
            Assert.AreEqual(FiveElement.Earth, branches["辰"].GetFiveElement());
            Assert.AreEqual(FiveElement.Fire, branches["巳"].GetFiveElement());
            Assert.AreEqual(FiveElement.Fire, branches["午"].GetFiveElement());
            Assert.AreEqual(FiveElement.Earth, branches["未"].GetFiveElement());
            Assert.AreEqual(FiveElement.Metal, branches["申"].GetFiveElement());
            Assert.AreEqual(FiveElement.Metal, branches["酉"].GetFiveElement());
            Assert.AreEqual(FiveElement.Earth, branches["戌"].GetFiveElement());
            Assert.AreEqual(FiveElement.Water, branches["亥"].GetFiveElement());
        }

        [TestMethod()]
        public void GetYinYangTest()
        {
            var stems = HeavenlyStem.BuildStringStemTable("C")
                .ToDictionary(item => item.s, item => item.stem);
            Assert.AreEqual(YinYang.Yang, stems["甲"].GetYinYang());
            Assert.AreEqual(YinYang.Yin, stems["乙"].GetYinYang());
            Assert.AreEqual(YinYang.Yang, stems["丙"].GetYinYang());
            Assert.AreEqual(YinYang.Yin, stems["丁"].GetYinYang());
            Assert.AreEqual(YinYang.Yang, stems["戊"].GetYinYang());
            Assert.AreEqual(YinYang.Yin, stems["己"].GetYinYang());
            Assert.AreEqual(YinYang.Yang, stems["庚"].GetYinYang());
            Assert.AreEqual(YinYang.Yin, stems["辛"].GetYinYang());
            Assert.AreEqual(YinYang.Yang, stems["壬"].GetYinYang());
            Assert.AreEqual(YinYang.Yin, stems["癸"].GetYinYang());

            var branches = EarthlyBranch.BuildStringBranchTable("C")
                .ToDictionary(item => item.s, item => item.branch);
            Assert.AreEqual(YinYang.Yang, branches["子"].GetYinYang());
            Assert.AreEqual(YinYang.Yin, branches["丑"].GetYinYang());
            Assert.AreEqual(YinYang.Yang, branches["寅"].GetYinYang());
            Assert.AreEqual(YinYang.Yin, branches["卯"].GetYinYang());
            Assert.AreEqual(YinYang.Yang, branches["辰"].GetYinYang());
            Assert.AreEqual(YinYang.Yin, branches["巳"].GetYinYang());
            Assert.AreEqual(YinYang.Yang, branches["午"].GetYinYang());
            Assert.AreEqual(YinYang.Yin, branches["未"].GetYinYang());
            Assert.AreEqual(YinYang.Yang, branches["申"].GetYinYang());
            Assert.AreEqual(YinYang.Yin, branches["酉"].GetYinYang());
            Assert.AreEqual(YinYang.Yang, branches["戌"].GetYinYang());
            Assert.AreEqual(YinYang.Yin, branches["亥"].GetYinYang());
        }
    }
}