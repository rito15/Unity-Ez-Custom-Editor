#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-06-02 PM 11:12:27
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    public abstract class RitoEditor : UnityEditor.Editor
    {
        // Settings -> 여기 private으로 숨기고, OnSetup에서 매개변수로 전달
        private RitoEditorGUI.SettingBuilder Settings => RitoEditorGUI.Settings;

        protected abstract void OnSetup();
        protected abstract void OnDrawInspector();

        public sealed override void OnInspectorGUI()
        {
            Settings.Reset();

            OnSetup();
            OnDrawInspector();

            RitoEditorGUI.Finalize(this);
        }
    }
}

#endif