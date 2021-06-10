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
        public string stringValue = "String Value";
        public bool foldout, toggleButtonPressed;

        public float[] floatArray = { 0.1f, 0.2f, 0.3f, 0.4f };
        public int floatSelected;

        [UnityEditor.CustomEditor(typeof(Demo_Old))]
        private class CE : Editor
        {
            private Demo_Old m;
            private string[] strFloatArray;

            private readonly Color BoxOutlineColor = Color.blue;
            private readonly Color HeaderBoxColor = Color.blue + Color.gray;
            private readonly Color ContentBoxColor = new Color(0f, 0f, 0.15f, 1f);
            private readonly Color HeaderLabelColor = new Color(0f, 0f, 0.1f, 1f);
            private readonly Color FieldBackgroundColor = new Color(1f, 1f, 4f, 1f);
            private readonly Color DropdownBackgroundColor = new Color(0.5f, 0.5f, 2f, 1f);
            private readonly Color ControlBackgroundColor = new Color(0f, 0f, 2f, 1f);

            private void OnEnable()
            {
                m = target as Demo_Old;

                strFloatArray = new string[m.floatArray.Length];
                for (int i = 0; i < m.floatArray.Length; i++)
                    strFloatArray[i] = m.floatArray[i].ToString();
            }

            public override void OnInspectorGUI()
            {
                SetStyles();
                DrawControls();
                RestoreStyles();
            }

            private void DrawControls()
            {
                const float PosX = 18f; // Left Margin
                const float BoxPaddingRight = 8f;
                float viewWidth = EditorGUIUtility.currentViewWidth - PosX - 4f;
                float insideBoxWidth = viewWidth - BoxPaddingRight;

                GUILayoutOption boxViewWidthOption = GUILayout.Width(insideBoxWidth);

                // W : Width, H : Height

                const float BoxPaddingLeft = 4f;
                const float Outline = 2f;
                const float BoxX = PosX - BoxPaddingLeft;
                const float OutBoxX = BoxX - Outline;

                const float HeaderBoxH = 20f;
                float contentBoxH = m.foldout ? 64f : 0f;
                float outBoxH = HeaderBoxH + contentBoxH + Outline * (m.foldout ? 3f : 2f);

                float boxW = viewWidth;
                float outBoxW = boxW + Outline * 2f;

                const float OutBoxY = 4f;
                const float HeaderBoxY = 4f + Outline;
                const float ContentBoxY = HeaderBoxY + HeaderBoxH + Outline;

                Rect outBoxRect     = new Rect(OutBoxX, OutBoxY, outBoxW, outBoxH);
                Rect headerBoxRect  = new Rect(BoxX, HeaderBoxY, boxW, HeaderBoxH);
                Rect contentBoxRect = new Rect(BoxX, ContentBoxY, boxW, contentBoxH);
                Rect foldoutRect    = new Rect(headerBoxRect);
                foldoutRect.xMin += 12f;

                // Header Foldout
                m.foldout =
                    EditorGUI.Foldout(foldoutRect, m.foldout, "", true);

                // Box
                EditorGUI.DrawRect(outBoxRect, BoxOutlineColor);
                EditorGUI.DrawRect(headerBoxRect, HeaderBoxColor);
                EditorGUI.DrawRect(contentBoxRect, ContentBoxColor);

                EditorGUILayout.Space(1f);
                EditorGUILayout.LabelField("Header Box", headerLabelStyle);

                EditorGUILayout.Space(Outline);

                if (m.foldout)
                {
                    GUI.backgroundColor = FieldBackgroundColor;

                    // String
                    m.stringValue =
                        EditorGUILayout.TextField("String FIeld", m.stringValue, boxViewWidthOption);

                    GUI.backgroundColor = DropdownBackgroundColor;

                    // Dropdown
                    m.floatSelected = 
                        EditorGUILayout.Popup("Float Dropdown", m.floatSelected, strFloatArray, boxViewWidthOption);

                    GUI.backgroundColor = ControlBackgroundColor;

                    // Buttons
                    using (new EditorGUILayout.HorizontalScope())
                    {
                        const float buttonPart = 0.7f;

                        GUILayout.Button("Button", GUILayout.Width(insideBoxWidth * buttonPart));
                        m.toggleButtonPressed =
                            GUILayout.Toggle(m.toggleButtonPressed, "Toggle Button",
                            "Button", GUILayout.Width(insideBoxWidth * (1f - buttonPart) - 4f));
                    }
                }
            }

            private GUIStyle headerLabelStyle;
            private Color oldBackgroundColor;

            private void SetStyles()
            {
                if (headerLabelStyle == null)
                {
                    headerLabelStyle = new GUIStyle(GUI.skin.label);
                    headerLabelStyle.normal.textColor = HeaderLabelColor;
                    headerLabelStyle.fontStyle = FontStyle.Bold;
                }

                oldBackgroundColor = GUI.backgroundColor;
            }

            private void RestoreStyles()
            {
                GUI.backgroundColor = oldBackgroundColor;
            }
        }
    }
}

#endif