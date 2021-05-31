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
    public class Sample_Brown : Sample_ThemeBase
    {
        [CustomEditor(typeof(Sample_Brown))]
        private class CE : SampleCustomEditorBase
        {
            protected override bool SetEditorBakgroundColor { get; } = false;

            protected override Color EditorBackgroundColor { get; } = default;

            protected override FoldoutHeaderBox fhBox { get; } = FoldoutHeaderBox.Brown;

            protected override HeaderBox hBox { get; } = HeaderBox.Brown;

            protected override Box box { get; } = Box.Brown;

            protected override Label label { get; } = Label.Brown;

            protected override SelectableLabel sLabel { get; } = SelectableLabel.Brown;

            protected override IntField intField { get; } = IntField.Brown;

            protected override FloatField floatField { get; } = FloatField.Brown;

            protected override Vector3Field v3Field { get; } = Vector3Field.Brown;

            protected override Vector4Field v4Field { get; } = Vector4Field.Brown;

            protected override BoolField boolField { get; } = BoolField.Brown;

            protected override StringField stringField { get; } = StringField.Brown;

            protected override ColorField colorField { get; } = ColorField.Brown;

            protected override ObjectField<Material> materialField { get; } = ObjectField<Material>.Brown;

            protected override IntSlider intSlider { get; } = IntSlider.Brown;

            protected override FloatSlider floatSlider { get; } = FloatSlider.Brown;

            protected override TextArea textArea { get; } = TextArea.Brown;

            protected override ColorPicker colorPicker { get; } = ColorPicker.Brown;

            protected override HelpBox helpBox { get; } = HelpBox.Brown;

            protected override Dropdown<float> floatDropdown { get; } = Dropdown<float>.Brown;

            protected override Dropdown<string> stringDropdown { get; } = Dropdown<string>.Brown;

            protected override Button button { get; } = Button.Brown;

            protected override ToggleButton toggleButton { get; } = ToggleButton.Brown;

            protected override Toggle toggle { get; } = Toggle.Brown;
        }
    }
}

#endif