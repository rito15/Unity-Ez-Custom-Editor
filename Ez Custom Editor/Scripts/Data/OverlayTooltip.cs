#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-06-02 PM 4:35:17
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    /// <summary> 마우스를 컨트롤에 올리면 표시할 툴팁 </summary>
    public class OverlayTooltip
    {
        public Rect rect;    // 마우스 인식 영역
        public float width;  // 툴팁의 너비
        public float height; // 툴팁의 높이
        public string text;
        public Color textColor;
        public Color backgroundColor;

        public OverlayTooltip() { }

        public OverlayTooltip(in Rect rect, in float width, in float height, in string text,
            in Color textColor = default, in Color bgColor = default)
        {
            this.rect = rect;
            this.width = width;
            this.height = height;
            this.text = text;
            this.textColor = textColor;
            this.backgroundColor = bgColor;
        }

        public OverlayTooltip Clone(in Rect newRect)
        {
            return new OverlayTooltip
            {
                rect = newRect,
                width = width,
                height = height,
                text = text,
                textColor = textColor,
                backgroundColor = backgroundColor
            };
        }
    }
}

#endif