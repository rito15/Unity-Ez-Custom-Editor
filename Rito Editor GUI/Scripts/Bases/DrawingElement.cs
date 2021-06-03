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
    using REG = RitoEditorGUI;
    using fPixel = System.Single;
    using fRatio = System.Single;

    public abstract class DrawingElement<T, R> : GUIElement<R> where R : DrawingElement<T, R>
    {
        protected T value;
        protected bool isChanged;

        public abstract R Draw(in fRatio xLeft, in fRatio xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f);

        public virtual R Draw(in float height)
            => Draw(0f, 1f, 0f, height, 0f, 0f);

        public virtual R Draw(in fRatio xLeft, in fRatio xRight)
            => Draw(xLeft, xRight, 0f, REG.LayoutControlHeight, 0f, 0f);

        public virtual R Draw(in fRatio xLeft, in fRatio xRight, in float height)
            => Draw(xLeft, xRight, 0f, height, 0f, 0f);

        // 레이아웃 요소?
        // - 높이 자동 설정(기본 높이 : 18f)
        // - 하단 여백(Space) 자동 지정(기본 높이 18f + 기본 여백 2f)

        /// <summary> 레이아웃 요소로 그리기 </summary>
        public virtual R DrawLayout()
        {
            Draw(REG.LayoutXLeft, REG.LayoutXRight, 0f, REG.LayoutControlHeight,
                REG.LayoutXLeftOffset, REG.LayoutXRightOffset);
            REG.Space(REG.LayoutControlHeight + REG.LayoutControlBottomMargin);

            isLastLayout = true;
            return this as R;
        }
        /// <summary> 레이아웃 요소로 그리기 + 너비(비율) 설정 </summary>
        public virtual R DrawLayout(in fRatio xLeft, in fRatio xRight)
        {
            Draw(xLeft, xRight, 0f, REG.LayoutControlHeight, REG.LayoutXLeftOffset, REG.LayoutXRightOffset);
            REG.Space(REG.LayoutControlHeight + REG.LayoutControlBottomMargin);

            isLastLayout = true;
            return this as R;
        }
        /// <summary> 레이아웃 요소로 그리기 + 너비(비율, 픽셀) 설정 </summary>
        public virtual R DrawLayout(in fRatio xLeft, in fRatio xRight,
                                    in float xLeftOffset, in float xRightOffset)
        {
            Draw(xLeft, xRight, 0f, REG.LayoutControlHeight, xLeftOffset, xRightOffset);
            REG.Space(REG.LayoutControlHeight + REG.LayoutControlBottomMargin);

            isLastLayout = true;
            return this as R;
        }

        public virtual T GetValue() => this.value;
        public virtual R GetValue(out T variable)
        {
            variable = this.value;
            return this as R;
        }

        /// <summary> GUI의 변화 여부 반환 </summary>
        public R GetChangeState(out bool variable)
        {
            variable = this.isChanged;
            return this as R;
        }
    }
}

#endif