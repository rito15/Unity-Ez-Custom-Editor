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
    public class Sample_Mint : Sample_ThemeBase
    {
        [CustomEditor(typeof(Sample_Mint))]
        private class CE : SampleCustomEditorBase
        {
            protected override bool SetEditorBakgroundColor { get; } = false;

            protected override Color EditorBackgroundColor { get; } = default;

            protected override FoldoutHeaderBox fhBox { get; } = FoldoutHeaderBox.Mint;

            protected override HeaderBox hBox { get; } = HeaderBox.Mint;

            protected override Box box { get; } = Box.Mint;

            protected override Label label { get; } = Label.Mint;

            protected override SelectableLabel sLabel { get; } = SelectableLabel.Mint;

            protected override IntField intField { get; } = IntField.Mint;

            protected override FloatField floatField { get; } = FloatField.Mint;

            protected override Vector3Field v3Field { get; } = Vector3Field.Mint;

            protected override Vector4Field v4Field { get; } = Vector4Field.Mint;

            protected override BoolField boolField { get; } = BoolField.Mint;

            protected override StringField stringField { get; } = StringField.Mint;

            protected override ColorField colorField { get; } = ColorField.Mint;

            protected override ObjectField<Material> materialField { get; } = ObjectField<Material>.Mint;

            protected override IntSlider intSlider { get; } = IntSlider.Mint;

            protected override FloatSlider floatSlider { get; } = FloatSlider.Mint;

            protected override TextArea textArea { get; } = TextArea.Mint;

            protected override ColorPicker colorPicker { get; } = ColorPicker.Mint;

            protected override HelpBox helpBox { get; } = HelpBox.Mint;

            protected override Dropdown<float> floatDropdown { get; } = Dropdown<float>.Mint;

            protected override Dropdown<string> stringDropdown { get; } = Dropdown<string>.Mint;

            protected override Button button { get; } = Button.Mint;

            protected override ToggleButton toggleButton { get; } = ToggleButton.Mint;

            protected override Toggle toggle { get; } = Toggle.Mint;
        }
    }
}

#endif