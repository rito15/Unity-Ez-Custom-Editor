using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-05-30 PM 3:18:00
// 작성자 : Rito

namespace Rito.EditorUtilities.Demo
{
    using RGUI = RitoEditorGUI;

    public class Demo_GrayTheme : Demo_ThemeBase
    {
        [CustomEditor(typeof(Demo_GrayTheme))]
        private class CE : UnityEditor.Editor
        {
            private Demo_GrayTheme m;

            private void OnEnable()
            {
                m = target as Demo_GrayTheme;
            }

            public override void OnInspectorGUI()
            {
                RGUI.Options
                    .SetMargins(top: 12f, left: 12f, right: 20f, bottom: 16f)
                    .ActivateRectDebugger(true)
                    .ActivateTooltipDebugger(true)
                    .Init();
                // ------------------------------------------------------
                FoldoutHeaderBox.Gray
                    .SetData(m.bool1, "Foldout Header Box", 2f, 2f)
                    .Draw(20f, 62f)
                    .HeaderSpace()
                    .Get(out m.bool1);

                if (m.bool1)
                {
                    Label.Gray
                        .SetData("Label 012345")
                        .Draw(0.01f, 0.4f);
                    SelectableLabel.Gray
                        .SetData("Selectable Label")
                        .Draw(0.4f, 0.99f).Layout();

                    IntField.Gray
                        .SetData("Int Field", m.int1)
                        .Draw(0.01f, 0.99f).Layout()
                        .Get(out m.int1);

                    IntSlider.Gray
                        .SetData("Int Slider", m.int2, 0, 10)
                        .Draw(0.01f, 0.99f).Layout()
                        .Get(out m.int2);

                    RGUI.Space(4f);
                }

                RGUI.Space(8f);

                // ------------------------------------------------------
                HeaderBox.Gray
                    .SetData("Header Box", 2f, 2f)
                    .DrawLayout(4);

                Vector3Field.Gray
                    .SetData("Vector3 Field", m.vector3)
                    .DrawLayout(0.01f, 0.99f).Get(out m.vector3);

                BoolField.Gray
                    .SetData("Bool Field", m.bool2)
                    .DrawLayout(0.01f, 0.99f).Get(out m.bool2);

                StringField.Gray
                    .SetData("String Field", m.string1, "Placeholder")
                    .DrawLayout(0.01f, 0.99f).Get(out m.string1);

                Button.Gray
                    .SetData("Button")
                    .Draw(0.01f, 0.49f);
                ToggleButton.Gray
                    .SetData("Toggle Button", m.bool3)
                    .Draw(0.5f, 0.99f).Layout(2f).Get(out m.bool3);

                RGUI.Space(12f);

                // ------------------------------------------------------
                Box.Gray
                    .SetData(2f)
                    .DrawLayout(4, 2f, 0f);

                ColorField.Gray
                    .SetData("Color Field", m.color1)
                    .DrawLayout(0.01f, 0.99f).Get(out m.color1);

                ObjectField<Material>.Gray
                    .SetData("Material Field", m.material1)
                    .DrawLayout(0.01f, 0.99f).Get(out m.material1);

                Dropdown<float>.Gray
                    .SetData("Float Dropdown", m.fList, m.fSelected)
                    .DrawLayout(0.01f, 0.99f).Get(out m.fSelected);

                HelpBox.Gray
                    .SetData("Help Box", MessageType.Warning)
                    .DrawLayout(0.01f, 0.99f);

                RGUI.Space(8f);

                // ------------------------------------------------------
                Label.Gray
                    .SetData("Label ABCD abcd")
                    .Draw(0f, 0.4f);

                SelectableLabel.Gray
                    .SetData("Selectable Label")
                    .Draw(0.4f, 1.0f).Layout();

                FloatField.Gray
                    .SetData("Float Field", m.float1)
                    .DrawLayout().Get(out m.float1);

                Vector4Field.Gray
                    .SetData("Vector4 Field", m.vector4)
                    .DrawLayout().Get(out m.vector4);

                FloatSlider.Gray
                    .SetData("Float Slider", m.float2, 0f, 1f)
                    .DrawLayout().Get(out m.float2);

                TextArea.Gray
                    .SetData(m.string2, "Text Area")
                    .DrawLayout().Get(out m.string2);

                ColorPicker.Gray
                    .SetData(m.color2)
                    .DrawLayout().Get(out m.color2);

                HelpBox.Gray
                    .SetData("Help Box", MessageType.Error)
                    .DrawLayout();

                Dropdown<string>.Gray
                    .SetData("String Dropdown", m.sArray, m.sSelected)
                    .DrawLayout().Get(out m.sSelected);

                Toggle.Gray
                    .SetData(m.bool4)
                    .DrawLayout().Get(out m.bool4);

                Button.Gray
                    .SetData("Button")
                    .Draw(0f, 0.49f);
                ToggleButton.Gray
                    .SetData("Toggle Button", m.bool5)
                    .Draw(0.5f, 1.0f).Layout().Get(out m.bool5);

                // ------------------------------------------------------
                RGUI.Finalize(this);
            }
        }
    }
}