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
    public class Sample_Green : Sample_ThemeBase
    {
        [CustomEditor(typeof(Sample_Green))]
        private class CE : SampleCustomEditorBase
        {
            protected override bool SetEditorBakgroundColor { get; } = false;

            protected override Color EditorBackgroundColor { get; } = default;

            protected override FoldoutHeaderBox fhBox { get; } = FoldoutHeaderBox.Green;

            protected override HeaderBox hBox { get; } = HeaderBox.Green;

            protected override Box box { get; } = Box.Green;

            protected override Label label { get; } = Label.Green;

            protected override SelectableLabel sLabel { get; } = SelectableLabel.Green;

            protected override IntField intField { get; } = IntField.Green;

            protected override FloatField floatField { get; } = FloatField.Green;

            protected override Vector3Field v3Field { get; } = Vector3Field.Green;

            protected override Vector4Field v4Field { get; } = Vector4Field.Green;

            protected override BoolField boolField { get; } = BoolField.Green;

            protected override StringField stringField { get; } = StringField.Green;

            protected override ColorField colorField { get; } = ColorField.Green;

            protected override ObjectField<Material> materialField { get; } = ObjectField<Material>.Green;

            protected override IntSlider intSlider { get; } = IntSlider.Green;

            protected override FloatSlider floatSlider { get; } = FloatSlider.Green;

            protected override TextArea textArea { get; } = TextArea.Green;

            protected override ColorPicker colorPicker { get; } = ColorPicker.Green;

            protected override HelpBox helpBox { get; } = HelpBox.Green;

            protected override Dropdown<float> floatDropdown { get; } = Dropdown<float>.Green;

            protected override Dropdown<string> stringDropdown { get; } = Dropdown<string>.Green;

            protected override Button button { get; } = Button.Green;

            protected override ToggleButton toggleButton { get; } = ToggleButton.Green;

            protected override Toggle toggle { get; } = Toggle.Green;
        }
    }
}

#endif