using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace YiJingFramework.StemsAndBranches
{
    /// <summary>
    /// 天干。
    /// A heavenly stem.
    /// </summary>
    public struct HeavenlyStem : IComparable<HeavenlyStem>, IEquatable<HeavenlyStem>, IFormattable
    {
        /// <summary>
        /// 天干的序数。
        /// 如以 <c>0</c> 对应甲。
        /// The index of the heavenly stem.
        /// For example, <c>0</c> represents Jia.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 初始化一个实例。
        /// Initialize an instance.
        /// </summary>
        /// <param name="index">
        /// 天干的序数。
        /// 如以 <c>0</c> 对应甲。
        /// The index of the heavenly stem.
        /// For example, <c>0</c> represents Jia.
        /// </param>
        public HeavenlyStem(int index)
        {
            this.Index = (index % 10 + 10) % 10;
        }

        #region converting
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Index switch {
                0 => "Jia",
                1 => "Yi",
                2 => "Bing",
                3 => "Ding",
                4 => "Wu",
                5 => "Ji",
                6 => "Geng",
                7 => "Xin",
                8 => "Ren",
                _ => "Gui" // 9 => "Gui"
            };
        }

        /// <summary>
        /// 按照指定格式转换为字符串。
        /// Convert to a string with the given format.
        /// </summary>
        /// <param name="format">
        /// 要使用的格式。
        /// <c>"G"</c> 表示拼音字母； <c>"C"</c> 表示中文； <c>"N"</c> 表示数字。
        /// <c>"G"</c> represents the phonetic alphabets; <c>"C"</c> represents chinese characters; and <c>"N"</c> represents numbers.
        /// </param>
        /// <param name="formatProvider">
        /// 不会使用此参数。
        /// This parameter will won't be used.
        /// </param>
        /// <returns>
        /// 结果。
        /// The result.
        /// </returns>
        /// <exception cref="FormatException">
        /// 给出的格式化字符串不受支持。
        /// The given format is not supported.
        /// </exception>
        public string ToString(string? format, IFormatProvider? formatProvider = null)
        {
            if (string.IsNullOrEmpty(format))
                format = "G";

            return format.ToUpperInvariant() switch {
                "G" => this.ToString(),
                "C" => this.Index switch {
                    0 => "甲",
                    1 => "乙",
                    2 => "丙",
                    3 => "丁",
                    4 => "戊",
                    5 => "己",
                    6 => "庚",
                    7 => "辛",
                    8 => "壬",
                    _ => "癸" // 9 => "癸"
                },
                "N" => this.Index.ToString(),
                _ => throw new FormatException($"The format string \"{format}\" is not supported.")
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="HeavenlyStem"></param>
        public static explicit operator int(HeavenlyStem HeavenlyStem)
            => HeavenlyStem.Index;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static explicit operator HeavenlyStem(int value)
            => new HeavenlyStem(value);
        #endregion

        #region comparing
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(HeavenlyStem other)
        {
            return this.Index.CompareTo(other.Index);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(HeavenlyStem other)
        {
            return this.Index.Equals(other.Index);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj is not HeavenlyStem other)
                return false;
            return this.Index.Equals(other.Index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.Index.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(HeavenlyStem left, HeavenlyStem right)
            => left.Index == right.Index;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(HeavenlyStem left, HeavenlyStem right)
            => left.Index != right.Index;
        #endregion
    }
}
