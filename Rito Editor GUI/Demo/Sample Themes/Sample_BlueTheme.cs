using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-05-30 PM 9:24:48
// 작성자 : Rito

namespace Rito.EditorUtilities.Samples
{
    public class Sample_BlueTheme : Sample_ThemeBase
    {
        [CustomEditor(typeof(Sample_BlueTheme))]
        private class CE : Sample_ThemeCustomEditorBase
        {
            protected override bool SetEditorBakgroundColor { get; } = true;

            protected override Color EditorBackgroundColor { get; } = RColor.Gray2;

            protected override FoldoutHeaderBox fhBox { get; } = FoldoutHeaderBox.Blue;

            protected override HeaderBox hBox { get; } = HeaderBox.Blue;

            protected override Box box { get; } = Box.Blue;

            protected override Label label { get; } = Label.Blue;

            protected override SelectableLabel sLabel { get; } = SelectableLabel.Blue;

            protected override IntField intField { get; } = IntField.Blue;

            protected override FloatField floatField { get; } = FloatField.Blue;

            protected override Vector3Field v3Field { get; } = Vector3Field.Blue;

            protected override Vector4Field v4Field { get; } = Vector4Field.Blue;

            protected override BoolField boolField { get; } = BoolField.Blue;

            protected override StringField stringField { get; } = StringField.Blue;

            protected override ColorField colorField { get; } = ColorField.Blue;

            protected override ObjectField<Material> materialField { get; } = ObjectField<Material>.Blue;

            protected override IntSlider intSlider { get; } = IntSlider.Blue;

            protected override FloatSlider floatSlider { get; } = FloatSlider.Blue;

            protected override TextArea textArea { get; } = TextArea.Blue;

            protected override ColorPicker colorPicker { get; } = ColorPicker.Blue;

            protected override HelpBox helpBox { get; } = HelpBox.Blue;

            protected override Dropdown<float> floatDropdown { get; } = Dropdown<float>.Blue;

            protected override Dropdown<string> stringDropdown { get; } = Dropdown<string>.Blue;

            protected override Button button { get; } = Button.Blue;

            protected override ToggleButton toggleButton { get; } = ToggleButton.Blue;

            protected override Toggle toggle { get; } = Toggle.Blue;
        }
    }
}