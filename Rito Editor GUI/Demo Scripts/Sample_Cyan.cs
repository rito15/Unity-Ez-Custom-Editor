using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-05-30 PM 9:24:48
// 작성자 : Rito

namespace Rito.EditorUtilities.Samples
{
    public class Sample_Cyan : Sample_ThemeBase
    {
        [CustomEditor(typeof(Sample_Cyan))]
        private class CE : SampleCustomEditorBase
        {
            protected override bool SetEditorBakgroundColor { get; } = false;

            protected override Color EditorBackgroundColor { get; } = default;

            protected override FoldoutHeaderBox fhBox { get; } = FoldoutHeaderBox.Cyan;

            protected override HeaderBox hBox { get; } = HeaderBox.Cyan;

            protected override Box box { get; } = Box.Cyan;

            protected override Label label { get; } = Label.Cyan;

            protected override SelectableLabel sLabel { get; } = SelectableLabel.Cyan;

            protected override IntField intField { get; } = IntField.Cyan;

            protected override FloatField floatField { get; } = FloatField.Cyan;

            protected override Vector3Field v3Field { get; } = Vector3Field.Cyan;

            protected override Vector4Field v4Field { get; } = Vector4Field.Cyan;

            protected override BoolField boolField { get; } = BoolField.Cyan;

            protected override StringField stringField { get; } = StringField.Cyan;

            protected override ColorField colorField { get; } = ColorField.Cyan;

            protected override ObjectField<Material> materialField { get; } = ObjectField<Material>.Cyan;

            protected override IntSlider intSlider { get; } = IntSlider.Cyan;

            protected override FloatSlider floatSlider { get; } = FloatSlider.Cyan;

            protected override TextArea textArea { get; } = TextArea.Cyan;

            protected override ColorPicker colorPicker { get; } = ColorPicker.Cyan;

            protected override HelpBox helpBox { get; } = HelpBox.Cyan;

            protected override Dropdown<float> floatDropdown { get; } = Dropdown<float>.Cyan;

            protected override Dropdown<string> stringDropdown { get; } = Dropdown<string>.Cyan;

            protected override Button button { get; } = Button.Cyan;

            protected override ToggleButton toggleButton { get; } = ToggleButton.Cyan;

            protected override Toggle toggle { get; } = Toggle.Cyan;
        }
    }
}