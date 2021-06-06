using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rito.EditorUtilities;
using UnityEditor;

// 날짜 : 2021-06-03 PM 3:41:01
// 작성자 : Rito

namespace Rito.EditorUtilities.Demo
{
    public class Sample_EditorWindow : RitoEditorWindow
    {
        public static void Open()
        {
            Sample_EditorWindow window = (Sample_EditorWindow)GetWindow(typeof(Sample_EditorWindow));
            window.titleContent.text = "RitoEditorWindow - Test";

            var pos = window.position;
            pos.width = 500f;
            pos.height = 290f;
            window.position = pos;

            window.Show();
        }

        protected override void OnSetup(RitoEditorGUI.Setting setting)
        {
            setting
                .SetMargins(right: 18f, bottom: 0f)
                .SetEditorBackgroundColor(RColor.Gray2)
                .SetLayoutControlHeight(20f, 4f)
                .SetLayoutControlWidth(0.01f, 0.99f)
                .ActivateRectDebugger()
                .ActivateTooltipDebugger()
                ;
        }

        private bool b1 = true;
        private float f1, f2;
        protected override void OnDrawGUI()
        {
            Box.Gold
                .SetData(2f)
                .SetTooltip("BOX")
                .DrawLayout(2);

            FloatField.Gold
                .SetData("Float Field", f1)
                .SetTooltip("Float 1")
                .DrawLayout().GetValue(out f1)
                .DrawLayout();

            Space(12f);

            FoldoutHeaderBox.Gold
                .SetData("Foldout", b1, 2f)
                .DrawLayout(5).GetValue(out b1);

            if (b1)
            {
                FloatField.Gold
                    .SetData("Float Field", f2)
                    .DrawLayout().GetValue(out f2)
                    .DrawLayout()
                    .DrawLayout()
                    .DrawLayout()
                    .DrawLayout();
            }

            Space();

        }
    }
}