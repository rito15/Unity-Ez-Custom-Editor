using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 날짜 : 2021-06-06 PM 8:05:33
// 작성자 : Rito

namespace Rito.EditorUtilities.Demo
{
    public class Sample_Extensions : MonoBehaviour
    {
        public EColor theme;

        public string label = "Label";
        public string sLabel = "Selectable Label";
        public string eLabel = "Editable Label";
        public string s = "String Value";

        public int i;
        public long l;
        public float f;
        public double d;
        public bool b;

        public Vector2 v2;
        public Vector3 v3;
        public Vector4 v4;
        public Vector2Int v2i;
        public Vector3Int v3i;

        public Color c;
        public Space space;
        public UnityEngine.Object obj;
        public Material mat;

        public bool toggle1 = true;

#if UNITY_EDITOR
        [UnityEditor.CustomEditor(typeof(Sample_Extensions))]
        private class CE : EzEditor
        {
            private Sample_Extensions m;

            private void OnEnable()
            {
                m = target as Sample_Extensions;
            }

            protected override void OnSetup(EzEditorUtility.Setting setting)
            {
                setting
                    .SetLayoutControlWidth(0.01f, 0.99f)
                    .ActivateTooltipDebugger()
                    ;
            }
            
            protected override void OnDrawInspector()
            {
                EzEditorUtility.SetDefaultColorTheme(m.theme);
                m.theme.DrawDropdown("Theme")
                    .GetValue(out m.theme)
                    .Space();

                "String Extensions".DrawFoldoutHeaderBox(ref m.toggle1, 5, 2f);

                if (m.toggle1)
                {
                    m.label.DrawLabel();
                    m.sLabel.DrawSelectableLabel();
                    m.eLabel.DrawEditableLabel().GetValue(out m.eLabel);
                    m.s.DrawStringField("String Field").GetValue(out m.s);
                    m.s.DrawTextArea("Placeholder").GetValue(out m.s);
                }

                Space(12f);
                "Int Extensions".DrawHeaderBox(4, 2f);

                m.i.DrawField("Int Field");
                m.i.DrawFieldRef("Int Field - Ref");
                m.i.DrawSlider("Int Slider", 0, 10);
                m.i.DrawSliderRef("Int Slider - Ref", 0, 10);

                Space(12f);
                "Float Extensions".DrawHeaderBox(4, 2f);

                m.f.DrawField("Float Field");
                m.f.DrawFieldRef("Float Field - Ref");
                m.f.DrawSlider("Float Slider", 0, 10);
                m.f.DrawSliderRef("Float Slider - Ref", 0, 10);

                Space(12f);
                "Double Extensions".DrawHeaderBox(4, 2f);

                m.d.DrawField("Double Field");
                m.d.DrawFieldRef("Double Field - Ref");
                m.d.DrawSlider("Double Slider", 0, 10);
                m.d.DrawSliderRef("Double Slider - Ref", 0, 10);

                Space(12f);
                "Long Extensions".DrawHeaderBox(2, 2f);

                m.l.DrawField("Long Field");
                m.l.DrawFieldRef("Long Field - Ref");

                Space(12f);
                "Bool Extensions".DrawHeaderBox(4, 2f);

                m.b.DrawField("Bool Field");
                m.b.DrawFieldRef("Bool Field - Ref");
                m.b.DrawToggle();
                m.b.DrawToggleRef();

                Space(12f);
                "Long Extensions".DrawHeaderBox(2, 2f);

                m.l.DrawField("Long Field");
                m.l.DrawFieldRef("Long Field - Ref");

                Space(12f);
                "Vector2 Extensions".DrawHeaderBox(2, 2f);

                m.v2.DrawField("Vector2 Field");
                m.v2.DrawFieldRef("Vector2 Field - Ref");

                Space(12f);
                "Vector3 Extensions".DrawHeaderBox(2, 2f);

                m.v3.DrawField("Vector3 Field");
                m.v3.DrawFieldRef("Vector3 Field - Ref");

                Space(12f);
                "Vector4 Extensions".DrawHeaderBox(2, 2f);

                m.v4.DrawField("Vector4 Field");
                m.v4.DrawFieldRef("Vector4 Field - Ref");

                Space(12f);
                "Vector2Int Extensions".DrawHeaderBox(2, 2f);

                m.v2i.DrawField("Vector2Int Field");
                m.v2i.DrawFieldRef("Vector2Int Field - Ref");

                Space(12f);
                "Vector3Int Extensions".DrawHeaderBox(2, 2f);

                m.v3i.DrawField("Vector3Int Field");
                m.v3i.DrawFieldRef("Vector3Int Field - Ref");

                Space(12f);
                "Color Extensions".DrawHeaderBox(4, 2f);

                m.c.DrawField("Color Field");
                m.c.DrawFieldRef("Color Field - Ref");
                m.c.DrawColorPicker();
                m.c.DrawColorPickerRef();

                Space(12f);
                "Enum Extensions".DrawHeaderBox(1, 2f);

                m.space.DrawDropdown("Enum Dropdown").GetValue(out m.space);

                Space(12f);
                "Object Extensions".DrawHeaderBox(2, 2f);

                m.obj.DrawField("Object Field").GetValue(out m.obj);
                m.mat.DrawField("Material Field").GetValue(out m.mat);
            }
        }
#endif
    }
}