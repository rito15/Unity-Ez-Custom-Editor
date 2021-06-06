using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 날짜 : 2021-06-07 AM 2:37:56
// 작성자 : Rito

namespace Rito.EditorUtilities.Demo
{
    public class Sample_WindowOpener : MonoBehaviour
    {
        [UnityEditor.CustomEditor(typeof(Sample_WindowOpener))]
        private class CE : RitoEditor
        {
            protected override void OnDrawInspector()
            {
                Button.Brown
                    .SetData("Open Editor Window")
                    .Draw(0.1f, 0.9f, 40f).Layout()
                    .OnValueChanged(_ => Sample_EditorWindow.Open());
            }

            protected override void OnSetup(RitoEditorGUI.Setting setting) { }
        }
    }
}