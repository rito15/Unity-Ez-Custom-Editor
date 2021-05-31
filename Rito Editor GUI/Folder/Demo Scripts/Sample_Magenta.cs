using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-05-30 PM 9:24:48
// 작성자 : Rito

namespace Rito.EditorUtilities.Samples
{
    public class Sample_Magenta : Sample_ThemeBase
    {
        [CustomEditor(typeof(Sample_Magenta))]
        private class CE : SampleCustomEditorBase
        {
            protected override bool SetEditorBakgroundColor { get; } = false;

            protected override Color EditorBackgroundColor { get; } = default;

            protected override FoldoutHeaderBox fhBox { get; } = FoldoutHeaderBox.Magenta;

            protected override HeaderBox hBox { get; } = HeaderBox.Magenta;

            protected override Box box { get; } = Box.Magenta;

            protected override Label label { get; } = Label.Magenta;

            protected override SelectableLabel sLabel { get; } = SelectableLabel.Magenta;

            protected override IntField intField { get; } = IntField.Magenta;

            protected override FloatField floatField { get; } = FloatField.Magenta;

            protected override Vector3Field v3Field { get; } = Vector3Field.Magenta;

            protected override Vector4Field v4Field { get; } = Vector4Field.Magenta;

            protected override BoolField boolField { get; } = BoolField.Magenta;

            protected override StringField stringField { get; } = StringField.Magenta;

            protected override ColorField colorField { get; } = ColorField.Magenta;

            protected override ObjectField<Material> materialField { get; } = ObjectField<Material>.Magenta;

            protected override IntSlider intSlider { get; } = IntSlider.Magenta;

            protected override FloatSlider floatSlider { get; } = FloatSlider.Magenta;

            protected override TextArea textArea { get; } = TextArea.Magenta;

            protected override ColorPicker colorPicker { get; } = ColorPicker.Magenta;

            protected override HelpBox helpBox { get; } = HelpBox.Magenta;

            protected override Dropdown<float> floatDropdown { get; } = Dropdown<float>.Magenta;

            protected override Dropdown<string> stringDropdown { get; } = Dropdown<string>.Magenta;

            protected override Button button { get; } = Button.Magenta;

            protected override ToggleButton toggleButton { get; } = ToggleButton.Magenta;

            protected override Toggle toggle { get; } = Toggle.Magenta;
        }
    }
}