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
    public partial class HelpBox : DrawingElement<None, HelpBox>
    {
        public static HelpBox Default => ThemeDict[EzEditorUtility.DefaultColorTheme];
        public static readonly Dictionary<EColor, HelpBox> ThemeDict = new Dictionary<EColor, HelpBox>()
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

        // Data
        protected string text = "";
        protected MessageType messageType;

        // Styles
        public Color textColor = Color.white;
        public Color backgroundColor = Color.white;
        public int fontSize = 10;
        public FontStyle fontStyle = FontStyle.Normal;
        public TextAnchor textAlignment = TextAnchor.MiddleLeft;

        public override HelpBox Clone()
        {
            return new HelpBox
            {
                textColor = textColor,
                backgroundColor = backgroundColor,
                fontSize = fontSize,
                fontStyle = fontStyle,
                textAlignment = textAlignment,
            };
        }

        /***********************************************************************
        *                               Style Setters
        ***********************************************************************/
        #region .

        public HelpBox SetTextColor(Color color)
        {
            this.textColor = color;
            return this;
        }
        public HelpBox SetBackgroundColor(Color color)
        {
            this.backgroundColor = color;
            return this;
        }
        public HelpBox SetFontSize(int fontSize)
        {
            this.fontSize = fontSize;
            return this;
        }
        public HelpBox SetFontStyle(FontStyle fontStyle)
        {
            this.fontStyle = fontStyle;
            return this;
        }
        public HelpBox SetTextAlignment(TextAnchor allignment)
        {
            this.textAlignment = allignment;
            return this;
        }

        #endregion

        public HelpBox SetData(string text, MessageType messageType)
        {
            this.text = text;
            this.messageType = messageType;
            return this;
        }

        public override HelpBox Draw(float xLeft, float xRight, float yOffset, float height,
            float xLeftOffset = 0f, float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this;
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            var oldBackgroundColor = GUI.backgroundColor;

            var helpBoxStyle = EditorStyles.helpBox;
            var oldTextColor = helpBoxStyle.normal.textColor;
            var oldFontSize = helpBoxStyle.fontSize;
            var oldFontStyle = helpBoxStyle.fontStyle;
            var oldAlignment = helpBoxStyle.alignment;

            GUI.backgroundColor = backgroundColor.SetA(100f);
            helpBoxStyle.normal.textColor = textColor;
            helpBoxStyle.fontSize = fontSize;
            helpBoxStyle.fontStyle = fontStyle;
            helpBoxStyle.alignment = textAlignment;

            EditorGUI.HelpBox(rect, text, messageType);

            GUI.backgroundColor = oldBackgroundColor;
            helpBoxStyle.normal.textColor = oldTextColor;
            helpBoxStyle.fontSize = oldFontSize;
            helpBoxStyle.fontStyle = oldFontStyle;
            helpBoxStyle.alignment = oldAlignment;

            CheckDebugs();
            EndDraw();
            return this;
        }
    }
}

#endif