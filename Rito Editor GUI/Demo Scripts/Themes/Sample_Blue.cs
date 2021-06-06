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
    public class Sample_Blue : Sample_ThemeBase
    {
        [CustomEditor(typeof(Sample_Blue))]
        private class CE : SampleCustomEditorBase
        {
            protected override bool SetEditorBakgroundColor { get; } = true;

            protected override Color EditorBackgroundColor { get; } = RColor.Gray2;

            protected override EColor DefaultColorTheme => EColor.Blue;
        }
    }
}

#endif