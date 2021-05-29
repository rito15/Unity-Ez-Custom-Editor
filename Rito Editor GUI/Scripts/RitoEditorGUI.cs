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

            /// <summary> 렉트 디버거 토글 생성 </summary>
            public OptionBuilder ActivateRectDebugger(bool value)
            {
                REG.ShowRectDebugToggle = value;
                return this;
            }
            /// <summary> 디버그 렉트 색상 설정 </summary>
            public OptionBuilder SetDebugRectColor(in Color color)
            {
                REG.RectDebugColor = color;
                return this;
            }

            /// <summary> 툴팁 디버거 토글 생성 </summary>
            public OptionBuilder AcrivateTooltipDebugger(bool value)
            {
                REG.ShowTooltipDebugToggle = value;
                return this;
            }
            /// <summary> 디버그 렉트 색상 설정 </summary>
            public OptionBuilder SetTooltipDebugColor(in Color color)
            {
                REG.TooltipDebugColor = color;
                return this;
            }

            /// <summary> 레이아웃 요소의 기본 높이, 하단 여백 설정 </summary>
            public OptionBuilder SetLayoutControlHeight(float height = 18f, float bottomMargin = 2f)
            {
                if(height < 0f) height = 0f;
                if(bottomMargin < 0f) bottomMargin = 0f;

                LayoutControlHeight = height;
                LayoutControlBottomMargin = bottomMargin;

                return this;
            }
            public OptionBuilder AllowTooltip(bool value)
            {
                REG.ShowTooltip = value;
                return this;
            }

            public void Init()
            {
                REG.CurrentY = 0f;

                // Finalize() 여부 검사
                if (initAndFinalizationCount < 2f)
                {
                    initAndFinalizationCount++;
                    ErrorOccured = false;
                }
                else
                {
                    ErrorOccured = true;
                    errorType = ErrorType.NeverFinalized;
                    ShowErrorHelpbox();
                    return;
                }

                // 인스펙터 상단부에 디버그 On/Off 토글 생성
                ShowDebuggerToggles();

                // -------------------------------------------------------------------------------------
                REG.ViewWidth =
                    EditorGUIUtility.currentViewWidth
                    - marginLeft
                    - marginRight;

                REG.Space(marginTop);
            }
            private void ShowDebuggerToggles()
            {
                float viewWidth = EditorGUIUtility.currentViewWidth - marginLeft - marginRight;

                // 1. Rect Debugger
                if (REG.ShowRectDebugToggle)
                {
                    Rect toggleRect = new Rect(marginLeft, REG.CurrentY + 2f, viewWidth, 20f);
                    Rect line = new Rect(0f, REG.CurrentY, EditorGUIUtility.currentViewWidth, 24f);

                    EditorGUI.DrawRect(line, Color.black);
                    using (var cc = new EditorGUI.ChangeCheckScope())
                    {
                        REG.ToggleRectDebugOn =
                            EditorGUI.ToggleLeft(toggleRect, "Rect Debug", REG.ToggleRectDebugOn);

                        if (cc.changed)
                            PlayerPrefs.SetInt(REG.RectDebugPrefName, REG.ToggleRectDebugOn ? 1 : 0);
                    }
                    REG.Space(24f);
                }

                // 2. Tooltip Debugger
                if (REG.ShowTooltipDebugToggle)
                {
                    Rect toggleRect = new Rect(marginLeft, REG.CurrentY + 2f, viewWidth, 20f);
                    Rect line = new Rect(0f, REG.CurrentY, EditorGUIUtility.currentViewWidth, 24f);

                    EditorGUI.DrawRect(line, Color.black);
                    using (var cc = new EditorGUI.ChangeCheckScope())
                    {
                        REG.ToggleTooltipDebugOn =
                            EditorGUI.ToggleLeft(toggleRect, "Tooltip Debug", REG.ToggleTooltipDebugOn);

                        if (cc.changed)
                            PlayerPrefs.SetInt(REG.TooltipDebugPrefName, REG.ToggleTooltipDebugOn ? 1 : 0);
                    }
                    REG.Space(24f);
                }
            }
        }

        #endregion
        /***********************************************************************
        *                               Debug
        ***********************************************************************/
        #region .

        // 1. Rect Debugger
        /// <summary> 인스펙터 상단에 렉트 디버그 토글을 표시할지 여부 </summary>
        public static bool ShowRectDebugToggle { get; private set; }

        /// <summary> 디버그 토글로 제어 - 렉트 디버그 활성화 여부 결정 </summary>
        public static bool ToggleRectDebugOn { get; private set; }

        /// <summary> 최종적으로 디버그 실행 가능 여부 </summary>
        public static bool RectDebugActivated => ShowRectDebugToggle && ToggleRectDebugOn;

        public static Color RectDebugColor { get; private set; } = Color.red;

        public const string RectDebugPrefName = "Rito_EditorGUI_RectDebug";


        // 2. Tooltip Debugger
        public static bool ShowTooltipDebugToggle { get; private set; }
        public static bool ToggleTooltipDebugOn { get; private set; }
        public static bool TooltipDebugActivated => ShowTooltipDebugToggle && ToggleTooltipDebugOn;

        public static Color TooltipDebugColor { get; private set; } = new Color(1.0f, 0.0f, 0.0f, 0.6f);

        public const string TooltipDebugPrefName = "Rito_EditorGUI_TooltipDebug";


        //--
        private static int initAndFinalizationCount = 0;

        [InitializeOnLoadMethod]
        static void LoadPrefsData()
        {
            ToggleRectDebugOn = PlayerPrefs.GetInt(RectDebugPrefName) == 1;
            ToggleTooltipDebugOn = PlayerPrefs.GetInt(TooltipDebugPrefName) == 1;
        }

        #endregion
        /***********************************************************************
        *                               Error Handling
        ***********************************************************************/
        #region .

        public static bool ErrorOccured { get; private set; } = false;

        private enum ErrorType
        {
            None,
            NeverInitalized,
            NeverFinalized,
        }

        private static ErrorType errorType;

        private static readonly Dictionary<ErrorType, string> errorMessageDict = new Dictionary<ErrorType, string>
        {
            { ErrorType.NeverInitalized, "OnInspectorGUI() 상단에서 RItoEditorGUI.Options.Init()을 호출하세요." },
            { ErrorType.NeverFinalized,  "OnInspectorGUI() 하단에서 RitoEditorGUI.Finalize(this)를 호출하세요." },
        };

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

        /// <summary> 레이아웃 요소의 기본 높이 </summary>
        public static float LayoutControlHeight { get; private set; } = 18f;
        /// <summary> 레이아웃 요소의 기본 하단 여백 </summary>
        public static float LayoutControlBottomMargin { get; private set; } = 2f;

        /// <summary> 툴팁을 표시할 수 있는지 여부 </summary>
        public static bool ShowTooltip { get; private set; } = true;

        public static List<OverlayTooltip> TooltipList { get; } = new List<OverlayTooltip>();
        public static List<OverlayTooltip> DebugTooltipList { get; } = new List<OverlayTooltip>();

        #endregion
        /***********************************************************************
        *                               Tiny Methods
        ***********************************************************************/
        #region .
        public static void Space(float height = 8f)
        {
            if(ErrorOccured) return;

            CurrentY += height;
            EditorGUILayout.Space(height);
        }
        public static void Space(float height, float space)
        {
            height += space;
            CurrentY += (height);
            EditorGUILayout.Space(height);
        }

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
            // Init() 여부 검사
            if (initAndFinalizationCount == 0)
            {
                ErrorOccured = true;
                errorType = ErrorType.NeverInitalized;
                ShowErrorHelpbox();
                return;
            }
            else
            {
                initAndFinalizationCount = 0;
                ErrorOccured = false;
            }

            EditorGUILayout.Space(marginBottom);

            // 컨트롤 없는 부분에 클릭할 경우 강제로 포커스 제거
            if (Event.current.type == EventType.MouseDown)
            {
                EditorGUI.FocusTextInControl("");
            }


            // 툴팁 디버거, 툴팁 기능 동작
            ShowTooltips(editor);
        }

        private static void ShowTooltips(Editor editor)
        {
            // 1. 툴팁 디버거
            if (TooltipDebugActivated)
            {
                // 매 에디터 프레임마다 다시 그려주기
                if (Event.current.type == EventType.Layout)
                {
                    editor.Repaint();
                }

                Vector2 mPos = Event.current.mousePosition;

                for (int i = DebugTooltipList.Count - 1; i >= 0; i--)
                {
                    OverlayTooltip tooltip = DebugTooltipList[i];

                    if (tooltip.rect.Contains(mPos))
                    {
                        EditorGUI.DrawRect(tooltip.rect, TooltipDebugColor);

                        float infoRectWidth = 180f;
                        float infoRectHeight = 80f;
                        float infoRectX = (mPos.x < ViewWidth - infoRectWidth) ? mPos.x + 10f : mPos.x - infoRectWidth;
                        float infoRectY = (mPos.y < CurrentY - infoRectHeight) ? mPos.y : mPos.y - infoRectHeight;
                        Rect infoRect = new Rect(infoRectX, infoRectY, infoRectWidth, infoRectHeight);
                        EditorGUI.DrawRect(infoRect, Color.black);

                        infoRect.x += 10f;
                        EditorGUI.LabelField(infoRect, tooltip.text);

                        break;
                    }
                }

                DebugTooltipList.Clear();
            }
            // 2. 툴팁 기능
            else if (ShowTooltip)
            {
                // 매 에디터 프레임마다 다시 그려주기
                if (Event.current.type == EventType.Layout)
                {
                    editor.Repaint();
                }

                Vector2 mPos = Event.current.mousePosition;

                // 툴팁 영역이 겹칠 경우, 더 나중에 그려진 컨트롤의 툴팁 표시
                for (int i = TooltipList.Count - 1; i >= 0; i--)
                {
                    OverlayTooltip tooltip = TooltipList[i];

                    if (tooltip.rect.Contains(mPos))
                    {
                        GUI.Box(new Rect(mPos.x + 10f, mPos.y, tooltip.width, tooltip.height), tooltip.text);
                        break;
                    }
                }

                TooltipList.Clear();
            }
        }

        private static void ShowErrorHelpbox()
        {
            EditorGUILayout.HelpBox(errorMessageDict[errorType], MessageType.Error);
        }

        #endregion
    }
}

#endif