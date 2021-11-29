using System;
using System.Linq;
using YiJingFramework.StemsAndBranches;

namespace UseCases
{
    class Program
    {
        static void Main(string[] args)
        {
            #region to get or convert stems and branches
            HeavenlyStem jia = new HeavenlyStem(1);
            EarthlyBranch xu = (EarthlyBranch)(-2);
            // for stems:
            // ...
            // -1: 壬 Ren *
            // 0: 癸 Gui *
            // 1: 甲 Jia *
            // 2: 乙 Yi *
            // 3: 丙 Bing *
            // 4: 丁 Ding *
            // 5: 戊 Wu *
            // 6: 己 Ji *
            // 7: 庚 Geng *
            // 8: 辛 Xin *
            // 9: 壬 Ren *
            // 10: 癸 Gui *
            // 11: 甲 Jia *
            // 12: 乙 Yi *
            // ...

            // for branches:
            // ...
            // -1: 戌 Xu *
            // 0: 亥 Hai *
            // 1: 子 Zi *
            // 2: 丑 Chou *
            // 3: 寅 Yin *
            // 4: 卯 Mao *
            // 5: 辰 Chen *
            // 6: 巳 Si *
            // 7: 午 Wu *
            // 8: 未 Wei *
            // 9: 申 Shen *
            // 10: 酉 You *
            // 11: 戌 Xu *
            // 12: 亥 Hai *
            // 13: 子 Zi *
            // 14: 丑 Chou *
            // ...

            Console.WriteLine("Sexagenary Cycle:");
            for (int i = 1; i <= 60; i++)
            {
                HeavenlyStem stem = new HeavenlyStem(i);
                EarthlyBranch branch = new EarthlyBranch(i);
                Console.WriteLine($"{i:00}: {stem.ToString("C")}{branch:C} ({stem.ToString()} {branch})");
            }
            Console.WriteLine();
            // Outputs: Sexagenary Cycle:
            // 01: 甲子 (Jia Zi)
            // 02: 乙丑 (Yi Chou)
            // 03: 丙寅 (Bing Yin)
            // 04: 丁卯 (Ding Mao)
            // 05: 戊辰 (Wu Chen)
            // 06: 己巳 (Ji Si)
            // 07: 庚午 (Geng Wu)
            // 08: 辛未 (Xin Wei)
            // 09: 壬申 (Ren Shen)
            // 10: 癸酉 (Gui You)
            // 11: 甲戌 (Jia Xu)
            // 12: 乙亥 (Yi Hai)
            // 13: 丙子 (Bing Zi)
            // 14: 丁丑 (Ding Chou)
            // 15: 戊寅 (Wu Yin)
            // 16: 己卯 (Ji Mao)
            // 17: 庚辰 (Geng Chen)
            // 18: 辛巳 (Xin Si)
            // 19: 壬午 (Ren Wu)
            // 20: 癸未 (Gui Wei)
            // 21: 甲申 (Jia Shen)
            // 22: 乙酉 (Yi You)
            // 23: 丙戌 (Bing Xu)
            // 24: 丁亥 (Ding Hai)
            // 25: 戊子 (Wu Zi)
            // 26: 己丑 (Ji Chou)
            // 27: 庚寅 (Geng Yin)
            // 28: 辛卯 (Xin Mao)
            // 29: 壬辰 (Ren Chen)
            // 30: 癸巳 (Gui Si)
            // 31: 甲午 (Jia Wu)
            // 32: 乙未 (Yi Wei)
            // 33: 丙申 (Bing Shen)
            // 34: 丁酉 (Ding You)
            // 35: 戊戌 (Wu Xu)
            // 36: 己亥 (Ji Hai)
            // 37: 庚子 (Geng Zi)
            // 38: 辛丑 (Xin Chou)
            // 39: 壬寅 (Ren Yin)
            // 40: 癸卯 (Gui Mao)
            // 41: 甲辰 (Jia Chen)
            // 42: 乙巳 (Yi Si)
            // 43: 丙午 (Bing Wu)
            // 44: 丁未 (Ding Wei)
            // 45: 戊申 (Wu Shen)
            // 46: 己酉 (Ji You)
            // 47: 庚戌 (Geng Xu)
            // 48: 辛亥 (Xin Hai)
            // 49: 壬子 (Ren Zi)
            // 50: 癸丑 (Gui Chou)
            // 51: 甲寅 (Jia Yin)
            // 52: 乙卯 (Yi Mao)
            // 53: 丙辰 (Bing Chen)
            // 54: 丁巳 (Ding Si)
            // 55: 戊午 (Wu Wu)
            // 56: 己未 (Ji Wei)
            // 57: 庚申 (Geng Shen)
            // 58: 辛酉 (Xin You)
            // 59: 壬戌 (Ren Xu)
            // 60: 癸亥 (Gui Hai)
            #endregion

            #region to convert from string to stems or branches
            var stemTableInChinese = HeavenlyStem.BuildStringStemTable("C");
            var dictionary = stemTableInChinese.ToDictionary(
                item => item.s, item => item.stem);

            var stemTableInPhoneticAlphabets = HeavenlyStem.BuildStringStemTable("G");
            foreach (var (s, stem) in stemTableInPhoneticAlphabets)
                dictionary.Add(s, stem);

            string stringToSearch = "甲";
            Console.WriteLine($"This is {dictionary[stringToSearch]}!");
            string stringToSearch2 = "Yi";
            Console.WriteLine($"这是{dictionary[stringToSearch2]:C}！");
            Console.WriteLine();
            // Outputs: This is Jia!
            // 这是乙！
            #endregion
        }
    }
}