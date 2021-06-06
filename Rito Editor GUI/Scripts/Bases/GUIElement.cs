#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/*
    [TODO]

    - 
*/

/*
    [Memo]

    - Draw() : 현재 CurrentY 값 기준으로 컨트롤 그리기. Space() 하지 않음
    - DrawLayout() : 높이 고정, 하단 여백 고정, 내부적으로 Space(높이 + 하단 여백)

    - Space(f) : CurrentY 이동 및 하단 여백 지정

    - 일반 컨트롤의 경우
        - Margin(f) : 컨트롤 높이 + 지정한 높이만큼 Space()
        - Layout()  : 레이아웃 요소의 높이 + 여백만큼 고정값 Space()

    - Box
        - Margin(f) : Space()와 동일
        - Layout()  : 레이아웃 요소의 여백만큼 고정값 Space()

    - HeaderBox
        - Margin(f) : 헤더 높이 + 아웃라인 두께 + 지정한 높이만큼 Space()
        - Layout()  : 헤더 높이 + 아웃라인 두께 + 레이아웃 요소 여백만큼 Space()

    - FoldoutHeaderBox
        - Margin(), Layout()이 펼쳐진 경우의 컨텐츠박스 상단 여백에만 영향을 미침

        - 펼친 경우 -> HeaderBox와 동일
            - Margin(f) : 헤더 높이 + 아웃라인 두께 + 지정한 높이만큼 Space()
            - Layout()  : 헤더 높이 + 아웃라인 두께 + 레이아웃 요소 여백만큼 Space()

        - 접힌 경우
            - Margin(f) : 헤더 높이만큼 Space()
            - Layout()  : 헤더 높이만큼 Space()
*/

// 날짜 : 2021-05-24 AM 1:32:18
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    using REG = RitoEditorGUI;

    public struct None { public static readonly None Empty = new None(); }

    public abstract class GUIElement<R> where R : GUIElement<R>
    {
        /***********************************************************************
        *                               Fields
        ***********************************************************************/
        #region .

        protected Rect rect;
        protected bool isLastLayout = false; // 마지막으로 그린 요소가 레이아웃 요소였는지 여부

        private OverlayTooltip tooltip;
        private bool tooltipFlag = false; // 툴팁 등록 여부 설정
        private bool debugAllowed = true; // 디버그 허용 여부

        #endregion
        /***********************************************************************
        *                               Public Methods
        ***********************************************************************/
        #region .

        /// <summary> 마지막으로 그린 Rect 가져오기 </summary>
        public Rect GetLastRect()
        {
            return rect;
        }

        /// <summary> 컨트롤에 마우스가 위치할 경우 툴팁 상자를 표시하도록 설정 </summary>
        public R SetTooltip(string text, float width = 100f, float height = 20f)
        {
            return SetTooltip(text, REG.DefaultTooltipTextColor, REG.DefaultTooltipBgColor, width, height);
        }
        /// <summary> 컨트롤에 마우스가 위치할 경우 툴팁 상자를 표시하도록 설정 </summary>
        public virtual R SetTooltip(string text, float width, float height, in Color textColor, in Color backgroundColor)
        {
            return SetTooltip(text, textColor, backgroundColor, width, height);
        }
        /// <summary> 컨트롤에 마우스가 위치할 경우 툴팁 상자를 표시하도록 설정 </summary>
        public R SetTooltip(string text, in Color textColor, in Color backgroundColor, float width = 100f, float height = 20f)
        {
            tooltipFlag = true;
            if(tooltip == null)
                tooltip = new OverlayTooltip();

            //tooltip.rect = this.rect; // CheckTooltip()에서 초기화
            tooltip.text = text;
            tooltip.width = width;
            tooltip.height = height;
            tooltip.textColor = textColor;
            tooltip.backgroundColor = backgroundColor;

            return this as R;
        }

        /// <summary> 하단 여백 지정 </summary>
        public virtual R Space(float height = 8f)
        {
            REG.Space(height);
            return this as R;
        }
        /// <summary> rect 높이 + 지정 높이만큼 여백 지정 </summary>
        public virtual R Margin(float height = 0f)
        {
            if(!isLastLayout) height += rect.height;
            REG.Space(height);
            return this as R;
        }

        // 레이아웃 요소가 아닌 컨트롤을 레이아웃 요소처럼 그리는 효과
        /// <summary> rect 높이 + 레이아웃 요소 기본 여백 지정 </summary>
        public virtual R Layout()
        {
            return Margin(REG.LayoutControlBottomMargin);
        }

        /// <summary> 디버그에서 제외하기 </summary>
        public R ExcludeFromDebug()
        {
            debugAllowed = false;
            return this as R;
        }

        /// <summary> 스타일 그대로 동일하게 복제한 객체 생성 </summary>
        public abstract R Clone();

        #endregion
        /***********************************************************************
        *                           Protected Methods
        ***********************************************************************/
        #region .

        protected bool CheckDrawErrors()
        {
            return REG.ErrorOccured;
        }

        /// <summary> Rect 위치 가시화하여 보여주기 </summary>
        protected void CheckDebugRect(Color color = default, in float border = 1f)
        {
            if(!debugAllowed) return;
            if(!REG.RectDebugActivated) return;
            if(rect == default) return;
            if(color == default) color = REG.RectDebugColor;

            float x = rect.x;
            float y = rect.y;
            float w = rect.width;
            float h = rect.height;

            Rect top = new Rect(x, y, w, border);
            Rect bot = new Rect(x, y + h - border, w, border);
            Rect left  = new Rect(x, y, border, h);
            Rect right = new Rect(x + w - border, y, border, h);

            EditorGUI.DrawRect(top, color);
            EditorGUI.DrawRect(bot, color);
            EditorGUI.DrawRect(left, color);
            EditorGUI.DrawRect(right, color);
        }

        /// <summary> 툴팁, 툴팁 디버그 등록 여부 확인 및 요청 </summary>
        protected void CheckTooltip()
        {
            CheckTooltipDebug(this.rect);
        }
        protected void CheckTooltipDebug(in Rect rect)
        {
            if (REG.TooltipDebugActivated)
            {
                if (debugAllowed)
                {
                    REG.TooltipDebugRectList.Add(rect);
                }
            }
            else if (tooltipFlag)
            {
                tooltipFlag = false;

                if (REG.ShowTooltip)
                {
                    REG.TooltipList.Add(tooltip.Clone(rect));
                }
            }
        }

        /// <summary> Draw() 하단에서 호출 - 디버거 두가지 확인 </summary>
        protected void CheckDebugs()
        {
            CheckTooltip();
            CheckDebugRect();
        }

        /// <summary> Draw() 최하단에서 호출 </summary>
        protected void EndDraw()
        {
            debugAllowed = true;
            isLastLayout = false;
        }

        // xLeft, xRight : ViewWidth에 대한 Rect 좌우 지점의 비율(0 ~ 1)
        /// <summary> 그려질 지점의 Rect 설정 </summary>
        protected void SetRect(in float xLeft, in float xRight, in float yOffset, in float height)
        {
            SetRect(xLeft, xRight, yOffset, height, 0f, 0f);
        }
        /// <summary> 그려질 지점의 Rect 설정 </summary>
        protected void SetRect(in float xLeft, in float xRight, in float yOffset, in float height,
            in float xLeftOffset, in float xRightOffset)
        {
            rect = REG.GetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);
        }

        #endregion
    }

}

#endif