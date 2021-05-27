using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-05-27 AM 2:31:20
// 작성자 : Rito

namespace Rito.EditorUtilities.Demo
{
    public class Demo_WhiteTheme : MonoBehaviour
    {
        public bool[] boolValues = new bool[100];

        [CustomEditor(typeof(Demo_WhiteTheme))]
        private class CE : UnityEditor.Editor
        {
            private Demo_WhiteTheme m;
            private void OnEnable()
            {
                m = target as Demo_WhiteTheme;
            }

            public override void OnInspectorGUI()
            {
                RitoEditorGUI.Options
                    .SetMargins(top: 12f, left: 12f, right: 20f, bottom: 8f)
                    .DebugOn(true)
                    .Init();

                int i = 0, f = 0, d = 0, b = 0;

                HeaderBox.White
                    .SetData("Header Box", 2f, 2f)
                    .Draw(0f, 1f, 0f, 20f, 40f);

                RitoEditorGUI.Space(28f);

                Button.White
                    .SetData("Button")
                    .Draw(0.02f, 0.49f, 0f, 28f);

                m.boolValues[b] = 
                ToggleButton.White
                    .SetData("Toggle Button", m.boolValues[b++])
                    .Draw(0.51f, 0.98f, 0f, 28f);

                RitoEditorGUI.Space(40f);

                RitoEditorGUI.Finalize(this);
            }
        }
    }
}