#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-05-24 AM 1:33:13
// 작성자 : Rito

using REG = Rito.EditorPlugins.RitoEditorGUI;

namespace Rito.EditorPlugins.Demo
{
    public class Demo_DefaultLayouts : MonoBehaviour
    {
        [CustomEditor(typeof(Demo_DefaultLayouts))]
        private class CE : UnityEditor.Editor
        {
            private Label label1 = new Label();
            private Button button1 = new Button();
            private IntField intField1 = new IntField();
            private FloatField floatField1 = new FloatField();
            private DoubleField doubleField1 = new DoubleField();
            private BoolField boolField1 = new BoolField();
            private StringField stringField1 = new StringField();
            private Toggle toggle1 = new Toggle();
            private ToggleButton toggleButton1 = new ToggleButton();

            const int MaxLength = 50;
            private int[] intValues = new int[MaxLength];
            private float[] floatValues = new float[MaxLength];
            private double[] doubleValues = new double[MaxLength];
            private string[] stringValues = new string[MaxLength];
            private bool[] boolValues = new bool[MaxLength];
            private Material materialValue;
            private GameObject gameObjectValue;
            private UnityEngine.Object objectValue;
            private int[] intDropdownList = { 1, 2, 3, 4, 5, 6 };
            private float[] floatDropdownList = { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f };
            private string[] stringDropdownList = { "String 1", "String 2", "String 3",  };

            private void InitStyles()
            {
                label1.fontSize = 14;
                label1.fontStyle = FontStyle.BoldAndItalic;
                label1.textColor = Color.magenta;
                label1.textAlignment = TextAnchor.LowerRight;
                label1.textColor = Color.red;
                label1.fontSize = 16;

                button1.textAlignment = TextAnchor.UpperLeft;
                button1.textColor = Color.yellow;
                button1.fontSize = 14;
                button1.fontStyle = FontStyle.Bold;
                button1.buttonColor = Color.red * 2f;

                intField1.labelFontSize = 14;
                intField1.labelColor = Color.blue;
                intField1.labelFontStyle = FontStyle.Bold;
                intField1.inputFontSize = 16;
                intField1.inputTextColor = Color.white;
                intField1.inputBackgroundColor = Color.blue * 5f;
                intField1.inputFontStyle = FontStyle.Italic;
                intField1.inputTextAlignment = TextAnchor.MiddleCenter;

                floatField1.labelFontSize = 14;
                floatField1.labelColor = Color.yellow;
                floatField1.labelFontStyle = FontStyle.Bold;
                floatField1.inputFontSize = 16;
                floatField1.inputTextColor = Color.black;
                floatField1.inputBackgroundColor = Color.yellow * 5f;
                floatField1.inputFontStyle = FontStyle.BoldAndItalic;
                floatField1.inputTextAlignment = TextAnchor.MiddleRight;

                doubleField1.labelFontSize = 16;
                doubleField1.labelColor = Color.red;
                doubleField1.labelFontStyle = FontStyle.Bold;
                doubleField1.inputFontSize = 16;
                doubleField1.inputTextColor = Color.green;
                doubleField1.inputBackgroundColor = Color.red * 5f;
                doubleField1.inputFontStyle = FontStyle.Bold;
                doubleField1.inputTextAlignment = TextAnchor.MiddleRight;

                stringField1.labelFontSize = 12;
                stringField1.labelColor = Color.black;
                stringField1.labelFontStyle = FontStyle.BoldAndItalic;
                stringField1.inputFontSize = 14;
                stringField1.inputTextColor = Color.magenta;
                stringField1.inputBackgroundColor = Color.black;
                stringField1.inputFontStyle = FontStyle.Bold;
                stringField1.inputTextAlignment = TextAnchor.MiddleCenter;

                boolField1.labelColor = Color.red;
                boolField1.labelFontStyle = FontStyle.Bold;

                toggle1.color = Color.blue * 5f;

                toggleButton1.normalButtonColor = Color.red * 2f;
                toggleButton1.normalFontStyle = FontStyle.Bold;
                toggleButton1.textAlignment = TextAnchor.UpperRight;
                toggleButton1.pressedTextColor = Color.yellow;
                toggleButton1.pressedButtonColor = Color.red * 2f;
            }

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
                    .DrawLayout();

                #endregion

                REG.Space(8f);

                /***********************************************************************
                *                               Fields
                ***********************************************************************/
                #region .

                Label.Default
                    .SetData("Default Label")
                    .SetTooltip("Default Label")
                    .DrawLayout();

