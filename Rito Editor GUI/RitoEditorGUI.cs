#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-05-24 AM 1:32:18
// 작성자 : Rito

namespace Rito.EditorPlugins
{
    using REG = RitoEditorGUI;

    /// <summary> EditorGUILayout 기능들을 커스텀하여 제공 </summary>
    public static class RitoEditorGUI
    {
        /***********************************************************************
        *                               Internal Classes
        ***********************************************************************/
        #region .
        public class OptionBuilder
        {
            public static OptionBuilder Instance { get; } = new OptionBuilder();
            private OptionBuilder() { }

            public OptionBuilder SetMarginTop(float value)
            {
                REG.marginTop = value;
                return this;
            }
            public OptionBuilder SetMarginLeft(float value)
            {
                REG.marginLeft = value;
                return this;
            }
            public OptionBuilder SetMarginRight(float value)
            {
                REG.marginRight = value;
                return this;
            }
            public OptionBuilder SetMarginBottom(float value)
            {
                REG.marginBottom = value;
                return this;
            }
            /// <summary> 렉트 디버그 사용 가능 여부 설정 </summary>
            public OptionBuilder DebugOn(bool value)
            {
                DrawingElement.debugOn = value;
                return this;
            }
            /// <summary> 모든 렉트에 자동 디버그 </summary>
            public OptionBuilder DebugAll(bool value)
            {
                DrawingElement.debugAll = value;
                return this;
            }
            /// <summary> 디버그 렉트 색상 설정 </summary>
            public OptionBuilder SetDebugRectColor(in Color color)
            {
                DrawingElement.debugColor = color;
                return this;
            }
            public void Init()
            {
                REG.ViewWidth = 
                    EditorGUIUtility.currentViewWidth
                    - marginLeft
                    - marginRight;
                REG.CurrentY = marginTop;

                // 인스펙터 상단부에 디버그 On/Off 토글 생성
                if (DrawingElement.debugOn)
                {
                    Rect toggleRect = new Rect(marginLeft, 2f, 120f, 20f);
                    Rect line = new Rect(0f, 0f, EditorGUIUtility.currentViewWidth, 24f);

                    EditorGUI.DrawRect(line, Color.black);
                    using (var cc = new EditorGUI.ChangeCheckScope())
                    {
                        DrawingElement.debugOnOption =
                            EditorGUI.ToggleLeft(toggleRect, "Show Debug Rect", DrawingElement.debugOnOption);

                        if(cc.changed)
                            PlayerPrefs.SetInt(DrawingElement.DebugOnPrefName, DrawingElement.debugOnOption ? 1 : 0);
                    }
                    REG.Space(24f);
                }
            }
        }

        #endregion
        /***********************************************************************
        *                               Private Fields
        ***********************************************************************/
        #region .
        private static float marginTop;
        private static float marginLeft;
        private static float marginRight;
        private static float marginBottom;

        private static Dictionary<GUIStyle, GUIStyle> styleRecordDict = new Dictionary<GUIStyle, GUIStyle>();

        #endregion
        /***********************************************************************
        *                               Fields, Properties
        ***********************************************************************/
        #region .
        /// <summary> OnInspectorGUI 최상단에서 .Init()까지 호출 </summary>
        public static OptionBuilder Options => OptionBuilder.Instance;
        public static float CurrentY { get; private set; }
        public static float ViewWidth { get; private set; }

        public static List<OverlayTooltip> TooltipList { get; } = new List<OverlayTooltip>();

        #endregion
        /***********************************************************************
        *                               Tiny Methods
        ***********************************************************************/
        #region .
        public static void Space(float height = 8f) => CurrentY += height;

        // xLeft : Rect 좌측 끝의 위치 비율(0 ~ 1)
        // xRight : Rect 우측 끝의 위치 비율(0 ~ 1)
        // yOffset : CurrentY 기준 픽셀 좌표
        // height : Rect의 높이(픽셀 값)
        public static Rect GetRect(in float xLeft, in float xRight, float yOffset, in float height)
        {
            return new Rect(
                marginLeft + ViewWidth * xLeft, 
                CurrentY + yOffset, 
                ViewWidth * (xRight - xLeft), 
                height);
        }
        // xLeftOffset : xLeft에 더할 픽셀값
        // xRightOffset : xRight에 더할 픽셀값
        public static Rect GetRect(in float xLeft, in float xRight, float yOffset, in float height, 
            in float xLeftOffset, in float xRightOffset)
        {
            return new Rect(
                marginLeft + ViewWidth * xLeft + xLeftOffset, 
                CurrentY + yOffset, 
                ViewWidth * (xRight - xLeft) - xLeftOffset + xRightOffset, 
                height);
        }

        #endregion
        /***********************************************************************
        *                               Methods
        ***********************************************************************/
        #region .
        /// <summary> 반드시 OnInspectorGUI 최하단에서 호출 </summary>
        public static void Finalize(Editor editor)
        {
            EditorGUILayout.Space(CurrentY + marginBottom);

            // 컨트롤 없는 부분에 클릭할 경우 강제로 포커스 제거
            if (Event.current.type == EventType.MouseDown)
                EditorGUI.FocusTextInControl("");

            // 매 에디터 프레임마다 다시 그려주기
            if (Event.current.type == EventType.Layout)
                editor.Repaint();

            Vector2 mPos = Event.current.mousePosition;

            foreach (var tooltip in TooltipList)
            {
                if (tooltip.mouseTargetRect.Contains(mPos))
                {
                    GUI.Box(new Rect(mPos.x, mPos.y, tooltip.width, tooltip.height), tooltip.text);
                    //editor.Repaint();
                }
            }

            TooltipList.Clear();
        }

        #endregion
    }
}

#endif