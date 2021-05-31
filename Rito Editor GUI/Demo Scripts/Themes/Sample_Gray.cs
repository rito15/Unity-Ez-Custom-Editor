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
    public class Sample_Gray : Sample_ThemeBase
    {
        [CustomEditor(typeof(Sample_Gray))]
        private class CE : SampleCustomEditorBase
        {
            protected override bool SetEditorBakgroundColor { get; } = false;

            protected override Color EditorBackgroundColor { get; } = RColor.Gray;

            protected override FoldoutHeaderBox fhBox { get; } = FoldoutHeaderBox.Gray;

            protected override HeaderBox hBox { get; } = HeaderBox.Gray;

            protected override Box box { get; } = Box.Gray;

            protected override Label label { get; } = Label.Gray;

            protected override SelectableLabel sLabel { get; } = SelectableLabel.Gray;

            protected override IntField intField { get; } = IntField.Gray;

            protected override FloatField floatField { get; } = FloatField.Gray;

            protected override Vector3Field v3Field { get; } = Vector3Field.Gray;

            protected override Vector4Field v4Field { get; } = Vector4Field.Gray;

            protected override BoolField boolField { get; } = BoolField.Gray;

            protected override StringField stringField { get; } = StringField.Gray;

            protected override ColorField colorField { get; } = ColorField.Gray;

            protected override ObjectField<Material> materialField { get; } = ObjectField<Material>.Gray;

            protected override IntSlider intSlider { get; } = IntSlider.Gray;

            protected override FloatSlider floatSlider { get; } = FloatSlider.Gray;

            protected override TextArea textArea { get; } = TextArea.Gray;

            protected override ColorPicker colorPicker { get; } = ColorPicker.Gray;

            protected override HelpBox helpBox { get; } = HelpBox.Gray;

            protected override Dropdown<float> floatDropdown { get; } = Dropdown<float>.Gray;

            protected override Dropdown<string> stringDropdown { get; } = Dropdown<string>.Gray;

            protected override Button button { get; } = Button.Gray;

            protected override ToggleButton toggleButton { get; } = ToggleButton.Gray;

            protected override Toggle toggle { get; } = Toggle.Gray;
        }
    }
}

#endif