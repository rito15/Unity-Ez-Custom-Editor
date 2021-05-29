using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-05-30 AM 2:20:07
// 작성자 : Rito

namespace Rito.EditorUtilities.Demo
{
    public class Demo_ThemeBase : MonoBehaviour
    {
        public int int1, int2, int3;
        public float float1, float2;
        public bool bool1, bool2, bool3, bool4, bool5;
        public string string1, string2;
        public Material material1;
        public Transform transform1;
        public Color color1, color2;
        public Vector3 vector3;
        public Vector4 vector4;

        public List<float> fList = new List<float> { 0.123f, 456.789f, 12345f, 67890f };
        public int fSelected;

        public string[] sArray = { "String 0", "String 1", "String 2" };
        public int sSelected;
    }
}