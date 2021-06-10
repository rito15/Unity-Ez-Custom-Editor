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
    public class Dropdown<T> : ValueFieldBase<int, Dropdown<T>>
    {
        // Data
        protected T[] options;
        protected string[] stringOptions;

        // value : selected Index

        public Dropdown<T> SetData(string label, T[] options, int selectedIndex, float widthThreshold = 0.4f)
        {
            this.labelContent = new GUIContent(label);
            this.value = selectedIndex;
            this.widthThreshold = widthThreshold;

            // options 값이 동일한 경우에는 새롭게 string 배열 생성하지 않음
            if (this.options == null || this.options != options)
            {
                this.options = options;
                this.stringOptions = new string[options.Length];

                for (int i = 0; i < options.Length; i++)
                    this.stringOptions[i] = options[i].ToString();
            }
            return this;
        }
        public Dropdown<T> SetData(string label, IList<T> options, int selectedIndex, float widthThreshold = 0.4f)
            => SetData(label, options.ToArray(), selectedIndex, widthThreshold);

        /// <summary> 선택된 요소의 값을 직접 가져오기 </summary>
        public T GetSelectedValue()
        {
            return options[value];
        }
        /// <summary> 선택된 요소의 값을 직접 가져오기 </summary>
        public Dropdown<T> GetSelectedValue(out T variable)
        {
            variable = options[value];
            return this;
        }

        protected override void InitInputStyle()
            => inputStyle = new GUIStyle(EditorStyles.popup);

        protected override void DrawFields(in Rect labelRect, in Rect inputRect)
        {
            EditorGUI.PrefixLabel(labelRect, labelContent, labelStyle);

            var oldBackgroundColor = GUI.backgroundColor;
            GUI.backgroundColor = inputBackgroundColor;

            EditorGUI.BeginChangeCheck();

            value = EditorGUI.Popup(inputRect, value, stringOptions, inputStyle);

            isChanged = EditorGUI.EndChangeCheck();

            GUI.backgroundColor = oldBackgroundColor;
        }
    }
}

#endif