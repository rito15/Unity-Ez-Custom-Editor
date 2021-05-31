#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-05-30 PM 9:24:48
// 작성자 : Rito

namespace Rito.EditorUtilities.Demo
{
    public class Sample_Violet : Sample_ThemeBase
    {
        [CustomEditor(typeof(Sample_Violet))]
        private class CE : SampleCustomEditorBase
        {
            protected override bool SetEditorBakgroundColor { get; } = false;

            protected override Color EditorBackgroundColor { get; } = default;

            protected override FoldoutHeaderBox fhBox { get; } = FoldoutHeaderBox.Violet;

            protected override HeaderBox hBox { get; } = HeaderBox.Violet;

            protected override Box box { get; } = Box.Violet;

            protected override Label label { get; } = Label.Violet;

            protected override SelectableLabel sLabel { get; } = SelectableLabel.Violet;

            protected override IntField intField { get; } = IntField.Violet;

            protected override FloatField floatField { get; } = FloatField.Violet;

            protected override Vector3Field v3Field { get; } = Vector3Field.Violet;

            protected override Vector4Field v4Field { get; } = Vector4Field.Violet;

            protected override BoolField boolField { get; } = BoolField.Violet;

            protected override StringField stringField { get; } = StringField.Violet;

            protected override ColorField colorField { get; } = ColorField.Violet;

            protected override ObjectField<Material> materialField { get; } = ObjectField<Material>.Violet;

            protected override IntSlider intSlider { get; } = IntSlider.Violet;

            protected override FloatSlider floatSlider { get; } = FloatSlider.Violet;

            protected override TextArea textArea { get; } = TextArea.Violet;

            protected override ColorPicker colorPicker { get; } = ColorPicker.Violet;

            protected override HelpBox helpBox { get; } = HelpBox.Violet;

            protected override Dropdown<float> floatDropdown { get; } = Dropdown<float>.Violet;

            protected override Dropdown<string> stringDropdown { get; } = Dropdown<string>.Violet;

            protected override Button button { get; } = Button.Violet;

            protected override ToggleButton toggleButton { get; } = ToggleButton.Violet;

            protected override Toggle toggle { get; } = Toggle.Violet;
        }
    }
}

#endif