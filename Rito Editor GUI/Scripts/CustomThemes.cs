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
        public static R White { get; } = new R { };
        public static R Black { get; } = new R
        {
            textColor = ColorReg.Black.Label
        };
        public static R Red { get; } = new R
        {
            textColor = ColorReg.Red.Label
        };
        public static R Green { get; } = new R
        {
            textColor = ColorReg.Green.Label
        };
        public static R Blue { get; } = new R
        {
            textColor = ColorReg.Blue.Label
        };
        public static R Pink { get; } = new R
        {
            textColor = ColorReg.Pink.Label
        };
    }
    public abstract partial class ValueFieldBase<T, R>
    {
        public static R Gray = new R() { };
        public static R White { get; } = new R
        {
            inputBackgroundColor = ColorReg.White.InputBG,
            inputTextColor = ColorReg.White.InputText,
            inputTextFocusedColor = ColorReg.White.InputTextFocused,
        };
        public static R Black { get; } = new R
        {
            labelColor = ColorReg.Black.Label,
            inputBackgroundColor = ColorReg.Black.InputBG,
            inputTextColor = ColorReg.Black.InputText,
            inputTextFocusedColor = ColorReg.Black.InputTextFocused,
        };
        public static R Red { get; } = new R
        {
            labelColor = ColorReg.Red.Label,
            inputBackgroundColor = ColorReg.Red.InputBG,
            inputTextColor = ColorReg.Red.InputText,
            inputTextFocusedColor = ColorReg.Red.InputTextFocused
        };
        public static R Green { get; } = new R
        {
            labelColor = ColorReg.Green.Label,
            inputBackgroundColor = ColorReg.Green.InputBG,
            inputTextColor = ColorReg.Green.InputText,
            inputTextFocusedColor = ColorReg.Green.InputTextFocused
        };
        public static R Blue { get; } = new R
        {
            labelColor = ColorReg.Blue.Label,
            inputBackgroundColor = ColorReg.Blue.InputBG,
            inputTextColor = ColorReg.Blue.InputText,
            inputTextFocusedColor = ColorReg.Blue.InputTextFocused
        };
        public static R Pink { get; } = new R
        {
            labelColor = ColorReg.Pink.Label,
            inputBackgroundColor = ColorReg.Pink.InputBG,
            inputTextColor = ColorReg.Pink.InputText,
            inputTextFocusedColor = ColorReg.Pink.InputTextFocused
        };
    }
    public partial class TextArea
    {
        public static TextArea Gray { get; } = new TextArea { };
        public static TextArea White { get; } = new TextArea
        {
            inputBackgroundColor = ColorReg.White.InputBG,
            inputTextColor = ColorReg.White.InputText,
        };
        public static TextArea Black { get; } = new TextArea
        {
            inputBackgroundColor = ColorReg.Black.InputBG,
            inputTextColor = ColorReg.Black.InputText,
        };
        public static TextArea Red { get; } = new TextArea
        {
            inputBackgroundColor = ColorReg.Red.InputBG,
            inputTextColor = ColorReg.Red.InputText,
        };
        public static TextArea Green { get; } = new TextArea
        {
            inputBackgroundColor = ColorReg.Green.InputBG,
            inputTextColor = ColorReg.Green.InputText,
        };
        public static TextArea Blue { get; } = new TextArea
        {
            inputBackgroundColor = ColorReg.Blue.InputBG,
            inputTextColor = ColorReg.Blue.InputText,
        };
        public static TextArea Pink { get; } = new TextArea
        {
            inputBackgroundColor = ColorReg.Pink.InputBG,
            inputTextColor = ColorReg.Pink.InputText,
        };
    }
    public partial class BoolField
    {
        public static BoolField Gray { get; } = new BoolField { };
        public static BoolField White { get; } = new BoolField { };
        public static BoolField Black { get; } = new BoolField
        {
            labelColor = ColorReg.Black.Label,
        };
        public static BoolField Red { get; } = new BoolField
        {
            labelColor = ColorReg.Red.Label,
            toggleColor = ColorReg.Red.Toggle
        };
        public static BoolField Green { get; } = new BoolField
        {
            labelColor = ColorReg.Green.Label,
            toggleColor = ColorReg.Green.Toggle
        };
        public static BoolField Blue { get; } = new BoolField
        {
            labelColor = ColorReg.Blue.Label,
            toggleColor = ColorReg.Blue.Toggle
        };
        public static BoolField Pink { get; } = new BoolField
        {
            labelColor = ColorReg.Pink.Label,
            toggleColor = ColorReg.Pink.Toggle
        };
    }
    public abstract partial class ValueSliderBase<T, R>
    {
        public static R Gray { get; } = new R { };
        public static R White { get; } = new R
        {
            sliderColor = ColorReg.White.InputBG,
            inputTextColor = ColorReg.White.InputText,
        };
        public static R Black { get; } = new R
        {
            labelColor = ColorReg.Black.Label,
            sliderColor = ColorReg.Black.InputBG,
            inputTextColor = ColorReg.Black.InputText,
        };
        public static R Red { get; } = new R
        {
            labelColor = ColorReg.Red.Label,
            sliderColor = ColorReg.Red.InputBG,
            inputTextColor = ColorReg.Red.InputText,
        };
        public static R Green { get; } = new R
        {
            labelColor = ColorReg.Green.Label,
            sliderColor = ColorReg.Green.InputBG,
            inputTextColor = ColorReg.Green.InputText,
        };
        public static R Blue { get; } = new R
        {
            labelColor = ColorReg.Blue.Label,
            sliderColor = ColorReg.Blue.InputBG,
            inputTextColor = ColorReg.Blue.InputText,
        };
        public static R Pink { get; } = new R
        {
            labelColor = ColorReg.Pink.Label,
            sliderColor = ColorReg.Pink.InputBG,
            inputTextColor = ColorReg.Pink.InputText,
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
            color = ColorReg.Red.Toggle
        };
        public static Toggle Green { get; } = new Toggle
        {
            color = ColorReg.Green.Toggle
        };
        public static Toggle Blue { get; } = new Toggle
        {
            color = ColorReg.Blue.Toggle
        };
        public static Toggle Pink { get; } = new Toggle
        {
            color = ColorReg.Pink.Toggle
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
            labelColor = ColorReg.Black.Label,
            colorPickerColor = ColorReg.Black.ColorPicker,
        };
        public static ColorField Red { get; } = new ColorField
        {
            labelColor = ColorReg.Red.Label,
            colorPickerColor = ColorReg.Red.ColorPicker,
        };
        public static ColorField Green { get; } = new ColorField
        {
            labelColor = ColorReg.Green.Label,
            colorPickerColor = ColorReg.Green.ColorPicker,
        };
        public static ColorField Blue { get; } = new ColorField
        {
            labelColor = ColorReg.Blue.Label,
            colorPickerColor = ColorReg.Blue.ColorPicker,
        };
        public static ColorField Pink { get; } = new ColorField
        {
            labelColor = ColorReg.Pink.Label,
            colorPickerColor = ColorReg.Pink.ColorPicker,
        };
    }
    public partial class ColorPicker
    {
        public static ColorPicker Gray { get; } = new ColorPicker { };
        public static ColorPicker White { get; } = new ColorPicker
        {
            colorPickerColor = ColorReg.White.ColorPicker,
        };
        public static ColorPicker Black { get; } = new ColorPicker
        {
            colorPickerColor = ColorReg.Black.ColorPicker,
        };
        public static ColorPicker Red { get; } = new ColorPicker
        {
            colorPickerColor = ColorReg.Red.ColorPicker,
        };
        public static ColorPicker Green { get; } = new ColorPicker
        {
            colorPickerColor = ColorReg.Green.ColorPicker,
        };
        public static ColorPicker Blue { get; } = new ColorPicker
        {
            colorPickerColor = ColorReg.Blue.ColorPicker,
        };
        public static ColorPicker Pink { get; } = new ColorPicker
        {
            colorPickerColor = ColorReg.Pink.ColorPicker,
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
            buttonColor = ColorReg.Red.Button
        };
        public static Button Green { get; } = new Button
        {
            textColor = RColor.white,
            pressedTextColor = RColor.Green.Bright,
            buttonColor = ColorReg.Green.Button
        };
        public static Button Blue { get; } = new Button
        {
            textColor = RColor.white,
            pressedTextColor = RColor.Blue.Bright,
            buttonColor = ColorReg.Blue.Button
        };
        public static Button Pink { get; } = new Button
        {
            textColor = RColor.white,
            pressedTextColor = RColor.Pink.Bright,
            buttonColor = ColorReg.Pink.Button
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
            normalButtonColor = ColorReg.Red.Button,

            pressedTextColor = RColor.white,
            pressedButtonColor = ColorReg.Red.ButtonPressed
        };
        public static ToggleButton Green { get; } = new ToggleButton
        {
            normalTextColor = RColor.white,
            normalButtonColor = ColorReg.Green.Button,

            pressedTextColor = RColor.white,
            pressedButtonColor = ColorReg.Green.ButtonPressed
        };
        public static ToggleButton Blue { get; } = new ToggleButton
        {
            normalTextColor = RColor.white,
            normalButtonColor = ColorReg.Blue.Button,

            pressedTextColor = RColor.white,
            pressedButtonColor = ColorReg.Blue.ButtonPressed
        };
        public static ToggleButton Pink { get; } = new ToggleButton
        {
            normalTextColor = RColor.white,
            normalButtonColor = ColorReg.Pink.Button,

            pressedTextColor = RColor.white,
            pressedButtonColor = ColorReg.Pink.ButtonPressed
        };
    }
    public partial class Box
    {
        public static Box Gray { get; } = new Box { };
        public static Box White { get; } = new Box
        {
            color = ColorReg.White.Box,
            outlineColor = ColorReg.White.BoxOutline
        };
        public static Box Black { get; } = new Box
        {
            color = ColorReg.Black.Box,
            outlineColor = ColorReg.Black.BoxOutline
        };
        public static Box Red { get; } = new Box
        {
            color = ColorReg.Red.Box,
            outlineColor = ColorReg.Red.BoxOutline
        };
        public static Box Green { get; } = new Box
        {
            color = ColorReg.Green.Box,
            outlineColor = ColorReg.Green.BoxOutline
        };
        public static Box Blue { get; } = new Box
        {
            color = ColorReg.Blue.Box,
            outlineColor = ColorReg.Blue.BoxOutline
        };
        public static Box Pink { get; } = new Box
        {
            color = ColorReg.Pink.Box,
            outlineColor = ColorReg.Pink.BoxOutline
        };
    }
    public abstract partial class HeaderBoxBase<R>
    {
        public static R Gray { get; } = new R { };
        public static R White { get; } = new R
        {
            contentColor = ColorReg.White.Box,
            headerColor = ColorReg.White.BoxHeader,
            headerTextColor = ColorReg.White.BoxHeaderText,
            outlineColor = ColorReg.White.BoxOutline
        };
        public static R Black { get; } = new R
        {
            contentColor = ColorReg.Black.Box,
            headerColor = ColorReg.Black.BoxHeader,
            headerTextColor = ColorReg.Black.BoxHeaderText,
            outlineColor = ColorReg.Black.BoxOutline
        };
        public static R Red { get; } = new R
        {
            contentColor = ColorReg.Red.Box,
            headerColor = ColorReg.Red.BoxHeader,
            headerTextColor = ColorReg.Red.BoxHeaderText,
            outlineColor = ColorReg.Red.BoxOutline
        };
        public static R Green { get; } = new R
        {
            contentColor = ColorReg.Green.Box,
            headerColor = ColorReg.Green.BoxHeader,
            headerTextColor = ColorReg.Green.BoxHeaderText,
            outlineColor = ColorReg.Green.BoxOutline
        };
        public static R Blue { get; } = new R
        {
            contentColor = ColorReg.Blue.Box,
            headerColor = ColorReg.Blue.BoxHeader,
            headerTextColor = ColorReg.Blue.BoxHeaderText,
            outlineColor = ColorReg.Blue.BoxOutline
        };
        public static R Pink { get; } = new R
        {
            contentColor = ColorReg.Pink.Box,
            headerColor = ColorReg.Pink.BoxHeader,
            headerTextColor = ColorReg.Pink.BoxHeaderText,
            outlineColor = ColorReg.Pink.BoxOutline
        };
    }
    public partial class FoldoutHeaderBox
    {
        public static new FoldoutHeaderBox White { get; } = new FoldoutHeaderBox
        {
            contentColor = ColorReg.White.Box,
            headerColor = ColorReg.White.BoxHeader,
            headerHoverColor = ColorReg.White.BoxHeaderHover,
            headerTextColor = ColorReg.White.BoxHeaderText,
            outlineColor = ColorReg.White.BoxOutline
        };
        public static new FoldoutHeaderBox Black { get; } = new FoldoutHeaderBox
        {
            contentColor = ColorReg.Black.Box,
            headerColor = ColorReg.Black.BoxHeader,
            headerHoverColor = ColorReg.Black.BoxHeaderHover,
            headerTextColor = ColorReg.Black.BoxHeaderText,
            outlineColor = ColorReg.Black.BoxOutline
        };
        public static new FoldoutHeaderBox Red { get; } = new FoldoutHeaderBox
        {
            contentColor = ColorReg.Red.Box,
            headerColor = ColorReg.Red.BoxHeader,
            headerHoverColor = ColorReg.Red.BoxHeaderHover,
            headerTextColor = ColorReg.Red.BoxHeaderText,
            outlineColor = ColorReg.Red.BoxOutline
        };
        public static new FoldoutHeaderBox Green { get; } = new FoldoutHeaderBox
        {
            contentColor = ColorReg.Green.Box,
            headerColor = ColorReg.Green.BoxHeader,
            headerHoverColor = ColorReg.Green.BoxHeaderHover,
            headerTextColor = ColorReg.Green.BoxHeaderText,
            outlineColor = ColorReg.Green.BoxOutline
        };
        public static new FoldoutHeaderBox Blue { get; } = new FoldoutHeaderBox
        {
            contentColor = ColorReg.Blue.Box,
            headerColor = ColorReg.Blue.BoxHeader,
            headerHoverColor = ColorReg.Blue.BoxHeaderHover,
            headerTextColor = ColorReg.Blue.BoxHeaderText,
            outlineColor = ColorReg.Blue.BoxOutline
        };
        public static new FoldoutHeaderBox Pink { get; } = new FoldoutHeaderBox
        {
            contentColor = ColorReg.Pink.Box,
            headerColor = ColorReg.Pink.BoxHeader,
            headerHoverColor = ColorReg.Pink.BoxHeaderHover,
            headerTextColor = ColorReg.Pink.BoxHeaderText,
            outlineColor = ColorReg.Pink.BoxOutline
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
            backgroundColor = RColor.Green.Soft
        };
        public static HelpBox Blue { get; } = new HelpBox
        {
            backgroundColor = RColor.Blue.Soft * 1.5f
        };
        public static HelpBox Pink { get; } = new HelpBox
        {
            backgroundColor = RColor.Pink.Soft * 2f
        };
    }
}