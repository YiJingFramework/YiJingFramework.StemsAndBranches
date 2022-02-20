using YiJingFramework.FiveElements;
using YiJingFramework.StemsAndBranches;

namespace ExtensionsOfStemsAndBranches
{
    public static class TwelveGrowthPhasesExtension
    {
        public enum TwelveGrowthPhase
        {
            ZhangSheng = 0,
            MuYu = 1,
            GuanDai = 2,
            LinGuan = 3,
            DiWang = 4,
            Shuai = 5,
            Bing = 6,
            Si = 7,
            Mu = 8,
            Jue = 9,
            Tai = 10,
            Yang = 11
        }

        /// <summary>
        /// <see cref="TwelveGrowthPhase.ZhangSheng"/> of the elements
        /// </summary>
        private static readonly IReadOnlyDictionary<FiveElement, EarthlyBranch> zhangShengOfElements =
            new Dictionary<FiveElement, EarthlyBranch>()
            {
                { FiveElement.Wood, new EarthlyBranch(12) },
                { FiveElement.Fire, new EarthlyBranch(3) },
                { FiveElement.Metal, new EarthlyBranch(6) },
                { FiveElement.Water, new EarthlyBranch(9) },
                { FiveElement.Earth, new EarthlyBranch(9) }
            };

        public static TwelveGrowthPhase GetTwelveGrowthPhase(
            this FiveElement fiveElement, EarthlyBranch branch)
        {
            var difference = branch.Index - zhangShengOfElements[fiveElement].Index;
            return (TwelveGrowthPhase)((difference + 12) % 12);
        }

        public static EarthlyBranch GetBranchByTwelveGrowthPhase(
            this FiveElement me, TwelveGrowthPhase relationship)
        {
            return zhangShengOfElements[me].Next((int)relationship);
        }
    }
}