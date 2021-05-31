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
    public class Sample_Black : Sample_ThemeBase
    {
        [CustomEditor(typeof(Sample_Black))]
        private class CE : SampleCustomEditorBase
        {
            protected override bool SetEditorBakgroundColor { get; } = true;

            protected override Color EditorBackgroundColor { get; } = Color.gray;

            protected override FoldoutHeaderBox fhBox { get; } = FoldoutHeaderBox.Black;

            protected override HeaderBox hBox { get; } = HeaderBox.Black;

            protected override Box box { get; } = Box.Black;

            protected override Label label { get; } = Label.Black;

            protected override SelectableLabel sLabel { get; } = SelectableLabel.Black;

            protected override IntField intField { get; } = IntField.Black;

            protected override FloatField floatField { get; } = FloatField.Black;

            protected override Vector3Field v3Field { get; } = Vector3Field.Black;

            protected override Vector4Field v4Field { get; } = Vector4Field.Black;

            protected override BoolField boolField { get; } = BoolField.Black;

            protected override StringField stringField { get; } = StringField.Black;

            protected override ColorField colorField { get; } = ColorField.Black;

            protected override ObjectField<Material> materialField { get; } = ObjectField<Material>.Black;

            protected override IntSlider intSlider { get; } = IntSlider.Black;

            protected override FloatSlider floatSlider { get; } = FloatSlider.Black;

            protected override TextArea textArea { get; } = TextArea.Black;

            protected override ColorPicker colorPicker { get; } = ColorPicker.Black;

            protected override HelpBox helpBox { get; } = HelpBox.Black;

            protected override Dropdown<float> floatDropdown { get; } = Dropdown<float>.Black;

            protected override Dropdown<string> stringDropdown { get; } = Dropdown<string>.Black;

            protected override Button button { get; } = Button.Black;

            protected override ToggleButton toggleButton { get; } = ToggleButton.Black;

            protected override Toggle toggle { get; } = Toggle.Black;
        }
    }
}

#endif