#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 날짜 : 2021-06-04 PM 8:59:26
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    public static class BoolExtensions
    {
        /***********************************************************************
        *                               Field
        ***********************************************************************/
        #region .
        public static BoolField DrawField(this bool @this, string label, BoolField boolField)
        {
            return boolField
                .SetData(label, @this)
                .DrawLayout();
        }
        public static BoolField DrawField(this bool @this, string label)
            => DrawField(@this, label, BoolField.Default);


        public static BoolField DrawFieldRef(ref this bool @this, string label, BoolField boolField)
        {
            return boolField
                .SetData(label, @this)
                .DrawLayout()
                .GetValue(out @this);
        }
        public static BoolField DrawFieldRef(ref this bool @this, string label)
            => DrawFieldRef(ref @this, label, BoolField.Default);

        #endregion
        /***********************************************************************
        *                               Toggle
        ***********************************************************************/
        #region .
        public static Toggle DrawToggle(this bool @this, Toggle toggle)
        {
            return toggle
                .SetData(@this)
                .DrawLayout();
        }
        public static Toggle DrawToggle(this bool @this)
            => DrawToggle(@this, Toggle.Default);


        public static Toggle DrawToggleRef(ref this bool @this, Toggle toggle)
        {
            return toggle
                .SetData(@this)
                .DrawLayout()
                .GetValue(out @this);
        }
        public static Toggle DrawToggleRef(ref this bool @this)
            => DrawToggleRef(ref @this, Toggle.Default);

        #endregion
    }
}

#endif