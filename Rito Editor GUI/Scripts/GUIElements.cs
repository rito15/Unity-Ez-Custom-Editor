#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;

/*
    [TODO]

    - EnumDropdown

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
    using fPixel = System.Single;
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

        protected bool tooltipDebugAllowed = true; // 디버그 허용 여부

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

        /// <summary> 툴팁 디버그에서 제외하기 </summary>
        public R ExcludeFromDebug()
        {
            tooltipDebugAllowed = false;
            return this as R;
        }

        protected bool CheckDrawErrors()
        {
            return REG.ErrorOccured;
        }

        /// <summary> Rect 위치 가시화하여 보여주기 </summary>
        protected void DebugRect(in Color color = default, in float border = 1f)
        {
            DebugRect(this.rect, color, border);
        }
        protected void DebugRect(in Rect rect, Color color = default, in float border = 1f)
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

        /// <summary> 툴팁, 툴팁 디버그 등록 여부 확인 및 요청 </summary>
        protected void CheckTooltip()
        {
            CheckTooltip(this.rect);
        }
        protected void CheckTooltip(in Rect rect)
        {
            if (REG.TooltipDebugActivated)
            {
                if(tooltipDebugAllowed)
                    REG.DebugTooltipList.Add(new OverlayTooltip(rect, 200f, 60f, ""));
            }
            else if (tooltipFlag)
            {
                tooltipFlag = false;

                if (REG.ShowTooltip)
                    REG.TooltipList.Add(new OverlayTooltip(rect, tooltipWidth, tooltipHeight, tooltipText));
            }

            tooltipDebugAllowed = true;
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
            SetRect(xLeft, xRight, yOffset, height, 0f, 0f);
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
            => Draw(REG.LayoutXLeft, REG.LayoutXRight, 0f, height, 0f, 0f);

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

        public virtual T Get() => value;
        public virtual R Get(out T variable)
        {
            variable = this.value;
            return this as R;
        }
    }

    public abstract partial class LabelBase<R> : DrawingElement<None, R> where R : LabelBase<R>, new()
    {
        public static R Default { get; } = new R();
        public static R Bold { get; } = new R { fontStyle = FontStyle.Bold };

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
        public R SetTextColor(Color color)
        {
            this.textColor = color;
            return this as R;
        }
        public R SetTextAlignment(TextAnchor alignment)
        {
            this.textAlignment = alignment;
            return this as R;
        }
        public R SetFontSize(int fontSize)
        {
            this.fontSize = fontSize;
            return this as R;
        }
        public R SetFontStyle(FontStyle fontStyle)
        {
            this.fontStyle = fontStyle;
            return this as R;
        }

        #endregion

        public R SetData(string text)
        {
            this.text = text;
            return this as R;
        }

        public override R Draw(in float xLeft, in float xRight, float yOffset, in float height,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            if(CheckDrawErrors()) return this as R;
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (style == null)
                style = new GUIStyle(GUI.skin.label);

            style.normal.textColor = textColor;
            style.hover.textColor = 
            style.active.textColor = 
            style.focused.textColor = textColor.AddRGB(0.25f);
            style.fontSize = fontSize;
            style.fontStyle = fontStyle;
            style.alignment = textAlignment;

            DrawLabel(rect, text, style);

            EndDraw();

            return this as R;
        }

        public abstract void DrawLabel(in Rect rect, in string text, GUIStyle style);
    }
    public class Label : LabelBase<Label>
    {
        public override void DrawLabel(in Rect rect, in string text, GUIStyle style)
        {
            EditorGUI.LabelField(rect, text, style);
        }
    }
    public class SelectableLabel : LabelBase<SelectableLabel>
    {
        public override void DrawLabel(in Rect rect, in string text, GUIStyle style)
        {
            EditorGUI.SelectableLabel(rect, text, style);
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
        public Color pressedTextColor = RColor.Gray.Light;
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
            style.hover.textColor = textColor.AddRGB(0.25f);
            style.focused.textColor = textColor.AddRGB(0.25f);
            style.active.textColor = pressedTextColor;

            // 모두 먹통
            //style.onActive.textColor = Color.red;
            //style.onFocused.textColor = Color.blue;
            //style.onHover.textColor = Color.green;
            //style.onNormal.textColor = Color.magenta;

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
        public Color normalButtonColor = Color.white;
        public FontStyle normalFontStyle = FontStyle.Normal;

        // Styles - Button Pressed
        public Color pressedTextColor = Color.white;
        public Color pressedButtonColor = Color.white * 1.5f;
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
            GUI.backgroundColor = value ? pressedButtonColor : normalButtonColor;

            style.normal.textColor = value ? pressedTextColor : normalTextColor;
            style.hover.textColor = normalTextColor.AddRGB(0.25f);
            style.focused.textColor = normalTextColor.AddRGB(0.25f);
            style.active.textColor = pressedTextColor;

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
    public abstract partial class ValueFieldBase<T, R> : DrawingElement<T, R> where R : ValueFieldBase<T, R>, new()
    {
        public static R Default { get; } = new R();

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
        public Color inputTextFocusedColor = Color.white;
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
            GUI.backgroundColor = inputBackgroundColor * 2f;

            labelStyle.normal.textColor = labelColor;
            labelStyle.hover.textColor = labelColor.AddRGB(0.25f);
            labelStyle.focused.textColor = labelColor.AddRGB(0.25f);
            labelStyle.onActive.textColor = labelColor.AddRGB(0.25f);
            labelStyle.fontSize = labelFontSize;
            labelStyle.fontStyle = labelFontStyle;
            labelStyle.alignment = labelAlignment;

            inputStyle.normal.textColor = inputTextColor;
            inputStyle.hover.textColor = inputTextColor.AddRGB(0.25f);
            inputStyle.focused.textColor = inputTextFocusedColor;
            inputStyle.fontSize = inputFontSize;
            inputStyle.fontStyle = inputFontStyle;
            inputStyle.alignment = inputTextAlignment;

            DrawFields(labelRect, inputRect);

            GUI.backgroundColor = oldBackgroundColor;

            EndDraw();
            return this as R;
        }

        protected virtual void InitInputStyle() 
            => inputStyle = new GUIStyle(EditorStyles.numberField);

        protected abstract void DrawFields(in Rect labelRect, in Rect inputRect);
    }
    public abstract class ValueFieldWithSetter<T, R> : ValueFieldBase<T, R>
        where R : ValueFieldWithSetter<T, R>, new()
    {
        public R SetData(string label, T value, float widthThreshold = 0.4f)
        {
            this.labelContent = new GUIContent(label);

            this.value = value;
            this.widthThreshold = widthThreshold;
            return this as R;
        }
    }

    public class IntField : ValueFieldWithSetter<int, IntField>
    {
        protected override void DrawFields(in Rect labelRect, in Rect inputRect)
        {
            value =
                ReflectionGUI.IntField(labelRect, inputRect, labelContent, value, labelStyle, inputStyle);
        }
    }
    public class LongField : ValueFieldWithSetter<long, LongField>
    {
        protected override void DrawFields(in Rect labelRect, in Rect inputRect)
        {
            value =
                ReflectionGUI.LongField(labelRect, inputRect, labelContent, value, labelStyle, inputStyle);
        }
    }
    public class FloatField : ValueFieldWithSetter<float, FloatField>
    {
        protected override void DrawFields(in Rect labelRect, in Rect inputRect)
        {
            value = 
                ReflectionGUI.FloatField(labelRect, inputRect, labelContent, value, labelStyle, inputStyle);
        }
    }
    public class DoubleField : ValueFieldWithSetter<double, DoubleField>
    {
        protected override void DrawFields(in Rect labelRect, in Rect inputRect)
        {
            value =
                ReflectionGUI.DoubleField(labelRect, inputRect, labelContent, value, labelStyle, inputStyle);
        }
    }
    public class StringField : ValueFieldWithSetter<string, StringField>
    {
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
        where R : VectorFieldBase<T, R>, new()
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
            var oldFocusedTextColor = EditorStyles.numberField.focused.textColor;
            var oldFontSize = EditorStyles.numberField.fontSize;
            var oldFontStyle = EditorStyles.numberField.fontStyle;
            var oldTextAlign = EditorStyles.numberField.alignment;

            GUI.backgroundColor = inputBackgroundColor * 2f;
            EditorStyles.numberField.normal.textColor = inputTextColor;
            EditorStyles.numberField.hover.textColor = inputTextColor.AddRGB(0.25f);
            EditorStyles.numberField.focused.textColor = inputTextColor.AddRGB(0.25f);
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
            EditorStyles.numberField.focused.textColor = oldFocusedTextColor;
            EditorStyles.numberField.fontSize = oldFontSize;
            EditorStyles.numberField.fontStyle = oldFontStyle;
            EditorStyles.numberField.alignment = oldTextAlign;

            EndDraw();
            return this as R;
        }
        protected override void DrawFields(in Rect labelRect, in Rect inputRect)
        {
            EditorGUI.LabelField(labelRect, labelContent, labelStyle);

            var oldLabelColor = EditorStyles.label.normal.textColor;
            var oldLabelHoverColor = EditorStyles.label.normal.textColor;
            var oldLabelFocusedColor = EditorStyles.label.focused.textColor;

            EditorStyles.label.normal.textColor = labelColor;
            EditorStyles.label.hover.textColor = labelColor.AddRGB(0.25f);
            EditorStyles.label.focused.textColor = labelColor.AddRGB(0.25f);

            DrawVectorField(inputRect);

            EditorStyles.label.normal.textColor = oldLabelColor;
            EditorStyles.label.hover.textColor = oldLabelHoverColor;
            EditorStyles.label.focused.textColor = oldLabelFocusedColor;
        }
        protected abstract void DrawVectorField(in Rect inputRect);
    }
    public class Vector2Field : VectorFieldBase<Vector2, Vector2Field>
    {
        protected override void DrawVectorField(in Rect inputRect)
        {
            value = EditorGUI.Vector2Field(inputRect, "", value);
        }
    }
    public class Vector3Field : VectorFieldBase<Vector3, Vector3Field>
    {
        protected override void DrawVectorField(in Rect inputRect)
        {
            value = EditorGUI.Vector3Field(inputRect, "", value);
        }
    }
    public class Vector4Field : VectorFieldBase<Vector4, Vector4Field>
    {
        protected override void DrawVectorField(in Rect inputRect)
        {
            value = EditorGUI.Vector4Field(inputRect, "", value);
        }
    }
    public class Vector2IntField : VectorFieldBase<Vector2Int, Vector2IntField>
    {
        protected override void DrawVectorField(in Rect inputRect)
        {
            value = EditorGUI.Vector2IntField(inputRect, "", value);
        }
    }
    public class Vector3IntField : VectorFieldBase<Vector3Int, Vector3IntField>
    {
        protected override void DrawVectorField(in Rect inputRect)
        {
            value = EditorGUI.Vector3IntField(inputRect, "", value);
        }
    }

    public class ObjectField<T> : ValueFieldWithSetter<T, ObjectField<T>> where T : UnityEngine.Object
    {
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

            GUI.backgroundColor = inputBackgroundColor * 2f;
            EditorStyles.objectField.normal.textColor = inputTextColor;
            EditorStyles.objectField.hover.textColor = inputTextColor.AddRGB(0.25f);
            EditorStyles.objectField.focused.textColor = inputTextFocusedColor;
            EditorStyles.objectField.fontSize = inputFontSize;
            EditorStyles.objectField.fontStyle = inputFontStyle;
            EditorStyles.objectField.alignment = inputTextAlignment;

            labelStyle.normal.textColor = labelColor;
            labelStyle.hover.textColor = labelColor.AddRGB(0.25f);
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
    public class Dropdown<T> : ValueFieldBase<int, Dropdown<T>>
    {
        // Data
        protected T[] options;
        protected string[] stringOptions;

        // value : selected Index

        public Dropdown<T> SetData(string label, T[] options, int selectedIndex, float widthThreshold = 0.4f)
        {
            this.labelContent = new GUIContent(label);
            this.options = options;
            this.value = selectedIndex;
            this.widthThreshold = widthThreshold;

            this.stringOptions = new string[options.Length];
            for (int i = 0; i < options.Length; i++)
                this.stringOptions[i] = options[i].ToString();

            return this;
        }
        public Dropdown<T> SetData(string label, List<T> options, int selectedIndex, float widthThreshold = 0.4f)
            => SetData(label, options.ToArray(), selectedIndex, widthThreshold);

        /// <summary> 선택된 요소의 값을 직접 가져오기 </summary>
        public T GetSelectedValue()
        {
            return options[value];
        }
        /// <summary> 선택된 요소의 값을 직접 가져오기 </summary>
        public Dropdown<T> GetSelectedValue(out T variable)
        {
            variable = options[value];
            return this;
        }

        protected override void InitInputStyle()
            => inputStyle = new GUIStyle(EditorStyles.popup);

        protected override void DrawFields(in Rect labelRect, in Rect inputRect)
        {
            EditorGUI.PrefixLabel(labelRect, labelContent, labelStyle);

            var oldBackgroundColor = GUI.backgroundColor;
            GUI.backgroundColor = inputBackgroundColor;

            value = EditorGUI.Popup(inputRect, value, stringOptions, inputStyle);

            GUI.backgroundColor = oldBackgroundColor;
        }
    }
    public class EnumDropdown<T> : ValueFieldBase<T, EnumDropdown<T>> where T : System.Enum
    {
        // value : Selected Enum Value

        public EnumDropdown<T> SetData(string label, T selectedValue, float widthThreshold = 0.4f)
        {
            this.labelContent = new GUIContent(label);
            this.widthThreshold = widthThreshold;
            this.value = selectedValue;

            return this;
        }

        protected override void InitInputStyle()
            => inputStyle = new GUIStyle(EditorStyles.popup);

        protected override void DrawFields(in Rect labelRect, in Rect inputRect)
        {
            EditorGUI.PrefixLabel(labelRect, labelContent, labelStyle);

            var oldBackgroundColor = GUI.backgroundColor;
            GUI.backgroundColor = inputBackgroundColor;

            value = (T)EditorGUI.EnumPopup(inputRect, value, inputStyle);

            GUI.backgroundColor = oldBackgroundColor;
        }
    }
    public class EnumDropdown : ValueFieldBase<System.Enum, EnumDropdown>
    {
        // value : Selected Enum Value

        public EnumDropdown SetData(string label, System.Enum selectedValue, float widthThreshold = 0.4f)
        {
            this.labelContent = new GUIContent(label);
            this.widthThreshold = widthThreshold;
            this.value = selectedValue;

            return this;
        }

        protected override void InitInputStyle()
            => inputStyle = new GUIStyle(EditorStyles.popup);

        protected override void DrawFields(in Rect labelRect, in Rect inputRect)
        {
            EditorGUI.PrefixLabel(labelRect, labelContent, labelStyle);

            var oldBackgroundColor = GUI.backgroundColor;
            GUI.backgroundColor = inputBackgroundColor;

            value = EditorGUI.EnumPopup(inputRect, value, inputStyle);

            GUI.backgroundColor = oldBackgroundColor;
        }
    }

    public partial class TextArea : DrawingElement<string, TextArea>
    {
        public static TextArea Default { get; } = new TextArea();
        protected GUIStyle inputStyle;

        // Data
        protected string placeholder = "";

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

        public TextArea SetTextColor(Color color)
        {
            this.inputTextColor = color;
            return this;
        }
        public TextArea SetBackgroundColor(Color color)
        {
            this.inputBackgroundColor = color;
            return this;
        }
        public TextArea SetFontSize(int fontSize)
        {
            this.inputFontSize = fontSize;
            return this;
        }
        public TextArea SetFontStyle(FontStyle fontStyle)
        {
            this.inputFontStyle = fontStyle;
            return this;
        }
        public TextArea SetTextAlignment(TextAnchor allignment)
        {
            this.inputTextAlignment = allignment;
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
            GUI.backgroundColor = inputBackgroundColor * 2f;

            inputStyle.normal.textColor = inputTextColor;
            inputStyle.hover.textColor = inputTextColor.AddRGB(0.25f);
            inputStyle.focused.textColor = inputTextColor.AddRGB(0.25f);
            inputStyle.fontSize = inputFontSize;
            inputStyle.fontStyle = inputFontStyle;
            inputStyle.alignment = inputTextAlignment;

            GUI.SetNextControlName("TextField");
            value = EditorGUI.TextArea(rect, value, inputStyle);

            // Placeholder
            inputStyle.normal.textColor = inputTextColor.SetA(0.5f);
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

            Draw(REG.LayoutXLeft, REG.LayoutXRight, 0f, height - REG.LayoutControlBottomMargin,
                REG.LayoutXLeftOffset, REG.LayoutXRightOffset);
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
            labelStyle.hover.textColor = labelColor.AddRGB(0.25f);
            labelStyle.focused.textColor = labelColor.AddRGB(0.25f);
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

            // NOTE : backgroundColor, contentColor 적용 안됨

            var oldColor = GUI.color;
            GUI.color = color;

            value = EditorGUI.Toggle(rect, "", value);

            GUI.color = oldColor;

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
            labelStyle.hover.textColor = labelColor.AddRGB(0.25f);
            labelStyle.focused.textColor = labelColor.AddRGB(0.25f);
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
            var oldColor = GUI.color;
            GUI.color = colorPickerColor;

            value = EditorGUI.ColorField(inputRect, "", value);

            GUI.color = oldColor;

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

            var oldColor = GUI.color;
            GUI.color = colorPickerColor;

            value = EditorGUI.ColorField(rect, "", value);

            GUI.color = oldColor;

            EndDraw();
            return this;
        }
    }

    public abstract partial class ValueSliderBase<T, R> : DrawingElement<T, R> where R : ValueSliderBase<T, R>, new()
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
        public Color inputTextColor = Color.white;

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
        public R SetInputTextColor(Color color)
        {
            this.inputTextColor = color;
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
                sliderStyle = new GUIStyle(GUI.skin.horizontalSlider);

            ref float t = ref widthThreshold;
            float omt = 1f - t;
            Rect labelRect = new Rect(rect.x, rect.y, rect.width * t, rect.height);
            Rect sliderRect = new Rect(rect.x + rect.width * t, rect.y, rect.width * omt, rect.height);

            // 1. Label
            labelStyle.normal.textColor = labelColor;
            labelStyle.fontSize = labelFontSize;
            labelStyle.fontStyle = labelFontStyle;
            labelStyle.alignment = labelAlignment;

            //var oldLabelColor = GUI.skin.label.normal.textColor;
            //GUI.skin.label.normal.textColor = labelColor;
            EditorGUI.LabelField(labelRect, labelContent, labelStyle);
            //GUI.skin.label.normal.textColor = oldLabelColor;

            // 2. Slider
            var oldContentColor = GUI.contentColor;
            var oldBackgroundColor = GUI.backgroundColor;

            GUI.contentColor = inputTextColor;
            GUI.backgroundColor = sliderColor * 2f;

            DrawSlider(sliderRect);

            GUI.contentColor = oldContentColor;
            GUI.backgroundColor = oldBackgroundColor;

            // -
            EndDraw();
            return this as R;
        }
        protected abstract void DrawSlider(in Rect sliderRect);
    }
    public partial class IntSlider : ValueSliderBase<int, IntSlider>
    {
        public static IntSlider Default { get; } = new IntSlider();

        protected override void DrawSlider(in Rect sliderRect)
        {
            value = EditorGUI.IntSlider(sliderRect, value, minValue, maxValue);
        }
    }
    public partial class FloatSlider : ValueSliderBase<float, FloatSlider>
    {
        public static FloatSlider Default { get; } = new FloatSlider();

        protected override void DrawSlider(in Rect sliderRect)
        {
            value = EditorGUI.Slider(sliderRect, value, minValue, maxValue);
        }
    }
    public partial class DoubleSlider : ValueSliderBase<double, DoubleSlider>
    {
        public static DoubleSlider Default { get; } = new DoubleSlider();

        protected override void DrawSlider(in Rect sliderRect)
        {
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

        /// <summary> 박스 상단 내부 여백 지정 </summary>
        public override Box Margin(float margin = 0f)
        {
            REG.Space(margin);
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
        /// 레이아웃 요소들을 감싸는 헤더박스 그리기 + 추가 높이 지정
        /// </summary>
        /// <param name="contentCount">레이아웃 요소 개수</param>
        /// <param name="bonusHeight">추가 높이(paddingBottom) </param>
        public Box DrawLayout(int contentCount, float bonusHeight)
        {
            return DrawLayout(contentCount, 0f, bonusHeight, 0f, 0f);
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

    public abstract partial class HeaderBoxBase<R> : GUIElement<R> where R : HeaderBoxBase<R>, new()
    {
        protected GUIStyle headerStyle;

        // Data
        protected float outlineWidth = 0f;
        protected string headerText = "Header";
        protected float headerTextLeftPadding = 0f;

        protected float headerHeight; // 헤더박스 높이

        // Styles - Header Text
        public Color headerTextColor = Color.black;
        public int headerFontSize = 12;
        public FontStyle headerFontStyle = FontStyle.Bold;
        public TextAnchor headerTextAlignment = TextAnchor.MiddleLeft;

        // Styles - Box
        public Color headerColor = Color.gray;
        public Color contentColor = Color.gray.SetA(0.5f);
        public Color outlineColor = Color.black;

        /***********************************************************************
        *                               Style Setters
        ***********************************************************************/
        #region .

        public R SetHeaderTextColor(Color color)
        {
            this.headerTextColor = color;
            return this as R;
        }
        public R SetHeaderFontSize(int fontSize)
        {
            this.headerFontSize = fontSize;
            return this as R;
        }
        public R SetHeaderFontStyle(FontStyle fontStyle)
        {
            this.headerFontStyle = fontStyle;
            return this as R;
        }
        public R SetHeaderTextAlignment(TextAnchor alignment)
        {
            this.headerTextAlignment = alignment;
            return this as R;
        }

        public R SetHeaderColor(Color color)
        {
            this.headerColor = color;
            return this as R;
        }
        public R SetContentColor(Color color)
        {
            this.contentColor = color;
            return this as R;
        }
        public R SetOutlineColor(Color color)
        {
            this.outlineColor = color;
            return this as R;
        }

        #endregion

        /// <summary> 헤더 높이만큼 Space + 컨텐츠 박스 상단 내부 여백 지정 </summary>
        public override R Margin(float margin = 0f)
        {
            REG.Space(headerHeight + outlineWidth + margin);
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
        /// 레이아웃 요소들을 감싸는 헤더박스 그리기 + 추가 높이 지정
        /// </summary>
        /// <param name="contentCount">레이아웃 요소 개수</param>
        /// <param name="bonusContentHeight">추가 높이(PaddingBottom)</param>
        public R DrawLayout(int contentCount, float bonusContentHeight)
        {
            return DrawLayout(contentCount, 0f, bonusContentHeight, 0f, 0f);
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
        public virtual R DrawLayout(int contentCount, float paddingTop, float paddingBottom, float paddingLeft, float paddingRight)
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
                contentHeight: paddingTop + lcMargin + AllControlsHeight + paddingBottom,
                xLeftOffset: -paddingLeft,
                xRightOffset: paddingRight
            );

            // 박스 상단 <-> 첫 컨트롤 상단 사이 간격
            // = 헤더 높이 + 헤더와 컨텐츠 사이 아웃라인 높이 + 레이아웃 요소 여백
            REG.Space(OneHeight + outlineWidth + lcMargin);

            isLastLayout = true;
            return this as R;
        }
    }
    public class HeaderBox : HeaderBoxBase<HeaderBox>
    {
        public static HeaderBox Default { get; } = new HeaderBox();

        public HeaderBox SetData(string headerText, float outlineWidth = 0f, float headerTextLeftPadding = 2f)
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
            this.headerHeight = headerHeight;
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

            // Debug
            CheckTooltip(rect);
            CheckTooltip(headerRect);
            CheckTooltip(contentRect);

            if (REG.RectDebugActivated)
            {
                DebugRect();
            }
            isLastLayout = false;

            return this;
        }
    }
    public partial class FoldoutHeaderBox : HeaderBoxBase<FoldoutHeaderBox>
    {
        public static FoldoutHeaderBox Default { get; } = new FoldoutHeaderBox();

        protected bool foldout = true; // true : 펼쳐짐

        protected Color headerHoverColor = RColor.Gray7;

        /***********************************************************************
        *                               Style Setters
        ***********************************************************************/
        #region .

        public FoldoutHeaderBox SetHeaderHoverColor(Color color)
        {
            this.headerColor = color;
            return this;
        }

        #endregion

        public FoldoutHeaderBox SetData(bool foldout, string headerText, float outlineWidth = 0f, float headerTextLeftPadding = 2f)
        {
            this.foldout = foldout;
            this.headerText = headerText;
            this.outlineWidth = outlineWidth;
            this.headerTextLeftPadding = headerTextLeftPadding;
            return this;
        }
        public FoldoutHeaderBox SetData(string headerText, bool foldout, float outlineWidth = 0f, float headerTextLeftPadding = 2f)
        {
            return SetData(foldout, headerText, outlineWidth, headerTextLeftPadding);
        }

        /// <summary> 헤더 높이만큼 Space + 컨텐츠 박스 상단 내부 여백 지정 </summary>
        public override FoldoutHeaderBox Margin(float margin = 0f)
        {
            REG.Space(headerHeight + (foldout ? outlineWidth + margin : 0f));
            return this;
        }
        /// <summary> rect 높이 + 레이아웃 요소 기본 여백 + 추가 여백만큼 여백 지정 </summary>
        public override FoldoutHeaderBox Layout(float margin = 0f)
        {
            return Margin(margin + REG.LayoutControlBottomMargin);
        }

        public override FoldoutHeaderBox Draw(in float xLeft, in float xRight, float yOffset, 
            in float headerHeight, in float contentHeight,
            in float xLeftOffset = 0f, in float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this;
            this.headerHeight = headerHeight;
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
            EditorGUI.DrawRect(headerRect, !mouseOver ? headerColor : headerHoverColor);

            // Header Label
            EditorGUI.LabelField(headerTextRect, headerText, headerStyle);


            if (foldout)
            {
                // Content Box
                Rect contentRect = new Rect(x, y + hh + o, w, ch);
                EditorGUI.DrawRect(contentRect, contentColor);

                CheckTooltip(rect);
                CheckTooltip(contentRect);
            }

            // Debug
            CheckTooltip(headerRect);

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
        public override FoldoutHeaderBox DrawLayout(int contentCount, float paddingTop, float paddingBottom, float paddingLeft, float paddingRight)
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
                contentHeight: paddingTop + lcMargin + AllControlsHeight + paddingBottom,
                xLeftOffset: -paddingLeft,
                xRightOffset: paddingRight
            );

            // 펼쳐진 경우 : 박스 상단 <-> 첫 컨트롤 상단 사이 여백
            //             = 헤더 높이 + 헤더와 컨텐츠 사이 아웃라인 너비 + 레이아웃 요소 하단 여백
            if (foldout)
            {
                REG.Space(OneHeight + outlineWidth + lcMargin);
            }
            // 접힌 경우 : 헤더 높이만큼만 Y 전진
            // -> 펼쳐진 경우와 여백을 동일하게 맞추기 위해 하단 아웃라인 두께는 고려하지 않음
            //    (필요하면 그리는 코드에서 수동으로 Space(아웃라인 두께))
            else
            {
                REG.Space(OneHeight);
            }

            isLastLayout = true;
            return this;
        }
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

            GUI.backgroundColor = backgroundColor.SetA(100f);
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