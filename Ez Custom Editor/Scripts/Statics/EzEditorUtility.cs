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
    using EZU = EzEditorUtility;

    public static class EzEditorUtility
    {
        /***********************************************************************
        *                               Internal Setting Class
        ***********************************************************************/
        #region .
        public class Setting
        {
            public static readonly string ResetMethodName  = nameof(ResetSettings);
            public static readonly string InitMethodName   = nameof(InitGUI);
            public static readonly string FinishMethodName = nameof(Finish);

            private static readonly Setting instance = new Setting();

            private Setting() { }

            public Setting SetMargins(
                float left = DefaultMarginLeft, float right = DefaultMarginRight, 
                float top = DefaultMarginTop, float bottom = DefaultMarginBottom)
            {
                marginLeft = left;
                marginRight = right;
                marginTop = top;
                marginBottom = bottom;
                return this;
            }

            /// <summary> 렉트 디버거 토글 생성 </summary>
            public Setting ActivateRectDebugger(bool value = true)
            {
                EZU.ShowRectDebugToggle = value;
                return this;
            }
            /// <summary> 디버그 렉트 색상 설정 </summary>
            public Setting SetDebugRectColor(in Color color)
            {
                EZU.RectDebugColor = color;
                return this;
            }

            /// <summary> 툴팁 디버거 토글 생성 </summary>
            public Setting ActivateTooltipDebugger(bool value = true)
            {
                EZU.ShowTooltipDebugToggle = value;
                return this;
            }
            /// <summary> 디버그 렉트 색상 설정 </summary>
            public Setting SetDebugTooltipColor(in Color color)
            {
                EZU.TooltipDebugColor = color;
                return this;
            }

            /// <summary> 레이아웃 요소의 기본 높이, 하단 여백 설정 </summary>
            public Setting SetLayoutControlHeight(float height = DefaultLayoutControlHeight, 
                float bottomMargin = DefaultLayoutControlBottomMargin)
            {
                EZU.SetLayoutControlHeight(height, bottomMargin);

                return this;
            }
            /// <summary> 레이아웃 요소의 X 좌표 비율, 오프셋을 통한 너비 설정 </summary>
            public Setting SetLayoutControlWidth(float xLeft = 0f, float xRight = 1f,
                float xLeftOffset = 0f, float xRightOffset = 0f)
            {
                EZU.SetLayoutControlWidth(xLeft, xRight, xLeftOffset, xRightOffset);

                return this;
            }
            /// <summary> 에디터 우측 스크롤바 존재유무에 관계 없이 판정 너비 고정하기 </summary>
            public Setting KeepSameViewWidth(bool value = true)
            {
                AlwaysKeepSameViewWidth = value;
                return this;
            }
            /// <summary> 에디터의 배경 색상 지정 </summary>
            public Setting SetEditorBackgroundColor(in Color color)
            {
                if (ErrorOccured) return this;

                Rect editorFullRect = new Rect(0f, 0f, EditorGUIUtility.currentViewWidth, EditorTotalHeight);
                EditorGUI.DrawRect(editorFullRect, color);
                return this;
            }
            /// <summary> Defualt를 참조했을 때 사용할 테마 설정 </summary>
            public Setting SetDefaultColorTheme(EColor colorTheme)
            {
                EZU.SetDefaultColorTheme(colorTheme);
                return this;
            }
            /// <summary> Undo 등록 </summary>
            public Setting RegisterUndo(bool value = true)
            {
                EZU.IsUndoRegistered = value;
                return this;
            }

            /// <summary> OnEnable()에서 호출 </summary>
            private static void ResetSettings()
            {
                // Debugs
                RectDebugColor = Color.red;
                TooltipDebugColor = Color.red.SetA(0.7f);
                ShowRectDebugToggle = false;
                ShowTooltipDebugToggle = false;
                AlwaysKeepSameViewWidth = false;

                // Settings
                EZU.SetLayoutControlHeight();
                EZU.SetLayoutControlWidth();
                EZU.SetDefaultColorTheme();
                EZU.IsUndoRegistered = false;

                // Margins
                marginLeft = DefaultMarginLeft;
                marginRight = DefaultMarginRight;
                marginTop = DefaultMarginTop;
                marginBottom = DefaultMarginBottom;
            }

            /// <summary> OnInspectorGUI() 상단에서 호출 </summary>
            private static void InitGUI()
            {
                EZU.CurrentY = 0f;

                // 인스펙터 상단부에 디버그 On/Off 토글 생성
                DrawDebuggerToggles();

                // 우측 스크롤바 존재 유무에 따라 유동적인 너비 설정
                EditorGUILayout.Space(0f);
                float flexibleViewWidth = GUILayoutUtility.GetLastRect().width + 23f;
                flexibleViewWidth = Mathf.Min(flexibleViewWidth, EditorGUIUtility.currentViewWidth);

                EZU.ViewWidth =
                    (AlwaysKeepSameViewWidth ?
                        EditorGUIUtility.currentViewWidth :
                        flexibleViewWidth)
                    - marginLeft
                    - marginRight;

                EZU.Space(marginTop);
            }
            private static void DrawDebuggerToggles()
            {
                const float toggleLeftMargin = 8f;
                float viewWidth = EditorGUIUtility.currentViewWidth - toggleLeftMargin;

                // 1. Rect Debugger
                if (EZU.ShowRectDebugToggle)
                {
                    Rect toggleRect = new Rect(toggleLeftMargin, EZU.CurrentY + 2f, viewWidth, DebugToggleHeight - 4f);
                    Rect line = new Rect(0f, EZU.CurrentY, EditorGUIUtility.currentViewWidth, DebugToggleHeight);

                    EditorGUI.DrawRect(line, Color.black);
                    using (var cc = new EditorGUI.ChangeCheckScope())
                    {
                        EZU.ToggleRectDebugOn =
                            EditorGUI.ToggleLeft(toggleRect, "Rect Debug", EZU.ToggleRectDebugOn);

                        if (cc.changed)
                            PlayerPrefs.SetInt(EZU.RectDebugPrefName, EZU.ToggleRectDebugOn ? 1 : 0);
                    }
                    EZU.Space(DebugToggleHeight);
                }

                // 2. Tooltip Debugger
                if (EZU.ShowTooltipDebugToggle)
                {
                    Rect toggleRect = new Rect(toggleLeftMargin, EZU.CurrentY + 2f, viewWidth, DebugToggleHeight - 4f);
                    Rect line = new Rect(0f, EZU.CurrentY, EditorGUIUtility.currentViewWidth, DebugToggleHeight);

                    EditorGUI.DrawRect(line, Color.black);
                    using (var cc = new EditorGUI.ChangeCheckScope())
                    {
                        EZU.ToggleTooltipDebugOn =
                            EditorGUI.ToggleLeft(toggleRect, "Tooltip Debug", EZU.ToggleTooltipDebugOn);

                        if (cc.changed)
                            PlayerPrefs.SetInt(EZU.TooltipDebugPrefName, EZU.ToggleTooltipDebugOn ? 1 : 0);
                    }
                    EZU.Space(DebugToggleHeight);
                }
            }

            private static void Finish(ScriptableObject editor)
            {
                Space(marginBottom);

                // 컨트롤 없는 부분에 클릭할 경우 강제로 포커스 제거
                if (Event.current.type == EventType.MouseDown)
                {
                    EditorGUI.FocusTextInControl("");
                }

                // 툴팁 디버거, 툴팁 기능 동작
                ShowTooltips(editor);

                // 에디터 전체 높이 계산
                // 1. 에디터 윈도우
                if (editor is EditorWindow ew)
                {
                    EditorTotalHeight = ew.position.height;
                }
                // 2. 커스텀 에디터
                else
                {
                    EditorTotalHeight = CurrentY + EditorDefaultMarginBottom;
                }
            }

        }// public class Setting

        #endregion
        /***********************************************************************
        *                               Fields, Properties
        ***********************************************************************/
        #region .
        private static float marginTop;
        private static float marginLeft;
        private static float marginRight;
        private static float marginBottom;

        private const float DefaultMarginTop = 8f;
        private const float DefaultMarginLeft = 18f;
        private const float DefaultMarginRight = 8f;
        private const float DefaultMarginBottom = 0f;

        /// <summary> 현재 커서(Y 좌표) 위치 </summary>
        public static float CurrentY { get; private set; }
        public static float Cursor => CurrentY;

        /// <summary> CurrentViewWidth에서 MarginLeft, MarginRight를 뺀 너비 </summary>
        public static float ViewWidth { get; private set; }

        public static readonly Color DefaultTooltipTextColor = Color.white * 10f;
        public static readonly Color DefaultTooltipBgColor = Color.black.SetA(0.5f);

        public static List<OverlayTooltip> TooltipList { get; } = new List<OverlayTooltip>();
        public static List<Rect> TooltipDebugRectList { get; } = new List<Rect>();

        //--

        /// <summary> 스크롤바 존재유무 관계 없이 항상 너비 고정하기 </summary>
        private static bool AlwaysKeepSameViewWidth { get; set; }

        /// <summary> 에디터 전체 영역 높이 </summary>
        private static float EditorTotalHeight { get; set; }

        /// <summary> 윈도우의 기본 하단 여백 </summary>
        const float EditorDefaultMarginBottom = 10f;

        #endregion
        /***********************************************************************
        *                               Setting Fields
        ***********************************************************************/
        #region .

        /// <summary> 레이아웃 요소의 기본 높이 </summary>
        public static float LayoutControlHeight { get; private set; } = DefaultLayoutControlHeight;
        /// <summary> 레이아웃 요소의 기본 하단 여백 </summary>
        public static float LayoutControlBottomMargin { get; private set; } = DefaultLayoutControlBottomMargin;

        public const float DefaultLayoutControlHeight = 18f;
        public const float DefaultLayoutControlBottomMargin = 2f;


        /// <summary> 레이아웃 요소의 X 좌측 위치(비율) </summary>
        public static float LayoutXLeft { get; private set; } = 0f;

        /// <summary> 레이아웃 요소의 X 우측 위치(비율) </summary>
        public static float LayoutXRight { get; private set; } = 1f;

        /// <summary> 레이아웃 요소의 X 좌측 위치 조정값(픽셀) </summary>
        public static float LayoutXLeftOffset { get; private set; } = 0f;

        /// <summary> 레이아웃 요소의 X 우측 위치 조정값(픽셀) </summary>
        public static float LayoutXRightOffset { get; private set; } = 0f;


        public static bool IsUndoRegistered { get; private set; }

        public static EColor DefaultColorTheme { get; private set; } = EColor.Gray;

        #endregion
        /***********************************************************************
        *                               Debug Fields
        ***********************************************************************/
        #region .

        private const float DebugToggleHeight = 24f;

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
            AlreadyInitiated,
        }

        private static ErrorType errorType;

        private static readonly Dictionary<ErrorType, string> errorMessageDict = new Dictionary<ErrorType, string>
        {
            { ErrorType.NeverInitalized, "OnInspectorGUI() 상단에서 RItoEditorGUI.Settings.Init()을 호출하세요." },
            { ErrorType.NeverFinalized,  "OnInspectorGUI() 하단에서 RitoEditorGUI.Finalize(this)를 호출하세요." },
            { ErrorType.AlreadyInitiated,  "RItoEditorGUI.Settings.Init() 메소드는 단 한 번만 호출해야 합니다." },
        };

        #endregion
        /***********************************************************************
        *                               Tiny Methods
        ***********************************************************************/
        #region .
        public static void Space(float height = 8f)
        {
            if(ErrorOccured) return;
            if(height < 0) return;

            CurrentY += height;

            // Exception Fixed : 2021. 06. 04. 00:51
            /*
                ArgumentException: Getting control position in a group 
                with only ## controls when doing repaint

                -> Color Picker 또는 오브젝트 선택 팝업을 띄울 때 발생
                -> 이벤트 타입이 Layout일 때만 Space() 호출함으로써 해결
            */
            //if (Event.current.type == EventType.Layout)

            // 2021. 06. 04. 20:40
            /*
                위와 같이 해결할 경우, EditorGUILayout 요소가 
                RitoEditorGUI 요소들과 함께 그려지지 않고,
                에디터 꼭대기에서 그려지는 현상 발생

                부득이하게 try-catch(ArgumentException)으로 해결
            */
            try
            {
                EditorGUILayout.Space(height);
            }
            catch (ArgumentException) { }
        }

        // xLeft : Rect 좌측 끝의 위치 비율(0 ~ 1)
        // xRight : Rect 우측 끝의 위치 비율(0 ~ 1)
        // yOffset : CurrentY 기준 픽셀 좌표
        // height : Rect의 높이(픽셀 값)
        public static Rect GetRect(in float xLeft, in float xRight, float yOffset, in float height)
        {
            return new Rect
            (
                marginLeft + ViewWidth * xLeft, 
                CurrentY + yOffset, 
                ViewWidth * (xRight - xLeft), 
                height
            );
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
        *                               Private Methods
        ***********************************************************************/
        #region .

        private static void ShowTooltips(ScriptableObject editor)
        {
            Vector2 mPos = Event.current.mousePosition;
            bool editorIsWindow = editor is EditorWindow;

            // 화면을 넘어가지 않는 rect 영역 계산하기
            Rect Local_GetTooltipRect(in float width, in float height)
            {
                float tooltipRectX = (mPos.x < ViewWidth - width) ? mPos.x + 10f : mPos.x - width;
                float tooltipRectY = (mPos.y < EditorTotalHeight - height) ? mPos.y : mPos.y - height;
                return new Rect(tooltipRectX, tooltipRectY, width, height);
            }
            void Local_Repaint()
            {
                // 매 에디터 프레임마다 다시 그려주기
                if (Event.current.type == EventType.Layout)
                {
                    switch (editor)
                    {
                        case Editor e: e.Repaint(); break;
                        case EditorWindow ew: ew.Repaint(); break;
                    }
                }
            }

            // 여백 영역 계산
            float yMin = 0f;
            if (ShowRectDebugToggle) yMin += DebugToggleHeight;
            if (ShowTooltipDebugToggle) yMin += DebugToggleHeight;

            float fullWidth = ViewWidth + marginLeft + marginRight;
            float fullHeight = EditorTotalHeight - yMin;

            Rect[] marginRects = new Rect[]
            {
                // Top
                new Rect(0f, yMin, fullWidth, marginTop),
                // Left
                new Rect(0f, yMin, marginLeft, fullHeight), 
                // Right
                new Rect(marginLeft + ViewWidth, yMin, marginRight, fullHeight),
                
                // Bottom
                new Rect(0f, CurrentY - marginBottom, fullWidth, marginBottom), 
                // Bottom : Inspector Default Margin
                new Rect(0f, CurrentY, fullWidth, EditorDefaultMarginBottom),
            };

            string[] tooltipStrings = new string[]
            {
                $"Margin Top : {marginTop} ({0f} ~ {marginTop})",
                $"Margin Left : {marginLeft} ({0f} ~ {marginLeft})",
                $"Margin Right : {marginRight} ({fullWidth - marginRight} ~ {fullWidth})",

                $"Margin Bottom : {marginBottom} ({CurrentY - marginBottom - yMin} ~ {CurrentY - yMin})",
                $"Default Margin : {EditorDefaultMarginBottom} ({CurrentY - yMin} ~ {CurrentY + EditorDefaultMarginBottom - yMin})",
            };

            int marginCount = editorIsWindow ? 3 : 5;

            // 1. 렉트 디버거 - 여백 영역 표시
            if (RectDebugActivated)
            {
                for (int i = 0; i < marginCount; i++)
                {
                    EditorGUI.DrawRect(marginRects[i], RectDebugColor.SetA(0.2f));
                }
            }

            // 2. 툴팁 디버거
            if (TooltipDebugActivated)
            {
                Local_Repaint();

                bool tooltipShowed = false;

                // 2-1. 각 컨트롤 영역
                for (int i = TooltipDebugRectList.Count - 1; i >= 0; i--)
                {
                    Rect curRect = TooltipDebugRectList[i];

                    if (curRect.Contains(mPos))
                    {
                        // [1] Control Rect
                        EditorGUI.DrawRect(curRect, TooltipDebugColor);

                        // [2] Tooltip Rect
                        float tooltipRectWidth = 270f;
                        float tooltipRectHeight = 60f;
                        Rect tooltipRect = Local_GetTooltipRect(tooltipRectWidth, tooltipRectHeight);
                        EditorGUI.DrawRect(tooltipRect, Color.black.SetA(0.8f));

                        // [2] Tooltip Rect : Label
                        float debugY = curRect.y;
                        float viewHeight = EditorTotalHeight - marginTop;

                        if(!editorIsWindow)
                            viewHeight -= (marginBottom + EditorDefaultMarginBottom);

                        if (ShowRectDebugToggle)
                        {
                            debugY -= DebugToggleHeight;
                            viewHeight -= DebugToggleHeight;
                        }
                        if (ShowTooltipDebugToggle)
                        {
                            debugY -= DebugToggleHeight;
                            viewHeight -= DebugToggleHeight;
                        }

                        float xLeft = (curRect.x - marginLeft) / ViewWidth;
                        float xRight = (curRect.xMax - marginLeft) / ViewWidth;
                        float yTop = (debugY - marginTop) / viewHeight;
                        float yBottom = (debugY + curRect.height - marginTop) / viewHeight;

                        string debugInfoLeft =
                            $"xMin : {curRect.x} ({xLeft:F3})\n" +
                            $"xMax : {curRect.x + curRect.width} ({xRight:F3})\n" +
                            $"Width : {curRect.width} ({(xRight - xLeft):F3})";
                        string debugInfoRight =
                            $"yMin : {debugY} ({yTop:F3})\n" +
                            $"yMax : {debugY + curRect.height} ({yBottom:F3})\n" +
                            $"Height : {curRect.height} ({(yBottom - yTop):F3})";

                        tooltipRect.x += 10f;
                        Rect leftRect = new Rect(tooltipRect);
                        Rect rightRect = new Rect(tooltipRect);
                        leftRect.width *= 0.5f;
                        rightRect.width *= 0.5f;
                        rightRect.x += rightRect.width;

                        EditorGUI.LabelField(leftRect, debugInfoLeft);
                        EditorGUI.LabelField(rightRect, debugInfoRight);

                        tooltipShowed = true;
                        break;
                    }
                }

                // 2-2. 여백
                if (!tooltipShowed)
                {
                    for (int i = 0; i < marginCount; i++)
                    {
                        if (marginRects[i].Contains(mPos))
                        {
                            EditorGUI.DrawRect(marginRects[i], TooltipDebugColor);

                            Rect tooltipRect = Local_GetTooltipRect(200f, 25f);
                            EditorGUI.DrawRect(tooltipRect, Color.black.SetA(0.8f));

                            var oldAlign = EditorStyles.label.alignment;
                            EditorStyles.label.alignment = TextAnchor.MiddleCenter;

                            EditorGUI.LabelField(tooltipRect, tooltipStrings[i]);

                            EditorStyles.label.alignment = oldAlign;
                            break;
                        }
                    }
                }
            }
            // 3. 툴팁 기능
            else
            {
                Local_Repaint();

                var oldTextColor = EditorStyles.label.normal.textColor;
                var oldAlign = EditorStyles.label.alignment;
                EditorStyles.label.alignment = TextAnchor.MiddleCenter;

                // 툴팁 영역이 겹칠 경우, 더 나중에 그려진 컨트롤의 툴팁 표시
                for (int i = TooltipList.Count - 1; i >= 0; i--)
                {
                    OverlayTooltip tooltip = TooltipList[i];
                    Rect rect = Local_GetTooltipRect(tooltip.width, tooltip.height);

                    if (tooltip.rect.Contains(mPos))
                    {
                        EditorStyles.label.normal.textColor = tooltip.textColor;
                        EditorGUI.DrawRect(rect, tooltip.backgroundColor);
                        EditorGUI.LabelField(rect, tooltip.text);
                        break;
                    }
                }
                EditorStyles.label.normal.textColor = oldTextColor;
                EditorStyles.label.alignment = oldAlign;
            }

            TooltipDebugRectList.Clear();
            TooltipList.Clear();
        }

        private static void ShowErrorHelpbox()
        {
            EditorGUILayout.HelpBox(errorMessageDict[errorType], MessageType.Error);
        }

        #endregion
        /***********************************************************************
        *                               Public Methods
        ***********************************************************************/
        #region 

        /// <summary> 레이아웃 요소의 기본 높이, 하단 여백 설정 </summary>
        public static void SetLayoutControlHeight(
            float height = DefaultLayoutControlHeight,
            float bottomMargin = DefaultLayoutControlBottomMargin)
        {
            if (height < 0f) height = 0f;
            if (bottomMargin < 0f) bottomMargin = 0f;

            LayoutControlHeight = height;
            LayoutControlBottomMargin = bottomMargin;
        }

        /// <summary> 레이아웃 요소의 X 좌표 비율, 오프셋을 통한 너비 설정 </summary>
        public static void SetLayoutControlWidth(float xLeft = 0f, float xRight = 1f,
                float xLeftOffset = 0f, float xRightOffset = 0f)
        {
            LayoutXLeft = xLeft;
            LayoutXRight = xRight;
            LayoutXLeftOffset = xLeftOffset;
            LayoutXRightOffset = xRightOffset;
        }

        /// <summary> Default를 참조했을 때 사용할 테마 설정 </summary>
        public static void SetDefaultColorTheme(EColor colorTheme = EColor.Gray)
        {
            DefaultColorTheme = colorTheme;
        }

        #endregion
    }
}

#endif