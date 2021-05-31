#if UNITY_EDITOR

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
        public static R Magenta { get; } = new R
        {
            textColor = ColorReg.Magenta.Label
        };
        public static R Violet { get; } = new R
        {
            textColor = ColorReg.Violet.Label
        };
        public static R Purple { get; } = new R
        {
            textColor = ColorReg.Purple.Label
        };
        public static R Brown { get; } = new R
        {
            textColor = ColorReg.Brown.Label
        };
        public static R Gold { get; } = new R
        {
            textColor = ColorReg.Gold.Label
        };
        public static R Orange { get; } = new R
        {
            textColor = ColorReg.Orange.Label
        };
        public static R Yellow { get; } = new R
        {
            textColor = ColorReg.Yellow.Label
        };
        public static R Lime { get; } = new R
        {
            textColor = ColorReg.Lime.Label
        };
        public static R Mint { get; } = new R
        {
            textColor = ColorReg.Mint.Label
        };
        public static R Cyan { get; } = new R
        {
            textColor = ColorReg.Cyan.Label
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
        public static R Magenta { get; } = new R
        {
            labelColor = ColorReg.Magenta.Label,
            inputBackgroundColor = ColorReg.Magenta.InputBG,
            inputTextColor = ColorReg.Magenta.InputText,
            inputTextFocusedColor = ColorReg.Magenta.InputTextFocused
        };
        public static R Violet { get; } = new R
        {
            labelColor = ColorReg.Violet.Label,
            inputBackgroundColor = ColorReg.Violet.InputBG,
            inputTextColor = ColorReg.Violet.InputText,
            inputTextFocusedColor = ColorReg.Violet.InputTextFocused
        };
        public static R Purple { get; } = new R
        {
            labelColor = ColorReg.Purple.Label,
            inputBackgroundColor = ColorReg.Purple.InputBG,
            inputTextColor = ColorReg.Purple.InputText,
            inputTextFocusedColor = ColorReg.Purple.InputTextFocused
        };
        public static R Brown { get; } = new R
        {
            labelColor = ColorReg.Brown.Label,
            inputBackgroundColor = ColorReg.Brown.InputBG,
            inputTextColor = ColorReg.Brown.InputText,
            inputTextFocusedColor = ColorReg.Brown.InputTextFocused
        };
        public static R Gold { get; } = new R
        {
            labelColor = ColorReg.Gold.Label,
            inputBackgroundColor = ColorReg.Gold.InputBG,
            inputTextColor = ColorReg.Gold.InputText,
            inputTextFocusedColor = ColorReg.Gold.InputTextFocused
        };
        public static R Orange { get; } = new R
        {
            labelColor = ColorReg.Orange.Label,
            inputBackgroundColor = ColorReg.Orange.InputBG,
            inputTextColor = ColorReg.Orange.InputText,
            inputTextFocusedColor = ColorReg.Orange.InputTextFocused
        };
        public static R Yellow { get; } = new R
        {
            labelColor = ColorReg.Yellow.Label,
            inputBackgroundColor = ColorReg.Yellow.InputBG,
            inputTextColor = ColorReg.Yellow.InputText,
            inputTextFocusedColor = ColorReg.Yellow.InputTextFocused
        };
        public static R Lime { get; } = new R
        {
            labelColor = ColorReg.Lime.Label,
            inputBackgroundColor = ColorReg.Lime.InputBG,
            inputTextColor = ColorReg.Lime.InputText,
            inputTextFocusedColor = ColorReg.Lime.InputTextFocused
        };
        public static R Mint { get; } = new R
        {
            labelColor = ColorReg.Mint.Label,
            inputBackgroundColor = ColorReg.Mint.InputBG,
            inputTextColor = ColorReg.Mint.InputText,
            inputTextFocusedColor = ColorReg.Mint.InputTextFocused
        };
        public static R Cyan { get; } = new R
        {
            labelColor = ColorReg.Cyan.Label,
            inputBackgroundColor = ColorReg.Cyan.InputBG,
            inputTextColor = ColorReg.Cyan.InputText,
            inputTextFocusedColor = ColorReg.Cyan.InputTextFocused
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
        public static TextArea Magenta { get; } = new TextArea
        {
            inputBackgroundColor = ColorReg.Magenta.InputBG,
            inputTextColor = ColorReg.Magenta.InputText,
        };
        public static TextArea Violet { get; } = new TextArea
        {
            inputBackgroundColor = ColorReg.Violet.InputBG,
            inputTextColor = ColorReg.Violet.InputText,
        };
        public static TextArea Purple { get; } = new TextArea
        {
            inputBackgroundColor = ColorReg.Purple.InputBG,
            inputTextColor = ColorReg.Purple.InputText,
        };
        public static TextArea Brown { get; } = new TextArea
        {
            inputBackgroundColor = ColorReg.Brown.InputBG,
            inputTextColor = ColorReg.Brown.InputText,
        };
        public static TextArea Gold { get; } = new TextArea
        {
            inputBackgroundColor = ColorReg.Gold.InputBG,
            inputTextColor = ColorReg.Gold.InputText,
        };
        public static TextArea Orange { get; } = new TextArea
        {
            inputBackgroundColor = ColorReg.Orange.InputBG,
            inputTextColor = ColorReg.Orange.InputText,
        };
        public static TextArea Yellow { get; } = new TextArea
        {
            inputBackgroundColor = ColorReg.Yellow.InputBG,
            inputTextColor = ColorReg.Yellow.InputText,
        };
        public static TextArea Lime { get; } = new TextArea
        {
            inputBackgroundColor = ColorReg.Lime.InputBG,
            inputTextColor = ColorReg.Lime.InputText,
        };
        public static TextArea Mint { get; } = new TextArea
        {
            inputBackgroundColor = ColorReg.Mint.InputBG,
            inputTextColor = ColorReg.Mint.InputText,
        };
        public static TextArea Cyan { get; } = new TextArea
        {
            inputBackgroundColor = ColorReg.Cyan.InputBG,
            inputTextColor = ColorReg.Cyan.InputText,
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
        public static BoolField Magenta { get; } = new BoolField
        {
            labelColor = ColorReg.Magenta.Label,
            toggleColor = ColorReg.Magenta.Toggle
        };
        public static BoolField Violet { get; } = new BoolField
        {
            labelColor = ColorReg.Violet.Label,
            toggleColor = ColorReg.Violet.Toggle
        };
        public static BoolField Purple { get; } = new BoolField
        {
            labelColor = ColorReg.Purple.Label,
            toggleColor = ColorReg.Purple.Toggle
        };
        public static BoolField Brown { get; } = new BoolField
        {
            labelColor = ColorReg.Brown.Label,
            toggleColor = ColorReg.Brown.Toggle
        };
        public static BoolField Gold { get; } = new BoolField
        {
            labelColor = ColorReg.Gold.Label,
            toggleColor = ColorReg.Gold.Toggle
        };
        public static BoolField Orange { get; } = new BoolField
        {
            labelColor = ColorReg.Orange.Label,
            toggleColor = ColorReg.Orange.Toggle
        };
        public static BoolField Yellow { get; } = new BoolField
        {
            labelColor = ColorReg.Yellow.Label,
            toggleColor = ColorReg.Yellow.Toggle
        };
        public static BoolField Lime { get; } = new BoolField
        {
            labelColor = ColorReg.Lime.Label,
            toggleColor = ColorReg.Lime.Toggle
        };
        public static BoolField Mint { get; } = new BoolField
        {
            labelColor = ColorReg.Mint.Label,
            toggleColor = ColorReg.Mint.Toggle
        };
        public static BoolField Cyan { get; } = new BoolField
        {
            labelColor = ColorReg.Cyan.Label,
            toggleColor = ColorReg.Cyan.Toggle
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
        public static R Magenta { get; } = new R
        {
            labelColor = ColorReg.Magenta.Label,
            sliderColor = ColorReg.Magenta.InputBG,
            inputTextColor = ColorReg.Magenta.InputText,
        };
        public static R Violet { get; } = new R
        {
            labelColor = ColorReg.Violet.Label,
            sliderColor = ColorReg.Violet.InputBG,
            inputTextColor = ColorReg.Violet.InputText,
        };
        public static R Purple { get; } = new R
        {
            labelColor = ColorReg.Purple.Label,
            sliderColor = ColorReg.Purple.InputBG,
            inputTextColor = ColorReg.Purple.InputText,
        };
        public static R Brown { get; } = new R
        {
            labelColor = ColorReg.Brown.Label,
            sliderColor = ColorReg.Brown.InputBG,
            inputTextColor = ColorReg.Brown.InputText,
        };
        public static R Gold { get; } = new R
        {
            labelColor = ColorReg.Gold.Label,
            sliderColor = ColorReg.Gold.InputBG,
            inputTextColor = ColorReg.Gold.InputText,
        };
        public static R Orange { get; } = new R
        {
            labelColor = ColorReg.Orange.Label,
            sliderColor = ColorReg.Orange.InputBG,
            inputTextColor = ColorReg.Orange.InputText,
        };
        public static R Yellow { get; } = new R
        {
            labelColor = ColorReg.Yellow.Label,
            sliderColor = ColorReg.Yellow.InputBG,
            inputTextColor = ColorReg.Yellow.InputText,
        };
        public static R Lime { get; } = new R
        {
            labelColor = ColorReg.Lime.Label,
            sliderColor = ColorReg.Lime.InputBG,
            inputTextColor = ColorReg.Lime.InputText,
        };
        public static R Mint { get; } = new R
        {
            labelColor = ColorReg.Mint.Label,
            sliderColor = ColorReg.Mint.InputBG,
            inputTextColor = ColorReg.Mint.InputText,
        };
        public static R Cyan { get; } = new R
        {
            labelColor = ColorReg.Cyan.Label,
            sliderColor = ColorReg.Cyan.InputBG,
            inputTextColor = ColorReg.Cyan.InputText,
        };
    }
    public partial class Toggle
    {
        public static Toggle Gray { get; } = new Toggle { };
        public static Toggle White { get; } = new Toggle
        {
            color = ColorReg.White.Toggle
        };
        public static Toggle Black { get; } = new Toggle
        {
            color = ColorReg.Black.Toggle
        };
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
        public static Toggle Magenta { get; } = new Toggle
        {
            color = ColorReg.Magenta.Toggle
        };
        public static Toggle Violet { get; } = new Toggle
        {
            color = ColorReg.Violet.Toggle
        };
        public static Toggle Purple { get; } = new Toggle
        {
            color = ColorReg.Purple.Toggle
        };
        public static Toggle Brown { get; } = new Toggle
        {
            color = ColorReg.Brown.Toggle
        };
        public static Toggle Gold { get; } = new Toggle
        {
            color = ColorReg.Gold.Toggle
        };
        public static Toggle Orange { get; } = new Toggle
        {
            color = ColorReg.Orange.Toggle
        };
        public static Toggle Yellow { get; } = new Toggle
        {
            color = ColorReg.Yellow.Toggle
        };
        public static Toggle Lime { get; } = new Toggle
        {
            color = ColorReg.Lime.Toggle
        };
        public static Toggle Mint { get; } = new Toggle
        {
            color = ColorReg.Mint.Toggle
        };
        public static Toggle Cyan { get; } = new Toggle
        {
            color = ColorReg.Cyan.Toggle
        };
    }
    public partial class ColorField
    {
        public static ColorField Gray { get; } = new ColorField { };
        public static ColorField White { get; } = new ColorField
        {
            labelColor = ColorReg.White.Label,
            colorPickerColor = ColorReg.White.ColorPicker,
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
        public static ColorField Magenta { get; } = new ColorField
        {
            labelColor = ColorReg.Magenta.Label,
            colorPickerColor = ColorReg.Magenta.ColorPicker,
        };
        public static ColorField Violet { get; } = new ColorField
        {
            labelColor = ColorReg.Violet.Label,
            colorPickerColor = ColorReg.Violet.ColorPicker,
        };
        public static ColorField Purple { get; } = new ColorField
        {
            labelColor = ColorReg.Purple.Label,
            colorPickerColor = ColorReg.Purple.ColorPicker,
        };
        public static ColorField Brown { get; } = new ColorField
        {
            labelColor = ColorReg.Brown.Label,
            colorPickerColor = ColorReg.Brown.ColorPicker,
        };
        public static ColorField Gold { get; } = new ColorField
        {
            labelColor = ColorReg.Gold.Label,
            colorPickerColor = ColorReg.Gold.ColorPicker,
        };
        public static ColorField Orange { get; } = new ColorField
        {
            labelColor = ColorReg.Orange.Label,
            colorPickerColor = ColorReg.Orange.ColorPicker,
        };
        public static ColorField Yellow { get; } = new ColorField
        {
            labelColor = ColorReg.Yellow.Label,
            colorPickerColor = ColorReg.Yellow.ColorPicker,
        };
        public static ColorField Lime { get; } = new ColorField
        {
            labelColor = ColorReg.Lime.Label,
            colorPickerColor = ColorReg.Lime.ColorPicker,
        };
        public static ColorField Mint { get; } = new ColorField
        {
            labelColor = ColorReg.Mint.Label,
            colorPickerColor = ColorReg.Mint.ColorPicker,
        };
        public static ColorField Cyan { get; } = new ColorField
        {
            labelColor = ColorReg.Cyan.Label,
            colorPickerColor = ColorReg.Cyan.ColorPicker,
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
        public static ColorPicker Magenta { get; } = new ColorPicker
        {
            colorPickerColor = ColorReg.Magenta.ColorPicker,
        };
        public static ColorPicker Violet { get; } = new ColorPicker
        {
            colorPickerColor = ColorReg.Violet.ColorPicker,
        };
        public static ColorPicker Purple { get; } = new ColorPicker
        {
            colorPickerColor = ColorReg.Purple.ColorPicker,
        };
        public static ColorPicker Brown { get; } = new ColorPicker
        {
            colorPickerColor = ColorReg.Brown.ColorPicker,
        };
        public static ColorPicker Gold { get; } = new ColorPicker
        {
            colorPickerColor = ColorReg.Gold.ColorPicker,
        };
        public static ColorPicker Orange { get; } = new ColorPicker
        {
            colorPickerColor = ColorReg.Orange.ColorPicker,
        };
        public static ColorPicker Yellow { get; } = new ColorPicker
        {
            colorPickerColor = ColorReg.Yellow.ColorPicker,
        };
        public static ColorPicker Lime { get; } = new ColorPicker
        {
            colorPickerColor = ColorReg.Lime.ColorPicker,
        };
        public static ColorPicker Mint { get; } = new ColorPicker
        {
            colorPickerColor = ColorReg.Mint.ColorPicker,
        };
        public static ColorPicker Cyan { get; } = new ColorPicker
        {
            colorPickerColor = ColorReg.Cyan.ColorPicker,
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
            textColor = ColorReg.White.ButtonText,
            pressedTextColor = ColorReg.White.ButtonTextPressed,
            buttonColor = ColorReg.White.Button
        };
        public static Button Black { get; } = new Button
        {
            textColor = ColorReg.Black.ButtonText,
            pressedTextColor = ColorReg.Black.ButtonTextPressed,
            buttonColor = ColorReg.Black.Button
        };
        public static Button Red { get; } = new Button
        {
            textColor = ColorReg.Red.ButtonText,
            pressedTextColor = ColorReg.Red.ButtonTextPressed,
            buttonColor = ColorReg.Red.Button
        };
        public static Button Green { get; } = new Button
        {
            textColor = ColorReg.Green.ButtonText,
            pressedTextColor = ColorReg.Green.ButtonTextPressed,
            buttonColor = ColorReg.Green.Button
        };
        public static Button Blue { get; } = new Button
        {
            textColor = ColorReg.Blue.ButtonText,
            pressedTextColor = ColorReg.Blue.ButtonTextPressed,
            buttonColor = ColorReg.Blue.Button
        };
        public static Button Pink { get; } = new Button
        {
            textColor = ColorReg.Pink.ButtonText,
            pressedTextColor = ColorReg.Pink.ButtonTextPressed,
            buttonColor = ColorReg.Pink.Button
        };
        public static Button Magenta { get; } = new Button
        {
            textColor = ColorReg.Magenta.ButtonText,
            pressedTextColor = ColorReg.Magenta.ButtonTextPressed,
            buttonColor = ColorReg.Magenta.Button
        };
        public static Button Violet { get; } = new Button
        {
            textColor = ColorReg.Violet.ButtonText,
            pressedTextColor = ColorReg.Violet.ButtonTextPressed,
            buttonColor = ColorReg.Violet.Button
        };
        public static Button Purple { get; } = new Button
        {
            textColor = ColorReg.Purple.ButtonText,
            pressedTextColor = ColorReg.Purple.ButtonTextPressed,
            buttonColor = ColorReg.Purple.Button
        };
        public static Button Brown { get; } = new Button
        {
            textColor = ColorReg.Brown.ButtonText,
            pressedTextColor = ColorReg.Brown.ButtonTextPressed,
            buttonColor = ColorReg.Brown.Button
        };
        public static Button Gold { get; } = new Button
        {
            textColor = ColorReg.Gold.ButtonText,
            pressedTextColor = ColorReg.Gold.ButtonTextPressed,
            buttonColor = ColorReg.Gold.Button
        };
        public static Button Orange { get; } = new Button
        {
            textColor = ColorReg.Orange.ButtonText,
            pressedTextColor = ColorReg.Orange.ButtonTextPressed,
            buttonColor = ColorReg.Orange.Button
        };
        public static Button Yellow { get; } = new Button
        {
            textColor = ColorReg.Yellow.ButtonText,
            pressedTextColor = ColorReg.Yellow.ButtonTextPressed,
            buttonColor = ColorReg.Yellow.Button
        };
        public static Button Lime { get; } = new Button
        {
            textColor = ColorReg.Lime.ButtonText,
            pressedTextColor = ColorReg.Lime.ButtonTextPressed,
            buttonColor = ColorReg.Lime.Button
        };
        public static Button Mint { get; } = new Button
        {
            textColor = ColorReg.Mint.ButtonText,
            pressedTextColor = ColorReg.Mint.ButtonTextPressed,
            buttonColor = ColorReg.Mint.Button
        };
        public static Button Cyan { get; } = new Button
        {
            textColor = ColorReg.Cyan.ButtonText,
            pressedTextColor = ColorReg.Cyan.ButtonTextPressed,
            buttonColor = ColorReg.Cyan.Button
        };
    }
    public partial class ToggleButton
    {
        public static ToggleButton Gray { get; } = new ToggleButton { };
        public static ToggleButton White { get; } = new ToggleButton
        {
            normalTextColor = ColorReg.White.ButtonText,
            normalButtonColor = ColorReg.White.Button,

            pressedTextColor = ColorReg.White.ButtonTextPressed,
            pressedButtonColor = ColorReg.White.ButtonPressed
        };
        public static ToggleButton Black { get; } = new ToggleButton
        {
            normalTextColor = ColorReg.Black.ButtonText,
            normalButtonColor = ColorReg.Black.Button,

            pressedTextColor = ColorReg.Black.ButtonTextPressed,
            pressedButtonColor = ColorReg.Black.ButtonPressed
        };
        public static ToggleButton Red { get; } = new ToggleButton
        {
            normalTextColor = ColorReg.Red.ButtonText,
            normalButtonColor = ColorReg.Red.Button,

            pressedTextColor = ColorReg.Red.ButtonTextPressed,
            pressedButtonColor = ColorReg.Red.ButtonPressed
        };
        public static ToggleButton Green { get; } = new ToggleButton
        {
            normalTextColor = ColorReg.Green.ButtonText,
            normalButtonColor = ColorReg.Green.Button,

            pressedTextColor = ColorReg.Green.ButtonTextPressed,
            pressedButtonColor = ColorReg.Green.ButtonPressed
        };
        public static ToggleButton Blue { get; } = new ToggleButton
        {
            normalTextColor = ColorReg.Blue.ButtonText,
            normalButtonColor = ColorReg.Blue.Button,

            pressedTextColor = ColorReg.Blue.ButtonTextPressed,
            pressedButtonColor = ColorReg.Blue.ButtonPressed
        };
        public static ToggleButton Pink { get; } = new ToggleButton
        {
            normalTextColor = ColorReg.Pink.ButtonText,
            normalButtonColor = ColorReg.Pink.Button,

            pressedTextColor = ColorReg.Pink.ButtonTextPressed,
            pressedButtonColor = ColorReg.Pink.ButtonPressed
        };
        public static ToggleButton Magenta { get; } = new ToggleButton
        {
            normalTextColor = ColorReg.Magenta.ButtonText,
            normalButtonColor = ColorReg.Magenta.Button,

            pressedTextColor = ColorReg.Magenta.ButtonTextPressed,
            pressedButtonColor = ColorReg.Magenta.ButtonPressed
        };
        public static ToggleButton Violet { get; } = new ToggleButton
        {
            normalTextColor = ColorReg.Violet.ButtonText,
            normalButtonColor = ColorReg.Violet.Button,

            pressedTextColor = ColorReg.Violet.ButtonTextPressed,
            pressedButtonColor = ColorReg.Violet.ButtonPressed
        };
        public static ToggleButton Purple { get; } = new ToggleButton
        {
            normalTextColor = ColorReg.Purple.ButtonText,
            normalButtonColor = ColorReg.Purple.Button,

            pressedTextColor = ColorReg.Purple.ButtonTextPressed,
            pressedButtonColor = ColorReg.Purple.ButtonPressed
        };
        public static ToggleButton Brown { get; } = new ToggleButton
        {
            normalTextColor = ColorReg.Brown.ButtonText,
            normalButtonColor = ColorReg.Brown.Button,

            pressedTextColor = ColorReg.Brown.ButtonTextPressed,
            pressedButtonColor = ColorReg.Brown.ButtonPressed
        };
        public static ToggleButton Gold { get; } = new ToggleButton
        {
            normalTextColor = ColorReg.Gold.ButtonText,
            normalButtonColor = ColorReg.Gold.Button,

            pressedTextColor = ColorReg.Gold.ButtonTextPressed,
            pressedButtonColor = ColorReg.Gold.ButtonPressed
        };
        public static ToggleButton Orange { get; } = new ToggleButton
        {
            normalTextColor = ColorReg.Orange.ButtonText,
            normalButtonColor = ColorReg.Orange.Button,

            pressedTextColor = ColorReg.Orange.ButtonTextPressed,
            pressedButtonColor = ColorReg.Orange.ButtonPressed
        };
        public static ToggleButton Yellow { get; } = new ToggleButton
        {
            normalTextColor = ColorReg.Yellow.ButtonText,
            normalButtonColor = ColorReg.Yellow.Button,

            pressedTextColor = ColorReg.Yellow.ButtonTextPressed,
            pressedButtonColor = ColorReg.Yellow.ButtonPressed
        };
        public static ToggleButton Lime { get; } = new ToggleButton
        {
            normalTextColor = ColorReg.Lime.ButtonText,
            normalButtonColor = ColorReg.Lime.Button,

            pressedTextColor = ColorReg.Lime.ButtonTextPressed,
            pressedButtonColor = ColorReg.Lime.ButtonPressed
        };
        public static ToggleButton Mint { get; } = new ToggleButton
        {
            normalTextColor = ColorReg.Mint.ButtonText,
            normalButtonColor = ColorReg.Mint.Button,

            pressedTextColor = ColorReg.Mint.ButtonTextPressed,
            pressedButtonColor = ColorReg.Mint.ButtonPressed
        };
        public static ToggleButton Cyan { get; } = new ToggleButton
        {
            normalTextColor = ColorReg.Cyan.ButtonText,
            normalButtonColor = ColorReg.Cyan.Button,

            pressedTextColor = ColorReg.Cyan.ButtonTextPressed,
            pressedButtonColor = ColorReg.Cyan.ButtonPressed
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
        public static Box Magenta { get; } = new Box
        {
            color = ColorReg.Magenta.Box,
            outlineColor = ColorReg.Magenta.BoxOutline
        };
        public static Box Violet { get; } = new Box
        {
            color = ColorReg.Violet.Box,
            outlineColor = ColorReg.Violet.BoxOutline
        };
        public static Box Purple { get; } = new Box
        {
            color = ColorReg.Purple.Box,
            outlineColor = ColorReg.Purple.BoxOutline
        };
        public static Box Brown { get; } = new Box
        {
            color = ColorReg.Brown.Box,
            outlineColor = ColorReg.Brown.BoxOutline
        };
        public static Box Gold { get; } = new Box
        {
            color = ColorReg.Gold.Box,
            outlineColor = ColorReg.Gold.BoxOutline
        };
        public static Box Orange { get; } = new Box
        {
            color = ColorReg.Orange.Box,
            outlineColor = ColorReg.Orange.BoxOutline
        };
        public static Box Yellow { get; } = new Box
        {
            color = ColorReg.Yellow.Box,
            outlineColor = ColorReg.Yellow.BoxOutline
        };
        public static Box Lime { get; } = new Box
        {
            color = ColorReg.Lime.Box,
            outlineColor = ColorReg.Lime.BoxOutline
        };
        public static Box Mint { get; } = new Box
        {
            color = ColorReg.Mint.Box,
            outlineColor = ColorReg.Mint.BoxOutline
        };
        public static Box Cyan { get; } = new Box
        {
            color = ColorReg.Cyan.Box,
            outlineColor = ColorReg.Cyan.BoxOutline
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
        public static R Magenta { get; } = new R
        {
            contentColor = ColorReg.Magenta.Box,
            headerColor = ColorReg.Magenta.BoxHeader,
            headerTextColor = ColorReg.Magenta.BoxHeaderText,
            outlineColor = ColorReg.Magenta.BoxOutline
        };
        public static R Violet { get; } = new R
        {
            contentColor = ColorReg.Violet.Box,
            headerColor = ColorReg.Violet.BoxHeader,
            headerTextColor = ColorReg.Violet.BoxHeaderText,
            outlineColor = ColorReg.Violet.BoxOutline
        };
        public static R Purple { get; } = new R
        {
            contentColor = ColorReg.Purple.Box,
            headerColor = ColorReg.Purple.BoxHeader,
            headerTextColor = ColorReg.Purple.BoxHeaderText,
            outlineColor = ColorReg.Purple.BoxOutline
        };
        public static R Brown { get; } = new R
        {
            contentColor = ColorReg.Brown.Box,
            headerColor = ColorReg.Brown.BoxHeader,
            headerTextColor = ColorReg.Brown.BoxHeaderText,
            outlineColor = ColorReg.Brown.BoxOutline
        };
        public static R Gold { get; } = new R
        {
            contentColor = ColorReg.Gold.Box,
            headerColor = ColorReg.Gold.BoxHeader,
            headerTextColor = ColorReg.Gold.BoxHeaderText,
            outlineColor = ColorReg.Gold.BoxOutline
        };
        public static R Orange { get; } = new R
        {
            contentColor = ColorReg.Orange.Box,
            headerColor = ColorReg.Orange.BoxHeader,
            headerTextColor = ColorReg.Orange.BoxHeaderText,
            outlineColor = ColorReg.Orange.BoxOutline
        };
        public static R Yellow { get; } = new R
        {
            contentColor = ColorReg.Yellow.Box,
            headerColor = ColorReg.Yellow.BoxHeader,
            headerTextColor = ColorReg.Yellow.BoxHeaderText,
            outlineColor = ColorReg.Yellow.BoxOutline
        };
        public static R Lime { get; } = new R
        {
            contentColor = ColorReg.Lime.Box,
            headerColor = ColorReg.Lime.BoxHeader,
            headerTextColor = ColorReg.Lime.BoxHeaderText,
            outlineColor = ColorReg.Lime.BoxOutline
        };
        public static R Mint { get; } = new R
        {
            contentColor = ColorReg.Mint.Box,
            headerColor = ColorReg.Mint.BoxHeader,
            headerTextColor = ColorReg.Mint.BoxHeaderText,
            outlineColor = ColorReg.Mint.BoxOutline
        };
        public static R Cyan { get; } = new R
        {
            contentColor = ColorReg.Cyan.Box,
            headerColor = ColorReg.Cyan.BoxHeader,
            headerTextColor = ColorReg.Cyan.BoxHeaderText,
            outlineColor = ColorReg.Cyan.BoxOutline
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
        public static new FoldoutHeaderBox Magenta { get; } = new FoldoutHeaderBox
        {
            contentColor = ColorReg.Magenta.Box,
            headerColor = ColorReg.Magenta.BoxHeader,
            headerHoverColor = ColorReg.Magenta.BoxHeaderHover,
            headerTextColor = ColorReg.Magenta.BoxHeaderText,
            outlineColor = ColorReg.Magenta.BoxOutline
        };
        public static new FoldoutHeaderBox Violet { get; } = new FoldoutHeaderBox
        {
            contentColor = ColorReg.Violet.Box,
            headerColor = ColorReg.Violet.BoxHeader,
            headerHoverColor = ColorReg.Violet.BoxHeaderHover,
            headerTextColor = ColorReg.Violet.BoxHeaderText,
            outlineColor = ColorReg.Violet.BoxOutline
        };
        public static new FoldoutHeaderBox Purple { get; } = new FoldoutHeaderBox
        {
            contentColor = ColorReg.Purple.Box,
            headerColor = ColorReg.Purple.BoxHeader,
            headerHoverColor = ColorReg.Purple.BoxHeaderHover,
            headerTextColor = ColorReg.Purple.BoxHeaderText,
            outlineColor = ColorReg.Purple.BoxOutline
        };
        public static new FoldoutHeaderBox Brown { get; } = new FoldoutHeaderBox
        {
            contentColor = ColorReg.Brown.Box,
            headerColor = ColorReg.Brown.BoxHeader,
            headerHoverColor = ColorReg.Brown.BoxHeaderHover,
            headerTextColor = ColorReg.Brown.BoxHeaderText,
            outlineColor = ColorReg.Brown.BoxOutline
        };
        public static new FoldoutHeaderBox Gold { get; } = new FoldoutHeaderBox
        {
            contentColor = ColorReg.Gold.Box,
            headerColor = ColorReg.Gold.BoxHeader,
            headerHoverColor = ColorReg.Gold.BoxHeaderHover,
            headerTextColor = ColorReg.Gold.BoxHeaderText,
            outlineColor = ColorReg.Gold.BoxOutline
        };
        public static new FoldoutHeaderBox Orange { get; } = new FoldoutHeaderBox
        {
            contentColor = ColorReg.Orange.Box,
            headerColor = ColorReg.Orange.BoxHeader,
            headerHoverColor = ColorReg.Orange.BoxHeaderHover,
            headerTextColor = ColorReg.Orange.BoxHeaderText,
            outlineColor = ColorReg.Orange.BoxOutline
        };
        public static new FoldoutHeaderBox Yellow { get; } = new FoldoutHeaderBox
        {
            contentColor = ColorReg.Yellow.Box,
            headerColor = ColorReg.Yellow.BoxHeader,
            headerHoverColor = ColorReg.Yellow.BoxHeaderHover,
            headerTextColor = ColorReg.Yellow.BoxHeaderText,
            outlineColor = ColorReg.Yellow.BoxOutline
        };
        public static new FoldoutHeaderBox Lime { get; } = new FoldoutHeaderBox
        {
            contentColor = ColorReg.Lime.Box,
            headerColor = ColorReg.Lime.BoxHeader,
            headerHoverColor = ColorReg.Lime.BoxHeaderHover,
            headerTextColor = ColorReg.Lime.BoxHeaderText,
            outlineColor = ColorReg.Lime.BoxOutline
        };
        public static new FoldoutHeaderBox Mint { get; } = new FoldoutHeaderBox
        {
            contentColor = ColorReg.Mint.Box,
            headerColor = ColorReg.Mint.BoxHeader,
            headerHoverColor = ColorReg.Mint.BoxHeaderHover,
            headerTextColor = ColorReg.Mint.BoxHeaderText,
            outlineColor = ColorReg.Mint.BoxOutline
        };
        public static new FoldoutHeaderBox Cyan { get; } = new FoldoutHeaderBox
        {
            contentColor = ColorReg.Cyan.Box,
            headerColor = ColorReg.Cyan.BoxHeader,
            headerHoverColor = ColorReg.Cyan.BoxHeaderHover,
            headerTextColor = ColorReg.Cyan.BoxHeaderText,
            outlineColor = ColorReg.Cyan.BoxOutline
        };
    }
    public partial class HelpBox
    {
        public static HelpBox Gray { get; } = new HelpBox { };
        public static HelpBox White { get; } = new HelpBox
        {
            textColor = ColorReg.White.HelpBoxText,
            backgroundColor = ColorReg.White.HelpBox
        };
        public static HelpBox Black { get; } = new HelpBox
        {
            textColor = ColorReg.Black.HelpBoxText,
            backgroundColor = ColorReg.Black.HelpBox
        };
        public static HelpBox Red { get; } = new HelpBox
        {
            textColor = ColorReg.Red.HelpBoxText,
            backgroundColor = ColorReg.Red.HelpBox
        };
        public static HelpBox Green { get; } = new HelpBox
        {
            textColor = ColorReg.Green.HelpBoxText,
            backgroundColor = ColorReg.Green.HelpBox
        };
        public static HelpBox Blue { get; } = new HelpBox
        {
            textColor = ColorReg.Blue.HelpBoxText,
            backgroundColor = ColorReg.Blue.HelpBox
        };
        public static HelpBox Pink { get; } = new HelpBox
        {
            textColor = ColorReg.Pink.HelpBoxText,
            backgroundColor = ColorReg.Pink.HelpBox
        };
        public static HelpBox Magenta { get; } = new HelpBox
        {
            textColor = ColorReg.Magenta.HelpBoxText,
            backgroundColor = ColorReg.Magenta.HelpBox
        };
        public static HelpBox Violet { get; } = new HelpBox
        {
            textColor = ColorReg.Violet.HelpBoxText,
            backgroundColor = ColorReg.Violet.HelpBox
        };
        public static HelpBox Purple { get; } = new HelpBox
        {
            textColor = ColorReg.Purple.HelpBoxText,
            backgroundColor = ColorReg.Purple.HelpBox
        };
        public static HelpBox Brown { get; } = new HelpBox
        {
            textColor = ColorReg.Brown.HelpBoxText,
            backgroundColor = ColorReg.Brown.HelpBox
        };
        public static HelpBox Gold { get; } = new HelpBox
        {
            textColor = ColorReg.Gold.HelpBoxText,
            backgroundColor = ColorReg.Gold.HelpBox
        };
        public static HelpBox Orange { get; } = new HelpBox
        {
            textColor = ColorReg.Orange.HelpBoxText,
            backgroundColor = ColorReg.Orange.HelpBox
        };
        public static HelpBox Yellow { get; } = new HelpBox
        {
            textColor = ColorReg.Yellow.HelpBoxText,
            backgroundColor = ColorReg.Yellow.HelpBox
        };
        public static HelpBox Lime { get; } = new HelpBox
        {
            textColor = ColorReg.Lime.HelpBoxText,
            backgroundColor = ColorReg.Lime.HelpBox
        };
        public static HelpBox Mint { get; } = new HelpBox
        {
            textColor = ColorReg.Mint.HelpBoxText,
            backgroundColor = ColorReg.Mint.HelpBox
        };
        public static HelpBox Cyan { get; } = new HelpBox
        {
            textColor = ColorReg.Cyan.HelpBoxText,
            backgroundColor = ColorReg.Cyan.HelpBox
        };
    }
}

#endif