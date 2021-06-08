#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 날짜 : 2021-06-04 PM 8:59:26
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    public static partial class ColorExtensions
    {
        /***********************************************************************
        *                               Field
        ***********************************************************************/
        #region .
        public static ColorField DrawField(this Color @this, string label, ColorField colorField)
        {
            return colorField
                .SetData(label, @this)
                .DrawLayout();
        }
        public static ColorField DrawField(this Color @this, string label)
            => DrawField(@this, label, ColorField.Default);


        public static ColorField DrawFieldRef(ref this Color @this, string label, ColorField colorField)
        {
            return colorField
                .SetData(label, @this)
                .DrawLayout()
                .GetValue(out @this);
        }
        public static ColorField DrawFieldRef(ref this Color @this, string label)
            => DrawFieldRef(ref @this, label, ColorField.Default);

        #endregion
        /***********************************************************************
        *                               ColorPicker
        ***********************************************************************/
        #region .
        public static ColorPicker DrawColorPicker(this Color @this, ColorPicker colorPicker)
        {
            return colorPicker
                .SetData(@this)
                .DrawLayout();
        }
        public static ColorPicker DrawColorPicker(this Color @this)
            => DrawColorPicker(@this, ColorPicker.Default);


        public static ColorPicker DrawColorPickerRef(ref this Color @this, ColorPicker colorPicker)
        {
            return colorPicker
                .SetData(@this)
                .DrawLayout()
                .GetValue(out @this);
        }
        public static ColorPicker DrawColorPickerRef(ref this Color @this)
            => DrawColorPickerRef(ref @this, ColorPicker.Default);

        #endregion
    }
}

#endif