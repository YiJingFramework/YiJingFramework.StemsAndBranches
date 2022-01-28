using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExtensionsOfStemsAndBranches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiJingFramework.FiveElements;
using YiJingFramework.StemsAndBranches;

namespace ExtensionsOfStemsAndBranches.Tests
{
    [TestClass()]
    public class TwelveGrowthPhasesTests
    {
        [TestMethod()]
        public void Usage()
        {
            var branchUpper = new EarthlyBranch(2);
            var branchLower = new EarthlyBranch(5);

            var phase = branchUpper.GetFiveElement().GetTwelveGrowthPhase(branchLower);
            // Here the GetFiveElement() comes from Attributes extension.

            var str = $"{branchUpper} comes to {branchLower} which is its {phase}";
            Assert.AreEqual("Chou comes to Chen which is its Mu", str);
        }

        [TestMethod()]
        public void GetTwelveGrowthPhaseTest()
        {
            var element = FiveElement.Wood;
            var currentBranch = new EarthlyBranch(12); // 亥
            for (int i = 0; i < 12; i++)
            {
                Assert.AreEqual((TwelveGrowthPhases.TwelveGrowthPhase)i,
                    element.GetTwelveGrowthPhase(currentBranch));
                currentBranch = currentBranch.Next();
            }

            element = FiveElement.Fire;
            currentBranch = new EarthlyBranch(3); // 寅
            for (int i = 0; i < 12; i++)
            {
                Assert.AreEqual((TwelveGrowthPhases.TwelveGrowthPhase)i,
                    element.GetTwelveGrowthPhase(currentBranch));
                currentBranch = currentBranch.Next();
            }

            element = FiveElement.Metal;
            currentBranch = new EarthlyBranch(6); // 巳
            for (int i = 0; i < 12; i++)
            {
                Assert.AreEqual((TwelveGrowthPhases.TwelveGrowthPhase)i,
                    element.GetTwelveGrowthPhase(currentBranch));
                currentBranch = currentBranch.Next();
            }

            element = FiveElement.Water;
            var element2 = FiveElement.Earth;
            currentBranch = new EarthlyBranch(9); // 申
            for (int i = 0; i < 12; i++)
            {
                Assert.AreEqual((TwelveGrowthPhases.TwelveGrowthPhase)i,
                    element.GetTwelveGrowthPhase(currentBranch));
                Assert.AreEqual((TwelveGrowthPhases.TwelveGrowthPhase)i,
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
                    element.GetBranchByTwelveGrowthPhase((TwelveGrowthPhases.TwelveGrowthPhase)i));
                currentBranch = currentBranch.Next();
            }

            element = FiveElement.Fire;
            currentBranch = new EarthlyBranch(3); // 寅
            for (int i = 0; i < 12; i++)
            {
                Assert.AreEqual(currentBranch,
                    element.GetBranchByTwelveGrowthPhase((TwelveGrowthPhases.TwelveGrowthPhase)i));
                currentBranch = currentBranch.Next();
            }

            element = FiveElement.Metal;
            currentBranch = new EarthlyBranch(6); // 巳
            for (int i = 0; i < 12; i++)
            {
                Assert.AreEqual(currentBranch,
                    element.GetBranchByTwelveGrowthPhase((TwelveGrowthPhases.TwelveGrowthPhase)i));
                currentBranch = currentBranch.Next();
            }

            element = FiveElement.Water;
            var element2 = FiveElement.Earth;
            currentBranch = new EarthlyBranch(9); // 申
            for (int i = 0; i < 12; i++)
            {
                Assert.AreEqual(currentBranch,
                    element.GetBranchByTwelveGrowthPhase((TwelveGrowthPhases.TwelveGrowthPhase)i));
                Assert.AreEqual(currentBranch,
                    element2.GetBranchByTwelveGrowthPhase((TwelveGrowthPhases.TwelveGrowthPhase)i));
                currentBranch = currentBranch.Next();
            }
        }
    }
}