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
    using EZU = EzEditorUtility;

    public abstract class EzEditor : UnityEditor.Editor
    {
        protected abstract void OnSetup(EZU.Setting setting);
        protected abstract void OnDrawInspector();

        public sealed override void OnInspectorGUI()
        {
            LoadSettingBuilder();

            CallReset();
            OnSetup(settingBuilder);
            CallInit();

            Undo.RecordObject(target, $"Edited : {target.name}");
            OnDrawInspector();

            CallFinish();
        }

        /// <summary> 커서 이동하기 </summary>
        protected void Space(float height = 8f)
            => EZU.Space(height);

        /// <summary> 현재 커서가 존재하는 위치 </summary>
        protected float Cursor => EZU.CurrentY;

        private static EZU.Setting settingBuilder;
        private static MethodInfo ResetMethod;
        private static MethodInfo InitMethod;
        private static MethodInfo FinishMethod;

        [InitializeOnLoadMethod]
        private static void LoadSettingBuilder()
        {
            if (settingBuilder == null)
            {
                Type t = typeof(EZU.Setting);
                var bf = BindingFlags.NonPublic | BindingFlags.Static;
                var fi = t.GetField("instance", bf);
                var instance = fi.GetValue(null);

                if (instance != null)
                    settingBuilder = instance as EZU.Setting;

                ResetMethod  = t.GetMethod(EZU.Setting.ResetMethodName,  bf);
                InitMethod   = t.GetMethod(EZU.Setting.InitMethodName,   bf);
                FinishMethod = t.GetMethod(EZU.Setting.FinishMethodName, bf);
            }
        }
        private void CallReset()
        {
            ResetMethod?.Invoke(null, null);
        }
        private void CallInit()
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