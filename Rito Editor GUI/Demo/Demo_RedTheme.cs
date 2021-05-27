using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-05-27 AM 2:31:20
// 작성자 : Rito

namespace Rito.EditorUtilities.Demo
{
    public class Demo_RedTheme : MonoBehaviour
    {
        [SerializeField]
        private Color[] colors = new Color[100];

        [CustomEditor(typeof(Demo_RedTheme))]
        private class CE : UnityEditor.Editor
        {
            private Color[] rColors = new Color[]
            {
                RColor.Dark  .Gold,
                RColor.Dim   .Gold,
                RColor.Normal.Gold,
                RColor.Soft  .Gold,
                RColor.Light .Gold,
                RColor.Bright.Gold, 
            };
            private string[] labels =
            {
                "Dim", "Dark", "Normal",
                "Soft", "Light", "Bright"
            };

            private Demo_RedTheme m;
            private void OnEnable()
            {
                m = target as Demo_RedTheme;
            }

            public override void OnInspectorGUI()
            {
                RitoEditorGUI.Options
                    .SetMargins(top: 8f, left:8f, right:20f)
                    .DebugOn(true)
                    .Init();

                for (int i = 0; i < rColors.Length; i++)
                {
                    Label.Default
                        .SetTextColor(m.colors[i])
                        .SetData("AbCDabcd0123")
                        .Draw(0.0f, 0.5f, 0f, 20f);

                    Label.Default
                        .SetTextColor(rColors[i])
                        .SetData("AbCDabcd0123")
                        .Draw(0.5f, 1.0f, 0f, 20f);

                    RitoEditorGUI.Space(24f);
                }

                RitoEditorGUI.Finalize(this);

                Undo.RecordObject(m, "");
                for (int i = 0; i < rColors.Length; i++)
                {
                    m.colors[i] = EditorGUILayout.ColorField(labels[i], m.colors[i]);
                }
            }
        }
    }
}