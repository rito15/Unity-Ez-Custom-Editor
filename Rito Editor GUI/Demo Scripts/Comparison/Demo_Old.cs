#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-06-01 AM 2:14:44
// 작성자 : Rito

namespace Rito.EditorUtilities.Demo
{
    public class Demo_Old : MonoBehaviour
    {
        [CustomEditor(typeof(Demo_Old))]
        private class CE : UnityEditor.Editor
        {
            private bool foldout = true;

            public override void OnInspectorGUI()
            {
                RitoEditorGUI.Settings
                    .SetMargins(top: 48f, bottom: 46f)
                    .SetLayoutControlXPositions(0.01f, 0.985f)
                    .ActivateRectDebugger()
                    .ActivateTooltipDebugger()
                    .Init();

                FoldoutHeaderBox.Brown
                    .SetData("Foldout Header Box", foldout, 2f)
                    .DrawLayout(2)
                    .GetValue(out foldout);

                if (foldout)
                {
                    IntField.Brown
                        .SetData("Int Field", 123)
                        .DrawLayout();

                    FloatField.Brown
                        .SetData("Float Field", 123f)
                        .DrawLayout();
                }

                RitoEditorGUI.Finalize(this);
            }
        }
    }
}

#endif