#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 날짜 : 2021-06-04 PM 8:59:26
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    public static class LongExtensions
    {
        public static LongField DrawField(this long @this, string label, LongField longField)
        {
            return longField
                .SetData(label, @this)
                .DrawLayout();
        }
        public static LongField DrawField(this long @this, string label)
            => DrawField(@this, label, LongField.Default);


        public static LongField DrawFieldRef(ref this long @this, string label, LongField longField)
        {
            return longField
                .SetData(label, @this)
                .DrawLayout()
                .GetValue(out @this);
        }
        public static LongField DrawFieldRef(ref this long @this, string label)
            => DrawFieldRef(ref @this, label, LongField.Default);
    }
}

#endif