#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 날짜 : 2021-06-04 PM 8:59:26
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    public static class EnumExtensions
    {
        public static EnumDropdown<T> DrawDropdown<T>(this T @this, string label, EnumDropdown<T> enumDropdown) where T : Enum
        {
            return enumDropdown
                .SetData(label, @this)
                .DrawLayout();
        }
        public static EnumDropdown<T> DrawDropdown<T>(this T @this, string label) where T : Enum
            => DrawDropdown(@this, label, EnumDropdown<T>.Default);

        public static EnumFlagDropdown<T> DrawFlagDropdown<T>(this T @this, string label, EnumFlagDropdown<T> enumDropdown) where T : Enum
        {
            return enumDropdown
                .SetData(label, @this)
                .DrawLayout();
        }
        public static EnumFlagDropdown<T> DrawFlagDropdown<T>(this T @this, string label) where T : Enum
            => DrawFlagDropdown(@this, label, EnumFlagDropdown<T>.Default);
    }
}

#endif