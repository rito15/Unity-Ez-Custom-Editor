using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 날짜 : 2021-05-24 PM 9:31:38
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    public static class ColorExtensions
    {
        public static Color AddRGB(this Color color, float rgb)
        {
            return new Color(color.r + rgb, color.g + rgb, color.b + rgb, color.a);
        }
        public static Color AddRGB(this Color color, float r, float g, float b)
        {
            return new Color(color.r + r, color.g + g, color.b + b, color.a);
        }
        public static Color MultiplyRGB(this Color color, float value)
        {
            return new Color(color.r * value, color.g * value, color.b * value, color.a);
        }
        public static Color SetR(this Color color, float r)
        {
            return new Color(r, color.g, color.b, color.a);
        }
        public static Color SetG(this Color color, float g)
        {
            return new Color(color.r, g, color.b, color.a);
        }
        public static Color SetB(this Color color, float b)
        {
            return new Color(color.r, color.g, b, color.a);
        }
        public static Color SetA(this Color color, float a)
        {
            return new Color(color.r, color.g, color.b, a);
        }
        /*
        public static Texture2D ToTexture(this Color color)
        {
            Texture2D tex = new Texture2D(1,1);
            tex.SetPixel(0,0, color);
            tex.Apply();
            return tex;
        }*/
    }
}