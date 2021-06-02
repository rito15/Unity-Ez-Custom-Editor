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
    public abstract partial class LabelBase<R> : DrawingElement<None, R> where R : LabelBase<R>, new()
    {
        public static R Default { get; } = new R();
        public static R Bold { get; } = new R { fontStyle = FontStyle.Bold };

        protected GUIStyle style;

        // Data
        protected string text;

        // Styles
        public Color textColor = Color.white;
        public TextAnchor textAlignment = TextAnchor.MiddleLeft;
        public int fontSize = 12;
        public FontStyle fontStyle = FontStyle.Normal;

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
            this.text = text;
            return this as R;
        }

        public override R Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
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

            DrawLabel(rect, text, style);

            EndDraw();

            return this as R;
        }

        protected abstract void DrawLabel(in Rect rect, in string text, GUIStyle style);
    }
    public class Label : LabelBase<Label>
    {
        protected override void DrawLabel(in Rect rect, in string text, GUIStyle style)
        {
            EditorGUI.LabelField(rect, text, style);
        }
    }
    public class SelectableLabel : LabelBase<SelectableLabel>
    {
        protected override void DrawLabel(in Rect rect, in string text, GUIStyle style)
        {
            EditorGUI.SelectableLabel(rect, text, style);
        }
    }
}

#endif