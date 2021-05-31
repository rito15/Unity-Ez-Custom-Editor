using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-05-30 PM 9:24:48
// 작성자 : Rito

namespace Rito.EditorUtilities.Samples
{
    public class Sample_Orange : Sample_ThemeBase
    {
        [CustomEditor(typeof(Sample_Orange))]
        private class CE : SampleCustomEditorBase
        {
            protected override bool SetEditorBakgroundColor { get; } = false;

            protected override Color EditorBackgroundColor { get; } = default;

            protected override FoldoutHeaderBox fhBox { get; } = FoldoutHeaderBox.Orange;

            protected override HeaderBox hBox { get; } = HeaderBox.Orange;

            protected override Box box { get; } = Box.Orange;

            protected override Label label { get; } = Label.Orange;

            protected override SelectableLabel sLabel { get; } = SelectableLabel.Orange;

            protected override IntField intField { get; } = IntField.Orange;

            protected override FloatField floatField { get; } = FloatField.Orange;

            protected override Vector3Field v3Field { get; } = Vector3Field.Orange;

            protected override Vector4Field v4Field { get; } = Vector4Field.Orange;

            protected override BoolField boolField { get; } = BoolField.Orange;

            protected override StringField stringField { get; } = StringField.Orange;

            protected override ColorField colorField { get; } = ColorField.Orange;

            protected override ObjectField<Material> materialField { get; } = ObjectField<Material>.Orange;

            protected override IntSlider intSlider { get; } = IntSlider.Orange;

            protected override FloatSlider floatSlider { get; } = FloatSlider.Orange;

            protected override TextArea textArea { get; } = TextArea.Orange;

            protected override ColorPicker colorPicker { get; } = ColorPicker.Orange;

            protected override HelpBox helpBox { get; } = HelpBox.Orange;

            protected override Dropdown<float> floatDropdown { get; } = Dropdown<float>.Orange;

            protected override Dropdown<string> stringDropdown { get; } = Dropdown<string>.Orange;

            protected override Button button { get; } = Button.Orange;

            protected override ToggleButton toggleButton { get; } = ToggleButton.Orange;

            protected override Toggle toggle { get; } = Toggle.Orange;
        }
    }
}