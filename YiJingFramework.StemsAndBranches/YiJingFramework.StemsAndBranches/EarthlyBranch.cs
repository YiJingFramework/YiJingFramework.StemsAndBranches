using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace YiJingFramework.StemsAndBranches
{
    /// <summary>
    /// 地支。
    /// A heavenly stem.
    /// </summary>
    public struct EarthlyBranch : IComparable<EarthlyBranch>, IEquatable<EarthlyBranch>, IFormattable
    {
        /// <summary>
        /// 地支的序数。
        /// 如以 <c>0</c> 对应子。
        /// The index of the heavenly stem.
        /// For example, <c>0</c> represents Zi.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 初始化一个实例。
        /// Initialize an instance.
        /// </summary>
        /// <param name="index">
        /// 地支的序数。
        /// 如以 <c>0</c> 对应子。
        /// The index of the heavenly stem.
        /// For example, <c>0</c> represents Zi.
        /// </param>
        public EarthlyBranch(int index)
        {
            this.Index = (index % 12 + 12) % 12;
        }

        #region converting
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Index switch {
                0 => "Zi",
                1 => "Chou",
                2 => "Yin",
                3 => "Mao",
                4 => "Chen",
                5 => "Si",
                6 => "Wu",
                7 => "Wei",
                8 => "Shen",
                9 => "You",
                10 => "Xu",
                _ => "Hai" // 11 => "Hai"
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
                    0 => "子",
                    1 => "丑",
                    2 => "寅",
                    3 => "卯",
                    4 => "辰",
                    5 => "巳",
                    6 => "午",
                    7 => "未",
                    8 => "申",
                    9 => "酉",
                    10 => "戌",
                    _ => "亥" // 11 => "亥"
                },
                "N" => this.Index.ToString(),
                _ => throw new FormatException($"The format string \"{format}\" is not supported.")
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="EarthlyBranch"></param>
        public static explicit operator int(EarthlyBranch EarthlyBranch)
            => EarthlyBranch.Index;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static explicit operator EarthlyBranch(int value)
            => new EarthlyBranch(value);
        #endregion

        #region comparing
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(EarthlyBranch other)
        {
            return this.Index.CompareTo(other.Index);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(EarthlyBranch other)
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
            if (obj is not EarthlyBranch other)
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
        public static bool operator ==(EarthlyBranch left, EarthlyBranch right)
            => left.Index == right.Index;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(EarthlyBranch left, EarthlyBranch right)
            => left.Index != right.Index;
        #endregion
    }
}
