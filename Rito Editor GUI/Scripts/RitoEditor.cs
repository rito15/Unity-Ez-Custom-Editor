#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;

// 날짜 : 2021-06-02 PM 11:12:27
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    using RGUI = RitoEditorGUI;

    public abstract class RitoEditor : UnityEditor.Editor
    {
        protected abstract void OnSetup(RGUI.Setting setting);
        protected abstract void OnDrawInspector();

        public sealed override void OnInspectorGUI()
        {
            LoadSettingBuilder();

            CallReset();
            OnSetup(settingBuilder);
            CallInit();

            OnDrawInspector();

            CallFinish();
        }

        /// <summary> 커서 이동하기 </summary>
        protected void Space(float height = 8f)
            => RGUI.Space(height);

        /// <summary> 현재 커서가 존재하는 위치 </summary>
        protected float Cursor => RGUI.CurrentY;

        private static RGUI.Setting settingBuilder;
        private static MethodInfo ResetMethod;
        private static MethodInfo InitMethod;
        private static MethodInfo FinishMethod;

        [InitializeOnLoadMethod]
        private static void LoadSettingBuilder()
        {
            if (settingBuilder == null)
            {
                Type t = typeof(RGUI.Setting);
                var bf = BindingFlags.NonPublic | BindingFlags.Static;
                var fi = t.GetField("instance", bf);
                var instance = fi.GetValue(null);

                if (instance != null)
                    settingBuilder = instance as RGUI.Setting;

                ResetMethod = t.GetMethod("Reset", bf);
                InitMethod = t.GetMethod("Init", bf);
                FinishMethod = t.GetMethod("Finish", bf);
            }
        }
        private static void CallReset()
        {
            ResetMethod?.Invoke(null, null);
        }
        private static void CallInit()
        {
            InitMethod?.Invoke(null, null);
        }
        private void CallFinish()
        {
            FinishMethod?.Invoke(null, new object[] { this });
        }
    }
}

#endif