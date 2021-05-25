#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


/*
    [TODO]

    - Int, Float, Double Field 레이블 영역 좌우 드래그하면 value 값 감소/증가

    - ObjectField

    - CustomizedEditorGUIThemes : White, Black, Red, Blue, Green, Cyan, Yellow, Purple, Pink
        - 따로 클래스파일 만들고, 각각 컨트롤마다 Partial로 프로퍼티들 작성
        - Demo_CustomizedEditorGUI_색상들 : 데모 테스트
*/

// 날짜 : 2021-05-24 AM 1:32:18
// 작성자 : Rito

namespace Rito.EditorPlugins
{
    using REG = RitoEditorGUI;

    /// <summary> 마우스를 컨트롤에 올리면 표시할 툴팁 </summary>
    public class OverlayTooltip
    {
        public Rect mouseTargetRect;
        public float width;
        public float height;
        public string text;
    }

    public abstract class DrawingElement
    {
        protected Rect rect;

        public const float DefaultControlHeight = 18f; // 컨트롤의 기본 높이
        public const float DefaultControlMargin = 2f;  // 컨트롤의 기본 하단 여백

        public static bool debugOn = true;  // 개별적으로 렉트 디버그
        public static bool debugOnOption = true;
        public static bool debugAll = false; // 모든 렉트 영역 디버그
        public static Color debugColor = Color.red;

        public static bool DebugOn => debugOn && debugOnOption;

        public const string DebugOnPrefName = "Rito_CustomEditorGUI_DebugOn";

        [InitializeOnLoadMethod]
        static void LoadPrefsData()
        {
            debugOnOption = PlayerPrefs.GetInt(DebugOnPrefName) == 1;
        }

        // xLeft, xRight : ViewWidth에 대한 Rect 좌우 지점의 비율(0 ~ 1)
        /// <summary> 그려질 지점의 Rect 설정 </summary>
        public void SetRect(in float xLeft, in float xRight, float yOffset, in float height)
        {
            rect = REG.GetRect(xLeft, xRight, yOffset, height);
        }
        /// <summary> 그려질 지점의 Rect 설정 </summary>
        public void SetRect(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset, in float xRightOffset)
        {
            rect = REG.GetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);
        }

        /// <summary> 마지막으로 그린 Rect 가져오기 </summary>
        public Rect GetLastRect()
        {
            return rect;
        }

        /// <summary> 컨트롤에 마우스가 올라갈 경우 툴팁 상자 표시 </summary>
        public void DrawTooltip(string text, float width, float height = 20f)
        {
            REG.TooltipList.Add(
                new OverlayTooltip { mouseTargetRect = rect, text = text, width = width, height = height });
        }

