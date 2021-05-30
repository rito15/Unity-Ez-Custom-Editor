using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-05-26 PM 3:34:43
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    public abstract partial class LabelBase<R>
    {
        public static R Gray { get; } = new R
        {
            textColor = RColor.Gray.Bright
        };
        public static R White { get; } = new R
        {
            textColor = RColor.white
        };
        public static R Black { get; } = new R
        {
            textColor = RColor.black
        };
        public static R Red { get; } = new R
        {
            textColor = RColor.Red
        };
        public static R Green { get; } = new R
        {
            textColor = RColor.Green
        };
    }
    public abstract partial class ValueFieldBase<T, R>
    {
        public static R Gray = new R() { };
        public static R White { get; } = new R
        {
            inputBackgroundColor = RColor.white * 5f,
            inputTextColor = RColor.black,
            inputTextFocusedColor = RColor.black,
        };
        public static R Black { get; } = new R
        {
            labelColor = RColor.black,
            inputBackgroundColor = RColor.black,
            inputTextColor = RColor.white,
            inputTextFocusedColor = RColor.Gray.Bright
        };
        public static R Red { get; } = new R
        {
            labelColor = RColor.Red,
            inputBackgroundColor = RColor.Red.Normal,
            inputTextColor = RColor.White,
            inputTextFocusedColor = RColor.Red.Bright
        };
        public static R Green { get; } = new R
        {
            labelColor = RColor.Green,
            inputBackgroundColor = RColor.Green.Dark,
            inputTextColor = RColor.White,
            inputTextFocusedColor = RColor.Green.Bright
        };
    }
    public partial class TextArea
    {
        public static TextArea Gray { get; } = new TextArea { };
        public static TextArea White { get; } = new TextArea
        {
            inputBackgroundColor = RColor.white * 10f,
            inputTextColor = RColor.black,
        };
        public static TextArea Black { get; } = new TextArea
        {
            inputBackgroundColor = RColor.black,
            inputTextColor = RColor.white,
        };
        public static TextArea Red { get; } = new TextArea
        {
            inputBackgroundColor = RColor.Red.Normal,
            inputTextColor = RColor.White,
        };
        public static TextArea Green { get; } = new TextArea
        {
            inputBackgroundColor = RColor.Green.Dark,
            inputTextColor = RColor.White,
        };
    }
    public partial class BoolField
    {
        public static BoolField Gray { get; } = new BoolField { };
        public static BoolField White { get; } = new BoolField { };
        public static BoolField Black { get; } = new BoolField
        {
            labelColor = RColor.black,
        };
        public static BoolField Red { get; } = new BoolField
        {
            labelColor = RColor.Red,
            toggleColor = RColor.Red.Soft
        };
        public static BoolField Green { get; } = new BoolField
        {
            labelColor = RColor.Green,
            toggleColor = RColor.Green.Soft
        };
    }
    public abstract partial class ValueSliderBase<T, R>
    {
        public static R Gray { get; } = new R { };
        public static R White { get; } = new R
        {
            labelColor = RColor.white,
            sliderColor = RColor.white * 10f,
            valueColor = RColor.black,
        };
        public static R Black { get; } = new R
        {
            labelColor = RColor.black,
            sliderColor = RColor.black,
            valueColor = RColor.white,
        };
        public static R Red { get; } = new R
        {
            labelColor = RColor.Red,
            sliderColor = RColor.Red.Normal,
            valueColor = RColor.White,
        };
        public static R Green { get; } = new R
        {
            labelColor = RColor.Green,
            sliderColor = RColor.Green.Dark,
            valueColor = RColor.White,
        };
    }
    public partial class Toggle
    {
        public static Toggle Gray { get; } = new Toggle { };
        public static Toggle White { get; } = new Toggle
        {
            color = RColor.white * 100f
        };
        public static Toggle Black { get; } = new Toggle { };
        public static Toggle Red { get; } = new Toggle
        {
            color = RColor.Red.Soft
        };
        public static Toggle Green { get; } = new Toggle
        {
            color = RColor.Green.Soft
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
            labelColor = RColor.black,
            colorPickerColor = RColor.black
        };
        public static ColorField Red { get; } = new ColorField
        {
            labelColor = RColor.Red,
            colorPickerColor = RColor.Red.Normal * 5f
        };
        public static ColorField Green { get; } = new ColorField
        {
            labelColor = RColor.Green,
            colorPickerColor = RColor.Green.Normal * 5f
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
            colorPickerColor = RColor.black
        };
        public static ColorPicker Red { get; } = new ColorPicker
        {
            colorPickerColor = RColor.Red.Normal * 5f
        };
        public static ColorPicker Green { get; } = new ColorPicker
        {
            colorPickerColor = RColor.Green.Normal * 5f
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
            pressedTextColor = RColor.Gray,
            buttonColor = RColor.white * 2.8f,
        };
        public static Button Black { get; } = new Button
        {
            textColor = RColor.white,
            pressedTextColor = RColor.Gray,
            buttonColor = RColor.black
        };
        public static Button Red { get; } = new Button
        {
            textColor = RColor.white,
            pressedTextColor = RColor.Red.Bright,
            buttonColor = RColor.red * 1.5f
        };
        public static Button Green { get; } = new Button
        {
            textColor = RColor.white,
            pressedTextColor = RColor.Green.Bright,
            buttonColor = RColor.Green.Normal * 1.5f
        };
    }
    public partial class ToggleButton
    {
        public static ToggleButton Gray { get; } = new ToggleButton { };
        public static ToggleButton White { get; } = new ToggleButton
        {
            normalTextColor = RColor.black,
            normalButtonColor = RColor.white * 2.8f,

            pressedTextColor = RColor.black,
            pressedButtonColor = RColor.white * 2f,
        };
        public static ToggleButton Black { get; } = new ToggleButton
        {
            normalTextColor = RColor.white,
            normalButtonColor = RColor.black,

            pressedTextColor = RColor.Gray.Bright,
            pressedButtonColor = RColor.Gray,
        };
        public static ToggleButton Red { get; } = new ToggleButton
        {
            normalTextColor = RColor.white,
            normalButtonColor = RColor.Red.Normal * 1.5f,

            pressedTextColor = RColor.white,
            pressedButtonColor = RColor.Red.Normal * 2f
        };
        public static ToggleButton Green { get; } = new ToggleButton
        {
            normalTextColor = RColor.white,
            normalButtonColor = RColor.Green.Normal * 1.5f,

            pressedTextColor = RColor.white,
            pressedButtonColor = RColor.Green.Normal * 2f
        };
    }
    public partial class Box
    {
        public static Box Gray { get; } = new Box
        {
        };
        public static Box White { get; } = new Box
        {
            color = RColor.Gray.Darker
        };
        public static Box Black { get; } = new Box
        {
            color = RColor.white
        };
        public static Box Red { get; } = new Box
        {
            color = RColor.Red.Bright
        };
        public static Box Green { get; } = new Box
        {
            color = RColor.black.SetG(0.1f)
        };
    }
    public abstract partial class HeaderBoxBase<R>
    {
        public static R Gray { get; } = new R { };
        public static R White { get; } = new R
        {
            headerTextColor = RColor.black,
            headerColor = RColor.white,
            contentColor = RColor.Gray.Darker,
            outlineColor = RColor.black
        };
        public static R Black { get; } = new R
        {
            headerTextColor = RColor.white,
            headerColor = RColor.black,
            contentColor = RColor.Gray.Bright,
            outlineColor = RColor.Gray.Darker
        };
        public static R Red { get; } = new R
        {
            headerTextColor = RColor.white,
            headerColor = RColor.Red.Dark,
            contentColor = RColor.Red.Bright,
            outlineColor = RColor.Red.Darker
        };
        public static R Green { get; } = new R
        {
            headerTextColor = RColor.Black,
            headerColor = RColor.Green.Light,
            contentColor = RColor.black.SetG(0.1f),
            outlineColor = RColor.Green.Darker
        };
    }
    public partial class FoldoutHeaderBox
    {
        public static new FoldoutHeaderBox White { get; } = new FoldoutHeaderBox
        {
            headerTextColor = RColor.black,
            headerColor = RColor.white,
            headerHoverColor = RColor.Gray7,
            contentColor = RColor.Gray.Darker,
            outlineColor = RColor.black
        };
        public static new FoldoutHeaderBox Black { get; } = new FoldoutHeaderBox
        {
            headerTextColor = RColor.white,
            headerColor = RColor.black,
            headerHoverColor = RColor.Gray3,
            contentColor = RColor.Gray.Bright,
            outlineColor = RColor.Gray.Darker
        };
        public static new FoldoutHeaderBox Red { get; } = new FoldoutHeaderBox
        {
            headerTextColor = RColor.white,
            headerColor = RColor.Red.Dark,
            headerHoverColor = RColor.Red,
            contentColor = RColor.Red.Bright,
            outlineColor = RColor.Red.Darker
        };
        public static new FoldoutHeaderBox Green { get; } = new FoldoutHeaderBox
        {
            headerTextColor = RColor.Black,
            headerColor = RColor.Green.Light,
            headerHoverColor = RColor.Green.Bright,
            contentColor = RColor.black.SetG(0.1f),
            outlineColor = RColor.Green.Darker
        };
    }
    public partial class HelpBox
    {
        public static HelpBox Gray { get; } = new HelpBox { };
        public static HelpBox White { get; } = new HelpBox
        {
            textColor = RColor.Black,
            backgroundColor = RColor.White * 10f
        };
        public static HelpBox Black { get; } = new HelpBox
        {
            backgroundColor = RColor.black
        };
        public static HelpBox Red { get; } = new HelpBox
        {
            backgroundColor = RColor.Red.Darker
        };
        public static HelpBox Green { get; } = new HelpBox
        {
            backgroundColor = RColor.black.SetG(0.55f)
        };
    }
}