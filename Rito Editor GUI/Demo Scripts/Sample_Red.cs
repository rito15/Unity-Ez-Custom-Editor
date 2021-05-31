using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-05-30 PM 9:24:48
// 작성자 : Rito

namespace Rito.EditorUtilities.Samples
{
    public class Sample_Red : Sample_ThemeBase
    {
        [CustomEditor(typeof(Sample_Red))]
        private class CE : SampleCustomEditorBase
        {
            protected override bool SetEditorBakgroundColor { get; } = false;

            protected override Color EditorBackgroundColor { get; } = RColor.Gray1;

            protected override FoldoutHeaderBox fhBox { get; } = FoldoutHeaderBox.Red;

            protected override HeaderBox hBox { get; } = HeaderBox.Red;

            protected override Box box { get; } = Box.Red;

            protected override Label label { get; } = Label.Red;

            protected override SelectableLabel sLabel { get; } = SelectableLabel.Red;

            protected override IntField intField { get; } = IntField.Red;

            protected override FloatField floatField { get; } = FloatField.Red;

            protected override Vector3Field v3Field { get; } = Vector3Field.Red;

            protected override Vector4Field v4Field { get; } = Vector4Field.Red;

            protected override BoolField boolField { get; } = BoolField.Red;

            protected override StringField stringField { get; } = StringField.Red;

            protected override ColorField colorField { get; } = ColorField.Red;

            protected override ObjectField<Material> materialField { get; } = ObjectField<Material>.Red;

            protected override IntSlider intSlider { get; } = IntSlider.Red;

            protected override FloatSlider floatSlider { get; } = FloatSlider.Red;

            protected override TextArea textArea { get; } = TextArea.Red;

            protected override ColorPicker colorPicker { get; } = ColorPicker.Red;

            protected override HelpBox helpBox { get; } = HelpBox.Red;

            protected override Dropdown<float> floatDropdown { get; } = Dropdown<float>.Red;

            protected override Dropdown<string> stringDropdown { get; } = Dropdown<string>.Red;

            protected override Button button { get; } = Button.Red;

            protected override ToggleButton toggleButton { get; } = ToggleButton.Red;

            protected override Toggle toggle { get; } = Toggle.Red;
        }
    }
}