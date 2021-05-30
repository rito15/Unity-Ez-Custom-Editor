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
            //public static readonly Color Label = RColor.white;
            public static readonly Color InputBG = RColor.white * 5f;
            public static readonly Color InputText = RColor.black;
            public static readonly Color InputTextFocused = RColor.black;
            public static readonly Color ColorPicker = RColor.White * 5f;
            //public static readonly Color Toggle = RColor.White;

            public static readonly Color Box = RColor.Gray.Darker;
            public static readonly Color BoxHeader = RColor.white;
            public static readonly Color BoxHeaderHover = RColor.Gray7;
            public static readonly Color BoxHeaderText = RColor.black;
            public static readonly Color BoxOutline = RColor.black;
        }
        public static class Black
        {
            public static readonly Color Label = RColor.Black;
            public static readonly Color InputBG = RColor.Black;
            public static readonly Color InputText = RColor.white;
            public static readonly Color InputTextFocused = RColor.Gray.Bright;
            public static readonly Color ColorPicker = RColor.Black;
            //public static readonly Color Toggle = RColor.White;

            public static readonly Color Box = RColor.Gray.Bright;
            public static readonly Color BoxHeader = RColor.black;
            public static readonly Color BoxHeaderHover = RColor.Gray3;
            public static readonly Color BoxHeaderText = RColor.white;
            public static readonly Color BoxOutline = RColor.Gray.Darker;
        }
        public static class Red
        {
            public static readonly Color Label = RColor.Red.Bright;
            public static readonly Color InputBG = RColor.Red.Normal;
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
        }
    }
}