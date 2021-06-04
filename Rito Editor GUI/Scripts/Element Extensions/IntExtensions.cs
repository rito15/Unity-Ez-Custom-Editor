#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 날짜 : 2021-06-04 PM 8:59:26
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    public static class IntExtensions
    {
        /***********************************************************************
        *                               Field
        ***********************************************************************/
        #region .
        public static IntField DrawField(this int @this, string label, IntField intField)
        {
            return intField
                .SetData(label, @this)
                .DrawLayout();
        }
        public static IntField DrawField(this int @this, string label)
            => DrawField(@this, label, IntField.Default);


        public static IntField DrawFieldRef(ref this int @this, string label, IntField intField)
        {
            return intField
                .SetData(label, @this)
                .DrawLayout()
                .GetValue(out @this);
        }
        public static IntField DrawFieldRef(ref this int @this, string label)
            => DrawFieldRef(ref @this, label, IntField.Default);

        #endregion
        /***********************************************************************
        *                               Slider
        ***********************************************************************/
        #region .
        public static IntSlider DrawSlider(this int @this, string label, int min, int max, IntSlider intSlider)
        {
            return intSlider
                .SetData(label, @this, min, max)
                .DrawLayout();
        }
        public static IntSlider DrawSlider(this int @this, string label, int min, int max)
            => DrawSlider(@this, label, min, max, IntSlider.Default);


        public static IntSlider DrawSliderRef(ref this int @this, string label, int min, int max, IntSlider intSlider)
        {
            return intSlider
                .SetData(label, @this, min, max)
                .DrawLayout()
                .GetValue(out @this);
        }
        public static IntSlider DrawSliderRef(ref this int @this, string label, int min, int max)
            => DrawSliderRef(ref @this, label, min, max, IntSlider.Default);

        #endregion
    }
}

#endif