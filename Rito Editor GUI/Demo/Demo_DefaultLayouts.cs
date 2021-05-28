#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-05-24 AM 1:33:13
// 작성자 : Rito

using REG = Rito.EditorUtilities.RitoEditorGUI;

namespace Rito.EditorUtilities.Demo
{
    public class Demo_DefaultLayouts : MonoBehaviour
    {
        [CustomEditor(typeof(Demo_DefaultLayouts))]
        private class CE : UnityEditor.Editor
        {
            const int MaxLength = 50;
            private int[] intValues = new int[MaxLength];
            private float[] floatValues = new float[MaxLength];
            private double[] doubleValues = new double[MaxLength];
            private string[] stringValues = new string[MaxLength];
            private bool[] boolValues = new bool[MaxLength];
            private Vector2 vector2Value;
            private Vector3 vector3Value;
            private Vector4 vector4Value;
            private Vector2Int vector2IntValue;
            private Vector3Int vector3IntValue;
            private Color colorValue1 = Color.white;
            private Color colorValue2 = Color.white;

            private Material materialValue;
            private GameObject gameObjectValue;
            private UnityEngine.Object objectValue;
            private int[] intDropdownList = { 1, 2, 3, 4, 5, 6 };
            private float[] floatDropdownList = { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f };
            private string[] stringDropdownList = { "String 1", "String 2", "String 3",  };

