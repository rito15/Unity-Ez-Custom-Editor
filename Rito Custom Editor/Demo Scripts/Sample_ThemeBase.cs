#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-05-30 AM 2:20:07
// 작성자 : Rito

namespace Rito.EditorUtilities.Demo
{
    using RGUI = RitoEditorGUI;

    public abstract class Sample_ThemeBase : MonoBehaviour
    {
        public int int1, int2, int3;
        public float float1, float2;
        public bool bool1, bool2, bool3, bool4, bool5;
        public string string1, string2;
        public Material material1;
        public Transform transform1;
        public Color color1, color2;
        public Vector3 vector3;
        public Vector4 vector4;

        public List<float> fList = new List<float> { 0.123f, 456.789f, 12345f, 67890f };
        public int fSelected;

        public string[] sArray = { "String 0", "String 1", "String 2" };
        public int sSelected;

    }
    public abstract class SampleCustomEditorBase: RitoEditor
    {
        private Sample_ThemeBase m;


        protected abstract bool SetEditorBakgroundColor { get; }
        protected abstract Color EditorBackgroundColor { get; }
        protected abstract EColor DefaultColorTheme { get; }

        protected virtual void OnEnable()
        {
            m = target as Sample_ThemeBase;
        }

        protected override void OnSetup(RGUI.Setting setting)
        {
            if (SetEditorBakgroundColor)
            {
                setting
                    .SetEditorBackgroundColor(EditorBackgroundColor);
            }

            setting
                //.SetMargins(top: 12f, left: 12f, right: 20f, bottom: 16f)
                .ActivateRectDebugger()
                .ActivateTooltipDebugger()
                .SetDefaultColorTheme(DefaultColorTheme)
                ;
        }

        protected override void OnDrawInspector()
        {
            FoldoutHeaderBox.Default
                .SetData(m.bool1, "Foldout Header Box", 2f, 2f)
                .Draw(20f, 62f)
                .Layout()
                .GetValue(out m.bool1);

            if (m.bool1)
            {
                Label.Default
                    .SetData("Label 012345")
                    .Draw(0.01f, 0.4f);
                SelectableLabel.Default
                    .SetData("Selectable Label")
                    .Draw(0.4f, 0.99f).Layout();

                IntField.Default
                    .SetData("Int Field", m.int1)
                    .Draw(0.01f, 0.99f).Layout()
                    .GetValue(out m.int1);

                IntSlider.Default
                    .SetData("Int Slider", m.int2, 0, 10)
                    .Draw(0.01f, 0.99f).Layout()
                    .GetValue(out m.int2);
            }

            RGUI.Space(10f);

            // ------------------------------------------------------
            HeaderBox.Default
                .SetData("Header Box", 2f, 2f)
                .Draw(20f, 82f).Layout();
                //.DrawLayout(4);

            Vector3Field.Default
                .SetData("Vector3 Field", m.vector3)
                .DrawLayout(0.01f, 0.99f).GetValue(out m.vector3);

            BoolField.Default
                .SetData("Bool Field", m.bool2)
                .DrawLayout(0.01f, 0.99f).GetValue(out m.bool2);

            StringField.Default
                .SetData("String Field", m.string1, "Placeholder")
                .DrawLayout(0.01f, 0.99f).GetValue(out m.string1);

            Button.Default
                .SetData("Button")
                .Draw(0.01f, 0.49f);
            ToggleButton.Default
                .SetData("Toggle Button", m.bool3)
                .Draw(0.5f, 0.99f).Layout().GetValue(out m.bool3);

            RGUI.Space(12f);

            // ------------------------------------------------------
            Box.Default
                .SetData(2f)
                .DrawLayout(4, 2f, 0f);

            ColorField.Default
                .SetData("Color Field", m.color1)
                .DrawLayout(0.01f, 0.99f).GetValue(out m.color1);

            ObjectField<Material>.Default
                .SetData("Material Field", m.material1)
                .DrawLayout(0.01f, 0.99f).GetValue(out m.material1);

            Dropdown<float>.Default
                .SetData("Float Dropdown", m.fList, m.fSelected)
                .DrawLayout(0.01f, 0.99f).GetValue(out m.fSelected);

            HelpBox.Default
                .SetData("Help Box", MessageType.Warning)
                .DrawLayout(0.01f, 0.99f);

            RGUI.Space(8f);

            // ------------------------------------------------------
            Label.Default
                .SetData("Label ABCD abcd")
                .Draw(0f, 0.4f);

            EditableLabel.Default
                .SetData("Editable Label")
                .Draw(0.4f, 1.0f).Layout();

            FloatField.Default
                .SetData("Float Field", m.float1)
                .DrawLayout().GetValue(out m.float1);

            Vector4Field.Default
                .SetData("Vector4 Field", m.vector4)
                .DrawLayout().GetValue(out m.vector4);

            FloatSlider.Default
                .SetData("Float Slider", m.float2, 0f, 1f)
                .DrawLayout().GetValue(out m.float2);

            TextArea.Default
                .SetData(m.string2, "Text Area")
                .DrawLayout().GetValue(out m.string2);

            ColorPicker.Default
                .SetData(m.color2)
                .DrawLayout().GetValue(out m.color2);

            HelpBox.Default
                .SetData("Help Box", MessageType.Error)
                .DrawLayout();

            Dropdown<string>.Default
                .SetData("String Dropdown", m.sArray, m.sSelected)
                .DrawLayout().GetValue(out m.sSelected);

            Toggle.Default
                .SetData(m.bool4)
                .DrawLayout().GetValue(out m.bool4);

            Button.Default
                .SetData("Button")
                .Draw(0f, 0.49f);
            ToggleButton.Default
                .SetData("Toggle Button", m.bool5)
                .Draw(0.5f, 1.0f).Layout().GetValue(out m.bool5);
        }
    }
}
#endif