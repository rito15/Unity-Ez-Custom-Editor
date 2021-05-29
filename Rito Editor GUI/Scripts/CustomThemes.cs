using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-05-26 PM 3:34:43
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    public partial class Label
    {
        public static Label Gray { get; } = new Label
        {
            textColor = RColor.Gray.Bright
        };
        public static Label White { get; } = new Label
        {
            textColor = RColor.white
        };
        public static Label Black { get; } = new Label
        {
            textColor = RColor.black
        };
    }
    public partial class SelectableLabel
    {
        public static new SelectableLabel Gray { get; } = new SelectableLabel
        {
            textColor = RColor.Gray.Bright
        };
        public static new SelectableLabel White { get; } = new SelectableLabel
        {
            textColor = RColor.white
        };
        public static new SelectableLabel Black { get; } = new SelectableLabel
        {
            textColor = RColor.black
        };
    }
    public partial class Button
    {
        public static Button Gray { get; } = new Button
        {
            textColor = RColor.Gray.Bright
        };
        public static Button White { get; } = new Button
        {
            textColor = RColor.black,
            hoverTextColor = RColor.Gray.Dark,
            buttonColor = RColor.white * 2.8f,
        };
        public static Button Black { get; } = new Button
        {
        };
    }
    public partial class ToggleButton
    {
        public static ToggleButton Gray { get; } = new ToggleButton { };
        public static ToggleButton White { get; } = new ToggleButton
        {
            normalTextColor = RColor.black,
            hoverTextColor = RColor.Gray.Dark,
            normalButtonColor = RColor.white * 2.8f,

            pressedTextColor = RColor.black,
            pressedButtonColor = RColor.white * 3f,
        };
        public static ToggleButton Black { get; } = new ToggleButton
        {
        };
    }
    public partial class IntField
    {
        public static IntField Gray { get; } = new IntField { };
        public static IntField White { get; } = new IntField
        {
            inputBackgroundColor = RColor.white * 10f,
            inputTextColor = RColor.black,
            inputTextFocusedColor = RColor.black,
        };
        public static IntField Black { get; } = new IntField
        {
        };
    }
    public partial class LongField
    {
        public static LongField Gray { get; } = new LongField { };
        public static LongField White { get; } = new LongField
        {
            inputBackgroundColor = RColor.white * 10f,
            inputTextColor = RColor.black,
            inputTextFocusedColor = RColor.black,
        };
        public static LongField Black { get; } = new LongField
        {
        };
    }
    public partial class FloatField
    {
        public static FloatField Gray { get; } = new FloatField { };
        public static FloatField White { get; } = new FloatField
        {
            inputBackgroundColor = RColor.white * 10f,
            inputTextColor = RColor.black,
            inputTextFocusedColor = RColor.black,
        };
        public static FloatField Black { get; } = new FloatField
        {
        };
    }
    public partial class DoubleField
    {
        public static DoubleField Gray { get; } = new DoubleField { };
        public static DoubleField White { get; } = new DoubleField
        {
            inputBackgroundColor = RColor.white * 10f,
            inputTextColor = RColor.black,
            inputTextFocusedColor = RColor.black,
        };
        public static DoubleField Black { get; } = new DoubleField
        {
        };
    }
    public partial class StringField
    {
        public static StringField Gray { get; } = new StringField 
        { 
        };
        public static StringField White { get; } = new StringField
        {
            inputBackgroundColor = RColor.white * 10f,
            inputTextColor = RColor.black,
            inputTextFocusedColor = RColor.black,
        };
        public static StringField Black { get; } = new StringField
        {
        };
    }
    public partial class TextArea
    {
        public static TextArea Gray { get; } = new TextArea { };
        public static TextArea White { get; } = new TextArea
        {
            inputBackgroundColor = RColor.white * 10f,
            inputTextColor = RColor.black,
            inputTextFocusedColor = RColor.black,
        };
        public static TextArea Black { get; } = new TextArea
        {
        };
    }
    public partial class Vector2Field
    {
        public static Vector2Field Gray { get; } = new Vector2Field
        {
        };
        public static Vector2Field White { get; } = new Vector2Field
        {
            inputBackgroundColor = RColor.white * 10f,
            inputTextColor = RColor.black,
            inputTextFocusedColor = RColor.black,
        };
        public static Vector2Field Black { get; } = new Vector2Field
        {
        };
    }
    public partial class Vector3Field
    {
        public static Vector3Field Gray { get; } = new Vector3Field
        {
        };
        public static Vector3Field White { get; } = new Vector3Field
        {
            inputBackgroundColor = RColor.white * 10f,
            inputTextColor = RColor.black,
            inputTextFocusedColor = RColor.black,
        };
        public static Vector3Field Black { get; } = new Vector3Field
        {
        };
    }
    public partial class Vector4Field
    {
        public static Vector4Field Gray { get; } = new Vector4Field
        {
        };
        public static Vector4Field White { get; } = new Vector4Field
        {
            inputBackgroundColor = RColor.white * 10f,
            inputTextColor = RColor.black,
            inputTextFocusedColor = RColor.black,
        };
        public static Vector4Field Black { get; } = new Vector4Field
        {
        };
    }
    public partial class Vector2IntField
    {
        public static Vector2IntField Gray { get; } = new Vector2IntField
        {
        };
        public static Vector2IntField White { get; } = new Vector2IntField
        {
            inputBackgroundColor = RColor.white * 10f,
            inputTextColor = RColor.black,
            inputTextFocusedColor = RColor.black,
        };
        public static Vector2IntField Black { get; } = new Vector2IntField
        {
        };
    }
    public partial class Vector3IntField
    {
        public static Vector3IntField Gray { get; } = new Vector3IntField
        {
        };
        public static Vector3IntField White { get; } = new Vector3IntField
        {
            inputBackgroundColor = RColor.white * 10f,
            inputTextColor = RColor.black,
            inputTextFocusedColor = RColor.black,
        };
        public static Vector3IntField Black { get; } = new Vector3IntField
        {
        };
    }
    public partial class ObjectField<T>
    {
        public static ObjectField<T> Gray { get; } = new ObjectField<T> { };
        public static ObjectField<T> White { get; } = new ObjectField<T>
        {
            inputBackgroundColor = RColor.white * 10f,
            inputTextColor = RColor.black,
            inputTextFocusedColor = RColor.Gray.Darker
        };
        public static ObjectField<T> Black { get; } = new ObjectField<T>
        {
        };
    }
    public partial class Dropdown<T>
    {
        public static Dropdown<T> Gray { get; } = new Dropdown<T>
        {
        };
        public static Dropdown<T> White { get; } = new Dropdown<T>
        {
            inputBackgroundColor = RColor.white * 10f,
            inputTextColor = RColor.black,
            inputTextFocusedColor = RColor.Gray.Darker
        };
        public static Dropdown<T> Black { get; } = new Dropdown<T>
        {
        };
    }
    public partial class BoolField
    {
        public static BoolField Gray { get; } = new BoolField { };
        public static BoolField White { get; } = new BoolField
        {
            toggleColor = RColor.white * 10f
        };
        public static BoolField Black { get; } = new BoolField
        {
        };
    }
    public partial class Toggle
    {
        public static Toggle Gray { get; } = new Toggle { };
        public static Toggle White { get; } = new Toggle
        {
            color = RColor.white * 100f
        };
        public static Toggle Black { get; } = new Toggle
        {
        };
    }
    public partial class ColorField
    {
        public static ColorField Gray { get; } = new ColorField { };
        public static ColorField White { get; } = new ColorField
        {
            colorPickerColor = RColor.white * 10f
        };
        public static ColorField Black { get; } = new ColorField
        {
        };
    }
    public partial class ColorPicker
    {
        public static ColorPicker Gray { get; } = new ColorPicker { };
        public static ColorPicker White { get; } = new ColorPicker
        {
            colorPickerColor = RColor.white * 10f
        };
        public static ColorPicker Black { get; } = new ColorPicker
        {
        };
    }
    public partial class IntSlider
    {
        public static IntSlider Gray { get; } = new IntSlider { };
        public static IntSlider White { get; } = new IntSlider
        {
            sliderColor = RColor.white * 10f,
            valueColor = RColor.black,
            labelColor = RColor.white
        };
        public static IntSlider Black { get; } = new IntSlider
        {
        };
    }
    public partial class FloatSlider
    {
        public static FloatSlider Gray { get; } = new FloatSlider
        {
        };
        public static FloatSlider White { get; } = new FloatSlider
        {
            sliderColor = RColor.white * 10f,
            valueColor = RColor.black,
            labelColor = RColor.white
        };
        public static FloatSlider Black { get; } = new FloatSlider
        {
        };
    }
    public partial class DoubleSlider
    {
        public static DoubleSlider Gray { get; } = new DoubleSlider
        {
        };
        public static DoubleSlider White { get; } = new DoubleSlider
        {
            sliderColor = RColor.white * 10f,
            valueColor = RColor.black,
            labelColor = RColor.white
        };
        public static DoubleSlider Black { get; } = new DoubleSlider
        {
        };
    }
    public partial class Box
    {
        public static Box Gray { get; } = new Box
        {
        };
        public static Box White { get; } = new Box
        {
            color = RColor.Gray.Darker,
        };
        public static Box Black { get; } = new Box
        {
        };
    }
    public partial class HeaderBox
    {
        public static HeaderBox Gray { get; } = new HeaderBox
        {
        };
        public static HeaderBox White { get; } = new HeaderBox
        {
            headerTextColor = RColor.black,
            headerColor = RColor.white,
            contentColor = RColor.Gray.Darker,
            outlineColor = RColor.black
        };
        public static HeaderBox Black { get; } = new HeaderBox
        {
        };
    }
    public partial class FoldoutHeaderBox
    {
        public static FoldoutHeaderBox Gray { get; } = new FoldoutHeaderBox
        {
        };
        public static FoldoutHeaderBox White { get; } = new FoldoutHeaderBox
        {
            headerTextColor = RColor.black,
            headerColor = RColor.white,
            contentColor = RColor.Gray.Darker,
            outlineColor = RColor.black,
        };
        public static FoldoutHeaderBox Black { get; } = new FoldoutHeaderBox
        {
        };
    }
    public partial class HelpBox
    {
        public static HelpBox Gray { get; } = new HelpBox
        {
        };
        public static HelpBox White { get; } = new HelpBox
        {
            textColor = RColor.Black,
            backgroundColor = RColor.White * 10f
        };
        public static HelpBox Black { get; } = new HelpBox
        {
        };
    }
}