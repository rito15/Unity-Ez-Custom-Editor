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
    public class Sample_Yellow : Sample_ThemeBase
    {
        [CustomEditor(typeof(Sample_Yellow))]
        private class CE : SampleCustomEditorBase
        {
            protected override bool SetEditorBakgroundColor { get; } = false;

            protected override Color EditorBackgroundColor { get; } = default;

            protected override FoldoutHeaderBox fhBox { get; } = FoldoutHeaderBox.Yellow;

            protected override HeaderBox hBox { get; } = HeaderBox.Yellow;

            protected override Box box { get; } = Box.Yellow;

            protected override Label label { get; } = Label.Yellow;

            protected override SelectableLabel sLabel { get; } = SelectableLabel.Yellow;

            protected override IntField intField { get; } = IntField.Yellow;

            protected override FloatField floatField { get; } = FloatField.Yellow;

            protected override Vector3Field v3Field { get; } = Vector3Field.Yellow;

            protected override Vector4Field v4Field { get; } = Vector4Field.Yellow;

            protected override BoolField boolField { get; } = BoolField.Yellow;

            protected override StringField stringField { get; } = StringField.Yellow;

            protected override ColorField colorField { get; } = ColorField.Yellow;

            protected override ObjectField<Material> materialField { get; } = ObjectField<Material>.Yellow;

            protected override IntSlider intSlider { get; } = IntSlider.Yellow;

            protected override FloatSlider floatSlider { get; } = FloatSlider.Yellow;

            protected override TextArea textArea { get; } = TextArea.Yellow;

            protected override ColorPicker colorPicker { get; } = ColorPicker.Yellow;

            protected override HelpBox helpBox { get; } = HelpBox.Yellow;

            protected override Dropdown<float> floatDropdown { get; } = Dropdown<float>.Yellow;

            protected override Dropdown<string> stringDropdown { get; } = Dropdown<string>.Yellow;

            protected override Button button { get; } = Button.Yellow;

            protected override ToggleButton toggleButton { get; } = ToggleButton.Yellow;

            protected override Toggle toggle { get; } = Toggle.Yellow;
        }
    }
}

#endif