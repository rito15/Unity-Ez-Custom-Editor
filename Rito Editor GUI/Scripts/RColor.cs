using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 날짜 : 2021-05-27 AM 2:00:54
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    // [6단계 색상 테스트]
    // 테스트 완료 :
    // - Red, Blue, Green
    // - Yellow, Magenta, Pink, Cyan
    // - Brown

    // 테스트중 : Gold, Orange


    public static class RColor
    {
        /// <summary> 어두운색 : 2단계 - 어두움 </summary>
        public static class Dark
        {
            public static readonly Color Red     = new Color(0.50f, 0.00f, 0.00f, 1.00f);
            public static readonly Color Green   = new Color(0.00f, 0.50f, 0.00f, 1.00f);
            public static readonly Color Blue    = new Color(0.00f, 0.00f, 0.50f, 1.00f);
                 
            public static readonly Color Yellow  = new Color(0.50f, 0.50f, 0.00f, 1.00f);
            public static readonly Color Magenta = new Color(0.50f, 0.00f, 0.50f, 1.00f);
            public static readonly Color Pink    = new Color(0.50f, 0.00f, 0.50f, 1.00f);
            public static readonly Color Cyan    = new Color(0.00f, 0.50f, 0.50f, 1.00f);
            
            public static readonly Color Brown   = new Color(0.20f, 0.00f, 0.00f, 1.00f);

            public static readonly Color Gold    = new Color(0.60f, 0.30f, 0.00f, 1.00f);

        }

        /// <summary> 어두운색 : 1단계 - 약간 어두움 </summary>
        public static class Dim
        {
            public static readonly Color Red     = new Color(0.75f, 0.00f, 0.00f, 1.00f);
            public static readonly Color Green   = new Color(0.00f, 0.75f, 0.00f, 1.00f);
            public static readonly Color Blue    = new Color(0.00f, 0.00f, 0.75f, 1.00f);
                 
            public static readonly Color Yellow  = new Color(0.75f, 0.75f, 0.00f, 1.00f);
            public static readonly Color Magenta = new Color(0.75f, 0.00f, 0.75f, 1.00f);
            public static readonly Color Pink    = new Color(0.75f, 0.00f, 0.75f, 1.00f);
            public static readonly Color Cyan    = new Color(0.00f, 0.75f, 0.75f, 1.00f);
            
            public static readonly Color Brown   = new Color(0.35f, 0.00f, 0.00f, 1.00f);

            public static readonly Color Gold    = new Color(0.70f, 0.55f, 0.00f, 1.00f);

        }

        /// <summary> 기본 밝기 </summary>
        public static class Normal
        {
            // 흑백
            public static readonly Color Black   = new Color(0.00f, 0.00f, 0.00f, 1.00f);
            public static readonly Color Gray1   = new Color(0.10f, 0.10f, 0.10f, 1.00f);
            public static readonly Color Gray2   = new Color(0.20f, 0.20f, 0.20f, 1.00f);
            public static readonly Color Gray3   = new Color(0.30f, 0.30f, 0.30f, 1.00f);
            public static readonly Color Gray4   = new Color(0.40f, 0.40f, 0.40f, 1.00f);
            public static readonly Color Gray    = new Color(0.50f, 0.50f, 0.50f, 1.00f);
            public static readonly Color Gray5   = new Color(0.50f, 0.50f, 0.50f, 1.00f);
            public static readonly Color Gray6   = new Color(0.60f, 0.60f, 0.60f, 1.00f);
            public static readonly Color Gray7   = new Color(0.70f, 0.70f, 0.70f, 1.00f);
            public static readonly Color Gray8   = new Color(0.80f, 0.80f, 0.80f, 1.00f);
            public static readonly Color Gray9   = new Color(0.90f, 0.90f, 0.90f, 1.00f);
            public static readonly Color White   = new Color(1.00f, 1.00f, 1.00f, 1.00f);

            // 원색                              
            public static readonly Color Red     = new Color(1.00f, 0.00f, 0.00f, 1.00f);
            public static readonly Color Green   = new Color(0.00f, 1.00f, 0.00f, 1.00f);
            public static readonly Color Blue    = new Color(0.00f, 0.00f, 1.00f, 1.00f);

            // 혼합색 1
            public static readonly Color Yellow  = new Color(1.00f, 1.00f, 0.00f, 1.00f);
            public static readonly Color Magenta = new Color(1.00f, 0.00f, 1.00f, 1.00f);
            public static readonly Color Pink    = new Color(1.00f, 0.00f, 1.00f, 1.00f);
            public static readonly Color Cyan    = new Color(0.00f, 1.00f, 1.00f, 1.00f);

            // 혼합색 2
            public static readonly Color Gold    = new Color(1.00f, 0.75f, 0.00f, 1.00f);
            public static readonly Color Orange  = new Color(1.00f, 0.40f, 0.00f, 1.00f);
            public static readonly Color Brown   = new Color(0.50f, 0.10f, 0.00f, 1.00f);
            public static readonly Color Violet  = new Color(0.50f, 0.00f, 1.00f, 1.00f);
            public static readonly Color Lime    = new Color(0.75f, 1.00f, 0.00f, 1.00f);
            public static readonly Color Mint    = new Color(0.00f, 1.00f, 0.50f, 1.00f);
        }


        /// <summary> 밝은색 : 1단계 - 약간 밝음 </summary>
        public static class Soft
        {
            public static readonly Color Red     = new Color(1.00f, 0.25f, 0.25f, 1.00f);
            public static readonly Color Green   = new Color(0.25f, 1.00f, 0.25f, 1.00f);
            public static readonly Color Blue    = new Color(0.25f, 0.25f, 1.00f, 1.00f);
                 
            public static readonly Color Yellow  = new Color(1.00f, 1.00f, 0.25f, 1.00f);
            public static readonly Color Magenta = new Color(1.00f, 0.25f, 1.00f, 1.00f);
            public static readonly Color Pink    = new Color(1.00f, 0.25f, 1.00f, 1.00f);
            public static readonly Color Cyan    = new Color(0.25f, 1.00f, 1.00f, 1.00f);
            
            public static readonly Color Gold    = new Color(1.00f, 0.80f, 0.20f, 1.00f);
            public static readonly Color Orange  = new Color(1.00f, 0.50f, 0.20f, 1.00f);
            public static readonly Color Brown   = new Color(0.50f, 0.20f, 0.00f, 1.00f);

            public static readonly Color Violet  = new Color(0.50f, 0.00f, 1.00f, 1.00f);
            public static readonly Color Lime    = new Color(0.75f, 1.00f, 0.00f, 1.00f);
            public static readonly Color Mint    = new Color(0.00f, 1.00f, 0.50f, 1.00f);
        }

        /// <summary> 밝은색 : 2단계 - 밝음 </summary>
        public static class Light
        {
            public static readonly Color Red     = new Color(1.00f, 0.50f, 0.50f, 1.00f);
            public static readonly Color Green   = new Color(0.50f, 1.00f, 0.50f, 1.00f);
            public static readonly Color Blue    = new Color(0.50f, 0.50f, 1.00f, 1.00f);
                 
            public static readonly Color Yellow  = new Color(1.00f, 1.00f, 0.50f, 1.00f);
            public static readonly Color Magenta = new Color(1.00f, 0.50f, 1.00f, 1.00f);
            public static readonly Color Pink    = new Color(1.00f, 0.50f, 1.00f, 1.00f);
            public static readonly Color Cyan    = new Color(0.50f, 1.00f, 1.00f, 1.00f);
            
            public static readonly Color Gold    = new Color(1.00f, 0.85f, 0.40f, 1.00f);
            public static readonly Color Orange  = new Color(1.00f, 0.70f, 0.50f, 1.00f);
            public static readonly Color Brown   = new Color(0.55f, 0.30f, 0.15f, 1.00f);

            public static readonly Color Violet  = new Color(0.50f, 0.00f, 1.00f, 1.00f);
            public static readonly Color Lime    = new Color(0.75f, 1.00f, 0.00f, 1.00f);
            public static readonly Color Mint    = new Color(0.00f, 1.00f, 0.50f, 1.00f);
        }

        /// <summary> 밝은색 : 3단계 - 매우 밝음 </summary>
        public static class Bright
        {
            public static readonly Color Red     = new Color(1.00f, 0.75f, 0.75f, 1.00f);
            public static readonly Color Green   = new Color(0.75f, 1.00f, 0.75f, 1.00f);
            public static readonly Color Blue    = new Color(0.75f, 0.75f, 1.00f, 1.00f);
            
            public static readonly Color Yellow  = new Color(1.00f, 1.00f, 0.75f, 1.00f);
            public static readonly Color Magenta = new Color(1.00f, 0.75f, 1.00f, 1.00f);
            public static readonly Color Pink    = new Color(1.00f, 0.75f, 1.00f, 1.00f);
            public static readonly Color Cyan    = new Color(0.75f, 1.00f, 1.00f, 1.00f);
            
            public static readonly Color Gold    = new Color(1.00f, 0.90f, 0.60f, 1.00f);
            public static readonly Color Orange  = new Color(1.00f, 0.80f, 0.70f, 1.00f);
            public static readonly Color Brown   = new Color(0.75f, 0.50f, 0.35f, 1.00f);

            public static readonly Color Violet  = new Color(0.50f, 0.00f, 1.00f, 1.00f);
            public static readonly Color Lime    = new Color(0.75f, 1.00f, 0.00f, 1.00f);
            public static readonly Color Mint    = new Color(0.00f, 1.00f, 0.50f, 1.00f);
        }
    }
}