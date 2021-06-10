#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

// 날짜 : 2021-06-02 PM 4:17:12
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    public abstract class EnumDropdownBase<T, R> : ValueFieldBase<T, R> 
        where T : System.Enum 
        where R : EnumDropdownBase<T, R>, new()
    {
        // value : Selected Enum Value

        public R SetData(string label, T selectedValue, float widthThreshold = 0.4f)
        {
            this.labelContent = new GUIContent(label);
            this.widthThreshold = widthThreshold;
            this.value = selectedValue;

            return this as R;
        }

        protected override void InitInputStyle()
            => inputStyle = new GUIStyle(EditorStyles.popup);
        protected override void DrawFields(in Rect labelRect, in Rect inputRect)
        {
            EditorGUI.PrefixLabel(labelRect, labelContent, labelStyle);

            var oldBackgroundColor = GUI.backgroundColor;
            GUI.backgroundColor = inputBackgroundColor;

            EditorGUI.BeginChangeCheck();

            DrawEnumPopup(inputRect);

            isChanged = EditorGUI.EndChangeCheck();

            GUI.backgroundColor = oldBackgroundColor;
        }

        protected abstract void DrawEnumPopup(in Rect inputRect);
    }

    public class EnumDropdown<T> : EnumDropdownBase<T, EnumDropdown<T>> where T : System.Enum
    {
        protected override void DrawEnumPopup(in Rect inputRect)
        {
            value = (T)EditorGUI.EnumPopup(inputRect, value, inputStyle);
        }
    }
    public class EnumDropdown : EnumDropdownBase<System.Enum, EnumDropdown>
    {
        protected override void DrawEnumPopup(in Rect inputRect)
        {
            value = EditorGUI.EnumPopup(inputRect, value, inputStyle);
        }
    }

    public class EnumFlagDropdown<T> : EnumDropdownBase<T, EnumFlagDropdown<T>> where T : System.Enum
    {
        protected override void DrawEnumPopup(in Rect inputRect)
        {
            value = (T)EditorGUI.EnumFlagsField(inputRect, value, inputStyle);
        }
    }
    public class EnumFlagDropdown : EnumDropdownBase<System.Enum, EnumFlagDropdown>
    {
        protected override void DrawEnumPopup(in Rect inputRect)
        {
            value = EditorGUI.EnumFlagsField(inputRect, value, inputStyle);
        }
    }
}

#endif