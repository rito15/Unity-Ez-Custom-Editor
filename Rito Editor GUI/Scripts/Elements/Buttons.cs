#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-06-02 PM 4:17:12
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    public partial class Button : DrawingElement<bool, Button>
    {
        public static Button Default { get; } = new Button();
        protected GUIStyle style;

        // Data
        protected string text = "";

        // Styles
        public Color textColor = Color.white;
        public Color pressedTextColor = RColor.Gray.Light;
        public TextAnchor textAlignment = TextAnchor.MiddleCenter;
        public int fontSize = 12;
        public FontStyle fontStyle = FontStyle.Normal;

        public Color buttonColor = Color.white;

        /***********************************************************************
        *                               Style Setters
        ***********************************************************************/
        #region .
        public Button SetTextColor(Color color)
        {
            this.textColor = color;
            return this;
        }
        public Button SetTextAlignment(TextAnchor alignment)
        {
            this.textAlignment = alignment;
            return this;
        }
        public Button SetFontSize(int fontSize)
        {
            this.fontSize = fontSize;
            return this;
        }
        public Button SetFontStyle(FontStyle fontStyle)
        {
            this.fontStyle = fontStyle;
            return this;
        }
        public Button SetButtonColor(Color color)
        {
            this.buttonColor = color;
            return this;
        }

        #endregion

        public Button SetData(string text)
        {
            this.text = text;
            return this;
        }

        public override Button Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this;
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (style == null)
                style = new GUIStyle(GUI.skin.button);

            var oldBackgroundColor = GUI.backgroundColor;
            GUI.backgroundColor = buttonColor;
            style.normal.textColor = textColor;
            style.hover.textColor = textColor.AddRGB(0.25f);
            style.focused.textColor = textColor.AddRGB(0.25f);
            style.active.textColor = pressedTextColor;

            // 모두 먹통
            //style.onActive.textColor = Color.red;
            //style.onFocused.textColor = Color.blue;
            //style.onHover.textColor = Color.green;
            //style.onNormal.textColor = Color.magenta;

            style.fontSize = fontSize;
            style.fontStyle = fontStyle;
            style.alignment = textAlignment;

            value = GUI.Button(rect, text, style);

            GUI.backgroundColor = oldBackgroundColor;

            EndDraw();
            return this;
        }
    }
    public partial class ToggleButton : DrawingElement<bool, ToggleButton>
    {
        public static ToggleButton Default { get; } = new ToggleButton();
        protected GUIStyle style;

        // Data
        protected string label = "Toggle Button";

        // Styles
        public int fontSize = 12;
        public TextAnchor textAlignment = TextAnchor.MiddleCenter;

        // Styles - Button Normal
        public Color normalTextColor = Color.white;
        public Color normalButtonColor = Color.white;
        public FontStyle normalFontStyle = FontStyle.Normal;

        // Styles - Button Pressed
        public Color pressedTextColor = Color.white;
        public Color pressedButtonColor = Color.white * 1.5f;
        public FontStyle pressedFontStyle = FontStyle.Bold;


        /***********************************************************************
        *                               Style Setters
        ***********************************************************************/
        #region .
        public ToggleButton SetFontSize(int fontSize)
        {
            this.fontSize = fontSize;
            return this;
        }
        public ToggleButton SetTextAlignment(TextAnchor alignment)
        {
            this.textAlignment = alignment;
            return this;
        }

        public ToggleButton SetTextColor(Color color)
        {
            this.normalTextColor = color;
            this.pressedTextColor = color;
            return this;
        }
        public ToggleButton SetButtonColor(Color color)
        {
            this.normalButtonColor = color;
            this.pressedButtonColor = color;
            return this;
        }
        public ToggleButton SetFontStyle(FontStyle fontStyle)
        {
            this.normalFontStyle = fontStyle;
            this.pressedFontStyle = fontStyle;
            return this;
        }

        public ToggleButton SetNormalTextColor(Color color)
        {
            this.normalTextColor = color;
            return this;
        }
        public ToggleButton SetNormalButtonColor(Color color)
        {
            this.normalButtonColor = color;
            return this;
        }
        public ToggleButton SetNormalFontStyle(FontStyle fontStyle)
        {
            this.normalFontStyle = fontStyle;
            return this;
        }

        public ToggleButton SetPressedTextColor(Color color)
        {
            this.pressedTextColor = color;
            return this;
        }
        public ToggleButton SetPressedButtonColor(Color color)
        {
            this.pressedButtonColor = color;
            return this;
        }
        public ToggleButton SetPressedFontStyle(FontStyle fontStyle)
        {
            this.pressedFontStyle = fontStyle;
            return this;
        }

        #endregion

        public ToggleButton SetData(string label, bool value)
        {
            this.label = label;
            this.value = value;
            return this;
        }

        public override ToggleButton Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this;
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (style == null)
                style = new GUIStyle(GUI.skin.button);

            var oldBackgroundColor = GUI.backgroundColor;
            GUI.backgroundColor = value ? pressedButtonColor : normalButtonColor;

            style.normal.textColor = value ? pressedTextColor : normalTextColor;
            style.hover.textColor = normalTextColor.AddRGB(0.25f);
            style.focused.textColor = normalTextColor.AddRGB(0.25f);
            style.active.textColor = pressedTextColor;

            style.fontSize = fontSize;
            style.fontStyle = value ? pressedFontStyle : normalFontStyle;
            style.alignment = textAlignment;

            if (GUI.Button(rect, label, style))
                value = !value;

            GUI.backgroundColor = oldBackgroundColor;

            EndDraw();
            return this;
        }
    }
}

#endif