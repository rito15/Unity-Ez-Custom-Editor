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
    public abstract class VectorFieldBase<T, R> : ValueFieldWithSetter<T, R>
        where R : VectorFieldBase<T, R>, new()
    {
        public override R Draw(float xLeft, float xRight, float yOffset, float height,
            float xLeftOffset = 0f, float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this as R;
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (labelStyle == null)
                labelStyle = new GUIStyle(GUI.skin.label);

            ref float t = ref widthThreshold;
            float omt = 1f - t;
            Rect labelRect = new Rect(rect.x, rect.y, rect.width * t, rect.height);
            Rect inputRect = new Rect(rect.x + rect.width * t, rect.y, rect.width * omt, rect.height);

            var oldBackgroundColor = GUI.backgroundColor;
            var oldTextColor = EditorStyles.numberField.normal.textColor;
            var oldHoverTextColor = EditorStyles.numberField.hover.textColor;
            var oldFocusedTextColor = EditorStyles.numberField.focused.textColor;
            var oldFontSize = EditorStyles.numberField.fontSize;
            var oldFontStyle = EditorStyles.numberField.fontStyle;
            var oldTextAlign = EditorStyles.numberField.alignment;

            GUI.backgroundColor = inputBackgroundColor * 2f;
            EditorStyles.numberField.normal.textColor = inputTextColor;
            EditorStyles.numberField.hover.textColor = inputTextColor.AddRGB(0.25f);
            EditorStyles.numberField.focused.textColor = inputTextColor.AddRGB(0.25f);
            EditorStyles.numberField.fontSize = inputFontSize;
            EditorStyles.numberField.fontStyle = inputFontStyle;
            EditorStyles.numberField.alignment = inputTextAlignment;

            labelStyle.normal.textColor = labelColor;
            labelStyle.fontSize = labelFontSize;
            labelStyle.fontStyle = labelFontStyle;
            labelStyle.alignment = labelAlignment;

            DrawFields(labelRect, inputRect);

            GUI.backgroundColor = oldBackgroundColor;
            EditorStyles.numberField.normal.textColor = oldTextColor;
            EditorStyles.numberField.hover.textColor = oldHoverTextColor;
            EditorStyles.numberField.focused.textColor = oldFocusedTextColor;
            EditorStyles.numberField.fontSize = oldFontSize;
            EditorStyles.numberField.fontStyle = oldFontStyle;
            EditorStyles.numberField.alignment = oldTextAlign;

            CheckDebugs();
            EndDraw();
            return this as R;
        }
        protected override void DrawFields(in Rect labelRect, in Rect inputRect)
        {
            EditorGUI.LabelField(labelRect, labelContent, labelStyle);

            var oldLabelColor = EditorStyles.label.normal.textColor;
            var oldLabelHoverColor = EditorStyles.label.normal.textColor;
            var oldLabelFocusedColor = EditorStyles.label.focused.textColor;

            EditorStyles.label.normal.textColor = labelColor;
            EditorStyles.label.hover.textColor = labelColor.AddRGB(0.25f);
            EditorStyles.label.focused.textColor = labelColor.AddRGB(0.25f);

            EditorGUI.BeginChangeCheck();

            DrawVectorField(inputRect);

            isChanged = EditorGUI.EndChangeCheck();

            EditorStyles.label.normal.textColor = oldLabelColor;
            EditorStyles.label.hover.textColor = oldLabelHoverColor;
            EditorStyles.label.focused.textColor = oldLabelFocusedColor;
        }
        protected abstract void DrawVectorField(in Rect inputRect);
    }
    public class Vector2Field : VectorFieldBase<Vector2, Vector2Field>
    {
        /// <summary> 소수점 자리수 제한 </summary>
        public Vector2Field SetPrecision(int precision)
        {
            value.SetPrecision(precision);
            return this;
        }
        protected override void DrawVectorField(in Rect inputRect)
        {
            value = EditorGUI.Vector2Field(inputRect, "", value);
        }
    }
    public class Vector3Field : VectorFieldBase<Vector3, Vector3Field>
    {
        /// <summary> 소수점 자리수 제한 </summary>
        public Vector3Field SetPrecision(int precision)
        {
            value.SetPrecision(precision);
            return this;
        }
        protected override void DrawVectorField(in Rect inputRect)
        {
            value = EditorGUI.Vector3Field(inputRect, "", value);
        }
    }
    public class Vector4Field : VectorFieldBase<Vector4, Vector4Field>
    {
        /// <summary> 소수점 자리수 제한 </summary>
        public Vector4Field SetPrecision(int precision)
        {
            value.SetPrecision(precision);
            return this;
        }
        protected override void DrawVectorField(in Rect inputRect)
        {
            value = EditorGUI.Vector4Field(inputRect, "", value);
        }
    }
    public class Vector2IntField : VectorFieldBase<Vector2Int, Vector2IntField>
    {
        protected override void DrawVectorField(in Rect inputRect)
        {
            value = EditorGUI.Vector2IntField(inputRect, "", value);
        }
    }
    public class Vector3IntField : VectorFieldBase<Vector3Int, Vector3IntField>
    {
        protected override void DrawVectorField(in Rect inputRect)
        {
            value = EditorGUI.Vector3IntField(inputRect, "", value);
        }
    }
}

#endif