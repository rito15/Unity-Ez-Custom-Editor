#if UNITY_EDITOR_

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

// 날짜 : 2021-06-10 PM 5:08:55
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    public abstract class ProgressFieldBase<T, R> : DrawingElement<T, R> where R : ProgressFieldBase<T, R>, new()
    {
        public static R Default { get; } = new R();

        // Data
        protected T minValue;
        protected T maxValue;
        protected float widthThreshold;
        protected GUIContent labelContent;
        protected Color color;
        protected Color backgroundColor;

        protected GUIStyle labelStyle;
        protected readonly GUIStyle dummyStyle = new GUIStyle();
        protected readonly GUIContent dummyContent = new GUIContent();
        protected readonly Rect dummyRect = new Rect() { x = 99999f };

        // Styles - Label
        public Color labelColor = Color.white;
        public int labelFontSize = 12;
        public FontStyle labelFontStyle = FontStyle.Normal;
        public TextAnchor labelAlignment = TextAnchor.MiddleLeft;

        // Styles - Bar


        public override R Clone()
        {
            return new R();
        }

        public R SetData(string label, T value, T min, T max, 
            in Color color, in Color backgroundColor, float widthThreshold = 0.4f)
        {
            if (this.labelContent == null)
                this.labelContent = new GUIContent();

            this.labelContent.text = label;
            this.value = value;
            this.minValue = min;
            this.maxValue = max;
            this.color = color;
            this.backgroundColor = backgroundColor;
            this.widthThreshold = widthThreshold;
            return this as R;
        }
        public R SetData(string label, T value, T min, T max, float widthThreshold = 0.4f)
        {
            return SetData(label, value, min, max, default, default, widthThreshold);
        }

        public override R Draw(float xLeft, float xRight, float yOffset, float height, float xLeftOffset = 0, float xRightOffset = 0)
        {
            if (CheckDrawErrors()) return this as R;
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (labelStyle == null)
                labelStyle = new GUIStyle(GUI.skin.label);

            labelStyle.normal.textColor = labelColor;
            labelStyle.hover.textColor = labelColor.AddRGB(0.25f);
            labelStyle.fontSize = labelFontSize;
            labelStyle.fontStyle = labelFontStyle;
            labelStyle.alignment = labelAlignment;

            ref float t = ref widthThreshold;
            float omt = 1f - t;
            Rect labelRect = new Rect(rect.x, rect.y, rect.width * t, rect.height);
            Rect barRect   = new Rect(rect.x + rect.width * t, rect.y, rect.width * omt, rect.height);

            // 1. Label
            EditorGUI.PrefixLabel(labelRect, labelContent, labelStyle);

            // 2. Bar
            EditorGUI.BeginChangeCheck();
            DrawBar(barRect);
            isChanged = EditorGUI.EndChangeCheck();

            CheckDebugs();
            EndDraw();
            return this as R;
        }

        protected abstract void DrawBar(in Rect barRect);
    }


    public class ProgressField : ProgressFieldBase<float, ProgressField>
    {
        protected override void DrawBar(in Rect barRect)
        {
            value =
                ReflectionGUI.FloatField(rect, dummyRect, dummyContent, value, dummyStyle, dummyStyle);

            value = Mathf.Clamp(value, minValue, maxValue);

            Rect smallRect = new Rect(barRect)
            {
                width = barRect.width * ((value - minValue) / (maxValue - minValue))
            };

            EditorGUI.DrawRect(barRect, Color.black);
            EditorGUI.DrawRect(smallRect, Color.red);
        }
    }
}

#endif