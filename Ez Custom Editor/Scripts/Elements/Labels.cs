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
    public abstract partial class LabelBase<R> : DrawingElement<string, R> where R : LabelBase<R>, new()
    {
        public static R Default
        {
            get
            {
                switch (EzEditorUtility.DefaultColorTheme)
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
        public static R Bold { get; } = new R { fontStyle = FontStyle.Bold };

        protected GUIStyle style;

        // Styles
        public Color textColor = Color.white;
        public TextAnchor textAlignment = TextAnchor.MiddleLeft;
        public int fontSize = 12;
        public FontStyle fontStyle = FontStyle.Normal;

        public override R Clone()
        {
            return new R
            {
                textColor = textColor,
                textAlignment = textAlignment,
                fontSize = fontSize,
                fontStyle = fontStyle,
            };
        }

        /***********************************************************************
        *                               Style Setters
        ***********************************************************************/
        #region .
        public R SetTextColor(Color color)
        {
            this.textColor = color;
            return this as R;
        }
        public R SetTextAlignment(TextAnchor alignment)
        {
            this.textAlignment = alignment;
            return this as R;
        }
        public R SetFontSize(int fontSize)
        {
            this.fontSize = fontSize;
            return this as R;
        }
        public R SetFontStyle(FontStyle fontStyle)
        {
            this.fontStyle = fontStyle;
            return this as R;
        }

        #endregion

        public R SetData(string text)
        {
            this.value = text;
            return this as R;
        }

        public override R Draw(float xLeft, float xRight, float yOffset, float height,
            float xLeftOffset = 0f, float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this as R;
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (style == null)
                style = new GUIStyle(GUI.skin.label);

            style.normal.textColor = textColor;
            style.hover.textColor =
            style.active.textColor =
            style.focused.textColor = textColor.AddRGB(0.25f);
            style.fontSize = fontSize;
            style.fontStyle = fontStyle;
            style.alignment = textAlignment;

            DrawLabel(rect, style);

            CheckDebugs();
            EndDraw();
            return this as R;
        }

        protected abstract void DrawLabel(in Rect rect, GUIStyle style);
    }
    public class Label : LabelBase<Label>
    {
        protected override void DrawLabel(in Rect rect, GUIStyle style)
        {
            EditorGUI.LabelField(rect, value, style);
        }
    }
    public class SelectableLabel : LabelBase<SelectableLabel>
    {
        protected override void DrawLabel(in Rect rect, GUIStyle style)
        {
            EditorGUI.SelectableLabel(rect, value, style);
        }
    }
    public class EditableLabel : LabelBase<EditableLabel>
    {
        protected override void DrawLabel(in Rect rect, GUIStyle style)
        {
            string focusedName = GUI.GetNameOfFocusedControl();

            if (focusedName != "TextArea")
            {
                GUI.SetNextControlName("Label");
                EditorGUI.SelectableLabel(rect, value, style);
            }

            if (focusedName == "Label" || focusedName == "TextArea")
            {
                EditorGUI.BeginChangeCheck();

                GUI.SetNextControlName("TextArea");
                value = EditorGUI.TextArea(rect, value);
                GUI.FocusControl("TextArea");

                isChanged = EditorGUI.EndChangeCheck();
            }
        }
    }
}

#endif