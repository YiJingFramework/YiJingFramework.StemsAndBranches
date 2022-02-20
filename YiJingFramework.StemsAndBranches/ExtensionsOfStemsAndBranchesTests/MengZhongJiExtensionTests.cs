using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using YiJingFramework.StemsAndBranches;

namespace ExtensionsOfStemsAndBranches.Tests
{
    [TestClass()]
    public class MengZhongJiExtensionTests
    {
        [TestMethod()]
        public void Usage()
        {
            var linq = from i in Enumerable.Range(1, 11).Prepend(12)
                       let branch = new EarthlyBranch(i)
                       select branch.JudgeMengZhongJi();
            var str = string.Join('-', linq);

            Assert.AreEqual("Meng-Zhong-Ji-Meng-Zhong-Ji-Meng-Zhong-Ji-Meng-Zhong-Ji", str);
        }

        [TestMethod()]
        public void JudgeMengZhongJiTest()
        {
            var branches = EarthlyBranch.BuildStringBranchTable("C")
                .ToDictionary(item => item.s, item => item.branch);
            Assert.AreEqual(MengZhongJiExtension.MengZhongJi.Zhong, branches["子"].JudgeMengZhongJi());
            Assert.AreEqual(MengZhongJiExtension.MengZhongJi.Ji, branches["丑"].JudgeMengZhongJi());
            Assert.AreEqual(MengZhongJiExtension.MengZhongJi.Meng, branches["寅"].JudgeMengZhongJi());
            Assert.AreEqual(MengZhongJiExtension.MengZhongJi.Zhong, branches["卯"].JudgeMengZhongJi());
            Assert.AreEqual(MengZhongJiExtension.MengZhongJi.Ji, branches["辰"].JudgeMengZhongJi());
            Assert.AreEqual(MengZhongJiExtension.MengZhongJi.Meng, branches["巳"].JudgeMengZhongJi());
            Assert.AreEqual(MengZhongJiExtension.MengZhongJi.Zhong, branches["午"].JudgeMengZhongJi());
            Assert.AreEqual(MengZhongJiExtension.MengZhongJi.Ji, branches["未"].JudgeMengZhongJi());
            Assert.AreEqual(MengZhongJiExtension.MengZhongJi.Meng, branches["申"].JudgeMengZhongJi());
            Assert.AreEqual(MengZhongJiExtension.MengZhongJi.Zhong, branches["酉"].JudgeMengZhongJi());
            Assert.AreEqual(MengZhongJiExtension.MengZhongJi.Ji, branches["戌"].JudgeMengZhongJi());
            Assert.AreEqual(MengZhongJiExtension.MengZhongJi.Meng, branches["亥"].JudgeMengZhongJi());
        }
    }
}