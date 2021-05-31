using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 날짜 : 2021-05-31 AM 2:44:14
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    static class ColorReg
    {
        public static class White
        {
            public static readonly Color Label = RColor.white * 10f;
            public static readonly Color InputBG = RColor.white * 5f;
            public static readonly Color InputText = RColor.black;
            public static readonly Color InputTextFocused = RColor.black;
            public static readonly Color ColorPicker = RColor.White * 5f;
            public static readonly Color Toggle = RColor.White * 10f;

            public static readonly Color Box = RColor.Gray.Darker;
            public static readonly Color BoxHeader = RColor.white;
            public static readonly Color BoxHeaderHover = RColor.Gray7;
            public static readonly Color BoxHeaderText = RColor.black;
            public static readonly Color BoxOutline = RColor.black;

            public static readonly Color Button = RColor.White * 2.8f;
            public static readonly Color ButtonPressed = RColor.White * 2.2f;
            public static readonly Color ButtonText = RColor.Black;
            public static readonly Color ButtonTextPressed = RColor.Gray.Darker;

            public static readonly Color HelpBox = RColor.White * 10f;
            public static readonly Color HelpBoxText = RColor.Black;
        }
        public static class Black
        {
            public static readonly Color Label = RColor.Black;
            public static readonly Color InputBG = RColor.Black;
            public static readonly Color InputText = RColor.white;
            public static readonly Color InputTextFocused = RColor.Gray.Bright;
            public static readonly Color ColorPicker = RColor.Black;
            public static readonly Color Toggle = RColor.White;

            public static readonly Color Box = RColor.Gray.Bright;
            public static readonly Color BoxHeader = RColor.black;
            public static readonly Color BoxHeaderHover = RColor.Gray3;
            public static readonly Color BoxHeaderText = RColor.white;
            public static readonly Color BoxOutline = RColor.Gray.Darker;

            public static readonly Color Button = RColor.Black;
            public static readonly Color ButtonPressed = RColor.Gray;
            public static readonly Color ButtonText = RColor.White;
            public static readonly Color ButtonTextPressed = RColor.Gray.Bright;

            public static readonly Color HelpBox = RColor.Black;
            public static readonly Color HelpBoxText = RColor.White;
        }
        public static class Red
        {
            public static readonly Color Label = RColor.Red.Bright;
            public static readonly Color InputBG = RColor.Red.Normal * 2f;
            public static readonly Color InputText = RColor.white;
            public static readonly Color InputTextFocused = RColor.Red.Bright;
            public static readonly Color ColorPicker = RColor.Red.Normal * 5f;
            public static readonly Color Toggle = RColor.Red.Soft;

            public static readonly Color Box = RColor.black.SetR(0.1f);
            public static readonly Color BoxHeader = RColor.Red.Light;
            public static readonly Color BoxHeaderHover = RColor.Red.Bright;
            public static readonly Color BoxHeaderText = RColor.Black;
            public static readonly Color BoxOutline = RColor.Red.Dark;

            public static readonly Color Button = RColor.Red.Normal * 2f;
            public static readonly Color ButtonPressed = RColor.Red.Normal * 2.8f;
            public static readonly Color ButtonText = RColor.White;
            public static readonly Color ButtonTextPressed = RColor.Red.Bright;

            public static readonly Color HelpBox = RColor.Red.Normal * 1.5f;
            public static readonly Color HelpBoxText = RColor.White;
        }
        public static class Green
        {
            public static readonly Color Label = RColor.Green;
            public static readonly Color InputBG = RColor.Green.Soft;
            public static readonly Color InputText = RColor.white;
            public static readonly Color InputTextFocused = RColor.Green.Bright;
            public static readonly Color ColorPicker = RColor.Green.Normal * 5f;
            public static readonly Color Toggle = RColor.Green.Soft;

            public static readonly Color Box = RColor.black.SetG(0.1f);
            public static readonly Color BoxHeader = RColor.Green.Light;
            public static readonly Color BoxHeaderHover = RColor.Green.Bright;
            public static readonly Color BoxHeaderText = RColor.Black;
            public static readonly Color BoxOutline = RColor.Green.Dark;

            public static readonly Color Button = RColor.Green.Normal * 1.5f;
            public static readonly Color ButtonPressed = RColor.Green.Normal * 2f;
            public static readonly Color ButtonText = RColor.White;
            public static readonly Color ButtonTextPressed = RColor.Green.Bright;

            public static readonly Color HelpBox = RColor.Green.Soft;
            public static readonly Color HelpBoxText = RColor.White;
        }
        public static class Blue
        {
            public static readonly Color Label = RColor.Blue.Soft.MultiplyRGB(2.8f);
            public static readonly Color InputBG = RColor.Blue.Soft.MultiplyRGB(2f);
            public static readonly Color InputText = RColor.white;
            public static readonly Color InputTextFocused = RColor.Blue.Bright;
            public static readonly Color ColorPicker = RColor.Blue.Normal * 5f;
            public static readonly Color Toggle = RColor.Blue.Soft;

            public static readonly Color Box = RColor.black.SetB(0.1f);
            public static readonly Color BoxHeader = RColor.Blue.Light;
            public static readonly Color BoxHeaderHover = RColor.Blue.Bright;
            public static readonly Color BoxHeaderText = RColor.Black;
            public static readonly Color BoxOutline = RColor.Blue.Normal;

            public static readonly Color Button = RColor.Blue.Normal * 1.5f;
            public static readonly Color ButtonPressed = RColor.Blue.Normal * 2f;
            public static readonly Color ButtonText = RColor.White;
            public static readonly Color ButtonTextPressed = RColor.Blue.Bright;

            public static readonly Color HelpBox = RColor.Blue.Soft * 1.5f;
            public static readonly Color HelpBoxText = RColor.White;
        }
        public static class Pink
        {
            public static readonly Color Label = RColor.Pink.Bright;
            public static readonly Color InputBG = RColor.Pink.Soft.MultiplyRGB(2f);
            public static readonly Color InputText = RColor.white;
            public static readonly Color InputTextFocused = RColor.Pink.Bright;
            public static readonly Color ColorPicker = RColor.Pink.Normal * 5f;
            public static readonly Color Toggle = RColor.Pink.Soft * 2f;

            public static readonly Color Box = RColor.Pink.Darker.MultiplyRGB(0.2f);
            public static readonly Color BoxHeader = RColor.Pink.Light.AddRGB(0.1f);
            public static readonly Color BoxHeaderHover = RColor.Pink.Bright;
            public static readonly Color BoxHeaderText = RColor.Black;
            public static readonly Color BoxOutline = RColor.Pink.Dark;

            public static readonly Color Button = RColor.Pink.Soft * 2f;
            public static readonly Color ButtonPressed = RColor.Pink.Soft * 3f;
            public static readonly Color ButtonText = RColor.White;
            public static readonly Color ButtonTextPressed = RColor.Pink.Bright;

            public static readonly Color HelpBox = RColor.Pink.Soft * 2f;
            public static readonly Color HelpBoxText = RColor.White;
        }
        public static class Magenta
        {
            public static readonly Color Label = RColor.Magenta.Bright;
            public static readonly Color InputBG = RColor.Magenta.Soft.MultiplyRGB(2f);
            public static readonly Color InputText = RColor.white;
            public static readonly Color InputTextFocused = RColor.Magenta.Bright;
            public static readonly Color ColorPicker = RColor.Magenta.Normal * 5f;
            public static readonly Color Toggle = RColor.Magenta.Soft * 2f;

            public static readonly Color Box = RColor.Magenta.Darker.MultiplyRGB(0.2f);
            public static readonly Color BoxHeader = RColor.Magenta.Light.AddRGB(0.1f);
            public static readonly Color BoxHeaderHover = RColor.Magenta.Bright;
            public static readonly Color BoxHeaderText = RColor.Black;
            public static readonly Color BoxOutline = RColor.Magenta.Dark;

            public static readonly Color Button = RColor.Magenta.Soft * 2f;
            public static readonly Color ButtonPressed = RColor.Magenta.Soft * 3f;
            public static readonly Color ButtonText = RColor.White;
            public static readonly Color ButtonTextPressed = RColor.Magenta.Bright;

            public static readonly Color HelpBox = RColor.Magenta.Soft * 2f;
            public static readonly Color HelpBoxText = RColor.White;
        }
        public static class Violet
        {
            public static readonly Color Label = RColor.Violet.Bright;
            public static readonly Color InputBG = RColor.Violet.Soft.MultiplyRGB(2f);
            public static readonly Color InputText = RColor.white;
            public static readonly Color InputTextFocused = RColor.Violet.Bright;
            public static readonly Color ColorPicker = RColor.Violet.Normal * 5f;
            public static readonly Color Toggle = RColor.Violet.Soft * 2f;

            public static readonly Color Box = RColor.Violet.Darker.MultiplyRGB(0.2f);
            public static readonly Color BoxHeader = RColor.Violet.Light.AddRGB(0.1f);
            public static readonly Color BoxHeaderHover = RColor.Violet.Bright;
            public static readonly Color BoxHeaderText = RColor.Black;
            public static readonly Color BoxOutline = RColor.Violet.Dark;

            public static readonly Color Button = RColor.Violet.Soft * 2f;
            public static readonly Color ButtonPressed = RColor.Violet.Soft * 3f;
            public static readonly Color ButtonText = RColor.White;
            public static readonly Color ButtonTextPressed = RColor.Violet.Bright;

            public static readonly Color HelpBox = RColor.Violet.Soft * 2f;
            public static readonly Color HelpBoxText = RColor.White;
        }
        public static class Purple
        {
            public static readonly Color Label = RColor.Purple.Bright;
            public static readonly Color InputBG = RColor.Purple.Soft.MultiplyRGB(2f);
            public static readonly Color InputText = RColor.white;
            public static readonly Color InputTextFocused = RColor.Purple.Bright;
            public static readonly Color ColorPicker = RColor.Purple.Normal * 5f;
            public static readonly Color Toggle = RColor.Purple.Soft * 2f;

            public static readonly Color Box = RColor.Purple.Darker.MultiplyRGB(0.2f);
            public static readonly Color BoxHeader = RColor.Purple.Light.AddRGB(0.1f);
            public static readonly Color BoxHeaderHover = RColor.Purple.Bright;
            public static readonly Color BoxHeaderText = RColor.Black;
            public static readonly Color BoxOutline = RColor.Purple.Dark;

            public static readonly Color Button = RColor.Purple.Soft * 2f;
            public static readonly Color ButtonPressed = RColor.Purple.Soft * 3f;
            public static readonly Color ButtonText = RColor.White;
            public static readonly Color ButtonTextPressed = RColor.Purple.Bright;

            public static readonly Color HelpBox = RColor.Purple.Soft * 2f;
            public static readonly Color HelpBoxText = RColor.White;
        }
        public static class Brown
        {
            public static readonly Color Label = RColor.Brown.Bright.AddRGB(0.2f);
            public static readonly Color InputBG = RColor.Brown.Soft.MultiplyRGB(2f);
            public static readonly Color InputText = RColor.white;
            public static readonly Color InputTextFocused = RColor.Brown.Bright;
            public static readonly Color ColorPicker = RColor.Brown.Normal * 5f;
            public static readonly Color Toggle = RColor.Brown.Soft * 2f;

            public static readonly Color Box = RColor.Brown.Darker.MultiplyRGB(0.2f);
            public static readonly Color BoxHeader = RColor.Brown.Light.AddRGB(0.4f);
            public static readonly Color BoxHeaderHover = RColor.Brown.Bright.AddRGB(0.4f);
            public static readonly Color BoxHeaderText = RColor.Black;
            public static readonly Color BoxOutline = RColor.Brown.Dark;

            public static readonly Color Button = RColor.Brown.Soft * 2f;
            public static readonly Color ButtonPressed = RColor.Brown.Soft * 3f;
            public static readonly Color ButtonText = RColor.White;
            public static readonly Color ButtonTextPressed = RColor.Brown.Bright;

            public static readonly Color HelpBox = RColor.Brown.Soft * 2f;
            public static readonly Color HelpBoxText = RColor.White;
        }
        public static class Gold
        {
            public static readonly Color Label = RColor.Gold.Bright;
            public static readonly Color InputBG = RColor.Gold.Soft.MultiplyRGB(2.4f);
            public static readonly Color InputText = RColor.Black;
            public static readonly Color InputTextFocused = RColor.Gold.Darker;
            public static readonly Color ColorPicker = RColor.Gold.Normal * 5f;
            public static readonly Color Toggle = RColor.Gold.Soft * 2f;

            public static readonly Color Box = RColor.Gold.Darker.MultiplyRGB(0.2f);
            public static readonly Color BoxHeader = RColor.Gold.Light.AddRGB(0.1f);
            public static readonly Color BoxHeaderHover = RColor.White;
            public static readonly Color BoxHeaderText = RColor.Black;
            public static readonly Color BoxOutline = RColor.Gold.Dark;

            public static readonly Color Button = RColor.Gold.Soft * 2f;
            public static readonly Color ButtonPressed = RColor.Gold.Soft * 3f;
            public static readonly Color ButtonText = RColor.Black;
            public static readonly Color ButtonTextPressed = RColor.Gold.Darker;

            public static readonly Color HelpBox = RColor.Gold.Soft * 2f;
            public static readonly Color HelpBoxText = RColor.Black;
        }
        public static class Orange
        {
            public static readonly Color Label = RColor.Orange.Bright;
            public static readonly Color InputBG = RColor.Orange.Soft.MultiplyRGB(2f);
            public static readonly Color InputText = RColor.white;
            public static readonly Color InputTextFocused = RColor.Orange.Bright;
            public static readonly Color ColorPicker = RColor.Orange.Normal * 5f;
            public static readonly Color Toggle = RColor.Orange.Soft * 2f;

            public static readonly Color Box = RColor.Orange.Darker.MultiplyRGB(0.2f);
            public static readonly Color BoxHeader = RColor.Orange.Light.AddRGB(0.1f);
            public static readonly Color BoxHeaderHover = RColor.White;
            public static readonly Color BoxHeaderText = RColor.Black;
            public static readonly Color BoxOutline = RColor.Orange.Dark;

            public static readonly Color Button = RColor.Orange.Soft * 2f;
            public static readonly Color ButtonPressed = RColor.Orange.Soft * 3f;
            public static readonly Color ButtonText = RColor.White;
            public static readonly Color ButtonTextPressed = RColor.Orange.Bright;

            public static readonly Color HelpBox = RColor.Orange.Soft * 2f;
            public static readonly Color HelpBoxText = RColor.White;
        }
        public static class Yellow
        {
            public static readonly Color Label = RColor.Yellow.Bright;
            public static readonly Color InputBG = RColor.Yellow.Soft * 3f;
            public static readonly Color InputText = RColor.Black;
            public static readonly Color InputTextFocused = RColor.Yellow.Darker;
            public static readonly Color ColorPicker = RColor.Yellow.Normal * 5f;
            public static readonly Color Toggle = RColor.Yellow.Soft * 2f;

            public static readonly Color Box = RColor.Yellow.Darker.MultiplyRGB(0.2f);
            public static readonly Color BoxHeader = RColor.Yellow.Light.AddRGB(0.1f);
            public static readonly Color BoxHeaderHover = RColor.White;
            public static readonly Color BoxHeaderText = RColor.Black;
            public static readonly Color BoxOutline = RColor.Yellow.Dark;

            public static readonly Color Button = RColor.Yellow.Soft * 3f;
            public static readonly Color ButtonPressed = RColor.Yellow.Soft * 3f;
            public static readonly Color ButtonText = RColor.Black;
            public static readonly Color ButtonTextPressed = RColor.Yellow.Darker;

            public static readonly Color HelpBox = RColor.Yellow.Soft * 2.5f;
            public static readonly Color HelpBoxText = RColor.Black;
        }
        public static class Lime
        {
            public static readonly Color Label = RColor.Lime.Bright;
            public static readonly Color InputBG = RColor.Lime.Soft * 3f;
            public static readonly Color InputText = RColor.Black;
            public static readonly Color InputTextFocused = RColor.Lime.Darker;
            public static readonly Color ColorPicker = RColor.Lime.Normal * 5f;
            public static readonly Color Toggle = RColor.Lime.Soft * 2f;

            public static readonly Color Box = RColor.Lime.Darker.MultiplyRGB(0.2f);
            public static readonly Color BoxHeader = RColor.Lime.Light.AddRGB(0.1f);
            public static readonly Color BoxHeaderHover = RColor.White;
            public static readonly Color BoxHeaderText = RColor.Black;
            public static readonly Color BoxOutline = RColor.Lime.Dark;

            public static readonly Color Button = RColor.Lime.Soft * 3f;
            public static readonly Color ButtonPressed = RColor.Lime.Soft * 3f;
            public static readonly Color ButtonText = RColor.Black;
            public static readonly Color ButtonTextPressed = RColor.Lime.Darker;

            public static readonly Color HelpBox = RColor.Lime.Soft * 2.5f;
            public static readonly Color HelpBoxText = RColor.Black;
        }
        public static class Mint
        {
            public static readonly Color Label = RColor.Mint.Bright;
            public static readonly Color InputBG = RColor.Mint.Soft * 3f;
            public static readonly Color InputText = RColor.Black;
            public static readonly Color InputTextFocused = RColor.Mint.Darker;
            public static readonly Color ColorPicker = RColor.Mint.Normal * 5f;
            public static readonly Color Toggle = RColor.Mint.Soft * 2f;

            public static readonly Color Box = RColor.Mint.Darker.MultiplyRGB(0.2f);
            public static readonly Color BoxHeader = RColor.Mint.Light.AddRGB(0.1f);
            public static readonly Color BoxHeaderHover = RColor.White;
            public static readonly Color BoxHeaderText = RColor.Black;
            public static readonly Color BoxOutline = RColor.Mint.Dark;

            public static readonly Color Button = RColor.Mint.Soft * 3f;
            public static readonly Color ButtonPressed = RColor.Mint.Soft * 3f;
            public static readonly Color ButtonText = RColor.Black;
            public static readonly Color ButtonTextPressed = RColor.Mint.Darker;

            public static readonly Color HelpBox = RColor.Mint.Soft * 2.5f;
            public static readonly Color HelpBoxText = RColor.Black;
        }
        public static class Cyan
        {
            public static readonly Color Label = RColor.Cyan.Bright;
            public static readonly Color InputBG = RColor.Cyan.Soft * 3f;
            public static readonly Color InputText = RColor.Black;
            public static readonly Color InputTextFocused = RColor.Cyan.Darker;
            public static readonly Color ColorPicker = RColor.Cyan.Normal * 5f;
            public static readonly Color Toggle = RColor.Cyan.Soft * 2f;

            public static readonly Color Box = RColor.Cyan.Darker.MultiplyRGB(0.2f);
            public static readonly Color BoxHeader = RColor.Cyan.Light.AddRGB(0.1f);
            public static readonly Color BoxHeaderHover = RColor.White;
            public static readonly Color BoxHeaderText = RColor.Black;
            public static readonly Color BoxOutline = RColor.Cyan.Dark;

            public static readonly Color Button = RColor.Cyan.Soft * 3f;
            public static readonly Color ButtonPressed = RColor.Cyan.Soft * 3f;
            public static readonly Color ButtonText = RColor.Black;
            public static readonly Color ButtonTextPressed = RColor.Cyan.Darker;

            public static readonly Color HelpBox = RColor.Cyan.Soft * 2.5f;
            public static readonly Color HelpBoxText = RColor.Black;
        }
    }
}