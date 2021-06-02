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
    public class ObjectField<T> : ValueFieldWithSetter<T, ObjectField<T>> where T : UnityEngine.Object
    {
        protected bool allowSceneObjects = true;

        public ObjectField<T> SetData(string label, T value, bool allowSceneObject = true, float widthThreshold = 0.4f)
        {
            this.labelContent = new GUIContent(label);
            this.value = value;
            this.allowSceneObjects = allowSceneObject;
            this.widthThreshold = widthThreshold;

            return this;
        }

        public override ObjectField<T> Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this;
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (labelStyle == null)
                labelStyle = new GUIStyle(GUI.skin.label);

            ref float t = ref widthThreshold;
            float omt = 1f - t;
            Rect labelRect = new Rect(rect.x, rect.y, rect.width * t, rect.height);
            Rect inputRect = new Rect(rect.x + rect.width * t, rect.y, rect.width * omt, rect.height);

            var oldBackgroundColor = GUI.backgroundColor;
            var oldTextColor = EditorStyles.objectField.normal.textColor;
            var oldHoverTextColor = EditorStyles.objectField.hover.textColor;
            var oldFontSize = EditorStyles.objectField.fontSize;
            var oldFontStyle = EditorStyles.objectField.fontStyle;
            var oldTextAlign = EditorStyles.objectField.alignment;

            GUI.backgroundColor = inputBackgroundColor * 2f;
            EditorStyles.objectField.normal.textColor = inputTextColor;
            EditorStyles.objectField.hover.textColor = inputTextColor.AddRGB(0.25f);
            EditorStyles.objectField.focused.textColor = inputTextFocusedColor;
            EditorStyles.objectField.fontSize = inputFontSize;
            EditorStyles.objectField.fontStyle = inputFontStyle;
            EditorStyles.objectField.alignment = inputTextAlignment;

            labelStyle.normal.textColor = labelColor;
            labelStyle.hover.textColor = labelColor.AddRGB(0.25f);
            labelStyle.fontSize = labelFontSize;
            labelStyle.fontStyle = labelFontStyle;
            labelStyle.alignment = labelAlignment;

            // Draw
            EditorGUI.PrefixLabel(labelRect, labelContent, labelStyle);
            value = EditorGUI.ObjectField(inputRect, value, typeof(T), allowSceneObjects) as T;

            GUI.backgroundColor = oldBackgroundColor;
            EditorStyles.objectField.normal.textColor = oldTextColor;
            EditorStyles.objectField.hover.textColor = oldHoverTextColor;
            EditorStyles.objectField.fontSize = oldFontSize;
            EditorStyles.objectField.fontStyle = oldFontStyle;
            EditorStyles.objectField.alignment = oldTextAlign;

            EndDraw();
            return this;
        }

        protected override void DrawFields(in Rect labelRect, in Rect inputRect) { }
    }
}

#endif