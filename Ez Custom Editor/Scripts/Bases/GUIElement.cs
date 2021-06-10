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
            return SetTooltip(text, EZU.DefaultTooltipTextColor, EZU.DefaultTooltipBgColor, width, height);
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
            EZU.Space(height);
            return this as R;
        }
        /// <summary> rect 높이 + 지정 높이만큼 여백 지정 </summary>
        public virtual R Margin(float height = 0f)
        {
            if(!isLastLayout) height += rect.height;
            EZU.Space(height);
            return this as R;
        }

        // 레이아웃 요소가 아닌 컨트롤을 레이아웃 요소처럼 그리는 효과
        /// <summary> rect 높이 + 레이아웃 요소 기본 여백 지정 </summary>
        public virtual R Layout()
        {
            return Margin(EZU.LayoutControlBottomMargin);
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
            return EZU.ErrorOccured;
        }

        /// <summary> Rect 위치 가시화하여 보여주기 </summary>
        protected void CheckDebugRect(Color color = default, in float border = 1f)
        {
            if(!debugAllowed) return;
            if(!EZU.RectDebugActivated) return;
            if(rect == default) return;
            if(color == default) color = EZU.RectDebugColor;

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
            if (EZU.TooltipDebugActivated)
            {
                if (debugAllowed)
                {
                    EZU.TooltipDebugRectList.Add(rect);
                }
            }
            else if (tooltipFlag)
            {
                tooltipFlag = false;

                EZU.TooltipList.Add(tooltip.Clone(rect));
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
            rect = EZU.GetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);
        }

        #endregion
    }

}

#endif