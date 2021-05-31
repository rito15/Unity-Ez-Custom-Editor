using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-05-30 PM 9:24:48
// 작성자 : Rito

namespace Rito.EditorUtilities.Samples
{
    public class Sample_Gold : Sample_ThemeBase
    {
        [CustomEditor(typeof(Sample_Gold))]
        private class CE : SampleCustomEditorBase
        {
            protected override bool SetEditorBakgroundColor { get; } = false;

            protected override Color EditorBackgroundColor { get; } = default;

            protected override FoldoutHeaderBox fhBox { get; } = FoldoutHeaderBox.Gold;

            protected override HeaderBox hBox { get; } = HeaderBox.Gold;

            protected override Box box { get; } = Box.Gold;

            protected override Label label { get; } = Label.Gold;

            protected override SelectableLabel sLabel { get; } = SelectableLabel.Gold;

            protected override IntField intField { get; } = IntField.Gold;

            protected override FloatField floatField { get; } = FloatField.Gold;

            protected override Vector3Field v3Field { get; } = Vector3Field.Gold;

            protected override Vector4Field v4Field { get; } = Vector4Field.Gold;

            protected override BoolField boolField { get; } = BoolField.Gold;

            protected override StringField stringField { get; } = StringField.Gold;

            protected override ColorField colorField { get; } = ColorField.Gold;

            protected override ObjectField<Material> materialField { get; } = ObjectField<Material>.Gold;

            protected override IntSlider intSlider { get; } = IntSlider.Gold;

            protected override FloatSlider floatSlider { get; } = FloatSlider.Gold;

            protected override TextArea textArea { get; } = TextArea.Gold;

            protected override ColorPicker colorPicker { get; } = ColorPicker.Gold;

            protected override HelpBox helpBox { get; } = HelpBox.Gold;

            protected override Dropdown<float> floatDropdown { get; } = Dropdown<float>.Gold;

            protected override Dropdown<string> stringDropdown { get; } = Dropdown<string>.Gold;

            protected override Button button { get; } = Button.Gold;

            protected override ToggleButton toggleButton { get; } = ToggleButton.Gold;

            protected override Toggle toggle { get; } = Toggle.Gold;
        }
    }
}