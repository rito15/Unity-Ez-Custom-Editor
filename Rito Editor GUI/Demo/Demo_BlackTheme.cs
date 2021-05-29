using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-05-30 AM 2:21:10
// 작성자 : Rito

namespace Rito.EditorUtilities.Demo
{
    using RGUI = RitoEditorGUI;

    public class Demo_BlackTheme : Demo_ThemeBase
    {
        [CustomEditor(typeof(Demo_BlackTheme))]
        private class CE : UnityEditor.Editor
        {
            private Demo_BlackTheme m;

            private void OnEnable()
            {
                m = target as Demo_BlackTheme;
            }

            public override void OnInspectorGUI()
            {
                RGUI.Options
                    .SetMargins(top: 12f, left: 12f, right: 20f, bottom: 16f)
                    .ActivateRectDebugger(true)
                    .AcrivateTooltipDebugger(true)
                    .Init();
                // ------------------------------------------------------

                LongField.Default
                    .SetData("Long FIeld", l)
                    .DrawLayout().Get(out l);

                // ------------------------------------------------------
                RGUI.Finalize(this);
            }
            double d;
            long l;
        }
    }
}