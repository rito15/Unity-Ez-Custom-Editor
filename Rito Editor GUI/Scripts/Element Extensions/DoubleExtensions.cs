#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 날짜 : 2021-06-04 PM 8:59:26
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    public static class DoubleExtensions
    {
        /***********************************************************************
        *                               Field
        ***********************************************************************/
        #region .
        public static DoubleField DrawField(this double @this, string label, DoubleField doubleField)
        {
            return doubleField
                .SetData(label, @this)
                .DrawLayout();
        }
        public static DoubleField DrawField(this double @this, string label)
            => DrawField(@this, label, DoubleField.Default);
        

        public static DoubleField DrawFieldRef(ref this double @this, string label, DoubleField doubleField)
        {
            return doubleField
                .SetData(label, @this)
                .DrawLayout()
                .GetValue(out @this);
        }
        public static DoubleField DrawFieldRef(ref this double @this, string label)
            => DrawFieldRef(ref @this, label, DoubleField.Default);

        #endregion
        /***********************************************************************
        *                               Slider
        ***********************************************************************/
        #region .
        public static DoubleSlider DrawSlider(this double @this, string label, double min, double max, DoubleSlider doubleSlider)
        {
            return doubleSlider
                .SetData(label, @this, min, max)
                .DrawLayout();
        }
        public static DoubleSlider DrawSlider(this double @this, string label, double min, double max)
            => DrawSlider(@this, label, min, max, DoubleSlider.Default);

        
        public static DoubleSlider DrawSliderRef(ref this double @this, string label, double min, double max, DoubleSlider doubleSlider)
        {
            return doubleSlider
                .SetData(label, @this, min, max)
                .DrawLayout()
                .GetValue(out @this);
        }
        public static DoubleSlider DrawSliderRef(ref this double @this, string label, double min, double max)
            => DrawSliderRef(ref @this, label, min, max, DoubleSlider.Default);

        #endregion
    }
}

#endif