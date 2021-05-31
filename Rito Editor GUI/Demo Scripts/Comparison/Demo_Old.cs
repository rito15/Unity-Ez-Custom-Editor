#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-06-01 AM 2:14:44
// 작성자 : Rito

namespace Rito.EditorUtilities.Demo
{
    public class Demo_Old : MonoBehaviour
    {
        [CustomEditor(typeof(Demo_Old))]
        private class CE : UnityEditor.Editor
        {
            public override void OnInspectorGUI()
            {
                GUILayout.Button("BUTTON");
            }
        }
    }
}

#endif