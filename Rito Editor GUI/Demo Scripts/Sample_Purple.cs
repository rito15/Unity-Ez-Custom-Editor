using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-05-30 PM 9:24:48
// 작성자 : Rito

namespace Rito.EditorUtilities.Samples
{
    public class Sample_Purple : Sample_ThemeBase
    {
        [CustomEditor(typeof(Sample_Purple))]
        private class CE : SampleCustomEditorBase
        {
            protected override bool SetEditorBakgroundColor { get; } = false;

            protected override Color EditorBackgroundColor { get; } = default;

            protected override FoldoutHeaderBox fhBox { get; } = FoldoutHeaderBox.Purple;

            protected override HeaderBox hBox { get; } = HeaderBox.Purple;

            protected override Box box { get; } = Box.Purple;

            protected override Label label { get; } = Label.Purple;

            protected override SelectableLabel sLabel { get; } = SelectableLabel.Purple;

            protected override IntField intField { get; } = IntField.Purple;

            protected override FloatField floatField { get; } = FloatField.Purple;

            protected override Vector3Field v3Field { get; } = Vector3Field.Purple;

            protected override Vector4Field v4Field { get; } = Vector4Field.Purple;

            protected override BoolField boolField { get; } = BoolField.Purple;

            protected override StringField stringField { get; } = StringField.Purple;

            protected override ColorField colorField { get; } = ColorField.Purple;

            protected override ObjectField<Material> materialField { get; } = ObjectField<Material>.Purple;

            protected override IntSlider intSlider { get; } = IntSlider.Purple;

            protected override FloatSlider floatSlider { get; } = FloatSlider.Purple;

            protected override TextArea textArea { get; } = TextArea.Purple;

            protected override ColorPicker colorPicker { get; } = ColorPicker.Purple;

            protected override HelpBox helpBox { get; } = HelpBox.Purple;

            protected override Dropdown<float> floatDropdown { get; } = Dropdown<float>.Purple;

            protected override Dropdown<string> stringDropdown { get; } = Dropdown<string>.Purple;

            protected override Button button { get; } = Button.Purple;

            protected override ToggleButton toggleButton { get; } = ToggleButton.Purple;

            protected override Toggle toggle { get; } = Toggle.Purple;
        }
    }
}