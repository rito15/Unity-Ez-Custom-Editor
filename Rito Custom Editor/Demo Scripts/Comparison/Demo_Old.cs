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
        [UnityEditor.CustomEditor(typeof(Demo_Old))]
        private class CE : Editor
        {
            private bool foldout = true;

            private float floatVariable;

            public override void OnInspectorGUI()
            {
                GUILayout.Button("ButtoN");
                GUILayout.Button("ButtoN");
                GUILayout.Button("ButtoN");
                GUILayout.Button("ButtoN");
                
            }
        }
    }
}

#endif