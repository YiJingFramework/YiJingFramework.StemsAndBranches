using Microsoft.VisualStudio.TestTools.UnitTesting;
using YiJingFramework.FiveElements;
using YiJingFramework.StemsAndBranches;

namespace ExtensionsOfStemsAndBranches.Tests
{
    [TestClass()]
    public class TwelveGrowthPhasesExtensionsTests
    {
        [TestMethod()]
        public void Usage()
        {
            {
                var branchUpper = new EarthlyBranch(2);
                var branchLower = new EarthlyBranch(5);
                var phase = branchUpper.GetFiveElement().GetTwelveGrowthPhase(branchLower);
                // Here GetFiveElement() is defined in Attributes extension.
                var str = $"{branchUpper} comes to {branchLower} which is its {phase}";
                Assert.AreEqual("Chou comes to Chen which is its Mu", str);
            }
            {
                var element = FiveElement.Fire;
                var branch1 = element.GetBranchByTwelveGrowthPhase(
                    TwelveGrowthPhasesExtensions.TwelveGrowthPhase.LinGuan);
                var branch2 = element.GetBranchByTwelveGrowthPhase(
                    TwelveGrowthPhasesExtensions.TwelveGrowthPhase.DiWang);
                Assert.AreEqual(branch1.GetFiveElement(), element);
                Assert.AreEqual(branch2.GetFiveElement(), element);
                // Except Earth, LinGuan and DiWang of a element will be
                // the two branches with the attribute of this element.
            }
        }

        [TestMethod()]
        public void GetTwelveGrowthPhaseTest()
        {
            var element = FiveElement.Wood;
            var currentBranch = new EarthlyBranch(12); // 亥
            for (int i = 0; i < 12; i++)
            {
                Assert.AreEqual((TwelveGrowthPhasesExtensions.TwelveGrowthPhase)i,
                    element.GetTwelveGrowthPhase(currentBranch));
                currentBranch = currentBranch.Next();
            }

            element = FiveElement.Fire;
            currentBranch = new EarthlyBranch(3); // 寅
            for (int i = 0; i < 12; i++)
            {
                Assert.AreEqual((TwelveGrowthPhasesExtensions.TwelveGrowthPhase)i,
                    element.GetTwelveGrowthPhase(currentBranch));
                currentBranch = currentBranch.Next();
            }

            element = FiveElement.Metal;
            currentBranch = new EarthlyBranch(6); // 巳
            for (int i = 0; i < 12; i++)
            {
                Assert.AreEqual((TwelveGrowthPhasesExtensions.TwelveGrowthPhase)i,
                    element.GetTwelveGrowthPhase(currentBranch));
                currentBranch = currentBranch.Next();
            }

            element = FiveElement.Water;
            var element2 = FiveElement.Earth;
            currentBranch = new EarthlyBranch(9); // 申
            for (int i = 0; i < 12; i++)
            {
                Assert.AreEqual((TwelveGrowthPhasesExtensions.TwelveGrowthPhase)i,
                    element.GetTwelveGrowthPhase(currentBranch));
                Assert.AreEqual((TwelveGrowthPhasesExtensions.TwelveGrowthPhase)i,
                    element2.GetTwelveGrowthPhase(currentBranch));
                currentBranch = currentBranch.Next();
            }
        }

        [TestMethod()]
        public void GetBranchByTwelveGrowthPhaseTest()
        {
            var element = FiveElement.Wood;
            var currentBranch = new EarthlyBranch(12); // 亥
            for (int i = 0; i < 12; i++)
            {
                Assert.AreEqual(currentBranch,
                    element.GetBranchByTwelveGrowthPhase((TwelveGrowthPhasesExtensions.TwelveGrowthPhase)i));
                currentBranch = currentBranch.Next();
            }

            element = FiveElement.Fire;
            currentBranch = new EarthlyBranch(3); // 寅
            for (int i = 0; i < 12; i++)
            {
                Assert.AreEqual(currentBranch,
                    element.GetBranchByTwelveGrowthPhase((TwelveGrowthPhasesExtensions.TwelveGrowthPhase)i));
                currentBranch = currentBranch.Next();
            }

            element = FiveElement.Metal;
            currentBranch = new EarthlyBranch(6); // 巳
            for (int i = 0; i < 12; i++)
            {
                Assert.AreEqual(currentBranch,
                    element.GetBranchByTwelveGrowthPhase((TwelveGrowthPhasesExtensions.TwelveGrowthPhase)i));
                currentBranch = currentBranch.Next();
            }

            element = FiveElement.Water;
            var element2 = FiveElement.Earth;
            currentBranch = new EarthlyBranch(9); // 申
            for (int i = 0; i < 12; i++)
            {
                Assert.AreEqual(currentBranch,
                    element.GetBranchByTwelveGrowthPhase((TwelveGrowthPhasesExtensions.TwelveGrowthPhase)i));
                Assert.AreEqual(currentBranch,
                    element2.GetBranchByTwelveGrowthPhase((TwelveGrowthPhasesExtensions.TwelveGrowthPhase)i));
                currentBranch = currentBranch.Next();
            }
        }
    }
}