                intValues[i] = 
                    IntField.Default
                    .SetData("Default Int", intValues[i++])
                    .SetTooltip("Default Int")
                    .DrawLayout();

                floatValues[f] = 
                    FloatField.Default
                    .SetData("Default Float", floatValues[f++])
                    .SetTooltip("Default Float")
                    .DrawLayout();

                doubleValues[d] = 
                    DoubleField.Default
                    .SetData("Default Double", doubleValues[d++])
                    .SetTooltip("Default Double")
                    .DrawLayout();

                stringValues[s] = 
                    StringField.Default
                    .SetData("Default String", stringValues[s++], "Placeholder")
                    .SetTooltip("Default String")
                    .DrawLayout();

                stringValues[s] =
                    TextField.Default
                    .SetData(stringValues[s++], "Input here..")
                    .SetTooltip("Default TextField", 120f)
                    .DrawLayout();

                boolValues[b] =
                    BoolField.Default
                    .SetData("Default Bool", boolValues[b++])
                    .SetTooltip("Default Bool")
                    .DrawLayout();

                boolValues[b] =
                    BoolField.Default
                    .SetData("Default Bool(Left)", boolValues[b++], true, 0.4f)
                    .SetTooltip("Default Bool(L)")
                    .DrawLayout();

                boolValues[b] =
                    Toggle.Default
                    .SetData(boolValues[b++])
                    .SetTooltip("Default Toggle")
                    .DrawLayout();

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
                    .DrawLayout();

                floatValues[f] =
                    FloatSlider.Default
                    .SetData("Float Slider", floatValues[f++], 0, 10)
                    .SetTooltip("Float Slider")
                    .DrawLayout();

                doubleValues[d] =
                    DoubleSlider.Default
                    .SetData("Double Slider", doubleValues[d++], 0, 10)
                    .SetTooltip("Double Slider")
                    .DrawLayout();

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
                    .DrawLayout();
                
                gameObjectValue = 
                    ObjectField<GameObject>.Default
                    .SetData("GameObject Field", gameObjectValue)
                    .SetTooltip("GameObject Field", 120f)
                    .DrawLayout();
                
                objectValue = 
                    ObjectField<UnityEngine.Object>.Default
                    .SetData("Object Field", objectValue)
                    .SetTooltip("Object Field", 120f)
                    .DrawLayout();

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
                    .DrawLayout();

                Label.Default
                    .SetData("Box")
                    .DrawLayout();

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
                    .DrawLayout();

                Label.Default
                    .SetData("Content 2")
                    .DrawLayout();

                REG.Space(8f);

                outlineWidth = 1f;

                HeaderBox.Default
                    .SetData("Header", outlineWidth)
                    .SetTooltip("Header Box(Outlined)", 160f)
                    .DrawLayout(2, 1f);

                REG.Space(outlineWidth);

                Label.Default
                    .SetData("Content 1")
                    .DrawLayout();

                Label.Default
                    .SetData("Content 2")
                    .DrawLayout();

                #endregion

                REG.Space(8f);

                /***********************************************************************
                *                           Foldout Header Box
                ***********************************************************************/
                #region .

                outlineWidth = 2f;

                boolValues[b] = 
                FoldoutHeaderBox.Default
                    .SetData(boolValues[b], "Header (Foldout)", outlineWidth, 2f)
                    .SetTooltip("Foldout Header Box(Outlined)", 200f)
                    .DrawLayout(2, 0f);

                if (boolValues[b])
                {
                    REG.Space(outlineWidth);

                    Label.Default
                        .SetData("Content 1")
                        .DrawLayout();

                    Label.Default
                        .SetData("Content 2")
                        .DrawLayout();

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
                    .DrawLayout();

                HelpBox.Default
                    .SetData("Help Box 2", MessageType.Warning)
                    .SetTooltip("Help Box (Warning)", 120f)
                    .DrawLayout();

                HelpBox.Default
                    .SetData("Help Box 3", MessageType.Error)
                    .SetTooltip("Help Box (Error)", 120f)
                    .DrawLayout();

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
                    .DrawLayout();

                intValues[i] = 
                Dropdown<float>.Default
                    .SetData("Float Dropdown", floatDropdownList, intValues[i++])
                    .SetTooltip("Float Dropdown", 120f)
                    .DrawLayout();

                intValues[i] = 
                Dropdown<string>.Default
                    .SetData("String Dropdown", stringDropdownList, intValues[i++])
                    .SetTooltip("String Dropdown", 120f)
                    .DrawLayout();

                #endregion

                REG.Finalize(this);
            }
        }
    }
}
#endif