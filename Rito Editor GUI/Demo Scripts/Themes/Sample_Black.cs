#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-05-30 PM 9:24:48
// 작성자 : Rito

namespace Rito.EditorUtilities.Demo
{
    public class Sample_Black : Sample_ThemeBase
    {
        [CustomEditor(typeof(Sample_Black))]
        private class CE : SampleCustomEditorBase
        {
            protected override bool SetEditorBakgroundColor { get; } = true;

            protected override Color EditorBackgroundColor { get; } = Color.gray;

            protected override EColor DefaultColorTheme => EColor.Black;
        }
    }
}

#endif