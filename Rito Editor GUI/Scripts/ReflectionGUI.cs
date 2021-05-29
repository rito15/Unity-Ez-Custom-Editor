using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

// 날짜 : 2021-05-30 AM 2:28:23
// 작성자 : Rito

namespace Rito.EditorUtilities
{

    [InitializeOnLoad]
    static class ReflectionGUI
    {
        // DoFloatField(s_RecycledEditor, position2, position, controlID,
        //             value, kFloatFieldFormatString, style, draggable: true);

        private static Type t_NumericFieldDraggerUtility;

        private static FieldInfo fi_recycledEditor;
        private static MethodInfo mi_DoIntField;
        private static MethodInfo mi_DoLongField;
        private static MethodInfo mi_DoFloatField;
        private static MethodInfo mi_DoDoubleField;
        private static MethodInfo mi_CalculateIntDragSensitivity;

        private static readonly int s_FloatFieldHash;
        private static readonly object s_recycledEditor;

        private static readonly string kIntFieldFormatString = "#######0";
        private static readonly string kFloatFieldFormatString = "g7";
        private static readonly string kDoubleFieldFormatString = "g15";

        // NumericFieldDraggerUtility.CalculateIntDragSensitivity(value)

        static ReflectionGUI()
        {
            Type editorGUIType = typeof(EditorGUI);
            BindingFlags binding = BindingFlags.NonPublic | BindingFlags.Static;

            t_NumericFieldDraggerUtility = Type.GetType("UnityEditor.NumericFieldDraggerUtility, UnityEditor"); 

            fi_recycledEditor = editorGUIType.GetField("s_RecycledEditor", binding);
            s_recycledEditor = fi_recycledEditor.GetValue(null);

            mi_DoIntField = editorGUIType.GetMethod("DoIntField",
                binding, null,
                new[]{
                    fi_recycledEditor.FieldType, typeof(Rect), typeof(Rect), typeof(int),
                    typeof(int), typeof(string), typeof(GUIStyle), typeof(bool), typeof(long)
                },
                null
            );

            mi_DoLongField = editorGUIType.GetMethod("DoLongField",
                binding, null,
                new[]{
                    fi_recycledEditor.FieldType, typeof(Rect), typeof(Rect), typeof(int),
                    typeof(long), typeof(string), typeof(GUIStyle), typeof(bool), typeof(long)
                },
                null
            );

            mi_DoFloatField = editorGUIType.GetMethod("DoFloatField",
                binding, null,
                new[]{
                    fi_recycledEditor.FieldType, typeof(Rect), typeof(Rect), typeof(int),
                    typeof(float), typeof(string), typeof(GUIStyle), typeof(bool)
                }, 
                null
            );

            mi_DoDoubleField = editorGUIType.GetMethod("DoDoubleField",
                binding, null,
                new[]{
                    fi_recycledEditor.FieldType, typeof(Rect), typeof(Rect), typeof(int),
                    typeof(double), typeof(string), typeof(GUIStyle), typeof(bool)
                }, 
                null
            );

            mi_CalculateIntDragSensitivity = t_NumericFieldDraggerUtility.GetMethod("CalculateIntDragSensitivity",
                binding, null,
                new[] { typeof(long) },
                null
            );

            s_FloatFieldHash = "EditorTextField".GetHashCode();

            //Debug.Log(mi_DoDoubleField);
        }

        public static int IntField(in Rect labelRect, in Rect fieldRect, GUIContent labelContent, int value,
            GUIStyle labelStyle, GUIStyle FieldStyle)
        {
            Rect fullRect = new Rect(labelRect);
            fullRect.width += fieldRect.width;

            int controlID = GUIUtility.GetControlID(s_FloatFieldHash, FocusType.Keyboard, fullRect);
            long dragSensitivity = (long)mi_CalculateIntDragSensitivity.Invoke(null, new object[] { value });

            EditorGUI.PrefixLabel(labelRect, controlID, labelContent, labelStyle);

            value = (int)mi_DoIntField.Invoke(null,
                new[] {
                    s_recycledEditor, fieldRect, labelRect, controlID, value,
                    kIntFieldFormatString, FieldStyle, true, dragSensitivity
                }
            );

            return value;
        }

        public static long LongField(in Rect labelRect, in Rect fieldRect, GUIContent labelContent, long value,
            GUIStyle labelStyle, GUIStyle FieldStyle)
        {
            Rect fullRect = new Rect(labelRect);
            fullRect.width += fieldRect.width;

            int controlID = GUIUtility.GetControlID(s_FloatFieldHash, FocusType.Keyboard, fullRect);
            long dragSensitivity = (long)mi_CalculateIntDragSensitivity.Invoke(null, new object[] { value });

            EditorGUI.PrefixLabel(labelRect, controlID, labelContent, labelStyle);

            value = (long)mi_DoLongField.Invoke(null,
                new[] {
                    s_recycledEditor, fieldRect, labelRect, controlID, value,
                    kIntFieldFormatString, FieldStyle, true, dragSensitivity
                }
            );

            return value;
        }

        public static float FloatField(in Rect labelRect, in Rect fieldRect, GUIContent labelContent, float value,
            GUIStyle labelStyle, GUIStyle FieldStyle)
        {
            Rect fullRect = new Rect(labelRect);
            fullRect.width += fieldRect.width;

            int controlID = GUIUtility.GetControlID(s_FloatFieldHash, FocusType.Keyboard, fullRect);

            EditorGUI.PrefixLabel(labelRect, controlID, labelContent, labelStyle);

            value = (float)mi_DoFloatField.Invoke(null,
                new[] {
                    s_recycledEditor, fieldRect, labelRect, controlID, value,
                    kFloatFieldFormatString, FieldStyle, true
                }
            );

            return value;
        }

        public static double DoubleField(in Rect labelRect, in Rect fieldRect, GUIContent labelContent, double value,
            GUIStyle labelStyle, GUIStyle FieldStyle)
        {
            Rect fullRect = new Rect(labelRect);
            fullRect.width += fieldRect.width;

            int controlID = GUIUtility.GetControlID(s_FloatFieldHash, FocusType.Keyboard, fullRect);

            EditorGUI.PrefixLabel(labelRect, controlID, labelContent, labelStyle);

            value = (double)mi_DoDoubleField.Invoke(null,
                new[] {
                    s_recycledEditor, fieldRect, labelRect, controlID, value,
                    kFloatFieldFormatString, FieldStyle, true
                }
            );

            return value;
        }
    }
}