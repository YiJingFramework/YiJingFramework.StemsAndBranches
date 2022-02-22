using YiJingFramework.StemsAndBranches;

namespace ExtensionsOfStemsAndBranches
{
    public static class BranchRelationshipsExtensions
    {
        public static EarthlyBranch LiuHe(this EarthlyBranch branch)
        {
            var index = 1 - (branch.Index - 2);
            return new EarthlyBranch(index);
        }
        public static EarthlyBranch Chong(this EarthlyBranch branch)
        {
            return branch.Next(6);
        }
        public static EarthlyBranch Hai(this EarthlyBranch branch)
        {
            var index = 10 - (branch.Index - 11);
            return new EarthlyBranch(index);
        }

        /// <summary>
        /// 返回的地支刑传入的地支。
        /// The returned branch will Xing the branch passed in.
        /// </summary>
        /// <param name="branch"></param>
        /// <returns></returns>
        public static EarthlyBranch XingBy(this EarthlyBranch branch)
        {
            var index = branch.Index switch
            {
                4 => 1,
                11 => 2,
                6 => 3,
                1 => 4,
                5 => 5,
                9 => 6,
                7 => 7,
                2 => 8,
                3 => 9,
                10 => 10,
                8 => 11,
                _ => 12 // 12
            };
            return new EarthlyBranch(index);
        }

        /// <summary>
        /// 传入的地支刑返回的地支。
        /// The branch passed in will Xing the returned branch.
        /// </summary>
        /// <param name="branch"></param>
        /// <returns></returns>
        public static EarthlyBranch Xing(this EarthlyBranch branch)
        {
            var index = branch.Index switch
            {
                1 => 4,
                2 => 11,
                3 => 6,
                4 => 1,
                5 => 5,
                6 => 9,
                7 => 7,
                8 => 2,
                9 => 3,
                10 => 10,
                11 => 8,
                _ => 12 // 12
            };
            return new EarthlyBranch(index);
        }
        public static EarthlyBranch Po(this EarthlyBranch branch)
        {
            var sign = 1 - (branch.Index % 2) * 2;
            // odd: -1, even: +1
            return branch.Next(3 * sign);
        }
    }
}
