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
    using EZU = EzEditorUtility;

    public partial class TextArea : DrawingElement<string, TextArea>
    {
        public static TextArea Default => ThemeDict[EzEditorUtility.DefaultColorTheme];
        public static readonly Dictionary<EColor, TextArea> ThemeDict = new Dictionary<EColor, TextArea>()
        {
            { EColor.Gray   , Gray    },
            { EColor.White  , White   },
            { EColor.Black  , Black   },
            { EColor.Red    , Red     },
            { EColor.Green  , Green   },
            { EColor.Blue   , Blue    },
            { EColor.Pink   , Pink    },
            { EColor.Magenta, Magenta },
            { EColor.Violet , Violet  },
            { EColor.Purple , Purple  },
            { EColor.Brown  , Brown   },
            { EColor.Gold   , Gold    },
            { EColor.Orange , Orange  },
            { EColor.Yellow , Yellow  },
            { EColor.Lime   , Lime    },
            { EColor.Mint   , Mint    },
            { EColor.Cyan   , Cyan    },
        };
        protected GUIStyle inputStyle;

        // Data
        protected string placeholder = "";

        // Styles - Input Field
        public Color textColor = Color.white;
        public Color textFocusedColor = Color.white;
        public Color backgroundColor = Color.white;
        public int fontSize = 12;
        public FontStyle fontStyle = FontStyle.Normal;
        public TextAnchor textAlignment = TextAnchor.MiddleLeft;

        public override TextArea Clone()
        {
            return new TextArea
            {
                textColor = textColor,
                textFocusedColor = textFocusedColor,
                backgroundColor = backgroundColor,
                fontSize = fontSize,
                fontStyle = fontStyle,
                textAlignment = textAlignment
            };
        }

        /***********************************************************************
        *                               Style Setters
        ***********************************************************************/
        #region .

        public TextArea SetTextColor(Color color)
        {
            this.textColor = color;
            return this;
        }
        public TextArea SetTextFocusedColor(Color color)
        {
            this.textFocusedColor = color;
            return this;
        }
        public TextArea SetBackgroundColor(Color color)
        {
            this.backgroundColor = color;
            return this;
        }
        public TextArea SetFontSize(int fontSize)
        {
            this.fontSize = fontSize;
            return this;
        }
        public TextArea SetFontStyle(FontStyle fontStyle)
        {
            this.fontStyle = fontStyle;
            return this;
        }
        public TextArea SetTextAlignment(TextAnchor allignment)
        {
            this.textAlignment = allignment;
            return this;
        }

        #endregion

        public TextArea SetData(string value, string placeholder = "")
        {
            this.value = value;
            this.placeholder = placeholder;
            return this;
        }

        public override TextArea Draw(float xLeft, float xRight, float yOffset, float height,
            float xLeftOffset = 0f, float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this;
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (inputStyle == null)
                inputStyle = new GUIStyle(GUI.skin.textField);

            var oldBackgroundColor = GUI.backgroundColor;
            GUI.backgroundColor = backgroundColor * 2f;

            inputStyle.normal.textColor = textColor;
            inputStyle.hover.textColor = textColor.AddRGB(0.25f);
            inputStyle.focused.textColor = textFocusedColor;
            inputStyle.fontSize = fontSize;
            inputStyle.fontStyle = fontStyle;
            inputStyle.alignment = textAlignment;


            EditorGUI.BeginChangeCheck();

            GUI.SetNextControlName("TextField");
            value = EditorGUI.TextArea(rect, value, inputStyle);

            isChanged = EditorGUI.EndChangeCheck();

            // Placeholder
            inputStyle.normal.textColor = textColor.SetA(0.5f);
            if (string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(placeholder) &&
                !(GUI.GetNameOfFocusedControl() == "TextField"))
                EditorGUI.LabelField(rect, placeholder, inputStyle);

            GUI.backgroundColor = oldBackgroundColor;

            CheckDebugs();
            EndDraw();
            return this;
        }
        public TextArea DrawLayout(int lineCount)
        {
            if (lineCount < 1) lineCount = 1;
            float height = (EZU.LayoutControlHeight + EZU.LayoutControlBottomMargin) * lineCount;

            Draw(EZU.LayoutXLeft, EZU.LayoutXRight, 0f, height - EZU.LayoutControlBottomMargin,
                EZU.LayoutXLeftOffset, EZU.LayoutXRightOffset);
            EZU.Space(height);

            isLastLayout = true;
            return this;
        }
    }
}

#endif