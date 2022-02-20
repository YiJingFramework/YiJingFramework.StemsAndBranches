using YiJingFramework.StemsAndBranches;

namespace ExtensionsOfStemsAndBranches
{
    public static class MengZhongJiExtension
    {
        public enum MengZhongJi
        {
            Meng = 0,
            Zhong = 1,
            Ji = 2
        }

        public static MengZhongJi JudgeMengZhongJi(this EarthlyBranch branch)
        {
            return (MengZhongJi)((branch.Index % 12) % 3);
        }
    }
}
