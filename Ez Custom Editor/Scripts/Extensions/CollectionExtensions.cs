#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 날짜 : 2021-06-09 AM 12:29:25
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    public static class CollectionExtensions
    {
        /***********************************************************************
        *                               Dropdown<T>
        ***********************************************************************/
        #region 

        public static Dropdown<T> DrawDropdown<T>(this T[] @this, string label, int selectedIndex, Dropdown<T> dropdown)
        {
            return dropdown
                .SetData(label, @this, selectedIndex)
                .DrawLayout();
        }
        public static Dropdown<T> DrawDropdown<T>(this T[] @this, string label, int selectedIndex)
            => DrawDropdown(@this, label, selectedIndex, Dropdown<T>.Default);

        public static Dropdown<T> DrawDropdown<T>(this IList<T> @this, string label, int selectedIndex, Dropdown<T> dropdown)
        {
            return dropdown
                .SetData(label, @this, selectedIndex)
                .DrawLayout();
        }
        public static Dropdown<T> DrawDropdown<T>(this IList<T> @this, string label, int selectedIndex)
            => DrawDropdown(@this, label, selectedIndex, Dropdown<T>.Default);

        #endregion
    }
}

#endif