using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-05-30 PM 9:24:48
// 작성자 : Rito

namespace Rito.EditorUtilities.Samples
{
    public class Sample_Lime : Sample_ThemeBase
    {
        [CustomEditor(typeof(Sample_Lime))]
        private class CE : SampleCustomEditorBase
        {
            protected override bool SetEditorBakgroundColor { get; } = false;

            protected override Color EditorBackgroundColor { get; } = default;

            protected override FoldoutHeaderBox fhBox { get; } = FoldoutHeaderBox.Lime;

            protected override HeaderBox hBox { get; } = HeaderBox.Lime;

            protected override Box box { get; } = Box.Lime;

            protected override Label label { get; } = Label.Lime;

            protected override SelectableLabel sLabel { get; } = SelectableLabel.Lime;

            protected override IntField intField { get; } = IntField.Lime;

            protected override FloatField floatField { get; } = FloatField.Lime;

            protected override Vector3Field v3Field { get; } = Vector3Field.Lime;

            protected override Vector4Field v4Field { get; } = Vector4Field.Lime;

            protected override BoolField boolField { get; } = BoolField.Lime;

            protected override StringField stringField { get; } = StringField.Lime;

            protected override ColorField colorField { get; } = ColorField.Lime;

            protected override ObjectField<Material> materialField { get; } = ObjectField<Material>.Lime;

            protected override IntSlider intSlider { get; } = IntSlider.Lime;

            protected override FloatSlider floatSlider { get; } = FloatSlider.Lime;

            protected override TextArea textArea { get; } = TextArea.Lime;

            protected override ColorPicker colorPicker { get; } = ColorPicker.Lime;

            protected override HelpBox helpBox { get; } = HelpBox.Lime;

            protected override Dropdown<float> floatDropdown { get; } = Dropdown<float>.Lime;

            protected override Dropdown<string> stringDropdown { get; } = Dropdown<string>.Lime;

            protected override Button button { get; } = Button.Lime;

            protected override ToggleButton toggleButton { get; } = ToggleButton.Lime;

            protected override Toggle toggle { get; } = Toggle.Lime;
        }
    }
}