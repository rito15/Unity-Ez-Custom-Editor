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
    public class Sample_DefaultLayouts : MonoBehaviour
    {
        [CustomEditor(typeof(Sample_DefaultLayouts))]
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
            private long longValue1;
            private CursorLockMode cursorLockMode;

            private Material materialValue;
            private GameObject gameObjectValue;
            private UnityEngine.Object objectValue;
            private int[] intDropdownList = { 1, 2, 3, 4, 5, 6 };
            private float[] floatDropdownList = { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f };
            private string[] stringDropdownList = { "String 1", "String 2", "String 3",  };

            public override void OnInspectorGUI()
            {
                REG.Settings
                    //.SetMargins(top: 8f, left: 12f, right: 24f, bottom: 4f)
                    .ActivateRectDebugger(true)
                    .ActivateTooltipDebugger(true)
                    .SetDebugRectColor(Color.cyan)
                    .SetDebugTooltipColor(Color.cyan.SetA(0.5f))
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
                    .DrawLayout().GetValue();

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
                    .DrawLayout().GetValue();

                longValue1 = 
                    LongField.Default
                    .SetData("Long Field", longValue1)
                    .SetTooltip("Long Field")
                    .DrawLayout().GetValue();

                floatValues[f] = 
                    FloatField.Default
                    .SetData("Float Field", floatValues[f++])
                    .SetTooltip("Float Field")
                    .DrawLayout().GetValue();

                doubleValues[d] = 
                    DoubleField.Default
                    .SetData("Double Field", doubleValues[d++])
                    .SetTooltip("Double Field")
                    .DrawLayout().GetValue();

                vector2Value = 
                    Vector2Field.Default
                    .SetData("Vector2 Field", vector2Value)
                    .SetTooltip("Vector2 Field")
                    .DrawLayout().GetValue();

                vector2IntValue =
                    Vector2IntField.Default
                    .SetData("Vector2Int Field", vector2IntValue)
                    .SetTooltip("Vector2Int Field")
                    .DrawLayout().GetValue();

                vector3Value = 
                    Vector3Field.Default
                    .SetData("Vector3 Field", vector3Value)
                    .SetTooltip("Vector3 Field")
                    .DrawLayout().GetValue();

                vector3IntValue =
                    Vector3IntField.Default
                    .SetData("Vector3Int Field", vector3IntValue)
                    .SetTooltip("Vector3Int Field")
                    .DrawLayout().GetValue();

                vector4Value = 
                    Vector4Field.Default
                    .SetData("Vector4 Field", vector4Value)
                    .SetTooltip("Vector4 Field")
                    .DrawLayout().GetValue();

                stringValues[s] = 
                    StringField.Default
                    .SetData("String Field", stringValues[s++], "Placeholder")
                    .SetTooltip("String Field")
                    .DrawLayout().GetValue();

                stringValues[s] =
                    TextArea.Default
                    .SetData(stringValues[s++], "Input here..")
                    .SetTooltip("Default TextField", 120f)
                    .DrawLayout().GetValue();

                boolValues[b] =
                    BoolField.Default
                    .SetData("Bool Field", boolValues[b++])
                    .SetTooltip("Bool Field")
                    .DrawLayout().GetValue();

                boolValues[b] =
                    BoolField.Default
                    .SetData("Bool Field(Left)", boolValues[b++], true, 0.4f)
                    .SetTooltip("Bool Field(L)")
                    .DrawLayout().GetValue();

                boolValues[b] =
                    Toggle.Default
                    .SetData(boolValues[b++])
                    .SetTooltip("Toggle")
                    .DrawLayout().GetValue();

                colorValue1 = 
                    ColorField.Default
                    .SetData("Color Field", colorValue1)
                    .SetTooltip("Color Field")
                    .DrawLayout().GetValue();

                colorValue2 = 
                    ColorPicker.Default
                    .SetData(colorValue2)
                    .SetTooltip("Color Picker")
                    .DrawLayout().GetValue();

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
                    .DrawLayout().GetValue();

                floatValues[f] =
                    FloatSlider.Default
                    .SetData("Float Slider", floatValues[f++], 0, 10)
                    .SetTooltip("Float Slider")
                    .DrawLayout().GetValue();

                doubleValues[d] =
                    DoubleSlider.Default
                    .SetData("Double Slider", doubleValues[d++], 0, 10)
                    .SetTooltip("Double Slider")
                    .DrawLayout().Margin(4f).GetValue();

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
                    .DrawLayout().GetValue();
                
                gameObjectValue = 
                    ObjectField<GameObject>.Default
                    .SetData("GameObject Field", gameObjectValue)
                    .SetTooltip("GameObject Field", 120f)
                    .DrawLayout().GetValue();
                
                objectValue = 
                    ObjectField<UnityEngine.Object>.Default
                    .SetData("Object Field", objectValue)
                    .SetTooltip("Object Field", 120f)
                    .DrawLayout().GetValue();

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
                    .DrawLayout().GetValue();

                Label.Default
                    .SetData("Box")
                    .DrawLayout().GetValue();

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
                    .DrawLayout().GetValue();

                Label.Default
                    .SetData("Content 2")
                    .DrawLayout().GetValue();

                REG.Space(8f);

                outlineWidth = 1f;

                HeaderBox.Default
                    .SetData("Header", outlineWidth)
                    .SetTooltip("Header Box(Outlined)", 160f)
                    .DrawLayout(2, 0f, 2f);

                REG.Space(outlineWidth);

                Label.Default
                    .SetData("Content 1")
                    .DrawLayout().GetValue();

                Label.Default
                    .SetData("Content 2")
                    .DrawLayout().GetValue();

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
                    .DrawLayout(2, 0f, 2f).GetValue(out boolValues[b]);

                if (boolValues[b])
                {
                    REG.Space(outlineWidth);

                    Label.Default
                        .SetData("Content 1")
                        .DrawLayout().GetValue();

                    Label.Default
                        .SetData("Content 2")
                        .DrawLayout().GetValue();

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
                    .DrawLayout().GetValue();

                HelpBox.Default
                    .SetData("Help Box 2", MessageType.Warning)
                    .SetTooltip("Help Box (Warning)", 120f)
                    .DrawLayout().GetValue();

                HelpBox.Default
                    .SetData("Help Box 3", MessageType.Error)
                    .SetTooltip("Help Box (Error)", 120f)
                    .DrawLayout().GetValue();

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
                    .DrawLayout().GetValue();

                intValues[i] = 
                Dropdown<float>.Default
                    .SetData("Float Dropdown", floatDropdownList, intValues[i++])
                    .SetTooltip("Float Dropdown", 120f)
                    .DrawLayout().GetValue();

                EditorGUI.BeginChangeCheck();

                intValues[i] = 
                Dropdown<string>.Default
                    .SetData("String Dropdown", stringDropdownList, intValues[i++])
                    .SetTooltip("String Dropdown", 120f)
                    .DrawLayout().GetSelectedValue(out var selected).GetValue();

                if(EditorGUI.EndChangeCheck())
                    Debug.Log(selected);

                EnumDropdown<CursorLockMode>.Default
                    .SetData("Enum Dropdown", cursorLockMode)
                    .DrawLayout().GetValue(out cursorLockMode);

                EnumDropdown.Default
                    .SetData("Enum Dropdown", cursorLockMode)
                    .DrawLayout().GetValue(out Enum clm);
                cursorLockMode = (CursorLockMode)clm;

                #endregion

                REG.Finalize(this);
            }
        }
    }
}
#endif