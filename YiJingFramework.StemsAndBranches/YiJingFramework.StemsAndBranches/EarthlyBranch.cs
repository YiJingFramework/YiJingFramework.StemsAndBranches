using System;
using System.Collections.Generic;

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
        /// 如以 <c>1</c> 对应子。
        /// The index of the heavenly stem.
        /// For example, <c>1</c> represents Zi.
        /// </summary>
        public int Index { get; }

        /// <summary>
        /// 初始化一个实例。
        /// Initialize an instance.
        /// </summary>
        /// <param name="index">
        /// 地支的序数。
        /// 如以 <c>1</c> 对应子。
        /// The index of the heavenly stem.
        /// For example, <c>1</c> represents Zi.
        /// </param>
        public EarthlyBranch(int index)
        {
            this.Index = ((index - 1) % 12 + 12) % 12 + 1;
        }

        #region converting
        /// <summary>        
        /// 按照指定格式构建字符串-地支表。
        /// Build a string-branch table with the given format.
        /// </summary>
        /// <param name="format">
        /// 要使用的格式。
        /// The format to be used.
        /// 参见 <seealso cref="ToString(string?, IFormatProvider?)"/> 。
        /// See <seealso cref="ToString(string?, IFormatProvider?)"/>.
        /// </param>
        /// <returns>
        /// 结果。
        /// The result.
        /// </returns>
        /// <exception cref="FormatException">
        /// 给出的格式化字符串不受支持。
        /// The given format is not supported.
        /// </exception>
        public static IEnumerable<(string s, EarthlyBranch branch)>
            BuildStringBranchTable(string? format = null)
        {
            for (int i = 1; i <= 12; i++)
            {
                var branch = new EarthlyBranch(i);
                yield return (branch.ToString(format), branch);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Index switch
            {
                1 => "Zi",
                2 => "Chou",
                3 => "Yin",
                4 => "Mao",
                5 => "Chen",
                6 => "Si",
                7 => "Wu",
                8 => "Wei",
                9 => "Shen",
                10 => "You",
                11 => "Xu",
                _ => "Hai" // 12 => "Hai"
            };
        }

        /// <summary>
        /// 按照指定格式转换为字符串。
        /// Convert to a string with the given format.
        /// </summary>
        /// <param name="format">
        /// 要使用的格式。
        /// The format to be used.
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

            return format.ToUpperInvariant() switch
            {
                "G" => this.ToString(),
                "C" => this.Index switch
                {
                    1 => "子",
                    2 => "丑",
                    3 => "寅",
                    4 => "卯",
                    5 => "辰",
                    6 => "巳",
                    7 => "午",
                    8 => "未",
                    9 => "申",
                    10 => "酉",
                    11 => "戌",
                    _ => "亥" // 12 => "亥"
                },
                "N" => this.Index.ToString(),
                _ => throw new FormatException($"The format string \"{format}\" is not supported.")
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="earthlyBranch"></param>
        public static explicit operator int(EarthlyBranch earthlyBranch)
            => earthlyBranch.Index;

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