            public override void OnInspectorGUI()
            {
                REG.Options 
                    .SetMarginLeft(12f)
                    .SetMarginRight(24f)
                    .SetMarginTop(8f)
                    .SetMarginBottom(4f)
                    .DebugOn(true)
                    .DebugAll(true)
                    .AllowTooltip(true)
                    .SetDebugRectColor(Color.cyan)
                    .Init();

                int i = 0, f = 0, d = 0, s = 0, b = 0;

                /***********************************************************************
                *                               Buttons
                ***********************************************************************/
                #region .

                Button.Default
                    .SetData("Default Button")
                    .SetTooltip("Default Button")
                    .DrawLayout();

                boolValues[b] =
                    ToggleButton.Default
                    .SetData("Toggle Button", boolValues[b++])
                    .SetTooltip("Toggle Button")
                    .DrawLayout().Get();

                #endregion

                REG.Space(8f);

                /***********************************************************************
                *                               Fields
                ***********************************************************************/
                #region .

                Label.Default
                    .SetData("Label Field")
                    .SetTooltip("Label Field")
                    .DrawLayout();

                SelectableLabel.Default
                    .SetData("Selectable Label")
                    .SetTooltip("Selectable Label")
                    .DrawLayout();

                intValues[i] = 
                    IntField.Default
                    .SetData("Int Field", intValues[i++])
                    .SetTooltip("Int Field")
                    .DrawLayout().Get();

                floatValues[f] = 
                    FloatField.Default
                    .SetData("Float Field", floatValues[f++])
                    .SetTooltip("Float Field")
                    .DrawLayout().Get();

                doubleValues[d] = 
                    DoubleField.Default
                    .SetData("Double Field", doubleValues[d++])
                    .SetTooltip("Double Field")
                    .DrawLayout().Get();

                vector2Value = 
                    Vector2Field.Default
                    .SetData("Vector2 Field", vector2Value)
                    .SetTooltip("Vector2 Field")
                    .DrawLayout().Get();

                vector2IntValue =
                    Vector2IntField.Default
                    .SetData("Vector2Int Field", vector2IntValue)
                    .SetTooltip("Vector2Int Field")
                    .DrawLayout().Get();

                vector3Value = 
                    Vector3Field.Default
                    .SetData("Vector3 Field", vector3Value)
                    .SetTooltip("Vector3 Field")
                    .DrawLayout().Get();

                vector3IntValue =
                    Vector3IntField.Default
                    .SetData("Vector3Int Field", vector3IntValue)
                    .SetTooltip("Vector3Int Field")
                    .DrawLayout().Get();

                vector4Value = 
                    Vector4Field.Default
                    .SetData("Vector4 Field", vector4Value)
                    .SetTooltip("Vector4 Field")
                    .DrawLayout().Get();

                stringValues[s] = 
                    StringField.Default
                    .SetData("String Field", stringValues[s++], "Placeholder")
                    .SetTooltip("String Field")
                    .DrawLayout().Get();

                stringValues[s] =
                    TextArea.Default
                    .SetData(stringValues[s++], "Input here..")
                    .SetTooltip("Default TextField", 120f)
                    .DrawLayout().Get();

                boolValues[b] =
                    BoolField.Default
                    .SetData("Bool Field", boolValues[b++])
                    .SetTooltip("Bool Field")
                    .DrawLayout().Get();

                boolValues[b] =
                    BoolField.Default
                    .SetData("Bool Field(Left)", boolValues[b++], true, 0.4f)
                    .SetTooltip("Bool Field(L)")
                    .DrawLayout().Get();

                boolValues[b] =
                    Toggle.Default
                    .SetData(boolValues[b++])
                    .SetTooltip("Toggle")
                    .DrawLayout().Get();

                colorValue1 = 
                    ColorField.Default
                    .SetData("Color Field", colorValue1)
                    .SetTooltip("Color Field")
                    .DrawLayout().Get();

                colorValue2 = 
                    ColorPicker.Default
                    .SetData(colorValue2)
                    .SetTooltip("Color Picker")
                    .DrawLayout().Get();

                #endregion

                REG.Space(8f);

                /***********************************************************************
                *                               Sliders
                ***********************************************************************/
                #region .

                intValues[i] = 
                    IntSlider.Default
                    .SetData("Int Slider", intValues[i++], 0, 10)
                    .SetTooltip("Int Slider", 60f, 20f)
                    .DrawLayout().Get();

                floatValues[f] =
                    FloatSlider.Default
                    .SetData("Float Slider", floatValues[f++], 0, 10)
                    .SetTooltip("Float Slider")
                    .DrawLayout().Get();

                doubleValues[d] =
                    DoubleSlider.Default
                    .SetData("Double Slider", doubleValues[d++], 0, 10)
                    .SetTooltip("Double Slider")
                    .DrawLayout().Margin(4f).Get();

                #endregion

                REG.Space(8f);

                /***********************************************************************
                *                               Object Fields
                ***********************************************************************/
                #region .

                materialValue = 
                    ObjectField<Material>.Default
                    .SetData("Material Field", materialValue)
                    .SetTooltip("Material Field", 120f)
                    .DrawLayout().Get();
                
                gameObjectValue = 
                    ObjectField<GameObject>.Default
                    .SetData("GameObject Field", gameObjectValue)
                    .SetTooltip("GameObject Field", 120f)
                    .DrawLayout().Get();
                
                objectValue = 
                    ObjectField<UnityEngine.Object>.Default
                    .SetData("Object Field", objectValue)
                    .SetTooltip("Object Field", 120f)
                    .DrawLayout().Get();

                #endregion

                REG.Space(8f);

                /***********************************************************************
                *                                 Box
                ***********************************************************************/
                #region .

                Box.Default
                    .SetData(1f)
                    .SetTooltip("Default Box")
                    .Draw(0f, 1f, -1f, 40f, -1f, 1f);

                Label.Default
                    .SetData("Box")
                    .SetTooltip("Label 1")
                    .DrawLayout().Get();

                Label.Default
                    .SetData("Box")
                    .DrawLayout().Get();

                #endregion

                REG.Space(8f);

                /***********************************************************************
                *                               Header Box
                ***********************************************************************/
                #region .

                float headerHeight = 20f;
                float outlineWidth = 0f;

                HeaderBox.Default
                    .SetData("Header", outlineWidth, 4f)
                    .SetTooltip("Header Box")
                    .Draw(0f, 1f, -1f, headerHeight, 40f, -2f, 2f);

                REG.Space(headerHeight + outlineWidth);

                Label.Default
                    .SetData("Content 1")
                    .DrawLayout().Get();

                Label.Default
                    .SetData("Content 2")
                    .DrawLayout().Get();

                REG.Space(8f);

                outlineWidth = 1f;

                HeaderBox.Default
                    .SetData("Header", outlineWidth)
                    .SetTooltip("Header Box(Outlined)", 160f)
                    .DrawLayout(2, 1f);

                REG.Space(outlineWidth);

                Label.Default
                    .SetData("Content 1")
                    .DrawLayout().Get();

                Label.Default
                    .SetData("Content 2")
                    .DrawLayout().Get();

                #endregion

                REG.Space(8f);

                /***********************************************************************
                *                           Foldout Header Box
                ***********************************************************************/
                #region .

                outlineWidth = 2f;

                FoldoutHeaderBox.Default
                    .SetData(boolValues[b], "Header (Foldout)", outlineWidth, 2f)
                    .SetTooltip("Foldout Header Box(Outlined)", 200f)
                    .DrawLayout(2, 0f).Get(out boolValues[b]);

                if (boolValues[b])
                {
                    REG.Space(outlineWidth);

                    Label.Default
                        .SetData("Content 1")
                        .DrawLayout().Get();

                    Label.Default
                        .SetData("Content 2")
                        .DrawLayout().Get();

                    Label.Default.SetTooltip("Label Tooltip", 100f, 20f);
                }
                b++;

                #endregion

                REG.Space(8f);

                /***********************************************************************
                *                               Help Boxes
                ***********************************************************************/
                #region .

                HelpBox.Default
                    .SetData("Help Box 1", MessageType.Info)
                    .SetTooltip("Help Box (Info)", 120f)
                    .DrawLayout().Get();

                HelpBox.Default
                    .SetData("Help Box 2", MessageType.Warning)
                    .SetTooltip("Help Box (Warning)", 120f)
                    .DrawLayout().Get();

                HelpBox.Default
                    .SetData("Help Box 3", MessageType.Error)
                    .SetTooltip("Help Box (Error)", 120f)
                    .DrawLayout().Get();

                #endregion

                REG.Space(8f);

                /***********************************************************************
                *                               Dropdowns
                ***********************************************************************/
                #region .

                intValues[i] = 
                Dropdown<int>.Default
                    .SetData("Int Dropdown", intDropdownList, intValues[i++])
                    .SetTooltip("Int Dropdown", 120f)
                    .DrawLayout().Get();

                intValues[i] = 
                Dropdown<float>.Default
                    .SetData("Float Dropdown", floatDropdownList, intValues[i++])
                    .SetTooltip("Float Dropdown", 120f)
                    .DrawLayout().Get();

                intValues[i] = 
                Dropdown<string>.Default
                    .SetData("String Dropdown", stringDropdownList, intValues[i++])
                    .SetTooltip("String Dropdown", 120f)
                    .DrawLayout().Get();

                #endregion

                REG.Finalize(this);
            }
        }
    }
}
#endif