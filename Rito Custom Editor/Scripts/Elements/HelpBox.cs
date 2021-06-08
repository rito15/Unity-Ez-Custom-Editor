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
        public static HelpBox Default
        {
            get
            {
                switch (RitoEditorGUI.DefaultColorTheme)
                {
                    default:
                    case EColor.Gray:    return Gray;
                    case EColor.White:   return White;
                    case EColor.Black:   return Black;
                    case EColor.Red:     return Red;    
                    case EColor.Green:   return Green;  
                    case EColor.Blue:    return Blue;   
                    case EColor.Pink:    return Pink;   
                    case EColor.Magenta: return Magenta;
                    case EColor.Violet:  return Violet; 
                    case EColor.Purple:  return Purple; 
                    case EColor.Brown:   return Brown;  
                    case EColor.Gold:    return Gold;   
                    case EColor.Orange:  return Orange; 
                    case EColor.Yellow:  return Yellow; 
                    case EColor.Lime:    return Lime;   
                    case EColor.Mint:    return Mint;    
                    case EColor.Cyan:    return Cyan;   
                }
            }
        }

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