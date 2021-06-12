#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-06-02 PM 4:17:12
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    public abstract partial class ValueSliderBase<T, R> : DrawingElement<T, R> where R : ValueSliderBase<T, R>, new()
    {
        public static R Default => ThemeDict[EzEditorUtility.DefaultColorTheme];
        public static readonly Dictionary<EColor, R> ThemeDict = new Dictionary<EColor, R>()
        {
            { EColor.Gray   , Gray    },
            { EColor.White  , White   },
            { EColor.Black  , Black   },
            { EColor.Red    , Red     },
            { EColor.Green  , Green   },
            { EColor.Blue   , Blue    },
            { EColor.Pink   , Pink    },
            { EColor.Magenta, Magenta },
            { EColor.Violet , Violet  },
            { EColor.Purple , Purple  },
            { EColor.Brown  , Brown   },
            { EColor.Gold   , Gold    },
            { EColor.Orange , Orange  },
            { EColor.Yellow , Yellow  },
            { EColor.Lime   , Lime    },
            { EColor.Mint   , Mint    },
            { EColor.Cyan   , Cyan    },
        };

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

        public override R Clone()
        {
            return new R
            {
                labelFontSize = labelFontSize,
                labelColor = labelColor,
                labelFontStyle = labelFontStyle,
                labelAlignment = labelAlignment,
                sliderColor = sliderColor,
                inputTextColor = inputTextColor,
            };
        }

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

        public override R Draw(float xLeft, float xRight, float yOffset, float height,
            float xLeftOffset = 0f, float xRightOffset = 0f)
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

            EditorGUI.LabelField(labelRect, labelContent, labelStyle);

            // 2. Slider
            var oldContentColor = GUI.contentColor;
            var oldBackgroundColor = GUI.backgroundColor;

            GUI.contentColor = inputTextColor;
            GUI.backgroundColor = sliderColor * 2f;

            EditorGUI.BeginChangeCheck();

            DrawSlider(sliderRect);

            isChanged = EditorGUI.EndChangeCheck();

            GUI.contentColor = oldContentColor;
            GUI.backgroundColor = oldBackgroundColor;

            // -
            CheckDebugs();
            EndDraw();
            return this as R;
        }
        protected abstract void DrawSlider(in Rect sliderRect);
    }
    public partial class IntSlider : ValueSliderBase<int, IntSlider>
    {
        protected override void DrawSlider(in Rect sliderRect)
        {
            value = EditorGUI.IntSlider(sliderRect, value, minValue, maxValue);
        }
    }
    public partial class FloatSlider : ValueSliderBase<float, FloatSlider>
    {
        /// <summary> 소수점 자리수 제한 </summary>
        public FloatSlider SetPrecision(int precision)
        {
            value.SetPrecision(precision);
            return this;
        }
        protected override void DrawSlider(in Rect sliderRect)
        {
            value = EditorGUI.Slider(sliderRect, value, minValue, maxValue);
        }
    }
    public partial class DoubleSlider : ValueSliderBase<double, DoubleSlider>
    {
        /// <summary> 소수점 자리수 제한 </summary>
        public DoubleSlider SetPrecision(int precision)
        {
            value.SetPrecision(precision);
            return this;
        }
        protected override void DrawSlider(in Rect sliderRect)
        {
            value = EditorGUI.Slider(sliderRect, (float)value, (float)minValue, (float)maxValue);
        }
    }
}

#endif