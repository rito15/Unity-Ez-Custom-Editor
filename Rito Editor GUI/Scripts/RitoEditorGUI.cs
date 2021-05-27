#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-05-24 AM 1:32:18
// 작성자 : Rito

namespace Rito.EditorUtilities
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

            public OptionBuilder SetMargins(float left = 0f, float right = 0f, float top = 0f, float bottom = 0f)
            {
                REG.marginLeft = left;
                REG.marginRight = right;
                REG.marginTop = top;
                REG.marginBottom = bottom;
                return this;
            }
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
                REG.ShowDebugToggle = value;
                return this;
            }
            /// <summary> 모든 렉트에 자동 디버그 </summary>
            public OptionBuilder DebugAll(bool value)
            {
                REG.DebugAllRect = value;
                return this;
            }
            /// <summary> 디버그 렉트 색상 설정 </summary>
            public OptionBuilder SetDebugRectColor(in Color color)
            {
                REG.DebugColor = color;
                return this;
            }
            public OptionBuilder AllowTooltip(bool value)
            {
                REG.ShowTooltip = value;
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
                if (REG.ShowDebugToggle)
                {
                    Rect toggleRect = new Rect(marginLeft, 2f, 120f, 20f);
                    Rect line = new Rect(0f, 0f, EditorGUIUtility.currentViewWidth, 24f);

                    EditorGUI.DrawRect(line, Color.black);
                    using (var cc = new EditorGUI.ChangeCheckScope())
                    {
                        REG.DebugOn =
                            EditorGUI.ToggleLeft(toggleRect, "Show Debug Rect", REG.DebugOn);

                        if(cc.changed)
                            PlayerPrefs.SetInt(REG.DebugOnPrefName, REG.DebugOn ? 1 : 0);
                    }
                    REG.Space(24f);
                }

                // Finalize() 여부 검사
                if (initAndFinalizationCount < 2f)
                    initAndFinalizationCount++;
                else
                    Debug.LogError("OnInspector() 하단에서 RitoEditorGUI.Finalize(this)를 호출하세요.");
            }
        }

        #endregion
        /***********************************************************************
        *                               Debug
        ***********************************************************************/
        #region .

        /// <summary> 인스펙터 상단에 디버그 토글을 표시할지 여부 </summary>
        public static bool ShowDebugToggle { get; private set; }

        /// <summary> 디버그 토글로 제어 - 디버그 활성화 여부 결정 </summary>
        public static bool DebugOn { get; private set; }

        /// <summary> 모든 Rect 영역 디버그 표시 여부 </summary>
        public static bool DebugAllRect { get; private set; }

        /// <summary> 최종적으로 디버그 실행 가능 여부 </summary>
        public static bool DebugActivated => ShowDebugToggle && DebugOn;

        public static Color DebugColor { get; private set; } = Color.red;

        public const string DebugOnPrefName = "Rito_EditorGUI_DebugOn";

        private static int initAndFinalizationCount = 0;

        [InitializeOnLoadMethod]
        static void LoadPrefsData()
        {
            DebugOn = PlayerPrefs.GetInt(DebugOnPrefName) == 1;
        }

        #endregion
        /***********************************************************************
        *                               Fields, Properties
        ***********************************************************************/
        #region .
        private static float marginTop;
        private static float marginLeft;
        private static float marginRight;
        private static float marginBottom;

        /// <summary> OnInspectorGUI 최상단에서 .Init()까지 호출 </summary>
        public static OptionBuilder Options => OptionBuilder.Instance;
        public static float CurrentY { get; private set; }
        public static float ViewWidth { get; private set; }

        /// <summary> 툴팁을 표시할 수 있는지 여부 </summary>
        public static bool ShowTooltip { get; private set; } = true;

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
            {
                EditorGUI.FocusTextInControl("");
            }

            if (ShowTooltip)
            {
                // 매 에디터 프레임마다 다시 그려주기
                if (Event.current.type == EventType.Layout)
                {
                    editor.Repaint();
                }

                Vector2 mPos = Event.current.mousePosition;

                // 툴팁 영역이 겹칠 경우, 더 나중에 그려진 컨트롤의 툴팁 표시
                for(int i = TooltipList.Count - 1; i >= 0; i--)
                {
                    OverlayTooltip tooltip = TooltipList[i];

                    if (tooltip.rect.Contains(mPos))
                    {
                        GUI.Box(new Rect(mPos.x + 10f, mPos.y, tooltip.width, tooltip.height), tooltip.text);
                        //editor.Repaint();
                        break;
                    }
                }
            }

            if(TooltipList.Count > 0)
                TooltipList.Clear();

            // Init() 여부 검사
            if(initAndFinalizationCount == 0)
                Debug.LogError("OnInspectorGUI() 상단에서 RItoEditorGUI.Options.Init()을 호출하세요.");
            else
                initAndFinalizationCount = 0;
        }

        #endregion
    }
}

#endif