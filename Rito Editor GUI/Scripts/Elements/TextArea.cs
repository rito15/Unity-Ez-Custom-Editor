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
    using REG = RitoEditorGUI;

    public partial class TextArea : DrawingElement<string, TextArea>
    {
        public static TextArea Default { get; } = new TextArea();
        protected GUIStyle inputStyle;

        // Data
        protected string placeholder = "";

        // Styles - Input Field
        public Color inputTextColor = Color.white;
        public Color inputBackgroundColor = Color.white;
        public int inputFontSize = 12;
        public FontStyle inputFontStyle = FontStyle.Normal;
        public TextAnchor inputTextAlignment = TextAnchor.MiddleLeft;

        public override TextArea Clone()
        {
            return new TextArea
            {
                inputTextColor = inputTextColor,
                inputBackgroundColor = inputBackgroundColor,
                inputFontSize = inputFontSize,
                inputFontStyle = inputFontStyle,
                inputTextAlignment = inputTextAlignment
            };
        }

        /***********************************************************************
        *                               Style Setters
        ***********************************************************************/
        #region .

        public TextArea SetTextColor(Color color)
        {
            this.inputTextColor = color;
            return this;
        }
        public TextArea SetBackgroundColor(Color color)
        {
            this.inputBackgroundColor = color;
            return this;
        }
        public TextArea SetFontSize(int fontSize)
        {
            this.inputFontSize = fontSize;
            return this;
        }
        public TextArea SetFontStyle(FontStyle fontStyle)
        {
            this.inputFontStyle = fontStyle;
            return this;
        }
        public TextArea SetTextAlignment(TextAnchor allignment)
        {
            this.inputTextAlignment = allignment;
            return this;
        }

        #endregion

        public TextArea SetData(string value, string placeholder = "")
        {
            this.value = value;
            this.placeholder = placeholder;
            return this;
        }

        public override TextArea Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this;
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (inputStyle == null)
                inputStyle = new GUIStyle(GUI.skin.textField);

            var oldBackgroundColor = GUI.backgroundColor;
            GUI.backgroundColor = inputBackgroundColor * 2f;

            inputStyle.normal.textColor = inputTextColor;
            inputStyle.hover.textColor = inputTextColor.AddRGB(0.25f);
            inputStyle.focused.textColor = inputTextColor.AddRGB(0.25f);
            inputStyle.fontSize = inputFontSize;
            inputStyle.fontStyle = inputFontStyle;
            inputStyle.alignment = inputTextAlignment;

            GUI.SetNextControlName("TextField");
            value = EditorGUI.TextArea(rect, value, inputStyle);

            // Placeholder
            inputStyle.normal.textColor = inputTextColor.SetA(0.5f);
            if (string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(placeholder) &&
                !(GUI.GetNameOfFocusedControl() == "TextField"))
                EditorGUI.LabelField(rect, placeholder, inputStyle);

            GUI.backgroundColor = oldBackgroundColor;

            EndDraw();
            return this;
        }
        public TextArea DrawLayout(int lineCount)
        {
            if (lineCount < 1) lineCount = 1;
            float height = (REG.LayoutControlHeight + REG.LayoutControlBottomMargin) * lineCount;

            Draw(REG.LayoutXLeft, REG.LayoutXRight, 0f, height - REG.LayoutControlBottomMargin,
                REG.LayoutXLeftOffset, REG.LayoutXRightOffset);
            REG.Space(height);

            isLastLayout = true;
            return this;
        }
    }
}

#endif