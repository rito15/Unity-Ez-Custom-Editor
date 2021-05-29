#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


/*
    [TODO]

    - Int, Float, Double Field 레이블 영역 좌우 드래그하면 value 값 감소/증가

    - CustomizedEditorGUIThemes : White, Gray, Black, Red, Blue, Green, Yellow, Cyan, Purple, Pink
        - 따로 클래스파일 만들고, 각각 컨트롤마다 Partial로 프로퍼티들 작성
        - Demo_CustomizedEditorGUI_색상들 : 데모 테스트

    - 깃헙용 : 예전 코드 vs 현재 코드 - Foldout 포함
*/

// 날짜 : 2021-05-24 AM 1:32:18
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    using REG = RitoEditorGUI;
    using fRatio = System.Single;

    public struct None { public static readonly None Empty = new None(); }

    /// <summary> 마우스를 컨트롤에 올리면 표시할 툴팁 </summary>
    public class OverlayTooltip
    {
        public Rect rect;    // 마우스 인식 영역
        public float width;  // 툴팁의 너비
        public float height; // 툴팁의 높이
        public string text;

        public OverlayTooltip(in Rect rect, in float width, in float height, in string text)
        {
            this.rect = rect;
            this.width = width;
            this.height = height;
            this.text = text;
        }
    }

    public abstract class GUIElement<R> where R : GUIElement<R>
    {
        protected Rect rect;

        protected bool isLastLayout = false; // 마지막으로 그린 요소가 레이아웃 요소였는지 여부

        protected bool tooltipFlag = false; // 툴팁 등록 여부 설정
        protected float tooltipWidth;
        protected float tooltipHeight;
        protected string tooltipText;


        /// <summary> 마지막으로 그린 Rect 가져오기 </summary>
        public Rect GetLastRect()
        {
            return rect;
        }

        /// <summary> 컨트롤에 마우스가 올라갈 경우 툴팁 상자 표시하도록 설정 </summary>
        public virtual R SetTooltip(string text, float width = 100f, float height = 20f)
        {
            tooltipFlag = true;
            tooltipText = text;
            tooltipWidth = width;
            tooltipHeight = height;
            return this as R;
        }

        /// <summary> 하단 여백 지정 </summary>
        public virtual R Space(float height)
        {
            REG.Space(height);
            return this as R;
        }
        /// <summary> rect 높이 + 지정 높이만큼 여백 지정 </summary>
        public virtual R Margin(float margin = 0f)
        {
            if(!isLastLayout) margin += rect.height;
            REG.Space(margin);
            return this as R;
        }

        // 레이아웃 요소가 아닌 컨트롤을 레이아웃 요소처럼 그리는 효과
        /// <summary> rect 높이 + 레이아웃 요소 기본 여백 + 추가 여백만큼 여백 지정 </summary>
        public virtual R Layout(float margin = 0f)
        {
            return Margin(margin + REG.LayoutControlBottomMargin);
        }

        /// <summary> Rect 위치 가시화하여 보여주기 </summary>
        protected void DebugRect(Color color = default, in float border = 1f)
        {
            if(!REG.RectDebugActivated) return;
            if(rect == default) return;
            if(color == default) color = REG.RectDebugColor;

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

        protected bool CheckDrawErrors()
        {
            return REG.ErrorOccured;
        }

        /// <summary> 툴팁 등록 여부 확인 및 요청 </summary>
        protected void CheckTooltip()
        {
            CheckTooltip(this.rect);
        }
        protected void CheckTooltip(in Rect rect)
        {
            if (REG.TooltipDebugActivated)
            {
                REG.DebugTooltipList.Add(new OverlayTooltip(rect, 200f, 60f, ""));
            }
            else if (tooltipFlag)
            {
                tooltipFlag = false;

                if (REG.ShowTooltip)
                    REG.TooltipList.Add(new OverlayTooltip(rect, tooltipWidth, tooltipHeight, tooltipText));
            }
        }

        /// <summary> Draw() 마무리 </summary>
        protected void EndDraw()
        {
            CheckTooltip();
            if (REG.RectDebugActivated)
                DebugRect();
            isLastLayout = false;
        }

        // xLeft, xRight : ViewWidth에 대한 Rect 좌우 지점의 비율(0 ~ 1)
        /// <summary> 그려질 지점의 Rect 설정 </summary>
        protected void SetRect(in fRatio xLeft, in fRatio xRight, in float yOffset, in float height)
        {
            rect = REG.GetRect(xLeft, xRight, yOffset, height);
        }
        /// <summary> 그려질 지점의 Rect 설정 </summary>
        protected void SetRect(in fRatio xLeft, in fRatio xRight, in float yOffset, in float height,
            in float xLeftOffset, in float xRightOffset)
        {
            rect = REG.GetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);
        }
    }
    public abstract class DrawingElement<T, R> : GUIElement<R> where R : DrawingElement<T, R>
    {
        protected T value;

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
            Draw(0f, 1f, 0f, REG.LayoutControlHeight);
            REG.Space(REG.LayoutControlHeight + REG.LayoutControlBottomMargin);

            isLastLayout = true;
            return this as R;
        }
        /// <summary> 레이아웃 요소로 그리기 + 너비(비율) 설정 </summary>
        public virtual R DrawLayout(in fRatio xLeft, in fRatio xRight)
        {
            Draw(xLeft, xRight, 0f, REG.LayoutControlHeight, 0f, 0f);
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

        public virtual T Get() => value;
        public virtual void Get(out T value) => value = this.value;
    }

    public partial class Label : DrawingElement<None, Label>
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

        /***********************************************************************
        *                               Style Setters
        ***********************************************************************/
        #region .
        public Label SetTextColor(Color color)
        {
            this.textColor = color;
            return this;
        }
        public Label SetTextAlignment(TextAnchor alignment)
        {
            this.textAlignment = alignment;
            return this;
        }
        public Label SetFontSize(int fontSize)
        {
            this.fontSize = fontSize;
            return this;
        }
        public Label SetFontStyle(FontStyle fontStyle)
        {
            this.fontStyle = fontStyle;
            return this;
        }

        #endregion

        public Label SetData(string text)
        {
            this.text = text;
            return this;
        }

        public override Label Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            if(CheckDrawErrors()) return this;
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (style == null)
                style = new GUIStyle(GUI.skin.label);

            style.normal.textColor = textColor;
            style.fontSize = fontSize;
            style.fontStyle = fontStyle;
            style.alignment = textAlignment;

            EditorGUI.LabelField(rect, text, style);

            EndDraw();

            return this;
        }
    }
    public partial class SelectableLabel : Label
    {
        public static new SelectableLabel Default { get; } = new SelectableLabel();

        public override Label Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this;
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (style == null)
                style = new GUIStyle(GUI.skin.label);

            style.normal.textColor = textColor;
            style.fontSize = fontSize;
            style.fontStyle = fontStyle;
            style.alignment = textAlignment;

            EditorGUI.SelectableLabel(rect, text, style);

            EndDraw();
            return this;
        }
    }

    public partial class Button : DrawingElement<bool, Button>
    {
        public static Button Default { get; } = new Button();
        protected GUIStyle style;

        // Data
        protected string text = "";

        // Styles
        public Color textColor = Color.white;
        public Color hoverTextColor = Color.white;
        public TextAnchor textAlignment = TextAnchor.MiddleCenter;
        public int fontSize = 12;
        public FontStyle fontStyle = FontStyle.Normal;

        public Color buttonColor = Color.white;

        /***********************************************************************
        *                               Style Setters
        ***********************************************************************/
        #region .
        public Button SetTextColor(Color color)
        {
            this.textColor = color;
            return this;
        }
        public Button SetTextAlignment(TextAnchor alignment)
        {
            this.textAlignment = alignment;
            return this;
        }
        public Button SetFontSize(int fontSize)
        {
            this.fontSize = fontSize;
            return this;
        }
        public Button SetFontStyle(FontStyle fontStyle)
        {
            this.fontStyle = fontStyle;
            return this;
        }
        public Button SetButtonColor(Color color)
        {
            this.buttonColor = color;
            return this;
        }

        #endregion

        public Button SetData(string text)
        {
            this.text = text;
            return this;
        }

        public override Button Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this;
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (style == null)
                style = new GUIStyle(GUI.skin.button);

            var oldBackgroundColor = GUI.backgroundColor;
            GUI.backgroundColor = buttonColor;
            style.normal.textColor = textColor;
            style.hover.textColor = hoverTextColor;
            style.fontSize = fontSize;
            style.fontStyle = fontStyle;
            style.alignment = textAlignment;

            value = GUI.Button(rect, text, style);

            GUI.backgroundColor = oldBackgroundColor;

            EndDraw();
            return this;
        }
    }
    public partial class ToggleButton : DrawingElement<bool, ToggleButton>
    {
        public static ToggleButton Default { get; } = new ToggleButton();
        protected GUIStyle style;

        // Data
        protected string label = "Toggle Button";

        // Styles
        public int fontSize = 12;
        public TextAnchor textAlignment = TextAnchor.MiddleCenter;

        // Styles - Button Normal
        public Color normalTextColor = Color.white;
        public Color hoverTextColor = Color.white;
        public Color normalButtonColor = Color.white;
        public FontStyle normalFontStyle = FontStyle.Normal;

        // Styles - Button Pressed
        public Color pressedTextColor = Color.white;
        public Color pressedButtonColor = Color.white;
        public FontStyle pressedFontStyle = FontStyle.Bold;


        /***********************************************************************
        *                               Style Setters
        ***********************************************************************/
        #region .
        public ToggleButton SetFontSize(int fontSize)
        {
            this.fontSize = fontSize;
            return this;
        }
        public ToggleButton SetTextAlignment(TextAnchor alignment)
        {
            this.textAlignment = alignment;
            return this;
        }

        public ToggleButton SetTextColor(Color color)
        {
            this.normalTextColor = color;
            this.pressedTextColor = color;
            return this;
        }
        public ToggleButton SetButtonColor(Color color)
        {
            this.normalButtonColor = color;
            this.pressedButtonColor = color;
            return this;
        }
        public ToggleButton SetFontStyle(FontStyle fontStyle)
        {
            this.normalFontStyle = fontStyle;
            this.pressedFontStyle = fontStyle;
            return this;
        }

        public ToggleButton SetNormalTextColor(Color color)
        {
            this.normalTextColor = color;
            return this;
        }
        public ToggleButton SetNormalButtonColor(Color color)
        {
            this.normalButtonColor = color;
            return this;
        }
        public ToggleButton SetNormalFontStyle(FontStyle fontStyle)
        {
            this.normalFontStyle = fontStyle;
            return this;
        }

        public ToggleButton SetPressedTextColor(Color color)
        {
            this.pressedTextColor = color;
            return this;
        }
        public ToggleButton SetPressedButtonColor(Color color)
        {
            this.pressedButtonColor = color;
            return this;
        }
        public ToggleButton SetPressedFontStyle(FontStyle fontStyle)
        {
            this.pressedFontStyle = fontStyle;
            return this;
        }

        #endregion

        public ToggleButton SetData(string label, bool value)
        {
            this.label = label;
            this.value = value;
            return this;
        }

        public override ToggleButton Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this;
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (style == null)
                style = new GUIStyle(GUI.skin.button);

            var oldBackgroundColor = GUI.backgroundColor;
            GUI.backgroundColor = value ? pressedButtonColor.AddRGB(0.5f) : normalButtonColor;

            style.normal.textColor = value ? pressedTextColor : normalTextColor;
            style.hover.textColor = hoverTextColor;
            style.fontSize = fontSize;
            style.fontStyle = value ? pressedFontStyle : normalFontStyle;
            style.alignment = textAlignment;

            if (GUI.Button(rect, label, style))
                value = !value;

            GUI.backgroundColor = oldBackgroundColor;

            EndDraw();
            return this;
        }
    }

    public abstract class ValueField<T, R> : DrawingElement<T, R> where R : ValueField<T, R>
    {
        protected GUIStyle labelStyle;
        protected GUIStyle inputStyle;

        // Data
        protected GUIContent labelContent;
        protected float widthThreshold = 0.4f;

        // Styles - Label
        public Color labelColor = Color.white;
        public int labelFontSize = 12;
        public FontStyle labelFontStyle = FontStyle.Normal;
        public TextAnchor labelAlignment = TextAnchor.MiddleLeft;

        // Styles - Input Field
        public Color inputTextColor = Color.white;
        public Color inputBackgroundColor = Color.white;
        public int inputFontSize = 12;
        public FontStyle inputFontStyle = FontStyle.Normal;
        public TextAnchor inputTextAlignment = TextAnchor.MiddleLeft;
        
        /***********************************************************************
        *                               Style Setters
        ***********************************************************************/
        #region .
        public R SetLabelColor(Color color)
        {
            this.labelColor = color;
            return this as R;
        }
        public R SetLabelFontSize(int fontSize)
        {
            this.labelFontSize = fontSize;
            return this as R;
        }
        public R SetLabelFontStyle(FontStyle fontStyle)
        {
            this.labelFontStyle = fontStyle;
            return this as R;
        }
        public R SetLabelTextAlignment(TextAnchor alignment)
        {
            this.labelAlignment = alignment;
            return this as R;
        }

        public R SetInputTextColor(Color color)
        {
            this.inputTextColor = color;
            return this as R;
        }
        public R SetInputBackgroundColor(Color color)
        {
            this.inputBackgroundColor = color;
            return this as R;
        }
        public R SetInputFontSize(int fontSize)
        {
            this.inputFontSize = fontSize;
            return this as R;
        }
        public R SetInputFontStyle(FontStyle fontStyle)
        {
            this.inputFontStyle = fontStyle;
            return this as R;
        }
        public R SetInputTextAlignment(TextAnchor allignment)
        {
            this.inputTextAlignment = allignment;
            return this as R;
        }

        #endregion

        public override R Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this as R;
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (labelStyle == null)
                labelStyle = new GUIStyle(GUI.skin.label);

            if(inputStyle == null)
                InitInputStyle();

            ref float t = ref widthThreshold;
            float omt = 1f - t;
            Rect labelRect = new Rect(rect.x, rect.y, rect.width * t, rect.height);
            Rect inputRect = new Rect(rect.x + rect.width * t, rect.y, rect.width * omt, rect.height);

            var oldBackgroundColor = GUI.backgroundColor;
            GUI.backgroundColor = inputBackgroundColor;

            labelStyle.normal.textColor = labelColor;
            labelStyle.fontSize = labelFontSize;
            labelStyle.fontStyle = labelFontStyle;
            labelStyle.alignment = labelAlignment;

            inputStyle.normal.textColor = inputTextColor;
            inputStyle.fontSize = inputFontSize;
            inputStyle.fontStyle = inputFontStyle;
            inputStyle.alignment = inputTextAlignment;

            DrawFields(labelRect, inputRect);

            GUI.backgroundColor = oldBackgroundColor;

            EndDraw();
            return this as R;
        }

        protected virtual void InitInputStyle() 
            => inputStyle = new GUIStyle(GUI.skin.textField);

        protected abstract void DrawFields(in Rect labelRect, in Rect inputRect);
    }
    public abstract class ValueFieldWithSetter<T, R> : ValueField<T, R>
        where R : ValueFieldWithSetter<T, R>
    {
        public R SetData(string label, T value, float widthThreshold = 0.4f)
        {
            this.labelContent = new GUIContent(label);

            this.value = value;
            this.widthThreshold = widthThreshold;
            return this as R;
        }
    }

    public partial class IntField : ValueFieldWithSetter<int, IntField>
    {
        public static IntField Default { get; } = new IntField();
        protected override void DrawFields(in Rect labelRect, in Rect inputRect)
        {
            EditorGUI.PrefixLabel(labelRect, labelContent, labelStyle);
            value = EditorGUI.IntField(inputRect, value, inputStyle);
        }
    }
    public partial class FloatField : ValueFieldWithSetter<float, FloatField>
    {
        public static FloatField Default { get; } = new FloatField();

        protected override void DrawFields(in Rect labelRect, in Rect inputRect)
        {
            EditorGUI.PrefixLabel(labelRect, labelContent, labelStyle);
            value = EditorGUI.FloatField(inputRect, value, inputStyle);
        }
    }
    public partial class DoubleField : ValueFieldWithSetter<double, DoubleField>
    {
        public static DoubleField Default { get; } = new DoubleField();

        protected override void DrawFields(in Rect labelRect, in Rect inputRect)
        {
            EditorGUI.PrefixLabel(labelRect, labelContent, labelStyle);
            value = EditorGUI.DoubleField(inputRect, value, inputStyle);
        }
    }
    public partial class StringField : ValueFieldWithSetter<string, StringField>
    {
        public static StringField Default { get; } = new StringField();

        protected string placeholder = "";

        public StringField SetData(string label, string value, string placeholder = "", float widthThreshold = 0.4f)
        {
            this.labelContent = new GUIContent(label);

            this.value = value;
            this.placeholder = placeholder;
            this.widthThreshold = widthThreshold;
            return this;
        }

        protected override void DrawFields(in Rect labelRect, in Rect inputRect)
        {
            EditorGUI.PrefixLabel(labelRect, labelContent, labelStyle);

            GUI.SetNextControlName("StringField");
            value = EditorGUI.TextField(inputRect, value, inputStyle);

            // Placeholder
            inputStyle.normal.textColor = inputTextColor.SetA(0.5f);
            if (string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(placeholder) &&
                !(GUI.GetNameOfFocusedControl() == "StringField"))
                EditorGUI.LabelField(inputRect, placeholder, inputStyle);
        }
    }

    public abstract class VectorFieldBase<T, R> : ValueFieldWithSetter<T, R>
        where R : VectorFieldBase<T, R>
    {
        public override R Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this as R;
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (labelStyle == null)
                labelStyle = new GUIStyle(GUI.skin.label);

            ref float t = ref widthThreshold;
            float omt = 1f - t;
            Rect labelRect = new Rect(rect.x, rect.y, rect.width * t, rect.height);
            Rect inputRect = new Rect(rect.x + rect.width * t, rect.y, rect.width * omt, rect.height);

            var oldBackgroundColor = GUI.backgroundColor;
            var oldTextColor = EditorStyles.numberField.normal.textColor;
            var oldHoverTextColor = EditorStyles.numberField.hover.textColor;
            var oldFontSize = EditorStyles.numberField.fontSize;
            var oldFontStyle = EditorStyles.numberField.fontStyle;
            var oldTextAlign = EditorStyles.numberField.alignment;

            GUI.backgroundColor = inputBackgroundColor;
            EditorStyles.numberField.normal.textColor = inputTextColor;
            EditorStyles.numberField.hover.textColor = inputTextColor.AddRGB(0.5f);
            EditorStyles.numberField.fontSize = inputFontSize;
            EditorStyles.numberField.fontStyle = inputFontStyle;
            EditorStyles.numberField.alignment = inputTextAlignment;

            labelStyle.normal.textColor = labelColor;
            labelStyle.fontSize = labelFontSize;
            labelStyle.fontStyle = labelFontStyle;
            labelStyle.alignment = labelAlignment;

            DrawFields(labelRect, inputRect);

            GUI.backgroundColor = oldBackgroundColor;
            EditorStyles.numberField.normal.textColor = oldTextColor;
            EditorStyles.numberField.hover.textColor = oldHoverTextColor;
            EditorStyles.numberField.fontSize = oldFontSize;
            EditorStyles.numberField.fontStyle = oldFontStyle;
            EditorStyles.numberField.alignment = oldTextAlign;

            EndDraw();
            return this as R;
        }
        protected override void DrawFields(in Rect labelRect, in Rect inputRect)
        {
            EditorGUI.PrefixLabel(labelRect, labelContent, labelStyle);

            var oldLabelColor = EditorStyles.label.normal.textColor;
            EditorStyles.label.normal.textColor = labelColor;

            DrawVectorField(inputRect);

            EditorStyles.label.normal.textColor = oldLabelColor;
        }
        protected abstract void DrawVectorField(in Rect inputRect);
    }
    public partial class Vector2Field : VectorFieldBase<Vector2, Vector2Field>
    {
        public static Vector2Field Default { get; } = new Vector2Field();

        protected override void DrawVectorField(in Rect inputRect)
        {
            value = EditorGUI.Vector2Field(inputRect, "", value);
        }
    }
    public partial class Vector3Field : VectorFieldBase<Vector3, Vector3Field>
    {
        public static Vector3Field Default { get; } = new Vector3Field();

        protected override void DrawVectorField(in Rect inputRect)
        {
            value = EditorGUI.Vector3Field(inputRect, "", value);
        }
    }
    public partial class Vector4Field : VectorFieldBase<Vector4, Vector4Field>
    {
        public static Vector4Field Default { get; } = new Vector4Field();

        protected override void DrawVectorField(in Rect inputRect)
        {
            value = EditorGUI.Vector4Field(inputRect, "", value);
        }
    }
    public partial class Vector2IntField : VectorFieldBase<Vector2Int, Vector2IntField>
    {
        public static Vector2IntField Default { get; } = new Vector2IntField();

        protected override void DrawVectorField(in Rect inputRect)
        {
            value = EditorGUI.Vector2IntField(inputRect, "", value);
        }
    }
    public partial class Vector3IntField : VectorFieldBase<Vector3Int, Vector3IntField>
    {
        public static Vector3IntField Default { get; } = new Vector3IntField();

        protected override void DrawVectorField(in Rect inputRect)
        {
            value = EditorGUI.Vector3IntField(inputRect, "", value);
        }
    }

    public partial class ObjectField<T> : ValueFieldWithSetter<T, ObjectField<T>> where T : UnityEngine.Object
    {
        public static ObjectField<T> Default { get; } = new ObjectField<T>();

        protected bool allowSceneObjects = true;

        public ObjectField<T> SetData(string label, T value, bool allowSceneObject = true, float widthThreshold = 0.4f)
        {
            this.labelContent = new GUIContent(label);
            this.value = value;
            this.allowSceneObjects = allowSceneObject;
            this.widthThreshold = widthThreshold;

            return this;
        }

        public override ObjectField<T> Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this;
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (labelStyle == null)
                labelStyle = new GUIStyle(GUI.skin.label);

            ref float t = ref widthThreshold;
            float omt = 1f - t;
            Rect labelRect = new Rect(rect.x, rect.y, rect.width * t, rect.height);
            Rect inputRect = new Rect(rect.x + rect.width * t, rect.y, rect.width * omt, rect.height);

            var oldBackgroundColor = GUI.backgroundColor;
            var oldTextColor = EditorStyles.objectField.normal.textColor;
            var oldHoverTextColor = EditorStyles.objectField.hover.textColor;
            var oldFontSize = EditorStyles.objectField.fontSize;
            var oldFontStyle = EditorStyles.objectField.fontStyle;
            var oldTextAlign = EditorStyles.objectField.alignment;

            GUI.backgroundColor = inputBackgroundColor;
            EditorStyles.objectField.normal.textColor = inputTextColor;
            EditorStyles.objectField.hover.textColor = inputTextColor.AddRGB(0.5f);
            EditorStyles.objectField.fontSize = inputFontSize;
            EditorStyles.objectField.fontStyle = inputFontStyle;
            EditorStyles.objectField.alignment = inputTextAlignment;

            labelStyle.normal.textColor = labelColor;
            labelStyle.fontSize = labelFontSize;
            labelStyle.fontStyle = labelFontStyle;
            labelStyle.alignment = labelAlignment;

            // Draw
            EditorGUI.PrefixLabel(labelRect, labelContent, labelStyle);
            value = EditorGUI.ObjectField(inputRect, value, typeof(T), allowSceneObjects) as T;

            GUI.backgroundColor = oldBackgroundColor;
            EditorStyles.objectField.normal.textColor = oldTextColor;
            EditorStyles.objectField.hover.textColor = oldHoverTextColor;
            EditorStyles.objectField.fontSize = oldFontSize;
            EditorStyles.objectField.fontStyle = oldFontStyle;
            EditorStyles.objectField.alignment = oldTextAlign;

            EndDraw();
            return this;
        }

        protected override void DrawFields(in Rect labelRect, in Rect inputRect) { }
    }
    public partial class Dropdown<T> : ValueField<int, Dropdown<T>>
    {
        public static Dropdown<T> Default { get; } = new Dropdown<T>();

        // Data
        protected T[] options;
        protected string[] stringValues;

        // value : selected Index

        public Dropdown<T> SetData(string label, T[] options, int selectedIndex, float widthThreshold = 0.4f)
        {
            this.labelContent = new GUIContent(label);
            this.options = options;
            this.value = selectedIndex;
            this.widthThreshold = widthThreshold;

            this.stringValues = new string[options.Length];
            for (int i = 0; i < options.Length; i++)
                this.stringValues[i] = options[i].ToString();

            return this;
        }
        public Dropdown<T> SetData(string label, List<T> options, int selectedIndex, float widthThreshold = 0.4f)
            => SetData(label, options.ToArray(), selectedIndex, widthThreshold);


        protected override void InitInputStyle()
            => inputStyle = new GUIStyle(EditorStyles.popup);

        protected override void DrawFields(in Rect labelRect, in Rect inputRect)
        {
            EditorGUI.PrefixLabel(labelRect, labelContent, labelStyle);
            value = EditorGUI.Popup(inputRect, value, stringValues, inputStyle);
        }
    }

    public partial class TextArea : DrawingElement<string, TextArea>
    {
        public static TextArea Default { get; } = new TextArea();
        protected GUIStyle inputStyle;

        // Data
        protected string placeholder = "";

        // Styles - Input Field
        public Color textColor = Color.white;
        public Color backgroundColor = Color.white;
        public int fontSize = 12;
        public FontStyle fontStyle = FontStyle.Normal;
        public TextAnchor textAlignment = TextAnchor.MiddleLeft;

        /***********************************************************************
        *                               Style Setters
        ***********************************************************************/
        #region .

        public TextArea SetTextColor(Color color)
        {
            this.textColor = color;
            return this;
        }
        public TextArea SetBackgroundColor(Color color)
        {
            this.backgroundColor = color;
            return this;
        }
        public TextArea SetFontSize(int fontSize)
        {
            this.fontSize = fontSize;
            return this;
        }
        public TextArea SetFontStyle(FontStyle fontStyle)
        {
            this.fontStyle = fontStyle;
            return this;
        }
        public TextArea SetTextAlignment(TextAnchor allignment)
        {
            this.textAlignment = allignment;
            return this;
        }

        #endregion

        public TextArea SetData(string value, string placeholder = "")
        {
            this.value = value;
            this.placeholder = placeholder;
            return this;
        }

        public override TextArea Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this;
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (inputStyle == null)
                inputStyle = new GUIStyle(GUI.skin.textField);

            var oldBackgroundColor = GUI.backgroundColor;
            GUI.backgroundColor = backgroundColor;

            inputStyle.normal.textColor = textColor;
            inputStyle.fontSize = fontSize;
            inputStyle.fontStyle = fontStyle;
            inputStyle.alignment = textAlignment;

            GUI.SetNextControlName("TextField");
            value = EditorGUI.TextArea(rect, value, inputStyle);

            // Placeholder
            inputStyle.normal.textColor = textColor.SetA(0.5f);
            if (string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(placeholder) &&
                !(GUI.GetNameOfFocusedControl() == "TextField"))
                EditorGUI.LabelField(rect, placeholder, inputStyle);

            GUI.backgroundColor = oldBackgroundColor;

            EndDraw();
            return this;
        }
        public TextArea DrawLayout(int lineCount)
        {
            if(lineCount < 1) lineCount = 1;
            float height = (REG.LayoutControlHeight + REG.LayoutControlBottomMargin) * lineCount;

            Draw(0f, 1f, 0f, height - REG.LayoutControlBottomMargin);
            REG.Space(height);

            isLastLayout = true;
            return this;
        }
    }
    public partial class BoolField : DrawingElement<bool, BoolField>
    {
        public static BoolField Default { get; } = new BoolField();
        protected GUIStyle labelStyle;

        // Data
        protected GUIContent labelContent;
        protected float widthThreshold = 0.4f;
        protected bool toggleLeft = false;

        // Styles - Label
        public Color labelColor = Color.white;
        public int labelFontSize = 12;
        public FontStyle labelFontStyle = FontStyle.Normal;
        public TextAnchor labelAlignment = TextAnchor.MiddleLeft;

        // Styles - Toggle
        public Color toggleColor = Color.white;

        /***********************************************************************
        *                               Style Setters
        ***********************************************************************/
        #region .

        public BoolField SetLabelColor(Color color)
        {
            this.labelColor = color;
            return this;
        }
        public BoolField SetLabelFontSize(int fontSize)
        {
            this.labelFontSize = fontSize;
            return this;
        }
        public BoolField SetLabelFontStyle(FontStyle fontStyle)
        {
            this.labelFontStyle = fontStyle;
            return this;
        }
        public BoolField SetLabelTextAlignment(TextAnchor allignment)
        {
            this.labelAlignment = allignment;
            return this;
        }

        public BoolField SetToggleColor(Color color)
        {
            this.toggleColor = color;
            return this;
        }

        #endregion

        public BoolField SetData(string label, bool value, bool toggleLeft = false, float widthThreshold = 0.4f)
        {
            this.labelContent = new GUIContent(label);

            this.value = value;
            this.widthThreshold = widthThreshold;
            this.toggleLeft = toggleLeft;
            return this;
        }

        public override BoolField Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this;
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (labelStyle == null)
                labelStyle = new GUIStyle(GUI.skin.label);

            labelStyle.normal.textColor = labelColor;
            labelStyle.fontSize = labelFontSize;
            labelStyle.fontStyle = labelFontStyle;
            labelStyle.alignment = labelAlignment;

            ref float t = ref widthThreshold;
            float omt = 1f - t;
            Rect leftRect = new Rect(rect.x, rect.y, rect.width * t, rect.height);
            Rect rightRect = new Rect(rect.x + rect.width * t, rect.y, rect.width * omt, rect.height);

            // 1. Label
            EditorGUI.PrefixLabel(!toggleLeft ? leftRect : rightRect, labelContent, labelStyle);

            // 2. Toggle
            var oldToggleColor = GUI.color;
            GUI.color = toggleColor;

            value = EditorGUI.Toggle(toggleLeft ? leftRect : rightRect, "", value);

            GUI.color = oldToggleColor;

            EndDraw();
            return this;
        }
    }
    public partial class Toggle : DrawingElement<bool, Toggle>
    {
        public static Toggle Default { get; } = new Toggle();
        protected GUIStyle style;

        // Style
        public Color color = Color.white;

        /***********************************************************************
        *                               Style Setters
        ***********************************************************************/
        #region .
        public Toggle SetColor(Color color)
        {
            this.color = color;
            return this;
        }

        #endregion

        public Toggle SetData(bool value)
        {
            this.value = value;
            return this;
        }

        public override Toggle Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this;
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (style == null)
                style = new GUIStyle(GUI.skin.toggle);

            var oldBackgroundColor = GUI.color;
            GUI.color = color;

            value = EditorGUI.Toggle(rect, "", value);

            GUI.color = oldBackgroundColor;

            EndDraw();
            return this;
        }
    }
    public partial class ColorField : DrawingElement<Color, ColorField>
    {
        public static ColorField Default { get; } = new ColorField();
        protected GUIStyle labelStyle;

        // Data
        protected GUIContent labelContent;
        protected float widthThreshold = 0.4f;

        // Styles - Label
        public Color labelColor = Color.white;
        public int labelFontSize = 12;
        public FontStyle labelFontStyle = FontStyle.Normal;
        public TextAnchor labelAlignment = TextAnchor.MiddleLeft;

        // Styles - Color Picker
        public Color colorPickerColor = Color.white;

        /***********************************************************************
        *                               Style Setters
        ***********************************************************************/
        #region .

        public ColorField SetLabelColor(Color color)
        {
            this.labelColor = color;
            return this;
        }
        public ColorField SetLabelFontSize(int fontSize)
        {
            this.labelFontSize = fontSize;
            return this;
        }
        public ColorField SetLabelFontStyle(FontStyle fontStyle)
        {
            this.labelFontStyle = fontStyle;
            return this;
        }
        public ColorField SetLabelTextAlignment(TextAnchor allignment)
        {
            this.labelAlignment = allignment;
            return this;
        }

        public ColorField SetColorPickerColor(Color color)
        {
            this.colorPickerColor = color;
            return this;
        }

        #endregion

        public ColorField SetData(string label, Color value, float widthThreshold = 0.4f)
        {
            this.labelContent = new GUIContent(label);
            this.value = value;
            this.widthThreshold = widthThreshold;

            return this;
        }

        public override ColorField Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this;
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            // Styles
            if (labelStyle == null)
                labelStyle = new GUIStyle(GUI.skin.label);

            labelStyle.normal.textColor = labelColor;
            labelStyle.fontSize = labelFontSize;
            labelStyle.fontStyle = labelFontStyle;
            labelStyle.alignment = labelAlignment;

            // Rects
            ref float t = ref widthThreshold;
            float omt = 1f - t;
            Rect labelRect = new Rect(rect.x, rect.y, rect.width * t, rect.height);
            Rect inputRect = new Rect(rect.x + rect.width * t, rect.y, rect.width * omt, rect.height);

            // 1. Label
            EditorGUI.PrefixLabel(labelRect, labelContent, labelStyle);

            // 2. Field
            var oldColor = GUI.backgroundColor;
            GUI.backgroundColor = colorPickerColor;

            value = EditorGUI.ColorField(inputRect, "", value);

            GUI.backgroundColor = oldColor;

            EndDraw();
            return this;
        }
    }
    public partial class ColorPicker : DrawingElement<Color, ColorPicker>
    {
        public static ColorPicker Default { get; } = new ColorPicker();


        // Styles - Color Picker
        public Color colorPickerColor = Color.white;

        public ColorPicker SetData(Color value)
        {
            this.value = value;

            return this;
        }

        public override ColorPicker Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this;
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            var oldColor = GUI.backgroundColor;
            GUI.backgroundColor = colorPickerColor;

            value = EditorGUI.ColorField(rect, "", value);

            GUI.backgroundColor = oldColor;

            EndDraw();
            return this;
        }
    }

    public abstract class ValueSlider<T, R> : DrawingElement<T, R> where R : ValueSlider<T, R>
    {
        protected GUIStyle labelStyle;
        protected GUIStyle sliderStyle;

        // Data
        protected GUIContent labelContent;
        protected T minValue;
        protected T maxValue;
        protected float widthThreshold = 0.4f;

        // Styles - Label
        public int labelFontSize = 12;
        public Color labelColor = Color.white;
        public FontStyle labelFontStyle = FontStyle.Normal;
        public TextAnchor labelAlignment = TextAnchor.MiddleLeft;

        // Styles - Slider
        public Color sliderColor = Color.white;
        public Color valueColor = Color.white;

        /***********************************************************************
        *                               Style Setters
        ***********************************************************************/
        #region .

        public R SetLabelColor(Color color)
        {
            this.labelColor = color;
            return this as R;
        }
        public R SetLabelFontSize(int fontSize)
        {
            this.labelFontSize = fontSize;
            return this as R;
        }
        public R SetLabelFontStyle(FontStyle fontStyle)
        {
            this.labelFontStyle = fontStyle;
            return this as R;
        }
        public R SetLabelTextAlignment(TextAnchor alignment)
        {
            this.labelAlignment = alignment;
            return this as R;
        }
        
        public R SetSliderColor(Color color)
        {
            this.sliderColor = color;
            return this as R;
        }
        public R SetValueColor(Color color)
        {
            this.valueColor = color;
            return this as R;
        }

        #endregion

        public R SetData(string label, T value, T minValue, T maxValue, float widthThreshold = 0.4f)
        {
            this.labelContent = new GUIContent(label);

            this.value = value;
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.widthThreshold = widthThreshold;
            return this as R;
        }

        public override R Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this as R;
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (labelStyle == null)
                labelStyle = new GUIStyle(GUI.skin.label);
            if (sliderStyle == null)
                sliderStyle = new GUIStyle(GUI.skin.textField);

            ref float t = ref widthThreshold;
            float omt = 1f - t;
            Rect labelRect = new Rect(rect.x, rect.y, rect.width * t, rect.height);
            Rect sliderRect = new Rect(rect.x + rect.width * t, rect.y, rect.width * omt, rect.height);

            var oldContentColor = GUI.contentColor;
            var oldBackgroundColor = GUI.backgroundColor;

            GUI.contentColor = valueColor;
            GUI.backgroundColor = sliderColor;

            labelStyle.normal.textColor = labelColor;
            labelStyle.fontSize = labelFontSize;
            labelStyle.fontStyle = labelFontStyle;
            labelStyle.alignment = labelAlignment;

            DrawGUI(labelRect, sliderRect);

            GUI.backgroundColor = oldBackgroundColor;
            GUI.contentColor = oldContentColor;

            EndDraw();
            return this as R;
        }
        protected abstract void DrawGUI(in Rect labelRect, in Rect sliderRect);
    }
    public partial class IntSlider : ValueSlider<int, IntSlider>
    {
        public static IntSlider Default { get; } = new IntSlider();

        protected override void DrawGUI(in Rect labelRect, in Rect sliderRect)
        {
            EditorGUI.PrefixLabel(labelRect, labelContent, labelStyle);
            value = EditorGUI.IntSlider(sliderRect, value, minValue, maxValue);
        }
    }
    public partial class FloatSlider : ValueSlider<float, FloatSlider>
    {
        public static FloatSlider Default { get; } = new FloatSlider();

        protected override void DrawGUI(in Rect labelRect, in Rect sliderRect)
        {
            EditorGUI.PrefixLabel(labelRect, labelContent, labelStyle);
            value = EditorGUI.Slider(sliderRect, value, minValue, maxValue);
        }
    }
    public partial class DoubleSlider : ValueSlider<double, DoubleSlider>
    {
        public static DoubleSlider Default { get; } = new DoubleSlider();

        protected override void DrawGUI(in Rect labelRect, in Rect sliderRect)
        {
            EditorGUI.PrefixLabel(labelRect, labelContent, labelStyle);
            value = EditorGUI.Slider(sliderRect, (float)value, (float)minValue, (float)maxValue);
        }
    }

    public partial class Box : GUIElement<Box>
    {
        public static Box Default { get; } = new Box();

        // Data
        protected float outlineWidth = 0f;

        // Styles
        public Color color = Color.gray.SetA(0.5f);
        public Color outlineColor = Color.black;

        /***********************************************************************
        *                               Style Setters
        ***********************************************************************/
        #region .

        public Box SetColor(Color color)
        {
            this.color = color;
            return this;
        }
        public Box SetOutlineColor(Color color)
        {
            this.outlineColor = color;
            return this;
        }

        #endregion

        public Box SetData(float outlineWidth)
        {
            this.outlineWidth = outlineWidth;
            return this;
        }

        public Box Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this;
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

            EndDraw();
            return this;
        }

        public Box Draw(in float height) 
            => Draw(0f, 1f, 0f, height, 0f, 0f);
        public Box Draw(in float xLeft, in float xRight)
            => Draw(xLeft, xRight, 0f, REG.LayoutControlHeight, 0f, 0f);
        public Box Draw(in float xLeft, in float xRight, in float height)
            => Draw(xLeft, xRight, 0f, height, 0f, 0f);

        /// <summary>
        /// 레이아웃 요소들을 감싸는 헤더박스 그리기
        /// </summary>
        /// <param name="contentCount">레이아웃 요소 개수</param>
        public Box DrawLayout(int contentCount)
        {
            return DrawLayout(contentCount, 0f, 0f, 0f, 0f);
        }
        /// <summary>
        /// 레이아웃 요소들을 감싸는 헤더박스 그리기
        /// </summary>
        /// <param name="contentCount">레이아웃 요소 개수</param>
        /// <param name="paddingVertical">상하 내부 여백</param>
        /// <param name="paddingHorizontal">좌우 내부 여백</param>
        public Box DrawLayout(int contentCount, float paddingVertical, float paddingHorizontal)
        {
            return DrawLayout(contentCount, paddingVertical, paddingVertical, paddingHorizontal, paddingHorizontal);
        }
        /// <summary>
        /// 레이아웃 요소들을 감싸는 헤더박스 그리기
        /// </summary>
        /// <param name="contentCount">레이아웃 요소 개수</param>
        /// <param name="paddingTop">상단 내부 여백</param>
        /// <param name="paddingBottom">하단 내부 여백</param>
        /// <param name="paddingLeft">좌측 내부 여백</param>
        /// <param name="paddingRight">우측 내부 여백</param>
        public Box DrawLayout(int contentCount, float paddingTop, float paddingBottom, float paddingLeft, float paddingRight)
        {
            if (contentCount < 0) contentCount = 0;

            float lcHeight = REG.LayoutControlHeight;
            float lcMargin = REG.LayoutControlBottomMargin;

            // 모든 레이아웃 요소의 높이 합
            float AllControlsHeight = (lcHeight + lcMargin) * contentCount;

            Draw
            (
                xLeft:0f, xRight:1f, 
                yOffset: -paddingTop, 
                height:  paddingTop + lcMargin + AllControlsHeight + paddingBottom,
                xLeftOffset: -paddingLeft,
                xRightOffset: paddingRight
            );

            // 박스 상단 패딩
            REG.Space(lcMargin);

            isLastLayout = true;
            return this;
        }
    }

    public abstract class HeaderBoxBase<R> : GUIElement<R> where R : HeaderBoxBase<R>
    {
        protected GUIStyle headerStyle;

        // Data
        protected float outlineWidth = 0f;
        protected string headerText = "Header";
        protected float headerTextLeftPadding = 0f;

        protected float headerHeight; // 헤더박스 높이 + 아웃라인 두께

        // Styles - Header Text
        public Color headerTextColor = Color.black;
        public int headerFontSize = 12;
        public FontStyle headerFontStyle = FontStyle.Bold;
        public TextAnchor headerTextAlignment = TextAnchor.MiddleLeft;

        // Styles - Box
        public Color headerColor = Color.gray;
        public Color contentColor = Color.gray.SetA(0.5f);
        public Color outlineColor = Color.black;

        /// <summary> (헤더 높이 + 아웃라인 두께) + 추가 여백 만큼 간격 이동 </summary>
        public R HeaderSpace(float contentPaddingTop = 0f)
        {
            REG.Space(headerHeight + contentPaddingTop);
            return this as R;
        }

        public abstract R Draw(in fRatio xLeft, in fRatio xRight, float yOffset,
            in float headerHeight, in float contentHeight,
            in float xLeftOffset = 0f, in float xRightOffset = 0f);

        public R Draw(in float headerHeight, in float contentHeight)
            => Draw(0f, 1f, 0f, headerHeight, contentHeight, 0f, 0f);
        public R Draw(in fRatio xLeft, in fRatio xRight, in float headerHeight, in float contentHeight)
            => Draw(xLeft, xRight, 0f, headerHeight, contentHeight, 0f, 0f);

        /// <summary>
        /// 레이아웃 요소들을 감싸는 헤더박스 그리기
        /// </summary>
        /// <param name="contentCount">레이아웃 요소 개수</param>
        public R DrawLayout(int contentCount)
        {
            return DrawLayout(contentCount, 0f, 0f, 0f, 0f);
        }
        /// <summary>
        /// 레이아웃 요소들을 감싸는 헤더박스 그리기
        /// </summary>
        /// <param name="contentCount">레이아웃 요소 개수</param>
        /// <param name="paddingVertical">상하 내부 여백</param>
        /// <param name="paddingHorizontal">좌우 내부 여백</param>
        public R DrawLayout(int contentCount, float paddingVertical, float paddingHorizontal)
        {
            return DrawLayout(contentCount, paddingVertical, paddingVertical, paddingHorizontal, paddingHorizontal);
        }
        /// <summary>
        /// 레이아웃 요소들을 감싸는 헤더박스 그리기
        /// </summary>
        /// <param name="contentCount">레이아웃 요소 개수</param>
        /// <param name="paddingTop">상단 내부 여백</param>
        /// <param name="paddingBottom">하단 내부 여백</param>
        /// <param name="paddingLeft">좌측 내부 여백</param>
        /// <param name="paddingRight">우측 내부 여백</param>
        public R DrawLayout(int contentCount, float paddingTop, float paddingBottom, float paddingLeft, float paddingRight)
        {
            if (contentCount < 0) contentCount = 0;

            float lcHeight = REG.LayoutControlHeight;
            float lcMargin = REG.LayoutControlBottomMargin;
            float OneHeight = lcHeight + lcMargin;

            // 모든 레이아웃 요소의 높이 합
            float AllControlsHeight = OneHeight * contentCount;

            Draw
            (
                xLeft: 0f, xRight: 1f,
                yOffset: -paddingTop,
                headerHeight: OneHeight,
                contentHeight: outlineWidth + paddingTop + lcMargin + AllControlsHeight + paddingBottom,
                xLeftOffset: -paddingLeft,
                xRightOffset: paddingRight
            );

            // 박스 상단 패딩
            REG.Space(lcMargin + OneHeight + outlineWidth);

            isLastLayout = true;
            return this as R;
        }
    }
    public partial class HeaderBox : HeaderBoxBase<HeaderBox>
    {
        public static HeaderBox Default { get; } = new HeaderBox();

        /***********************************************************************
        *                               Style Setters
        ***********************************************************************/
        #region .

        public HeaderBox SetHeaderTextColor(Color color)
        {
            this.headerTextColor = color;
            return this;
        }
        public HeaderBox SetHeaderFontSize(int fontSize)
        {
            this.headerFontSize = fontSize;
            return this;
        }
        public HeaderBox SetHeaderFontStyle(FontStyle fontStyle)
        {
            this.headerFontStyle = fontStyle;
            return this;
        }
        public HeaderBox SetHeaderTextAlignment(TextAnchor alignment)
        {
            this.headerTextAlignment = alignment;
            return this;
        }

        public HeaderBox SetHeaderColor(Color color)
        {
            this.headerColor = color;
            return this;
        }
        public HeaderBox SetContentColor(Color color)
        {
            this.contentColor = color;
            return this;
        }
        public HeaderBox SetOutlineColor(Color color)
        {
            this.outlineColor = color;
            return this;
        }

        #endregion

        public HeaderBox SetData(string headerText, float outlineWidth = 0f, float headerTextLeftPadding = 0f)
        {
            this.headerTextLeftPadding = headerTextLeftPadding;
            this.headerText = headerText;
            this.outlineWidth = outlineWidth;
            return this;
        }

        public override HeaderBox Draw(in float xLeft, in float xRight, float yOffset, 
            in float headerHeight, in float contentHeight,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this;
            this.headerHeight = headerHeight + outlineWidth;
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

            EndDraw();
            return this;
        }
    }
    public partial class FoldoutHeaderBox : HeaderBoxBase<FoldoutHeaderBox>
    {
        public static FoldoutHeaderBox Default { get; } = new FoldoutHeaderBox();

        protected bool foldout = true; // true : 펼쳐짐

        /***********************************************************************
        *                               Style Setters
        ***********************************************************************/
        #region .

        public FoldoutHeaderBox SetHeaderTextColor(Color color)
        {
            this.headerTextColor = color;
            return this;
        }
        public FoldoutHeaderBox SetHeaderFontSize(int fontSize)
        {
            this.headerFontSize = fontSize;
            return this;
        }
        public FoldoutHeaderBox SetHeaderFontStyle(FontStyle fontStyle)
        {
            this.headerFontStyle = fontStyle;
            return this;
        }
        public FoldoutHeaderBox SetHeaderTextAlignment(TextAnchor alignment)
        {
            this.headerTextAlignment = alignment;
            return this;
        }

        public FoldoutHeaderBox SetHeaderColor(Color color)
        {
            this.headerColor = color;
            return this;
        }
        public FoldoutHeaderBox SetContentColor(Color color)
        {
            this.contentColor = color;
            return this;
        }
        public FoldoutHeaderBox SetOutlineColor(Color color)
        {
            this.outlineColor = color;
            return this;
        }

        #endregion

        public FoldoutHeaderBox SetData(bool foldout, string headerText, float outlineWidth = 0f, float headerTextLeftPadding = 0f)
        {
            this.foldout = foldout;
            this.headerText = headerText;
            this.outlineWidth = outlineWidth;
            this.headerTextLeftPadding = headerTextLeftPadding;
            return this;
        }

        public override FoldoutHeaderBox Draw(in float xLeft, in float xRight, float yOffset, 
            in float headerHeight, in float contentHeight,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this;
            this.headerHeight = headerHeight + outlineWidth;
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
            EditorGUI.DrawRect(headerRect, !mouseOver ? headerColor : headerColor.AddRGB(0.25f));

            // Header Label
            EditorGUI.LabelField(headerTextRect, headerText, headerStyle);

            // Content Box
            if (foldout)
            {
                Rect contentRect = new Rect(x, y + hh + o, w, ch);
                EditorGUI.DrawRect(contentRect, contentColor);
            }

            CheckTooltip(foldout ? rect : headerRect);
            if (REG.RectDebugActivated)
            {
                if(!foldout)
                    rect = headerRect;
                DebugRect();
            }
            isLastLayout = false;
            return this;
        }

        public virtual bool Get() => foldout;
        public virtual void Get(out bool value) => value = this.foldout;
    }

    public partial class HelpBox : DrawingElement<None, HelpBox>
    {
        public static HelpBox Default { get; } = new HelpBox();

        // Data
        protected string text = "";
        protected MessageType messageType;

        // Styles
        public Color textColor = Color.white;
        public Color backgroundColor = Color.white;
        public int fontSize = 10;
        public FontStyle fontStyle = FontStyle.Normal;
        public TextAnchor textAlignment = TextAnchor.MiddleLeft;

        /***********************************************************************
        *                               Style Setters
        ***********************************************************************/
        #region .

        public HelpBox SetTextColor(Color color)
        {
            this.textColor = color;
            return this;
        }
        public HelpBox SetBackgroundColor(Color color)
        {
            this.backgroundColor = color;
            return this;
        }
        public HelpBox SetFontSize(int fontSize)
        {
            this.fontSize = fontSize;
            return this;
        }
        public HelpBox SetFontStyle(FontStyle fontStyle)
        {
            this.fontStyle = fontStyle;
            return this;
        }
        public HelpBox SetTextAlignment(TextAnchor allignment)
        {
            this.textAlignment = allignment;
            return this;
        }

        #endregion

        public HelpBox SetData(string text, MessageType messageType)
        {
            this.text = text;
            this.messageType = messageType;
            return this;
        }

        public override HelpBox Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this;
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

            EndDraw();
            return this;
        }
    }

}

#endif