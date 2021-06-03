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
    public abstract partial class ValueFieldBase<T, R> : DrawingElement<T, R> where R : ValueFieldBase<T, R>, new()
    {
        public static R Default { get; } = new R();

        protected GUIStyle labelStyle;
        protected GUIStyle inputStyle;

        // Data
        protected GUIContent labelContent;
        protected float widthThreshold = 0.4f;

        // Styles - Label
        public Color labelColor = Color.white;
        public int labelFontSize = 12;
        public FontStyle labelFontStyle = FontStyle.Normal;
        public TextAnchor labelAlignment = TextAnchor.MiddleLeft;

        // Styles - Input Field
        public Color inputTextColor = Color.white;
        public Color inputTextFocusedColor = Color.white;
        public Color inputBackgroundColor = Color.white;
        public int inputFontSize = 12;
        public FontStyle inputFontStyle = FontStyle.Normal;
        public TextAnchor inputTextAlignment = TextAnchor.MiddleLeft;

        public override R Clone()
        {
            return new R
            {
                labelColor = labelColor,
                labelFontSize = labelFontSize,
                labelFontStyle = labelFontStyle,
                labelAlignment = labelAlignment,
                inputTextColor = inputTextColor,
                inputTextFocusedColor = inputTextFocusedColor,
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
        public R SetLabelColor(Color color)
        {
            this.labelColor = color;
            return this as R;
        }
        public R SetLabelFontSize(int fontSize)
        {
            this.labelFontSize = fontSize;
            return this as R;
        }
        public R SetLabelFontStyle(FontStyle fontStyle)
        {
            this.labelFontStyle = fontStyle;
            return this as R;
        }
        public R SetLabelTextAlignment(TextAnchor alignment)
        {
            this.labelAlignment = alignment;
            return this as R;
        }

        public R SetInputTextColor(Color color)
        {
            this.inputTextColor = color;
            return this as R;
        }
        public R SetInputBackgroundColor(Color color)
        {
            this.inputBackgroundColor = color;
            return this as R;
        }
        public R SetInputFontSize(int fontSize)
        {
            this.inputFontSize = fontSize;
            return this as R;
        }
        public R SetInputFontStyle(FontStyle fontStyle)
        {
            this.inputFontStyle = fontStyle;
            return this as R;
        }
        public R SetInputTextAlignment(TextAnchor allignment)
        {
            this.inputTextAlignment = allignment;
            return this as R;
        }

        #endregion

        public override R Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this as R;
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (labelStyle == null)
                labelStyle = new GUIStyle(GUI.skin.label);

            if (inputStyle == null)
                InitInputStyle();

            ref float t = ref widthThreshold;
            float omt = 1f - t;
            Rect labelRect = new Rect(rect.x, rect.y, rect.width * t, rect.height);
            Rect inputRect = new Rect(rect.x + rect.width * t, rect.y, rect.width * omt, rect.height);

            var oldBackgroundColor = GUI.backgroundColor;
            GUI.backgroundColor = inputBackgroundColor * 2f;

            labelStyle.normal.textColor = labelColor;
            labelStyle.hover.textColor = labelColor.AddRGB(0.25f);
            labelStyle.focused.textColor = labelColor.AddRGB(0.25f);
            labelStyle.onActive.textColor = labelColor.AddRGB(0.25f);
            labelStyle.fontSize = labelFontSize;
            labelStyle.fontStyle = labelFontStyle;
            labelStyle.alignment = labelAlignment;

            inputStyle.normal.textColor = inputTextColor;
            inputStyle.hover.textColor = inputTextColor.AddRGB(0.25f);
            inputStyle.focused.textColor = inputTextFocusedColor;
            inputStyle.fontSize = inputFontSize;
            inputStyle.fontStyle = inputFontStyle;
            inputStyle.alignment = inputTextAlignment;

            EditorGUI.BeginChangeCheck();

            DrawFields(labelRect, inputRect);

            isChanged = EditorGUI.EndChangeCheck();

            GUI.backgroundColor = oldBackgroundColor;

            CheckDebugs();
            EndDraw();
            return this as R;
        }

        protected virtual void InitInputStyle()
            => inputStyle = new GUIStyle(EditorStyles.numberField);

        protected abstract void DrawFields(in Rect labelRect, in Rect inputRect);
    }

    public abstract class ValueFieldWithSetter<T, R> : ValueFieldBase<T, R>
        where R : ValueFieldWithSetter<T, R>, new()
    {
        public R SetData(string label, T value, float widthThreshold = 0.4f)
        {
            this.labelContent = new GUIContent(label);

            this.value = value;
            this.widthThreshold = widthThreshold;
            return this as R;
        }
    }

    public class IntField : ValueFieldWithSetter<int, IntField>
    {
        protected override void DrawFields(in Rect labelRect, in Rect inputRect)
        {
            value =
                ReflectionGUI.IntField(labelRect, inputRect, labelContent, value, labelStyle, inputStyle);
        }
    }
    public class LongField : ValueFieldWithSetter<long, LongField>
    {
        protected override void DrawFields(in Rect labelRect, in Rect inputRect)
        {
            value =
                ReflectionGUI.LongField(labelRect, inputRect, labelContent, value, labelStyle, inputStyle);
        }
    }
    public class FloatField : ValueFieldWithSetter<float, FloatField>
    {
        protected override void DrawFields(in Rect labelRect, in Rect inputRect)
        {
            value =
                ReflectionGUI.FloatField(labelRect, inputRect, labelContent, value, labelStyle, inputStyle);
        }
    }
    public class DoubleField : ValueFieldWithSetter<double, DoubleField>
    {
        protected override void DrawFields(in Rect labelRect, in Rect inputRect)
        {
            value =
                ReflectionGUI.DoubleField(labelRect, inputRect, labelContent, value, labelStyle, inputStyle);
        }
    }
    public class StringField : ValueFieldWithSetter<string, StringField>
    {
        protected string placeholder = "";

        public StringField SetData(string label, string value, string placeholder = "", float widthThreshold = 0.4f)
        {
            this.labelContent = new GUIContent(label);

            this.value = value;
            this.placeholder = placeholder;
            this.widthThreshold = widthThreshold;
            return this;
        }

        protected override void DrawFields(in Rect labelRect, in Rect inputRect)
        {
            EditorGUI.PrefixLabel(labelRect, labelContent, labelStyle);

            GUI.SetNextControlName("StringField");
            value = EditorGUI.TextField(inputRect, value, inputStyle);

            // Placeholder
            inputStyle.normal.textColor = inputTextColor.SetA(0.5f);
            if (string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(placeholder) &&
                !(GUI.GetNameOfFocusedControl() == "StringField"))
                EditorGUI.LabelField(inputRect, placeholder, inputStyle);
        }
    }
}

#endif