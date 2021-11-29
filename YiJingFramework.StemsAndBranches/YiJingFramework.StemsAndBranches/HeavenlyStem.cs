using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
// using YiJingFramework.Core;
// using YiJingFramework.FiveElements;

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
        /// 如以 <c>1</c> 对应甲。
        /// The index of the heavenly stem.
        /// For example, <c>1</c> represents Jia.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 初始化一个实例。
        /// Initialize an instance.
        /// </summary>
        /// <param name="index">
        /// 天干的序数。
        /// 如以 <c>1</c> 对应甲。
        /// The index of the heavenly stem.
        /// For example, <c>1</c> represents Jia.
        /// </param>
        public HeavenlyStem(int index)
        {
            this.Index = ((index - 1) % 10 + 10) % 10 + 1;
        }

        #region converting
        /// <summary>        
        /// 按照指定格式构建字符串-天干表。
        /// Build a string-stem table with the given format.
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
        public static IEnumerable<(string s, HeavenlyStem stem)> 
            BuildStringStemTable(string? format = null)
        {
            for (int i = 1; i <= 10; i++)
            {
                var stem = new HeavenlyStem(i);
                yield return (stem.ToString(format), stem);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Index switch {
                1 => "Jia",
                2 => "Yi",
                3 => "Bing",
                4 => "Ding",
                5 => "Wu",
                6 => "Ji",
                7 => "Geng",
                8 => "Xin",
                9 => "Ren",
                _ => "Gui" // 10 => "Gui"
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

            return format.ToUpperInvariant() switch {
                "G" => this.ToString(),
                "C" => this.Index switch {
                    1 => "甲",
                    2 => "乙",
                    3 => "丙",
                    4 => "丁",
                    5 => "戊",
                    6 => "己",
                    7 => "庚",
                    8 => "辛",
                    9 => "壬",
                    _ => "癸" // 10 => "癸"
                },
                "N" => this.Index.ToString(),
                _ => throw new FormatException($"The format string \"{format}\" is not supported.")
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="heavenlyStem"></param>
        public static explicit operator int(HeavenlyStem heavenlyStem)
            => heavenlyStem.Index;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static explicit operator HeavenlyStem(int value)
            => new HeavenlyStem(value);
        #endregion

        /*
        public (FiveElement, YinYang) Attributes
        {
            get
            {
                YinYang yinYang = (YinYang)(this.Index % 2);
                FiveElement element = (FiveElement)((this.Index - 1) / 2);
                return (element, yinYang);
            }
        }
        */

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