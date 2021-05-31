using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-05-30 AM 2:20:07
// 작성자 : Rito

namespace Rito.EditorUtilities.Samples
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
    public abstract class Sample_ThemeCustomEditorBase: UnityEditor.Editor
    {
        private Sample_ThemeBase m;

        protected abstract FoldoutHeaderBox fhBox { get; }
        protected abstract HeaderBox hBox { get; }
        protected abstract Box box { get; }
        protected abstract Label label { get; }
        protected abstract SelectableLabel sLabel { get; }

        protected abstract IntField intField { get; }
        protected abstract FloatField floatField { get; }
        protected abstract Vector3Field v3Field { get; }
        protected abstract Vector4Field v4Field { get; }
        protected abstract BoolField boolField { get; }
        protected abstract StringField stringField { get; }
        protected abstract ColorField colorField { get; }
        protected abstract ObjectField<Material> materialField { get; }

        protected abstract IntSlider intSlider { get; }
        protected abstract FloatSlider floatSlider { get; }
        protected abstract TextArea textArea { get; }
        protected abstract ColorPicker colorPicker { get; }
        protected abstract HelpBox helpBox { get; }

        protected abstract Dropdown<float> floatDropdown { get; }
        protected abstract Dropdown<string> stringDropdown { get; }
        protected abstract Button button { get; }
        protected abstract ToggleButton toggleButton { get; }
        protected abstract Toggle toggle { get; }

        protected abstract bool SetEditorBakgroundColor { get; }
        protected abstract Color EditorBackgroundColor { get; }

        protected virtual void OnEnable()
        {
            m = target as Sample_ThemeBase;
        }

        public override void OnInspectorGUI()
        {
            if (SetEditorBakgroundColor)
            {
                RGUI.Options
                    .SetEditorBackgroundColor(EditorBackgroundColor);
            }

            RGUI.Options
                .SetMargins(top: 12f, left: 12f, right: 20f, bottom: 16f)
                .ActivateRectDebugger(true)
                .ActivateTooltipDebugger(true)
                .Init();

            // ------------------------------------------------------
            fhBox
                .SetData(m.bool1, "Foldout Header Box", 2f, 2f)
                .Draw(20f, 62f)
                .HeaderSpace()
                .Get(out m.bool1);

            if (m.bool1)
            {
                label
                    .SetData("Label 012345")
                    .Draw(0.01f, 0.4f);
                sLabel
                    .SetData("Selectable Label")
                    .Draw(0.4f, 0.99f).Layout();

                intField
                    .SetData("Int Field", m.int1)
                    .Draw(0.01f, 0.99f).Layout()
                    .Get(out m.int1);

                intSlider
                    .SetData("Int Slider", m.int2, 0, 10)
                    .Draw(0.01f, 0.99f).Layout()
                    .Get(out m.int2);

                RGUI.Space(4f);
            }

            RGUI.Space(8f);

            // ------------------------------------------------------
            hBox
                .SetData("Header Box", 2f, 2f)
                .DrawLayout(4);

            v3Field
                .SetData("Vector3 Field", m.vector3)
                .DrawLayout(0.01f, 0.99f).Get(out m.vector3);

            boolField
                .SetData("Bool Field", m.bool2)
                .DrawLayout(0.01f, 0.99f).Get(out m.bool2);

            stringField
                .SetData("String Field", m.string1, "Placeholder")
                .DrawLayout(0.01f, 0.99f).Get(out m.string1);

            button
                .SetData("Button")
                .Draw(0.01f, 0.49f);
            toggleButton
                .SetData("Toggle Button", m.bool3)
                .Draw(0.5f, 0.99f).Layout(2f).Get(out m.bool3);

            RGUI.Space(12f);

            // ------------------------------------------------------
            box
                .SetData(2f)
                .DrawLayout(4, 2f, 0f);

            colorField
                .SetData("Color Field", m.color1)
                .DrawLayout(0.01f, 0.99f).Get(out m.color1);

            materialField
                .SetData("Material Field", m.material1)
                .DrawLayout(0.01f, 0.99f).Get(out m.material1);

            floatDropdown
                .SetData("Float Dropdown", m.fList, m.fSelected)
                .DrawLayout(0.01f, 0.99f).Get(out m.fSelected);

            helpBox
                .SetData("Help Box", MessageType.Warning)
                .DrawLayout(0.01f, 0.99f);

            RGUI.Space(8f);

            // ------------------------------------------------------
            label
                .SetData("Label ABCD abcd")
                .Draw(0f, 0.4f);

            sLabel
                .SetData("Selectable Label")
                .Draw(0.4f, 1.0f).Layout();

            floatField
                .SetData("Float Field", m.float1)
                .DrawLayout().Get(out m.float1);

            v4Field
                .SetData("Vector4 Field", m.vector4)
                .DrawLayout().Get(out m.vector4);

            floatSlider
                .SetData("Float Slider", m.float2, 0f, 1f)
                .DrawLayout().Get(out m.float2);

            textArea
                .SetData(m.string2, "Text Area")
                .DrawLayout().Get(out m.string2);

            colorPicker
                .SetData(m.color2)
                .DrawLayout().Get(out m.color2);

            helpBox
                .SetData("Help Box", MessageType.Error)
                .DrawLayout();

            stringDropdown
                .SetData("String Dropdown", m.sArray, m.sSelected)
                .DrawLayout().Get(out m.sSelected);

            toggle
                .SetData(m.bool4)
                .DrawLayout().Get(out m.bool4);

            button
                .SetData("Button")
                .Draw(0f, 0.49f);
            toggleButton
                .SetData("Toggle Button", m.bool5)
                .Draw(0.5f, 1.0f).Layout().Get(out m.bool5);

            RGUI.Finalize(this);
        }
    }
}