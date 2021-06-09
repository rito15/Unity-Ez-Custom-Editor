#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 날짜 : 2021-06-04 PM 8:59:26
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    public static class StringExtensions
    {
        /***********************************************************************
        *                               Label
        ***********************************************************************/
        #region .
        public static Label DrawLabel(this string @this, Label label)
        {
            return label
                .SetData(@this)
                .DrawLayout();
        }
        public static Label DrawLabel(this string @this)
            => DrawLabel(@this, Label.Default);

        #endregion
        /***********************************************************************
        *                               Selectable Label
        ***********************************************************************/
        #region .
        public static SelectableLabel DrawSelectableLabel(this string @this, SelectableLabel label)
        {
            return label
                .SetData(@this)
                .DrawLayout();
        }
        public static SelectableLabel DrawSelectableLabel(this string @this)
            => DrawSelectableLabel(@this, SelectableLabel.Default);

        #endregion
        /***********************************************************************
        *                               Editable Label
        ***********************************************************************/
        #region .
        public static EditableLabel DrawEditableLabel(this string @this, EditableLabel label)
        {
            return label
                .SetData(@this)
                .DrawLayout();
        }
        public static EditableLabel DrawEditableLabel(this string @this)
            => DrawEditableLabel(@this, EditableLabel.Default);

        #endregion
        /***********************************************************************
        *                               String Field
        ***********************************************************************/
        #region .
        public static StringField DrawStringField(this string @this, string label, StringField stringField)
        {
            return stringField
                .SetData(label, @this)
                .DrawLayout();
        }
        public static StringField DrawStringField(this string @this, string label)
            => DrawStringField(@this, label, StringField.Default);

        #endregion
        /***********************************************************************
        *                               TextArea
        ***********************************************************************/
        #region .
        public static TextArea DrawTextArea(this string @this, TextArea textArea)
        {
            return textArea
                .SetData(@this)
                .DrawLayout();
        }
        public static TextArea DrawTextArea(this string @this, string placeholder, TextArea textArea)
        {
            return textArea
                .SetData(@this, placeholder)
                .DrawLayout();
        }
        public static TextArea DrawTextArea(this string @this)
            => DrawTextArea(@this, TextArea.Default);
        public static TextArea DrawTextArea(this string @this, string placeholder)
            => DrawTextArea(@this, placeholder, TextArea.Default);

        #endregion
        /***********************************************************************
        *                               Header Box
        ***********************************************************************/
        #region .
        public static HeaderBox DrawHeaderBox(this string @this, int contentCount, HeaderBox headerBox,
            float outlineWidth = 0f, float headerTextIndent = 2f)
        {
            return headerBox
                .SetData(@this, outlineWidth, headerTextIndent)
                .DrawLayout(contentCount);
        }
        public static HeaderBox DrawHeaderBox(this string @this, int contentCount,
            float outlineWidth = 0f, float headerTextIndent = 2f)
        {
            return HeaderBox.Default
                .SetData(@this, outlineWidth, headerTextIndent)
                .DrawLayout(contentCount);
        }
        
        #endregion
        /***********************************************************************
        *                               Foldout Header Box
        ***********************************************************************/
        #region .
        public static FoldoutHeaderBox DrawFoldoutHeaderBox(this string @this, ref bool foldout,
            int contentCount, FoldoutHeaderBox foldoutHeaderBox,
            float outlineWidth = 0f, float headerTextIndent = 2f)
        {
            return foldoutHeaderBox
                .SetData(foldout, @this, outlineWidth, headerTextIndent)
                .DrawLayout(contentCount)
                .GetValue(out foldout);
        }
        public static FoldoutHeaderBox DrawFoldoutHeaderBox(this string @this, ref bool foldout,
            int contentCount, float outlineWidth = 0f, float headerTextIndent = 2f)
        {
            return FoldoutHeaderBox.Default
                .SetData(foldout, @this, outlineWidth, headerTextIndent)
                .DrawLayout(contentCount)
                .GetValue(out foldout);
        }
        
        #endregion
        /***********************************************************************
        *                               Button
        ***********************************************************************/
        #region .
        public static Button DrawButton(this string @this, Button button)
        {
            return button
                .SetData(@this)
                .DrawLayout();
        }
        public static Button DrawButton(this string @this)
            => DrawButton(@this, Button.Default);
        
        #endregion
        /***********************************************************************
        *                               Toggle Button
        ***********************************************************************/
        #region .
        public static ToggleButton DrawToggleButton(this string @this, ref bool pressed, ToggleButton toggleButton)
        {
            return toggleButton
                .SetData(@this, pressed)
                .DrawLayout()
                .GetValue(out pressed);
        }
        public static ToggleButton DrawToggleButton(this string @this, ref bool pressed)
            => DrawToggleButton(@this, ref pressed, ToggleButton.Default);
        
        #endregion
    }
}

#endif