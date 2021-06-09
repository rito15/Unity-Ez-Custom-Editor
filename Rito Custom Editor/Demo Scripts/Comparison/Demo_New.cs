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
        public bool foldout, toggleButtonPressed;

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
                    .SetDefaultColorTheme(EColor.Blue)
                    .SetLayoutControlWidth(0.01f, 0.985f)
                    //.ActivateRectDebugger()
                    //.ActivateTooltipDebugger()
                    ;
            }

            protected override void OnDrawInspector()
            {
                FoldoutHeaderBox.Blue
                    .SetData("Foldout Header Box", m.foldout, 2f, 4f)
                    .DrawLayout(3, 2f)
                    .GetValue(out m.foldout);

                if (m.foldout)
                {
                    StringField.Blue
                        .SetData("String Field", m.stringValue)
                        .DrawLayout().GetValue(out m.stringValue);

                    Dropdown<float>.Blue
                        .SetData("Float Dropdown", m.floatArray, m.floatSelected)
                        .DrawLayout().GetValue(out m.floatSelected);

                    const float buttonPart = 0.7f;

                    Button.Blue
                        .SetData("Button")
                        .Draw(0.01f, buttonPart, 20f);

                    ToggleButton.Blue
                        .SetData("Toggle Button", m.toggleButtonPressed)
                        .Draw(buttonPart + 0.01f, 0.985f, 20f).Layout()
                        .GetValue(out m.toggleButtonPressed);
                } 
            }
        }
    }
}

#endif