        /// <summary> Rect 위치 가시화하여 보여주기 </summary>
        public void DebugRect(Color color = default, in float border = 1f)
        {
            if(!DebugOn) return;
            if(rect == default) return;
            if(color == default) color = debugColor;

            float x = rect.x;
            float y = rect.y;
            float w = rect.width;
            float h = rect.height;

            Rect top = new Rect(x, y, w, border);
            Rect bot = new Rect(x, y + h - border, w, border);
            Rect left  = new Rect(x, y, border, h);
            Rect right = new Rect(x + w - border, y, border, h);

            EditorGUI.DrawRect(top, color);
            EditorGUI.DrawRect(bot, color);
            EditorGUI.DrawRect(left, color);
            EditorGUI.DrawRect(right, color);
        }
    }
    public class Label : DrawingElement
    {
        public static Label Default { get; } = new Label();
        public static Label Bold { get; } = new Label { fontStyle = FontStyle.Bold };

        protected GUIStyle style;

        // Data
        protected string text;

        // Styles
        public Color textColor = Color.white;
        public TextAnchor textAlignment = TextAnchor.MiddleLeft;
        public int fontSize = 12;
        public FontStyle fontStyle = FontStyle.Normal;

        public Label SetData(string text)
        {
            this.text = text;
            return this;
        }

        public void Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (style == null)
                style = new GUIStyle(GUI.skin.label);

            style.normal.textColor = textColor;
            style.fontSize = fontSize;
            style.fontStyle = fontStyle;
            style.alignment = textAlignment;

            EditorGUI.LabelField(rect, text, style);

            if(debugAll)
                DebugRect();
        }

        /// <summary> 레이아웃 요소로 그리기 </summary>
        public void DrawLayout()
        {
            Draw(0f, 1f, 0f, DefaultControlHeight);
            REG.Space(DefaultControlHeight + DefaultControlMargin);
        }
    }
    public class Button : DrawingElement
    {
        public static Button Default { get; } = new Button();
        protected GUIStyle style;

        // Data
        protected string text = "";

        // Styles
        public Color textColor = Color.white;
        public TextAnchor textAlignment = TextAnchor.MiddleCenter;
        public int fontSize = 12;
        public FontStyle fontStyle = FontStyle.Normal;

        public Color buttonColor = Color.white;

        public Button SetData(string text)
        {
            this.text = text;
            return this;
        }

        public bool Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (style == null)
                style = new GUIStyle(GUI.skin.button);

            var oldBackgroundColor = GUI.backgroundColor;
            GUI.backgroundColor = buttonColor;
            style.normal.textColor = textColor;
            style.fontSize = fontSize;
            style.fontStyle = fontStyle;
            style.alignment = textAlignment;

            bool pressed = GUI.Button(rect, text, style);

            GUI.backgroundColor = oldBackgroundColor;

            if (debugAll)
                DebugRect();

            return pressed;
        }

        /// <summary> 레이아웃 요소로 그리기 </summary>
        public bool DrawLayout()
        {
            bool pressed = Draw(0f, 1f, 0f, DefaultControlHeight);
            REG.Space(DefaultControlHeight + DefaultControlMargin);
            return pressed;
        }
    }
    public class ToggleButton : DrawingElement
    {
        public static ToggleButton Default { get; } = new ToggleButton();
        protected GUIStyle style;

        // Data
        protected string label = "Toggle Button";
        protected bool value = false;

        // Styles
        public int fontSize = 12;

        // Styles - Button Normal
        public Color normalTextColor = Color.white;
        public Color normalButtonColor = Color.white;
        public TextAnchor textAlignment = TextAnchor.MiddleCenter;
        public FontStyle fontStyle = FontStyle.Normal;

        // Styles - Button Pressed
        public Color pressedTextColor = Color.white;
        public Color pressedButtonColor = Color.white;
        public FontStyle pressedFontStyle = FontStyle.Bold;

        public ToggleButton SetData(string label, bool value)
        {
            this.label = label;
            this.value = value;
            return this;
        }

        public bool Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (style == null)
                style = new GUIStyle(GUI.skin.button);

            var oldBackgroundColor = GUI.backgroundColor;
            GUI.backgroundColor = value ? pressedButtonColor.AddRGB(0.5f) : normalButtonColor;

            style.normal.textColor = value ? pressedTextColor : normalTextColor;
            style.fontSize = fontSize;
            style.fontStyle = value ? pressedFontStyle : fontStyle;
            style.alignment = textAlignment;

            if (GUI.Button(rect, label, style))
                value = !value;

            GUI.backgroundColor = oldBackgroundColor;

            if (debugAll)
                DebugRect();

            return value;
        }

        /// <summary> 레이아웃 요소로 그리기 </summary>
        public bool DrawLayout()
        {
            value = Draw(0f, 1f, 0f, DefaultControlHeight);
            REG.Space(DefaultControlHeight + DefaultControlMargin);
            return value;
        }
    }

    public class IntField : DrawingElement
    {
        public static IntField Default { get; } = new IntField();
        protected GUIStyle labelStyle;
        protected GUIStyle inputStyle;

        // Data
        protected GUIContent labelContent;
        protected int value = 0;
        protected float widthThreshold = 0.4f;

        // Styles - Label
        public int labelFontSize = 12;
        public Color labelColor = Color.white;
        public FontStyle labelFontStyle = FontStyle.Normal;

        // Styles - Input Field
        public int inputFontSize = 12;
        public Color inputTextColor = Color.white;
        public Color inputBackgroundColor = Color.white;
        public FontStyle inputFontStyle = FontStyle.Normal;
        public TextAnchor inputTextAlignment = TextAnchor.MiddleLeft;

        public IntField SetData(string label, int value, float widthThreshold = 0.4f)
        {
            this.labelContent = new GUIContent(label);

            this.value = value;
            this.widthThreshold = widthThreshold;
            return this;
        }

        public int Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (labelStyle == null)
                labelStyle = new GUIStyle(GUI.skin.label);
            if (inputStyle == null)
                inputStyle = new GUIStyle(GUI.skin.textField);

            ref float t = ref widthThreshold;
            float omt = 1f - t;
            Rect labelRect = new Rect(rect.x, rect.y, rect.width * t, rect.height);
            Rect inputRect = new Rect(rect.x + rect.width * t, rect.y, rect.width * omt, rect.height);

            var oldBackgroundColor = GUI.backgroundColor;
            GUI.backgroundColor = inputBackgroundColor;

            labelStyle.normal.textColor = labelColor;
            labelStyle.fontSize = labelFontSize;
            labelStyle.fontStyle = labelFontStyle;

            inputStyle.normal.textColor = inputTextColor;
            inputStyle.fontSize = inputFontSize;
            inputStyle.fontStyle = inputFontStyle;
            inputStyle.alignment = inputTextAlignment;

            EditorGUI.PrefixLabel(labelRect, labelContent, labelStyle);
            value = EditorGUI.IntField(inputRect, value, inputStyle);

            GUI.backgroundColor = oldBackgroundColor;

            if (debugAll)
                DebugRect();

            return value;
        }

        /// <summary> 레이아웃 요소로 그리기 </summary>
        public int DrawLayout()
        {
            value = Draw(0f, 1f, 0f, DefaultControlHeight);
            REG.Space(DefaultControlHeight + DefaultControlMargin);
            return value;
        }
    }
    public class FloatField : DrawingElement
    {
        public static FloatField Default { get; } = new FloatField();
        protected GUIStyle labelStyle;
        protected GUIStyle inputStyle;

        // Data
        protected GUIContent labelContent;
        protected float value = 0f;
        protected float widthThreshold = 0.4f;

        // Styles - Label
        public int labelFontSize = 12;
        public Color labelColor = Color.white;
        public FontStyle labelFontStyle = FontStyle.Normal;

        // Styles - Input Field
        public int inputFontSize = 12;
        public Color inputTextColor = Color.white;
        public Color inputBackgroundColor = Color.white;
        public FontStyle inputFontStyle = FontStyle.Normal;
        public TextAnchor inputTextAlignment = TextAnchor.MiddleLeft;

        public FloatField SetData(string label, float value, float widthThreshold = 0.4f)
        {
            this.labelContent = new GUIContent(label);

            this.value = value;
            this.widthThreshold = widthThreshold;
            return this;
        }

        public float Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (labelStyle == null)
                labelStyle = new GUIStyle(GUI.skin.label);
            if (inputStyle == null)
                inputStyle = new GUIStyle(GUI.skin.textField);

            ref float t = ref widthThreshold;
            float omt = 1f - t;
            Rect labelRect = new Rect(rect.x, rect.y, rect.width * t, rect.height);
            Rect inputRect = new Rect(rect.x + rect.width * t, rect.y, rect.width * omt, rect.height);

            var oldBackgroundColor = GUI.backgroundColor;
            GUI.backgroundColor = inputBackgroundColor;

            labelStyle.normal.textColor = labelColor;
            labelStyle.fontSize = labelFontSize;
            labelStyle.fontStyle = labelFontStyle;

            inputStyle.normal.textColor = inputTextColor;
            inputStyle.fontSize = inputFontSize;
            inputStyle.fontStyle = inputFontStyle;
            inputStyle.alignment = inputTextAlignment;

            EditorGUI.PrefixLabel(labelRect, labelContent, labelStyle);
            value = EditorGUI.FloatField(inputRect, value, inputStyle);

            GUI.backgroundColor = oldBackgroundColor;

            if (debugAll)
                DebugRect();

            return value;
        }

        /// <summary> 레이아웃 요소로 그리기 </summary>
        public float DrawLayout()
        {
            value = Draw(0f, 1f, 0f, DefaultControlHeight);
            REG.Space(DefaultControlHeight + DefaultControlMargin);
            return value;
        }
    }
    public class DoubleField : DrawingElement
    {
        public static DoubleField Default { get; } = new DoubleField();
        protected GUIStyle labelStyle;
        protected GUIStyle inputStyle;

        // Data
        protected GUIContent labelContent;
        protected double value = 0.0;
        protected float widthThreshold = 0.4f;

        // Styles - Label
        public int labelFontSize = 12;
        public Color labelColor = Color.white;
        public FontStyle labelFontStyle = FontStyle.Normal;

        // Styles - Input Field
        public int inputFontSize = 12;
        public Color inputTextColor = Color.white;
        public Color inputBackgroundColor = Color.white;
        public FontStyle inputFontStyle = FontStyle.Normal;
        public TextAnchor inputTextAlignment = TextAnchor.MiddleLeft;

        public DoubleField SetData(string label, double value, float widthThreshold = 0.4f)
        {
            this.labelContent = new GUIContent(label);

            this.value = value;
            this.widthThreshold = widthThreshold;
            return this;
        }

        public double Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (labelStyle == null)
                labelStyle = new GUIStyle(GUI.skin.label);
            if (inputStyle == null)
                inputStyle = new GUIStyle(GUI.skin.textField);

            ref float t = ref widthThreshold;
            float omt = 1f - t;
            Rect labelRect = new Rect(rect.x, rect.y, rect.width * t, rect.height);
            Rect inputRect = new Rect(rect.x + rect.width * t, rect.y, rect.width * omt, rect.height);

            var oldBackgroundColor = GUI.backgroundColor;
            GUI.backgroundColor = inputBackgroundColor;

            labelStyle.normal.textColor = labelColor;
            labelStyle.fontSize = labelFontSize;
            labelStyle.fontStyle = labelFontStyle;

            inputStyle.normal.textColor = inputTextColor;
            inputStyle.fontSize = inputFontSize;
            inputStyle.fontStyle = inputFontStyle;
            inputStyle.alignment = inputTextAlignment;

            EditorGUI.PrefixLabel(labelRect, labelContent, labelStyle);
            value = EditorGUI.DoubleField(inputRect, value, inputStyle);

            GUI.backgroundColor = oldBackgroundColor;

            if (debugAll)
                DebugRect();

            return value;
        }

        /// <summary> 레이아웃 요소로 그리기 </summary>
        public double DrawLayout()
        {
            value = Draw(0f, 1f, 0f, DefaultControlHeight);
            REG.Space(DefaultControlHeight + DefaultControlMargin);
            return value;
        }
    }
    public class StringField : DrawingElement
    {
        public static StringField Default { get; } = new StringField();
        protected GUIStyle labelStyle;
        protected GUIStyle inputStyle;

        // Data
        protected GUIContent labelContent;
        protected string value = "";
        protected string placeholder = "";
        protected float widthThreshold = 0.4f;

        // Styles - Label
        public int labelFontSize = 12;
        public Color labelColor = Color.white;
        public FontStyle labelFontStyle = FontStyle.Normal;

        // Styles - Input Field
        public int inputFontSize = 12;
        public Color inputTextColor = Color.white;
        public Color inputBackgroundColor = Color.white;
        public FontStyle inputFontStyle = FontStyle.Normal;
        public TextAnchor inputTextAlignment = TextAnchor.MiddleLeft;

        public StringField SetData(string label, string value, string placeholder = "", float widthThreshold = 0.4f)
        {
            this.labelContent = new GUIContent(label);

            this.value = value;
            this.placeholder = placeholder;
            this.widthThreshold = widthThreshold;
            return this;
        }

        public string Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (labelStyle == null)
                labelStyle = new GUIStyle(GUI.skin.label);
            if (inputStyle == null)
                inputStyle = new GUIStyle(GUI.skin.textField);

            ref float t = ref widthThreshold;
            float omt = 1f - t;
            Rect labelRect = new Rect(rect.x, rect.y, rect.width * t, rect.height);
            Rect inputRect = new Rect(rect.x + rect.width * t, rect.y, rect.width * omt, rect.height);

            var oldBackgroundColor = GUI.backgroundColor;
            GUI.backgroundColor = inputBackgroundColor;

            labelStyle.normal.textColor = labelColor;
            labelStyle.fontSize = labelFontSize;
            labelStyle.fontStyle = labelFontStyle;

            inputStyle.normal.textColor = inputTextColor;
            inputStyle.fontSize = inputFontSize;
            inputStyle.fontStyle = inputFontStyle;
            inputStyle.alignment = inputTextAlignment;

            EditorGUI.PrefixLabel(labelRect, labelContent, labelStyle);

            GUI.SetNextControlName("StringField");
            value = EditorGUI.TextField(inputRect, value, inputStyle);

            // Placeholder
            inputStyle.normal.textColor = inputTextColor.SetA(0.5f);
            if (string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(placeholder) &&
                !(GUI.GetNameOfFocusedControl() == "StringField"))
                EditorGUI.LabelField(inputRect, placeholder, inputStyle);

            GUI.backgroundColor = oldBackgroundColor;

            if (debugAll)
                DebugRect();

            return value;
        }

        /// <summary> 레이아웃 요소로 그리기 </summary>
        public string DrawLayout()
        {
            value = Draw(0f, 1f, 0f, DefaultControlHeight);
            REG.Space(DefaultControlHeight + DefaultControlMargin);
            return value;
        }
    }
    public class TextField : DrawingElement
    {
        public static TextField Default { get; } = new TextField();
        protected GUIStyle inputStyle;

        // Data
        protected string value = "";
        protected string placeholder = "";

        // Styles - Input Field
        public int inputFontSize = 12;
        public Color inputTextColor = Color.white;
        public Color inputBackgroundColor = Color.white;
        public FontStyle inputFontStyle = FontStyle.Normal;
        public TextAnchor inputTextAlignment = TextAnchor.MiddleLeft;

        public TextField SetData(string value, string placeholder = "")
        {
            this.value = value;
            this.placeholder = placeholder;
            return this;
        }

        public string Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (inputStyle == null)
                inputStyle = new GUIStyle(GUI.skin.textField);

            var oldBackgroundColor = GUI.backgroundColor;
            GUI.backgroundColor = inputBackgroundColor;

            inputStyle.normal.textColor = inputTextColor;
            inputStyle.fontSize = inputFontSize;
            inputStyle.fontStyle = inputFontStyle;
            inputStyle.alignment = inputTextAlignment;

            GUI.SetNextControlName("TextField");
            value = EditorGUI.TextField(rect, value, inputStyle);

            // Placeholder
            inputStyle.normal.textColor = inputTextColor.SetA(0.5f);
            if (string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(placeholder) &&
                !(GUI.GetNameOfFocusedControl() == "TextField"))
                EditorGUI.LabelField(rect, placeholder, inputStyle);

            GUI.backgroundColor = oldBackgroundColor;

            if (debugAll)
                DebugRect();

            return value;
        }

        /// <summary> 레이아웃 요소로 그리기 </summary>
        public string DrawLayout()
        {
            value = Draw(0f, 1f, 0f, DefaultControlHeight);
            REG.Space(DefaultControlHeight + DefaultControlMargin);
            return value;
        }
    }
    public class BoolField : DrawingElement
    {
        public static BoolField Default { get; } = new BoolField();
        protected GUIStyle labelStyle;

        // Data
        protected GUIContent labelContent;
        protected bool value = false;
        protected float widthThreshold = 0.4f;
        protected bool toggleLeft = false;

        // Styles - Label
        public Color labelColor = Color.white;
        public int labelFontSize = 12;
        public FontStyle labelFontStyle = FontStyle.Normal;
        public TextAnchor labelAlignment = TextAnchor.MiddleLeft;

        // Styles - Toggle
        public Color toggleColor = Color.white;

        public BoolField SetData(string label, bool value, bool toggleLeft = false, float widthThreshold = 0.4f)
        {
            this.labelContent = new GUIContent(label);

            this.value = value;
            this.widthThreshold = widthThreshold;
            this.toggleLeft = toggleLeft;
            return this;
        }

        public bool Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (labelStyle == null)
                labelStyle = new GUIStyle(GUI.skin.label);

            var oldBackgroundColor = GUI.color;
            GUI.color = toggleColor;

            labelStyle.normal.textColor = labelColor;
            labelStyle.alignment = labelAlignment;
            labelStyle.fontSize = labelFontSize;
            labelStyle.fontStyle = labelFontStyle;

            ref float t = ref widthThreshold;
            float omt = 1f - t;
            Rect leftRect = new Rect(rect.x, rect.y, rect.width * t, rect.height);
            Rect rightRect = new Rect(rect.x + rect.width * t, rect.y, rect.width * omt, rect.height);

            EditorGUI.PrefixLabel(!toggleLeft ? leftRect : rightRect, labelContent, labelStyle);
            value = EditorGUI.Toggle(toggleLeft ? leftRect : rightRect, "", value);

            GUI.color = oldBackgroundColor;

            if (debugAll)
                DebugRect();

            return value;
        }

        /// <summary> 레이아웃 요소로 그리기 </summary>
        public bool DrawLayout()
        {
            value = Draw(0f, 1f, 0f, DefaultControlHeight);
            REG.Space(DefaultControlHeight + DefaultControlMargin);
            return value;
        }
    }
    public class Toggle : DrawingElement
    {
        public static Toggle Default { get; } = new Toggle();
        protected GUIStyle style;

        // Data
        protected bool value = false;

        // Style
        public Color toggleColor = Color.white;

        public Toggle SetData(bool value)
        {
            this.value = value;
            return this;
        }

        public bool Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (style == null)
                style = new GUIStyle(GUI.skin.toggle);

            var oldBackgroundColor = GUI.color;
            GUI.color = toggleColor;

            value = EditorGUI.Toggle(rect, "", value);

            GUI.color = oldBackgroundColor;

            if (debugAll)
                DebugRect();

            return value;
        }

        /// <summary> 레이아웃 요소로 그리기 </summary>
        public bool DrawLayout()
        {
            value = Draw(0f, 1f, 0f, DefaultControlHeight);
            REG.Space(DefaultControlHeight + DefaultControlMargin);
            return value;
        }
    }

    public class IntSlider : DrawingElement
    {
        public static IntSlider Default { get; } = new IntSlider();
        protected GUIStyle labelStyle;
        protected GUIStyle inputStyle;

        // Data
        protected GUIContent labelContent;
        protected int value = 0;
        protected int minValue = 0;
        protected int maxValue = 0;
        protected float widthThreshold = 0.4f;

        // Styles - Label
        public int labelFontSize = 12;
        public Color labelColor = Color.white;
        public FontStyle labelFontStyle = FontStyle.Normal;

        // Styles - Slider
        public Color sliderColor = Color.white;
        public Color valueColor = Color.white;

        public IntSlider SetData(string label, int value, int minValue, int maxValue, float widthThreshold = 0.4f)
        {
            this.labelContent = new GUIContent(label);

            this.value = value;
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.widthThreshold = widthThreshold;
            return this;
        }

        public int Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (labelStyle == null)
                labelStyle = new GUIStyle(GUI.skin.label);
            if (inputStyle == null)
                inputStyle = new GUIStyle(GUI.skin.textField);

            ref float t = ref widthThreshold;
            float omt = 1f - t;
            Rect labelRect = new Rect(rect.x, rect.y, rect.width * t, rect.height);
            Rect inputRect = new Rect(rect.x + rect.width * t, rect.y, rect.width * omt, rect.height);

            var oldContentColor = GUI.contentColor;
            var oldBackgroundColor = GUI.backgroundColor;

            GUI.contentColor = valueColor;
            GUI.backgroundColor = sliderColor;

            labelStyle.normal.textColor = labelColor;
            labelStyle.fontSize = labelFontSize;
            labelStyle.fontStyle = labelFontStyle;

            EditorGUI.PrefixLabel(labelRect, labelContent, labelStyle);
            value = EditorGUI.IntSlider(inputRect, value, minValue, maxValue);

            GUI.backgroundColor = oldBackgroundColor;
            GUI.contentColor = oldContentColor;

            if (debugAll)
                DebugRect();

            return value;
        }

        /// <summary> 레이아웃 요소로 그리기 </summary>
        public int DrawLayout()
        {
            value = Draw(0f, 1f, 0f, DefaultControlHeight);
            REG.Space(DefaultControlHeight + DefaultControlMargin);
            return value;
        }
    }
    public class FloatSlider : DrawingElement
    {
        public static FloatSlider Default { get; } = new FloatSlider();
        protected GUIStyle labelStyle;
        protected GUIStyle inputStyle;

        // Data
        protected GUIContent labelContent;
        protected float value = 0;
        protected float minValue = 0;
        protected float maxValue = 0;
        protected float widthThreshold = 0.4f;

        // Styles - Label
        public int labelFontSize = 12;
        public Color labelColor = Color.white;
        public FontStyle labelFontStyle = FontStyle.Normal;

        // Styles - Slider
        public Color sliderColor = Color.white;
        public Color valueColor = Color.white;

        public FloatSlider SetData(string label, float value, float minValue, float maxValue,
            float widthThreshold = 0.4f)
        {
            this.labelContent = new GUIContent(label);

            this.value = value;
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.widthThreshold = widthThreshold;
            return this;
        }

        public float Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (labelStyle == null)
                labelStyle = new GUIStyle(GUI.skin.label);
            if (inputStyle == null)
                inputStyle = new GUIStyle(GUI.skin.textField);

            ref float t = ref widthThreshold;
            float omt = 1f - t;
            Rect labelRect = new Rect(rect.x, rect.y, rect.width * t, rect.height);
            Rect inputRect = new Rect(rect.x + rect.width * t, rect.y, rect.width * omt, rect.height);

            var oldContentColor = GUI.contentColor;
            var oldBackgroundColor = GUI.backgroundColor;

            GUI.contentColor = valueColor;
            GUI.backgroundColor = sliderColor;

            labelStyle.normal.textColor = labelColor;
            labelStyle.fontSize = labelFontSize;
            labelStyle.fontStyle = labelFontStyle;

            EditorGUI.PrefixLabel(labelRect, labelContent, labelStyle);
            value = EditorGUI.Slider(inputRect, value, minValue, maxValue);

            GUI.backgroundColor = oldBackgroundColor;
            GUI.contentColor = oldContentColor;

            if (debugAll)
                DebugRect();

            return value;
        }

        /// <summary> 레이아웃 요소로 그리기 </summary>
        public float DrawLayout()
        {
            value = Draw(0f, 1f, 0f, DefaultControlHeight);
            REG.Space(DefaultControlHeight + DefaultControlMargin);
            return value;
        }
    }
    public class DoubleSlider : DrawingElement
    {
        public static DoubleSlider Default { get; } = new DoubleSlider();
        protected GUIStyle labelStyle;
        protected GUIStyle inputStyle;

        // Data
        protected GUIContent labelContent;
        protected double value = 0;
        protected double minValue = 0;
        protected double maxValue = 0;
        protected float widthThreshold = 0.4f;

        // Styles - Label
        public int labelFontSize = 12;
        public Color labelColor = Color.white;
        public FontStyle labelFontStyle = FontStyle.Normal;

        // Styles - Slider
        public Color sliderColor = Color.white;
        public Color valueColor = Color.white;

        public DoubleSlider SetData(string label, double value, double minValue, double maxValue,
            float widthThreshold = 0.4f)
        {
            this.labelContent = new GUIContent(label);

            this.value = value;
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.widthThreshold = widthThreshold;
            return this;
        }

        public double Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (labelStyle == null)
                labelStyle = new GUIStyle(GUI.skin.label);
            if (inputStyle == null)
                inputStyle = new GUIStyle(GUI.skin.textField);

            ref float t = ref widthThreshold;
            float omt = 1f - t;
            Rect labelRect = new Rect(rect.x, rect.y, rect.width * t, rect.height);
            Rect inputRect = new Rect(rect.x + rect.width * t, rect.y, rect.width * omt, rect.height);

            var oldContentColor = GUI.contentColor;
            var oldBackgroundColor = GUI.backgroundColor;

            GUI.contentColor = valueColor;
            GUI.backgroundColor = sliderColor;

            labelStyle.normal.textColor = labelColor;
            labelStyle.fontSize = labelFontSize;
            labelStyle.fontStyle = labelFontStyle;

            EditorGUI.PrefixLabel(labelRect, labelContent, labelStyle);
            value = EditorGUI.Slider(inputRect, (float)value, (float)minValue, (float)maxValue);

            GUI.backgroundColor = oldBackgroundColor;
            GUI.contentColor = oldContentColor;

            if (debugAll)
                DebugRect();

            return value;
        }

        /// <summary> 레이아웃 요소로 그리기 </summary>
        public double DrawLayout()
        {
            value = Draw(0f, 1f, 0f, DefaultControlHeight);
            REG.Space(DefaultControlHeight + DefaultControlMargin);
            return value;
        }
    }

    public class Box : DrawingElement
    {
        public static Box Default { get; } = new Box();

        // Data
        protected float outlineWidth = 0f;

        // Styles
        public Color color = Color.gray.SetA(0.5f);
        public Color outlineColor = Color.black;

        public Box SetData(float outlineWidth)
        {
            this.outlineWidth = outlineWidth;
            return this;
        }

        public void Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (outlineWidth > 0f)
            {
                ref var o = ref outlineWidth;
                float x = rect.x;
                float y = rect.y;
                float w = rect.width;
                float h = rect.height;

                Rect topLine = new Rect(x, y - o, w, o);
                Rect botLine = new Rect(x, y + h, w, o);
                Rect leftLine = new Rect(x - o, y - o, o, h + 2 * o);
                Rect rightLine = new Rect(x + w, y - o, o, h + 2 * o);

                EditorGUI.DrawRect(topLine, outlineColor);
                EditorGUI.DrawRect(botLine, outlineColor);
                EditorGUI.DrawRect(leftLine, outlineColor);
                EditorGUI.DrawRect(rightLine, outlineColor);
            }
            EditorGUI.DrawRect(rect, color);

            if (debugAll)
                DebugRect();
        }
    }
    public class HeaderBox : DrawingElement
    {
        public static HeaderBox Default { get; } = new HeaderBox();

        protected GUIStyle headerStyle;

        // Data
        protected float outlineWidth = 0f;
        protected string headerText = "Header";
        protected float headerTextLeftPadding = 0f;

        // Styles - Header Text
        public Color headerTextColor = Color.black;
        public int headerFontSize = 12;
        public FontStyle headerFontStyle = FontStyle.Bold;
        public TextAnchor headerTextAlignment = TextAnchor.MiddleLeft;

        // Styles - Box
        public Color headerColor = Color.gray;
        public Color contentColor = Color.gray.SetA(0.5f);
        public Color outlineColor = Color.black;

        public HeaderBox SetData(string headerText, float outlineWidth = 0f, float headerTextLeftPadding = 0f)
        {
            this.headerTextLeftPadding = headerTextLeftPadding;
            this.headerText = headerText;
            this.outlineWidth = outlineWidth;
            return this;
        }

        public void Draw(in float xLeft, in float xRight, float yOffset, 
            in float headerHeight, in float contentHeight,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            SetRect(xLeft, xRight, yOffset, headerHeight + contentHeight + outlineWidth, xLeftOffset, xRightOffset);

            if(headerStyle == null)
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
            Rect headerTextRect = new Rect(x + headerTextLeftPadding, y, w - headerTextLeftPadding, hh);
            Rect contentRect = new Rect(x, y + hh + o, w, ch);
            EditorGUI.DrawRect(headerRect, headerColor);
            EditorGUI.DrawRect(contentRect, contentColor);
            EditorGUI.LabelField(headerTextRect, headerText, headerStyle);

            if (debugAll)
                DebugRect();
        }

        /// <summary>
        /// 레이아웃 요소들을 감싸는 헤더박스 그리기
        /// </summary>
        /// <param name="contentCount">레이아웃 요소 개수</param>
        /// <param name="paddingHorizontal">좌우 내부 여백</param>
        /// <param name="paddingVertical">상하 내부 여백</param>
        public void DrawLayout(int contentCount, float paddingHorizontal = 0f, float paddingVertical = 0f)
        {
            if(contentCount < 0) contentCount = 0;

            const float OneHeight = DefaultControlHeight + DefaultControlMargin;
            Draw(0f, 1f, -paddingVertical, OneHeight, OneHeight * contentCount + paddingVertical * 2f,
                -paddingHorizontal, paddingHorizontal);

            REG.Space(OneHeight);
        }
    }
    public class FoldoutHeaderBox : DrawingElement
    {
        public static FoldoutHeaderBox Default { get; } = new FoldoutHeaderBox();

        protected GUIStyle headerStyle;

        // Data
        protected float outlineWidth = 0f;
        protected string headerText = "Header";
        protected float headerTextLeftPadding = 0f;
        protected bool foldout = true; // true : 펼쳐짐

        // Styles - Header Text
        public Color headerTextColor = Color.black;
        public int headerFontSize = 12;
        public FontStyle headerFontStyle = FontStyle.Bold;
        public TextAnchor headerTextAlignment = TextAnchor.MiddleLeft;

        // Styles - Box
        public Color headerColor = Color.gray;
        public Color contentColor = Color.gray.SetA(0.5f);
        public Color outlineColor = Color.black;

        public FoldoutHeaderBox SetData(bool foldout, string headerText, float outlineWidth = 0f, float headerTextLeftPadding = 0f)
        {
            this.foldout = foldout;
            this.headerText = headerText;
            this.outlineWidth = outlineWidth;
            this.headerTextLeftPadding = headerTextLeftPadding;
            return this;
        }

        public bool Draw(in float xLeft, in float xRight, float yOffset, 
            in float headerHeight, in float contentHeight,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
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
                Rect leftLine  = new Rect(x - o, y - o, o, foldout ? h + 2 * o : hh + 2 * o);
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
            Rect headerTextRect = new Rect(x + headerTextLeftPadding, y, w - headerTextLeftPadding, hh);

            // Header Button
            var oldBG = GUI.backgroundColor;
            GUI.backgroundColor = new Color(0,0,0,0);

            if (GUI.Button(headerRect, ""))
            {
                foldout = !foldout;
            }

            GUI.backgroundColor = oldBG;

            // Header Box
            bool mouseOver = headerRect.Contains(Event.current.mousePosition);
            EditorGUI.DrawRect(headerRect, !mouseOver ? headerColor : headerColor.MultiplyRGB(1.25f));

            // Header Label
            EditorGUI.LabelField(headerTextRect, headerText, headerStyle);

            // Content Box
            if (foldout)
            {
                Rect contentRect = new Rect(x, y + hh + o, w, ch);
                EditorGUI.DrawRect(contentRect, contentColor);
            }

            if (debugAll)
            {
                if(!foldout)
                    rect = headerRect;
                DebugRect();
            }

            return foldout;
        }

        /// <summary>
        /// 레이아웃 요소들을 감싸는 헤더박스 그리기
        /// </summary>
        /// <param name="contentCount">레이아웃 요소 개수</param>
        /// <param name="paddingHorizontal">좌우 내부 여백</param>
        /// <param name="paddingVertical">상하 내부 여백</param>
        public bool DrawLayout(int contentCount, float paddingHorizontal = 0f, float paddingVertical = 0f)
        {
            if (contentCount < 0) contentCount = 0;

            const float OneHeight = DefaultControlHeight + DefaultControlMargin;
            foldout = Draw(0f, 1f, -paddingVertical, OneHeight, OneHeight * contentCount + paddingVertical * 2f,
                -paddingHorizontal, paddingHorizontal);

            REG.Space(OneHeight);

            return foldout;
        }
    }
    public class HelpBox : DrawingElement
    {
        public static HelpBox Default { get; } = new HelpBox();

        // Data
        protected string text = "";
        protected MessageType messageType;

        // Styles
        public Color textColor = Color.white;
        public TextAnchor textAlignment = TextAnchor.MiddleLeft;
        public int fontSize = 10;
        public FontStyle fontStyle = FontStyle.Normal;

        public Color backgroundColor = Color.white;

        public HelpBox SetData(string text, MessageType messageType)
        {
            this.text = text;
            this.messageType = messageType;
            return this;
        }

        public void Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            var oldBackgroundColor = GUI.backgroundColor;

            var helpBoxStyle = EditorStyles.helpBox;
            var oldTextColor = helpBoxStyle.normal.textColor;
            var oldFontSize = helpBoxStyle.fontSize;
            var oldFontStyle = helpBoxStyle.fontStyle;
            var oldAlignment = helpBoxStyle.alignment;

            GUI.backgroundColor = backgroundColor;
            helpBoxStyle.normal.textColor = textColor;
            helpBoxStyle.fontSize = fontSize;
            helpBoxStyle.fontStyle = fontStyle;
            helpBoxStyle.alignment = textAlignment;

            EditorGUI.HelpBox(rect, text, messageType);

            GUI.backgroundColor = oldBackgroundColor;
            helpBoxStyle.normal.textColor = oldTextColor;
            helpBoxStyle.fontSize = oldFontSize;
            helpBoxStyle.fontStyle = oldFontStyle;
            helpBoxStyle.alignment = oldAlignment;

            if (debugAll)
                DebugRect();
        }

        /// <summary> 레이아웃 요소로 그리기 </summary>
        public void DrawLayout()
        {
            Draw(0f, 1f, 0f, DefaultControlHeight);
            REG.Space(DefaultControlHeight + DefaultControlMargin);
        }
    }

    public class Dropdown<T> : DrawingElement
    {
        public static Dropdown<T> Default { get; } = new Dropdown<T>();
        protected GUIStyle labelStyle;
        protected GUIStyle dropdownStyle;

        // Data
        protected GUIContent labelContent;
        protected T[] values;
        protected string[] stringValues;
        protected int selectedIndex;
        protected float widthThreshold = 0.4f;

        // Styles - Label
        public int labelFontSize = 12;
        public Color labelColor = Color.white;
        public FontStyle labelFontStyle = FontStyle.Normal;

        // Styles - Popup
        public int dropdownFontSize = 12;
        public Color dropdownTextColor = Color.white;
        public Color dropdownBackgroundColor = Color.white;
        public FontStyle dropdownFontStyle = FontStyle.Normal;
        public TextAnchor dropdownTextAlignment = TextAnchor.MiddleLeft;

        public Dropdown<T> SetData(string label, T[] values, int selectedIndex, float widthThreshold = 0.4f)
        {
            this.labelContent = new GUIContent(label);
            this.values = values;
            this.selectedIndex = selectedIndex;
            this.widthThreshold = widthThreshold;

            this.stringValues = new string[values.Length];
            for (int i = 0; i < values.Length; i++)
                this.stringValues[i] = values[i].ToString();

            return this;
        }

        public int Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (labelStyle == null)
                labelStyle = new GUIStyle(GUI.skin.label);
            if (dropdownStyle == null)
                dropdownStyle = new GUIStyle(EditorStyles.popup);

            ref float t = ref widthThreshold;
            float omt = 1f - t;
            Rect labelRect = new Rect(rect.x, rect.y, rect.width * t, rect.height);
            Rect dropdownRect = new Rect(rect.x + rect.width * t, rect.y, rect.width * omt, rect.height);

            var oldBackgroundColor = GUI.backgroundColor;
            GUI.backgroundColor = dropdownBackgroundColor;

            labelStyle.normal.textColor = labelColor;
            labelStyle.fontSize = labelFontSize;
            labelStyle.fontStyle = labelFontStyle;

            dropdownStyle.normal.textColor = dropdownTextColor;
            dropdownStyle.hover.textColor = dropdownTextColor;
            dropdownStyle.focused.textColor = dropdownTextColor;
            dropdownStyle.fontSize = dropdownFontSize;
            dropdownStyle.fontStyle = dropdownFontStyle;
            dropdownStyle.alignment = dropdownTextAlignment;

            EditorGUI.PrefixLabel(labelRect, labelContent, labelStyle);
            selectedIndex = EditorGUI.Popup(dropdownRect, selectedIndex, stringValues, dropdownStyle);

            GUI.backgroundColor = oldBackgroundColor;

            if (debugAll)
                DebugRect();

            return selectedIndex;
        }

        /// <summary> 레이아웃 요소로 그리기 </summary>
        public int DrawLayout()
        {
            selectedIndex = Draw(0f, 1f, 0f, DefaultControlHeight);
            REG.Space(DefaultControlHeight + DefaultControlMargin);
            return selectedIndex;
        }
    }
}

#endif