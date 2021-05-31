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
    public class Sample_Pink : Sample_ThemeBase
    {
        [CustomEditor(typeof(Sample_Pink))]
        private class CE : SampleCustomEditorBase
        {
            protected override bool SetEditorBakgroundColor { get; } = false;

            protected override Color EditorBackgroundColor { get; } = default;

            protected override FoldoutHeaderBox fhBox { get; } = FoldoutHeaderBox.Pink;

            protected override HeaderBox hBox { get; } = HeaderBox.Pink;

            protected override Box box { get; } = Box.Pink;

            protected override Label label { get; } = Label.Pink;

            protected override SelectableLabel sLabel { get; } = SelectableLabel.Pink;

            protected override IntField intField { get; } = IntField.Pink;

            protected override FloatField floatField { get; } = FloatField.Pink;

            protected override Vector3Field v3Field { get; } = Vector3Field.Pink;

            protected override Vector4Field v4Field { get; } = Vector4Field.Pink;

            protected override BoolField boolField { get; } = BoolField.Pink;

            protected override StringField stringField { get; } = StringField.Pink;

            protected override ColorField colorField { get; } = ColorField.Pink;

            protected override ObjectField<Material> materialField { get; } = ObjectField<Material>.Pink;

            protected override IntSlider intSlider { get; } = IntSlider.Pink;

            protected override FloatSlider floatSlider { get; } = FloatSlider.Pink;

            protected override TextArea textArea { get; } = TextArea.Pink;

            protected override ColorPicker colorPicker { get; } = ColorPicker.Pink;

            protected override HelpBox helpBox { get; } = HelpBox.Pink;

            protected override Dropdown<float> floatDropdown { get; } = Dropdown<float>.Pink;

            protected override Dropdown<string> stringDropdown { get; } = Dropdown<string>.Pink;

            protected override Button button { get; } = Button.Pink;

            protected override ToggleButton toggleButton { get; } = ToggleButton.Pink;

            protected override Toggle toggle { get; } = Toggle.Pink;
        }
    }
}

#endif