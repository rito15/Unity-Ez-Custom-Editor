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
    using fPixel = System.Single;
    using fRatio = System.Single;

    public abstract partial class HeaderBoxBase<R> : GUIElement<R> where R : HeaderBoxBase<R>, new()
    {
        protected GUIStyle headerStyle;

        // Data
        protected float outlineWidth = 0f;
        protected string headerText = "Header";
        protected float headerTextLeftPadding = 0f;

        protected float headerHeight; // 헤더박스 높이

        // Styles - Header Text
        public Color headerTextColor = Color.black;
        public int headerFontSize = 12;
        public FontStyle headerFontStyle = FontStyle.Bold;
        public TextAnchor headerTextAlignment = TextAnchor.MiddleLeft;

        // Styles - Box
        public Color headerColor = Color.gray;
        public Color contentColor = Color.gray.SetA(0.5f);
        public Color outlineColor = Color.black;

        public override R Clone()
        {
            return new R
            {
                headerTextColor = headerTextColor,
                headerFontSize = headerFontSize,
                headerFontStyle = headerFontStyle,
                headerTextAlignment = headerTextAlignment,
                headerColor = headerColor,
                contentColor = contentColor,
                outlineColor = outlineColor,
            };
        }

        /***********************************************************************
        *                               Style Setters
        ***********************************************************************/
        #region .

        public R SetHeaderTextColor(Color color)
        {
            this.headerTextColor = color;
            return this as R;
        }
        public R SetHeaderFontSize(int fontSize)
        {
            this.headerFontSize = fontSize;
            return this as R;
        }
        public R SetHeaderFontStyle(FontStyle fontStyle)
        {
            this.headerFontStyle = fontStyle;
            return this as R;
        }
        public R SetHeaderTextAlignment(TextAnchor alignment)
        {
            this.headerTextAlignment = alignment;
            return this as R;
        }

        public R SetHeaderColor(Color color)
        {
            this.headerColor = color;
            return this as R;
        }
        public R SetContentColor(Color color)
        {
            this.contentColor = color;
            return this as R;
        }
        public R SetOutlineColor(Color color)
        {
            this.outlineColor = color;
            return this as R;
        }

        #endregion

        /// <summary> 헤더 높이만큼 Space + 컨텐츠 박스 상단 내부 여백 지정 </summary>
        public override R Margin(float margin = 0f)
        {
            REG.Space(headerHeight + outlineWidth + margin);
            return this as R;
        }

        public abstract R Draw(in fRatio xLeft, in fRatio xRight, float yOffset,
            in float headerHeight, in float contentHeight,
            in float xLeftOffset = 0f, in float xRightOffset = 0f);

        public R Draw(in float headerHeight, in float contentHeight)
            => Draw(0f, 1f, 0f, headerHeight, contentHeight, 0f, 0f);
        public R Draw(in fRatio xLeft, in fRatio xRight, in float headerHeight, in float contentHeight)
            => Draw(xLeft, xRight, 0f, headerHeight, contentHeight, 0f, 0f);

        /// <summary>
        /// 레이아웃 요소들을 감싸는 헤더박스 그리기
        /// </summary>
        /// <param name="contentCount">레이아웃 요소 개수</param>
        public R DrawLayout(int contentCount)
        {
            return DrawLayout(contentCount, 0f, 0f, 0f, 0f);
        }
        /// <summary>
        /// 레이아웃 요소들을 감싸는 헤더박스 그리기 + 추가 높이 지정
        /// </summary>
        /// <param name="contentCount">레이아웃 요소 개수</param>
        /// <param name="bonusContentHeight">추가 높이(PaddingBottom)</param>
        public R DrawLayout(int contentCount, float bonusContentHeight)
        {
            return DrawLayout(contentCount, 0f, bonusContentHeight, 0f, 0f);
        }
        /// <summary>
        /// 레이아웃 요소들을 감싸는 헤더박스 그리기
        /// </summary>
        /// <param name="contentCount">레이아웃 요소 개수</param>
        /// <param name="paddingVertical">상하 내부 여백</param>
        /// <param name="paddingHorizontal">좌우 내부 여백</param>
        public R DrawLayout(int contentCount, float paddingVertical, float paddingHorizontal)
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
        public virtual R DrawLayout(int contentCount, float paddingTop, float paddingBottom, float paddingLeft, float paddingRight)
        {
            if (contentCount < 0) contentCount = 0;

            float lcHeight = REG.LayoutControlHeight;
            float lcMargin = REG.LayoutControlBottomMargin;
            float OneHeight = lcHeight + lcMargin;

            // 모든 레이아웃 요소의 높이 합
            float AllControlHeight = OneHeight * contentCount;

            Draw
            (
                xLeft: 0f, xRight: 1f,
                yOffset: -paddingTop,
                headerHeight: OneHeight,
                contentHeight: paddingTop + lcMargin + AllControlHeight + paddingBottom,
                xLeftOffset: -paddingLeft,
                xRightOffset: paddingRight
            );

            // 박스 상단 <-> 첫 컨트롤 상단 사이 간격
            // = 헤더 높이 + 헤더와 컨텐츠 사이 아웃라인 높이 + 레이아웃 요소 여백
            REG.Space(OneHeight + outlineWidth + lcMargin);

            isLastLayout = true;
            return this as R;
        }
    }
    public class HeaderBox : HeaderBoxBase<HeaderBox>
    {
        public static HeaderBox Default { get; } = new HeaderBox();

        public HeaderBox SetData(string headerText, float outlineWidth = 0f, float headerTextLeftPadding = 2f)
        {
            this.headerTextLeftPadding = headerTextLeftPadding;
            this.headerText = headerText;
            this.outlineWidth = outlineWidth;
            return this;
        }

        public override HeaderBox Draw(in float xLeft, in float xRight, float yOffset,
            in float headerHeight, in float contentHeight,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this;
            this.headerHeight = headerHeight;
            SetRect(xLeft, xRight, yOffset, headerHeight + contentHeight + outlineWidth, xLeftOffset, xRightOffset);

            if (headerStyle == null)
                headerStyle = new GUIStyle(GUI.skin.label);

            headerStyle.normal.textColor = headerTextColor;
            headerStyle.alignment = headerTextAlignment;
            headerStyle.fontSize = headerFontSize;
            headerStyle.fontStyle = headerFontStyle;

            ref var o = ref outlineWidth;
            float x = rect.x;
            float y = rect.y;
            float w = rect.width;
            float h = rect.height;
            float hh = headerHeight;
            float ch = contentHeight;

            if (outlineWidth > 0f)
            {
                Rect topLine = new Rect(x, y - o, w, o);
                Rect botLine = new Rect(x, y + h, w, o);
                Rect leftLine = new Rect(x - o, y - o, o, h + 2 * o);
                Rect rightLine = new Rect(x + w, y - o, o, h + 2 * o);
                Rect centerLine = new Rect(x, y + hh, w, o);

                EditorGUI.DrawRect(topLine, outlineColor);
                EditorGUI.DrawRect(botLine, outlineColor);
                EditorGUI.DrawRect(leftLine, outlineColor);
                EditorGUI.DrawRect(rightLine, outlineColor);
                EditorGUI.DrawRect(centerLine, outlineColor);
            }

            Rect headerRect = new Rect(x, y, w, hh);
            Rect headerTextRect = new Rect(x + headerTextLeftPadding, y, w - headerTextLeftPadding, hh);
            Rect contentRect = new Rect(x, y + hh + o, w, ch);
            EditorGUI.DrawRect(headerRect, headerColor);
            EditorGUI.DrawRect(contentRect, contentColor);
            EditorGUI.LabelField(headerTextRect, headerText, headerStyle);

            // Debug
            CheckTooltip(rect);
            CheckTooltip(headerRect);
            CheckTooltip(contentRect);

            if (REG.RectDebugActivated)
            {
                DebugRect();
            }
            isLastLayout = false;

            return this;
        }
    }
    public partial class FoldoutHeaderBox : HeaderBoxBase<FoldoutHeaderBox>
    {
        public static FoldoutHeaderBox Default { get; } = new FoldoutHeaderBox();

        protected bool foldout; // true : 펼쳐짐

        protected Color headerHoverColor = RColor.Gray7;

        public override FoldoutHeaderBox Clone()
        {
            FoldoutHeaderBox newBox = base.Clone();
            newBox.headerHoverColor = this.headerHoverColor;
            return newBox;
        }

        /***********************************************************************
        *                               Style Setters
        ***********************************************************************/
        #region .

        public FoldoutHeaderBox SetHeaderHoverColor(Color color)
        {
            this.headerColor = color;
            return this;
        }

        #endregion

        public FoldoutHeaderBox SetData(bool foldout, string headerText, float outlineWidth = 0f, float headerTextLeftPadding = 2f)
        {
            this.foldout = foldout;
            this.headerText = headerText;
            this.outlineWidth = outlineWidth;
            this.headerTextLeftPadding = headerTextLeftPadding;
            return this;
        }
        public FoldoutHeaderBox SetData(string headerText, bool foldout, float outlineWidth = 0f, float headerTextLeftPadding = 2f)
        {
            return SetData(foldout, headerText, outlineWidth, headerTextLeftPadding);
        }

        /// <summary> 헤더 높이만큼 Space + 컨텐츠 박스 상단 내부 여백 지정 </summary>
        public override FoldoutHeaderBox Margin(float margin = 0f)
        {
            REG.Space(headerHeight + (foldout ? outlineWidth + margin : 0f));
            return this;
        }
        /// <summary> rect 높이 + 레이아웃 요소 기본 여백 + 추가 여백만큼 여백 지정 </summary>
        public override FoldoutHeaderBox Layout()
        {
            return Margin(REG.LayoutControlBottomMargin);
        }

        public override FoldoutHeaderBox Draw(in float xLeft, in float xRight, float yOffset,
            in float headerHeight, in float contentHeight,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this;
            this.headerHeight = headerHeight;
            SetRect(xLeft, xRight, yOffset, headerHeight + contentHeight + outlineWidth, xLeftOffset, xRightOffset);

            if (headerStyle == null)
                headerStyle = new GUIStyle(GUI.skin.label);

            headerStyle.normal.textColor = headerTextColor;
            headerStyle.alignment = headerTextAlignment;
            headerStyle.fontSize = headerFontSize;
            headerStyle.fontStyle = headerFontStyle;

            ref var o = ref outlineWidth;
            float x = rect.x;
            float y = rect.y;
            float w = rect.width;
            float h = rect.height;
            float hh = headerHeight;
            float ch = contentHeight;

            if (outlineWidth > 0f)
            {
                Rect topLine = new Rect(x, y - o, w, o);
                Rect leftLine = new Rect(x - o, y - o, o, foldout ? h + 2 * o : hh + 2 * o);
                Rect rightLine = new Rect(x + w, y - o, o, foldout ? h + 2 * o : hh + 2 * o);
                Rect centerLine = new Rect(x, y + hh, w, o);

                EditorGUI.DrawRect(topLine, outlineColor);
                EditorGUI.DrawRect(centerLine, outlineColor);
                EditorGUI.DrawRect(leftLine, outlineColor);
                EditorGUI.DrawRect(rightLine, outlineColor);

                if (foldout)
                {
                    Rect botLine = new Rect(x, y + h, w, o);
                    EditorGUI.DrawRect(botLine, outlineColor);
                }
            }

            Rect headerRect = new Rect(x, y, w, hh);
            Rect headerTextRect = new Rect(x + headerTextLeftPadding, y, w - headerTextLeftPadding, hh);

            // Header Button
            var oldBG = GUI.backgroundColor;
            GUI.backgroundColor = new Color(0, 0, 0, 0);

            if (GUI.Button(headerRect, ""))
            {
                foldout = !foldout;
            }

            GUI.backgroundColor = oldBG;

            // Header Box
            bool mouseOver = headerRect.Contains(Event.current.mousePosition);
            EditorGUI.DrawRect(headerRect, !mouseOver ? headerColor : headerHoverColor);

            // Header Label
            EditorGUI.LabelField(headerTextRect, headerText, headerStyle);


            if (foldout)
            {
                // Content Box
                Rect contentRect = new Rect(x, y + hh + o, w, ch);
                EditorGUI.DrawRect(contentRect, contentColor);

                CheckTooltip(rect);
                CheckTooltip(contentRect);
            }

            // Debug
            CheckTooltip(headerRect);

            if (REG.RectDebugActivated)
            {
                if (!foldout)
                    rect = headerRect;
                DebugRect();
            }
            isLastLayout = false;
            return this;
        }

        public virtual bool GetValue() => foldout;
        public virtual void GetValue(out bool value) => value = this.foldout;
        public override FoldoutHeaderBox DrawLayout(int contentCount, float paddingTop, float paddingBottom, float paddingLeft, float paddingRight)
        {
            if (contentCount < 0) contentCount = 0;

            float lcHeight = REG.LayoutControlHeight;
            float lcMargin = REG.LayoutControlBottomMargin;
            float OneHeight = lcHeight + lcMargin;

            // 모든 레이아웃 요소의 높이 합
            float AllControlHeight = OneHeight * contentCount;

            Draw
            (
                xLeft: 0f, xRight: 1f,
                yOffset: -paddingTop,
                headerHeight: OneHeight,
                contentHeight: paddingTop + lcMargin + AllControlHeight + paddingBottom,
                xLeftOffset: -paddingLeft,
                xRightOffset: paddingRight
            );

            // 펼쳐진 경우 : 박스 상단 <-> 첫 컨트롤 상단 사이 여백
            //             = 헤더 높이 + 헤더와 컨텐츠 사이 아웃라인 너비 + 레이아웃 요소 하단 여백
            if (foldout)
            {
                REG.Space(OneHeight + outlineWidth + lcMargin);
            }
            // 접힌 경우 : 헤더 높이만큼만 Y 전진
            // -> 펼쳐진 경우와 여백을 동일하게 맞추기 위해 하단 아웃라인 두께는 고려하지 않음
            //    (필요하면 그리는 코드에서 수동으로 Space(아웃라인 두께))
            else
            {
                REG.Space(OneHeight);
            }

            isLastLayout = true;
            return this;
        }
    }
}

#endif