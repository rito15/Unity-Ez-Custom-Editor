#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-06-02 PM 4:17:12
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    using REG = RitoEditorGUI;

    public partial class Box : GUIElement<Box>
    {
        public static Box Default { get; } = new Box();

        // Data
        protected float outlineWidth = 0f;

        // Styles
        public Color color = Color.gray.SetA(0.5f);
        public Color outlineColor = Color.black;

        public override Box Clone()
        {
            return new Box
            {
                color = color,
                outlineColor = outlineColor
            };
        }

        /***********************************************************************
        *                               Style Setters
        ***********************************************************************/
        #region .

        public Box SetColor(Color color)
        {
            this.color = color;
            return this;
        }
        public Box SetOutlineColor(Color color)
        {
            this.outlineColor = color;
            return this;
        }

        #endregion

        public Box SetData(float outlineWidth)
        {
            this.outlineWidth = outlineWidth;
            return this;
        }

        /// <summary> 박스 상단 내부 여백 지정 (Space()와 동일) </summary>
        public override Box Margin(float margin = 0f)
        {
            REG.Space(margin);
            return this;
        }

        public Box Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this;
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (outlineWidth > 0f)
            {
                ref var o = ref outlineWidth;
                float x = rect.x;
                float y = rect.y;
                float w = rect.width;
                float h = rect.height;

                Rect topLine = new Rect(x, y - o, w, o);
                Rect botLine = new Rect(x, y + h, w, o);
                Rect leftLine = new Rect(x - o, y - o, o, h + 2 * o);
                Rect rightLine = new Rect(x + w, y - o, o, h + 2 * o);

                EditorGUI.DrawRect(topLine, outlineColor);
                EditorGUI.DrawRect(botLine, outlineColor);
                EditorGUI.DrawRect(leftLine, outlineColor);
                EditorGUI.DrawRect(rightLine, outlineColor);
            }
            EditorGUI.DrawRect(rect, color);

            EndDraw();
            return this;
        }

        public Box Draw(in float height)
            => Draw(0f, 1f, 0f, height, 0f, 0f);
        public Box Draw(in float xLeft, in float xRight)
            => Draw(xLeft, xRight, 0f, REG.LayoutControlHeight, 0f, 0f);
        public Box Draw(in float xLeft, in float xRight, in float height)
            => Draw(xLeft, xRight, 0f, height, 0f, 0f);

        /// <summary>
        /// 레이아웃 요소들을 감싸는 헤더박스 그리기
        /// </summary>
        /// <param name="contentCount">레이아웃 요소 개수</param>
        public Box DrawLayout(int contentCount)
        {
            return DrawLayout(contentCount, 0f, 0f, 0f, 0f);
        }
        /// <summary>
        /// 레이아웃 요소들을 감싸는 헤더박스 그리기 + 추가 높이 지정
        /// </summary>
        /// <param name="contentCount">레이아웃 요소 개수</param>
        /// <param name="bonusHeight">추가 높이(paddingBottom) </param>
        public Box DrawLayout(int contentCount, float bonusHeight)
        {
            return DrawLayout(contentCount, 0f, bonusHeight, 0f, 0f);
        }
        /// <summary>
        /// 레이아웃 요소들을 감싸는 헤더박스 그리기
        /// </summary>
        /// <param name="contentCount">레이아웃 요소 개수</param>
        /// <param name="paddingVertical">상하 내부 여백</param>
        /// <param name="paddingHorizontal">좌우 내부 여백</param>
        public Box DrawLayout(int contentCount, float paddingVertical, float paddingHorizontal)
        {
            return DrawLayout(contentCount, paddingVertical, paddingVertical, paddingHorizontal, paddingHorizontal);
        }
        /// <summary>
        /// 레이아웃 요소들을 감싸는 헤더박스 그리기
        /// </summary>
        /// <param name="contentCount">레이아웃 요소 개수</param>
        /// <param name="paddingTop">상단 내부 여백</param>
        /// <param name="paddingBottom">하단 내부 여백</param>
        /// <param name="paddingLeft">좌측 내부 여백</param>
        /// <param name="paddingRight">우측 내부 여백</param>
        public Box DrawLayout(int contentCount, float paddingTop, float paddingBottom, float paddingLeft, float paddingRight)
        {
            if (contentCount < 0) contentCount = 0;

            float lcHeight = REG.LayoutControlHeight;
            float lcMargin = REG.LayoutControlBottomMargin;

            // 모든 레이아웃 요소의 높이 합
            float AllControlHeight = (lcHeight + lcMargin) * contentCount;

            Draw
            (
                xLeft: 0f, xRight: 1f,
                yOffset: -paddingTop,
                height: paddingTop + lcMargin + AllControlHeight + paddingBottom,
                xLeftOffset: -paddingLeft,
                xRightOffset: paddingRight
            );

            // 박스 상단 패딩
            REG.Space(lcMargin);

            isLastLayout = true;
            return this;
        }
    }
}

#endif