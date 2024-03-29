﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text.Json.Serialization;
using YiJingFramework.Serialization;

namespace YiJingFramework.StemsAndBranches
{
    /// <summary>
    /// 地支。
    /// A heavenly stem.
    /// </summary>
    [JsonConverter(typeof(JsonConverterOfStringConvertibleForJson<EarthlyBranch>))]
    public readonly struct EarthlyBranch :
        IComparable<EarthlyBranch>, IEquatable<EarthlyBranch>, IFormattable,
        IParsable<EarthlyBranch>, IEqualityOperators<EarthlyBranch, EarthlyBranch, bool>,
        IStringConvertibleForJson<EarthlyBranch>,
        IAdditionOperators<EarthlyBranch, int, EarthlyBranch>,
        ISubtractionOperators<EarthlyBranch, int, EarthlyBranch>
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

        /// <summary>
        /// 获取此地支的前第 <paramref name="n"/> 个地支。
        /// Get the <paramref name="n"/>th branch in front of this instance.
        /// 前，如子前为丑。
        /// Chou is thought to be in front of Zi for example.
        /// </summary>
        /// <param name="n">
        /// 数字 <paramref name="n"/> 。
        /// The number <paramref name="n"/>.
        /// 可以小于零以表示另一个方向。
        /// It could be smaller than zero which means the other direction.
        /// </param>
        /// <returns>
        /// 指定地支。
        /// The branch.
        /// </returns>
        public EarthlyBranch Next(int n = 1)
        {
            return new EarthlyBranch(this.Index + n);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static EarthlyBranch operator +(EarthlyBranch left, int right)
        {
            return left.Next(right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static EarthlyBranch operator -(EarthlyBranch left, int right)
        {
            right = right % 12;
            return left.Next(-right);
        }

        #region converting
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
        /// 从字符串转换。
        /// Convert from a string.
        /// </summary>
        /// <param name="s">
        /// 字符串。
        /// The string.
        /// </param>
        /// <returns>
        /// 结果。
        /// The result.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="s"/> 是 <c>null</c> 。
        /// <paramref name="s"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="FormatException">
        /// 传入字符串的格式不受支持。
        /// The input string was not in the supported format.
        /// </exception>
        public static EarthlyBranch Parse(string s)
        {
            ArgumentNullException.ThrowIfNull(s);

            if (TryParse(s, out var result))
                return result;
            throw new FormatException($"Cannot parse \"{s}\" as {nameof(EarthlyBranch)}.");
        }

        /// <summary>
        /// 从字符串转换。
        /// Convert from a string.
        /// </summary>
        /// <param name="s">
        /// 字符串。
        /// The string.
        /// </param>
        /// <param name="result">
        /// 结果。
        /// The result.
        /// </param>
        /// <returns>
        /// 一个指示转换成功与否的值。
        /// A value indicates whether it has been successfully converted or not.
        /// </returns>
        public static bool TryParse(
            [NotNullWhen(true)] string? s,
            [MaybeNullWhen(false)] out EarthlyBranch result)
        {
            switch (s?.Trim()?.ToLowerInvariant())
            {
                case "zi":
                case "子":
                case "1":
                    result = new EarthlyBranch(1);
                    return true;
                case "chou":
                case "丑":
                case "2":
                    result = new EarthlyBranch(2);
                    return true;
                case "yin":
                case "寅":
                case "3":
                    result = new EarthlyBranch(3);
                    return true;
                case "mao":
                case "卯":
                case "4":
                    result = new EarthlyBranch(4);
                    return true;
                case "chen":
                case "辰":
                case "5":
                    result = new EarthlyBranch(5);
                    return true;
                case "si":
                case "巳":
                case "6":
                    result = new EarthlyBranch(6);
                    return true;
                case "wu":
                case "午":
                case "7":
                    result = new EarthlyBranch(7);
                    return true;
                case "wei":
                case "未":
                case "8":
                    result = new EarthlyBranch(8);
                    return true;
                case "shen":
                case "申":
                case "9":
                    result = new EarthlyBranch(9);
                    return true;
                case "you":
                case "酉":
                case "10":
                    result = new EarthlyBranch(10);
                    return true;
                case "xu":
                case "戌":
                case "11":
                    result = new EarthlyBranch(11);
                    return true;
                case "hai":
                case "亥":
                case "12":
                    result = new EarthlyBranch(12);
                    return true;
                default:
                    result = default;
                    return false;
            }
        }

        static EarthlyBranch IParsable<EarthlyBranch>.Parse(string s, IFormatProvider? provider)
        {
            return Parse(s);
        }

        static bool IParsable<EarthlyBranch>.TryParse(
            [NotNullWhen(true)] string? s,
            IFormatProvider? provider,
            [MaybeNullWhen(false)] out EarthlyBranch result)
        {
            return TryParse(s, out result);
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

        #region serializing
        static bool IStringConvertibleForJson<EarthlyBranch>.FromStringForJson(string s, out EarthlyBranch result)
        {
            return TryParse(s, out result);
        }

        string IStringConvertibleForJson<EarthlyBranch>.ToStringForJson()
        {
            return this.ToString();
        }
        #endregion

        #region values
        /// <summary>
        /// 子。
        /// Zi.
        /// </summary>
        public static EarthlyBranch Zi => new EarthlyBranch(1);
        /// <summary>
        /// 丑。
        /// Chou.
        /// </summary>
        public static EarthlyBranch Chou => new EarthlyBranch(2);
        /// <summary>
        /// 寅。
        /// Yin.
        /// </summary>
        public static EarthlyBranch Yin => new EarthlyBranch(3);
        /// <summary>
        /// 卯。
        /// Mao.
        /// </summary>
        public static EarthlyBranch Mao => new EarthlyBranch(4);
        /// <summary>
        /// 辰。
        /// Chen.
        /// </summary>
        public static EarthlyBranch Chen => new EarthlyBranch(5);
        /// <summary>
        /// 巳。
        /// Si.
        /// </summary>
        public static EarthlyBranch Si => new EarthlyBranch(6);
        /// <summary>
        /// 午。
        /// Wu.
        /// </summary>
        public static EarthlyBranch Wu => new EarthlyBranch(7);
        /// <summary>
        /// 未。
        /// Wei.
        /// </summary>
        public static EarthlyBranch Wei => new EarthlyBranch(8);
        /// <summary>
        /// 申。
        /// Shen.
        /// </summary>
        public static EarthlyBranch Shen => new EarthlyBranch(9);
        /// <summary>
        /// 酉。
        /// You.
        /// </summary>
        public static EarthlyBranch You => new EarthlyBranch(10);
        /// <summary>
        /// 戌。
        /// Xu.
        /// </summary>
        public static EarthlyBranch Xu => new EarthlyBranch(11);
        /// <summary>
        /// 亥。
        /// Hai.
        /// </summary>
        public static EarthlyBranch Hai => new EarthlyBranch(12);
        #endregion
    }
}