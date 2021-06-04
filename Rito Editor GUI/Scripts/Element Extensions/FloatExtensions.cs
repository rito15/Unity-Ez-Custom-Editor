#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 날짜 : 2021-06-04 PM 8:59:26
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    public static class FloatExtensions
    {
        /***********************************************************************
        *                               Field
        ***********************************************************************/
        #region .
        public static FloatField DrawField(this float @this, string label, FloatField floatField)
        {
            return floatField
                .SetData(label, @this)
                .DrawLayout();
        }
        public static FloatField DrawField(this float @this, string label)
            => DrawField(@this, label, FloatField.Default);
        

        public static FloatField DrawFieldRef(ref this float @this, string label, FloatField floatField)
        {
            return floatField
                .SetData(label, @this)
                .DrawLayout()
                .GetValue(out @this);
        }
        public static FloatField DrawFieldRef(ref this float @this, string label)
            => DrawFieldRef(ref @this, label, FloatField.Default);

        #endregion
        /***********************************************************************
        *                               Slider
        ***********************************************************************/
        #region .
        public static FloatSlider DrawSlider(this float @this, string label, float min, float max, FloatSlider floatSlider)
        {
            return floatSlider
                .SetData(label, @this, min, max)
                .DrawLayout();
        }
        public static FloatSlider DrawSlider(this float @this, string label, float min, float max)
            => DrawSlider(@this, label, min, max, FloatSlider.Default);

        
        public static FloatSlider DrawSliderRef(ref this float @this, string label, float min, float max, FloatSlider floatSlider)
        {
            return floatSlider
                .SetData(label, @this, min, max)
                .DrawLayout()
                .GetValue(out @this);
        }
        public static FloatSlider DrawSliderRef(ref this float @this, string label, float min, float max)
            => DrawSliderRef(ref @this, label, min, max, FloatSlider.Default);

        #endregion
    }
}

#endif