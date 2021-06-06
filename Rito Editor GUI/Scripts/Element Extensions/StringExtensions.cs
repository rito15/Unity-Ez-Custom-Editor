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
        #region 
        public static HeaderBox DrawHeaderBox(this string @this, HeaderBox headerBox,
            int elementCount, float outlineWidth = 0f, float headerTextLeftPadding = 2f)
        {
            return headerBox
                .SetData(@this, outlineWidth, headerTextLeftPadding)
                .DrawLayout(elementCount);
        }
        public static HeaderBox DrawHeaderBox(this string @this,
            int elementCount, float outlineWidth = 0f, float headerTextLeftPadding = 2f)
        {
            return HeaderBox.Default
                .SetData(@this, outlineWidth, headerTextLeftPadding)
                .DrawLayout(elementCount);
        }
        
        #endregion
        /***********************************************************************
        *                               Foldout Header Box
        ***********************************************************************/
        #region 
        public static FoldoutHeaderBox DrawFoldoutHeaderBox(this string @this, ref bool toggle, 
            FoldoutHeaderBox foldoutHeaderBox,
            int elementCount, float outlineWidth = 0f, float headerTextLeftPadding = 2f)
        {
            return foldoutHeaderBox
                .SetData(toggle, @this, outlineWidth, headerTextLeftPadding)
                .DrawLayout(elementCount)
                .GetValue(out toggle);
        }
        public static FoldoutHeaderBox DrawFoldoutHeaderBox(this string @this, ref bool toggle,
            int elementCount, float outlineWidth = 0f, float headerTextLeftPadding = 2f)
        {
            return FoldoutHeaderBox.Default
                .SetData(toggle, @this, outlineWidth, headerTextLeftPadding)
                .DrawLayout(elementCount)
                .GetValue(out toggle);
        }
        
        #endregion
    }
}

#endif