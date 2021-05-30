using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-05-30 PM 9:24:48
// 작성자 : Rito

namespace Rito.EditorUtilities.Demo
{
    public class Demo_WhiteTheme : Demo_ThemeBase
    {
        [CustomEditor(typeof(Demo_WhiteTheme))]
        private class CE : Demo_ThemeCustomEditorBase
        {
            protected override bool SetEditorBakgroundColor { get; } = false;

            protected override Color EditorBackgroundColor { get; } = default;

            protected override FoldoutHeaderBox fhBox { get; } = FoldoutHeaderBox.White;

            protected override HeaderBox hBox { get; } = HeaderBox.White;

            protected override Box box { get; } = Box.White;

            protected override Label label { get; } = Label.White;

            protected override SelectableLabel sLabel { get; } = SelectableLabel.White;

            protected override IntField intField { get; } = IntField.White;

            protected override FloatField floatField { get; } = FloatField.White;

            protected override Vector3Field v3Field { get; } = Vector3Field.White;

            protected override Vector4Field v4Field { get; } = Vector4Field.White;

            protected override BoolField boolField { get; } = BoolField.White;

            protected override StringField stringField { get; } = StringField.White;

            protected override ColorField colorField { get; } = ColorField.White;

            protected override ObjectField<Material> materialField { get; } = ObjectField<Material>.White;

            protected override IntSlider intSlider { get; } = IntSlider.White;

            protected override FloatSlider floatSlider { get; } = FloatSlider.White;

            protected override TextArea textArea { get; } = TextArea.White;

            protected override ColorPicker colorPicker { get; } = ColorPicker.White;

            protected override HelpBox helpBox { get; } = HelpBox.White;

            protected override Dropdown<float> floatDropdown { get; } = Dropdown<float>.White;

            protected override Dropdown<string> stringDropdown { get; } = Dropdown<string>.White;

            protected override Button button { get; } = Button.White;

            protected override ToggleButton toggleButton { get; } = ToggleButton.White;

            protected override Toggle toggle { get; } = Toggle.White;
        }
    }
}