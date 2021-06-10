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
    using EZU = EzEditorUtility;

    public abstract partial class HeaderBoxBase<R> : GUIElement<R> where R : HeaderBoxBase<R>, new()
    {
        protected GUIStyle headerStyle;

        // Data
        protected float outlineWidth = 0f;
        protected string headerText = "Header";
        protected float headerTextIndent = 0f; // 헤더 텍스트 들여쓰기

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
        public override R Margin(float height = 0f)
        {
            EZU.Space(headerHeight + outlineWidth + height);
            return this as R;
        }

        public abstract R Draw(float xLeft, float xRight, float yOffset,
            float headerHeight, float contentHeight,
            float xLeftOffset = 0f, float xRightOffset = 0f);

        public R Draw(float headerHeight, float contentHeight)
            => Draw(0f, 1f, 0f, headerHeight, contentHeight, 0f, 0f);
        public R Draw(float xLeft, float xRight, float headerHeight, float contentHeight)
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

            float lcHeight = EZU.LayoutControlHeight;
            float lcMargin = EZU.LayoutControlBottomMargin;
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
            EZU.Space(OneHeight + outlineWidth + lcMargin);

            isLastLayout = true;
            return this as R;
        }
    }
    public class HeaderBox : HeaderBoxBase<HeaderBox>
    {
        public static HeaderBox Default
        {
            get
            {
                switch (EzEditorUtility.DefaultColorTheme)
                {
                    default:
                    case EColor.Gray:    return Gray;
                    case EColor.White:   return White;
                    case EColor.Black:   return Black;
                    case EColor.Red:     return Red;    
                    case EColor.Green:   return Green;  
                    case EColor.Blue:    return Blue;   
                    case EColor.Pink:    return Pink;   
                    case EColor.Magenta: return Magenta;
                    case EColor.Violet:  return Violet; 
                    case EColor.Purple:  return Purple; 
                    case EColor.Brown:   return Brown;  
                    case EColor.Gold:    return Gold;   
                    case EColor.Orange:  return Orange; 
                    case EColor.Yellow:  return Yellow; 
                    case EColor.Lime:    return Lime;   
                    case EColor.Mint:    return Mint;    
                    case EColor.Cyan:    return Cyan;   
                }
            }
        }

        public HeaderBox SetData(string headerText, float outlineWidth = 0f, float headerTextIndent = 2f)
        {
            this.headerTextIndent = headerTextIndent;
            this.headerText = headerText;
            this.outlineWidth = outlineWidth;
            return this;
        }

        public override HeaderBox Draw(float xLeft, float xRight, float yOffset,
            float headerHeight, float contentHeight,
            float xLeftOffset = 0f, float xRightOffset = 0f)
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
            Rect headerTextRect = new Rect(x + headerTextIndent, y, w - headerTextIndent, hh);
            Rect contentRect = new Rect(x, y + hh + o, w, ch);
            EditorGUI.DrawRect(headerRect, headerColor);
            EditorGUI.DrawRect(contentRect, contentColor);
            EditorGUI.LabelField(headerTextRect, headerText, headerStyle);

            // Debug
            CheckTooltipDebug(rect);
            CheckTooltipDebug(headerRect);
            CheckTooltipDebug(contentRect);
            CheckDebugRect();

            EndDraw();
            return this;
        }
    }
    public partial class FoldoutHeaderBox : HeaderBoxBase<FoldoutHeaderBox>
    {
        public static FoldoutHeaderBox Default
        {
            get
            {
                switch (EzEditorUtility.DefaultColorTheme)
                {
                    default:
                    case EColor.Gray:    return Gray;
                    case EColor.White:   return White;
                    case EColor.Black:   return Black;
                    case EColor.Red:     return Red;    
                    case EColor.Green:   return Green;  
                    case EColor.Blue:    return Blue;   
                    case EColor.Pink:    return Pink;   
                    case EColor.Magenta: return Magenta;
                    case EColor.Violet:  return Violet; 
                    case EColor.Purple:  return Purple; 
                    case EColor.Brown:   return Brown;  
                    case EColor.Gold:    return Gold;   
                    case EColor.Orange:  return Orange; 
                    case EColor.Yellow:  return Yellow; 
                    case EColor.Lime:    return Lime;   
                    case EColor.Mint:    return Mint;    
                    case EColor.Cyan:    return Cyan;   
                }
            }
        }

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

        public FoldoutHeaderBox SetData(bool foldout, string headerText, float outlineWidth = 0f, float headerTextIndent = 2f)
        {
            this.foldout = foldout;
            this.headerText = headerText;
            this.outlineWidth = outlineWidth;
            this.headerTextIndent = headerTextIndent;
            return this;
        }
        public FoldoutHeaderBox SetData(string headerText, bool foldout, float outlineWidth = 0f, float headerTextIndent = 2f)
        {
            return SetData(foldout, headerText, outlineWidth, headerTextIndent);
        }

        /// <summary> 헤더 높이만큼 Space + 컨텐츠 박스 상단 내부 여백 지정 </summary>
        public override FoldoutHeaderBox Margin(float height = 0f)
        {
            EZU.Space(headerHeight + (foldout ? outlineWidth + height : 0f));
            return this;
        }
        /// <summary> rect 높이 + 레이아웃 요소 기본 여백 + 추가 여백만큼 여백 지정 </summary>
        public override FoldoutHeaderBox Layout()
        {
            return Margin(EZU.LayoutControlBottomMargin);
        }

        public override FoldoutHeaderBox Draw(float xLeft, float xRight, float yOffset,
            float headerHeight, float contentHeight,
            float xLeftOffset = 0f, float xRightOffset = 0f)
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
            Rect headerTextRect = new Rect(x + headerTextIndent, y, w - headerTextIndent, hh);

            // Header Button
            var oldBG = GUI.backgroundColor;
            GUI.backgroundColor = new Color(0, 0, 0, 0);

            if (GUI.Button(headerRect, ""))
            {
                foldout = !foldout;
            }

            GUI.backgroundColor = oldBG;

            // Draw Header Box
            bool mouseOver = headerRect.Contains(Event.current.mousePosition);
            EditorGUI.DrawRect(headerRect, !mouseOver ? headerColor : headerHoverColor);

            // Draw Header Label
            EditorGUI.LabelField(headerTextRect, headerText, headerStyle);


            if (foldout)
            {
                // Draw Content Box
                Rect contentRect = new Rect(x, y + hh + o, w, ch);
                EditorGUI.DrawRect(contentRect, contentColor);

                CheckTooltipDebug(rect);
                CheckTooltipDebug(contentRect);
            }
            else
            {
                rect = headerRect;
            }

            CheckTooltipDebug(headerRect);
            CheckDebugRect();

            EndDraw();
            return this;
        }

        public bool GetValue() => foldout;
        public FoldoutHeaderBox GetValue(out bool value)
        {
            value = this.foldout;
            return this;
        }
        public override FoldoutHeaderBox DrawLayout(int contentCount, float paddingTop, float paddingBottom, float paddingLeft, float paddingRight)
        {
            if (contentCount < 0) contentCount = 0;

            float lcHeight = EZU.LayoutControlHeight;
            float lcMargin = EZU.LayoutControlBottomMargin;
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
                EZU.Space(OneHeight + outlineWidth + lcMargin);
            }
            // 접힌 경우 : 헤더 높이만큼만 Y 전진
            // -> 펼쳐진 경우와 여백을 동일하게 맞추기 위해 하단 아웃라인 두께는 고려하지 않음
            //    (필요하면 그리는 코드에서 수동으로 Space(아웃라인 두께))
            else
            {
                EZU.Space(OneHeight);
            }

            isLastLayout = true;
            return this;
        }
    }
}

#endif