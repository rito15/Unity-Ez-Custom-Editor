#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-06-01 AM 2:18:13
// 작성자 : Rito

namespace Rito.EditorUtilities.Demo
{
    public class Demo_New : MonoBehaviour
    {
        public string stringValue;
        public bool foldoutValue, toggleButtonValue;

        public float[] floatArray = { 0.1f, 0.2f, 0.3f, 0.4f };
        public int floatSelected;

        [UnityEditor.CustomEditor(typeof(Demo_New))]
        private class CE : RitoEditor
        {
            private Demo_New m;
            private void OnEnable() => m = target as Demo_New;
            
            protected override void OnSetup(RitoEditorGUI.Setting setting)
            {
                setting
                    .SetMargins(bottom: 12f, right:12f)
                    //.KeepSameViewWidth()
                    //.SetEditorBackgroundColor(Color.white.SetA(0.2f))
                    .SetLayoutControlWidth(0.01f, 0.985f)
                    .ActivateRectDebugger()
                    .ActivateTooltipDebugger();
            }

            protected override void OnDrawInspector()
            {
                const float boxOutlineWidth = 2f;

                FoldoutHeaderBox.Blue
                    .SetData("Header Box", m.foldoutValue, boxOutlineWidth, 4f)
                    .DrawLayout(3, 2f)
                    //.Draw(20f, 64f).Layout()
                    .GetValue(out m.foldoutValue);

                if (m.foldoutValue)
                {
                    StringField.Violet
                        .SetData("String Field", m.stringValue, "Placeholder")
                        .DrawLayout().GetValue(out m.stringValue);

                    Dropdown<float>.Purple
                        .SetData("Float Dropdown", m.floatArray, m.floatSelected)
                        .DrawLayout().GetValue(out m.floatSelected);

                    // Button & ToggleButton
                    const float buttonRatio = 0.7f;

                    Button.Blue
                        .SetData("Button")
                        .Draw(0.01f, buttonRatio, 20f);

                    ToggleButton.Blue
                        .SetData("Toggle Button", m.toggleButtonValue)
                        .Draw(buttonRatio + 0.01f, 0.985f, 20f).Layout()
                        .GetValue(out m.toggleButtonValue);
                }

                Space(40f);

                //private bool foldout1, foldout2;

                FoldoutHeaderBox.Default
                    .SetData(foldout1, "Foldout Header Box 1", 0f)
                    .Draw(20f, 40f)
                    .GetValue(out foldout1)
                    .Space(!foldout1 ? 30f : 70f);

                FoldoutHeaderBox.Default
                    .SetData(foldout2, "Foldout Header Box 2", 2f)
                    .DrawLayout(2)
                    .GetValue(out foldout2);

                if (foldout2)
                {
                    IntField.Default
                        .SetData("Int Field", 1)
                        .DrawLayout();

                    Button.Default
                        .SetData("Button")
                        .DrawLayout();
                }


                Space(40f);
                Space(40f);
                Space(40f);
            }
            private bool foldout1, foldout2;

            private bool boolValue, toggle;
            private int intValue = 5;
            private float floatValue = 5f;
            private double doubleValue = 5.0;
            private string stringValue = "abcde";
            private string stringValue2 = "";

            private Space enumValue;

            private Color color = Color.red;

            private Vector2 vector2Value = new Vector2(1f, 2f);
            private Vector3 vector3Value = new Vector3(1f, 2f, 3f);
            private Vector4 vector4Value = new Vector4(1f, 2f, 3f, 4f);
            private Vector2Int vector2IntValue = new Vector2Int(1, 2);
            private Vector3Int vector3IntValue = new Vector3Int(1, 2, 3);

        }
        public string labelText = "Editable Label";
    }
}

#endif