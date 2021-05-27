using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-05-26 PM 3:34:43
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    public partial class Label
    {
        public static Label White { get; } = new Label
        {
            textColor = RColor.white
        };
        public static Label Gray { get; } = new Label
        {
            textColor = RColor.gray
        };
        public static Label Black { get; } = new Label
        {
            textColor = RColor.black
        };
    }
    public partial class Button
    {
        public static Button White { get; } = new Button
        {
            textColor = RColor.white
        };
        public static Button Gray { get; } = new Button
        {
        };
        public static Button Black { get; } = new Button
        {
        };
    }
    public partial class ToggleButton
    {
        public static ToggleButton White { get; } = new ToggleButton
        {
        };
        public static ToggleButton Gray { get; } = new ToggleButton
        {
        };
        public static ToggleButton Black { get; } = new ToggleButton
        {
        };
    }
    public partial class IntField
    {
        public static IntField White { get; } = new IntField
        {
        };
        public static IntField Gray { get; } = new IntField
        {
        };
    }
    public partial class FloatField
    {
        public static FloatField White { get; } = new FloatField
        {
        };
        public static FloatField Gray { get; } = new FloatField
        {
        };
        public static FloatField Black { get; } = new FloatField
        {
        };
        public static FloatField Red { get; } = new FloatField
        {
        };
        public static FloatField Blue { get; } = new FloatField
        {
        };
        public static FloatField Green { get; } = new FloatField
        {
        };
    }
    public partial class DoubleField
    {
        public static DoubleField White { get; } = new DoubleField
        {
        };
        public static DoubleField Gray { get; } = new DoubleField
        {
        };
        public static DoubleField Black { get; } = new DoubleField
        {
        };
    }
    public partial class StringField
    {
        public static StringField White { get; } = new StringField
        {
        };
        public static StringField Gray { get; } = new StringField
        {
        };
        public static StringField Black { get; } = new StringField
        {
        };
    }
    public partial class TextField
    {
        public static TextField White { get; } = new TextField
        {
        };
        public static TextField Gray { get; } = new TextField
        {
        };
        public static TextField Black { get; } = new TextField
        {
        };
    }
    public partial class BoolField
    {
        public static BoolField White { get; } = new BoolField
        {
        };
        public static BoolField Gray { get; } = new BoolField
        {
        };
        public static BoolField Black { get; } = new BoolField
        {
        };
    }
    public partial class Toggle
    {
        public static Toggle White { get; } = new Toggle
        {
        };
        public static Toggle Gray { get; } = new Toggle
        {
        };
        public static Toggle Black { get; } = new Toggle
        {
        };
    }
    public partial class ObjectField<T>
    {
        public static ObjectField<T> White { get; } = new ObjectField<T>
        {
        };
        public static ObjectField<T> Gray { get; } = new ObjectField<T>
        {
        };
        public static ObjectField<T> Black { get; } = new ObjectField<T>
        {
        };
    }
    public partial class IntSlider
    {
        public static IntSlider White { get; } = new IntSlider
        {
        };
        public static IntSlider Gray { get; } = new IntSlider
        {
        };
        public static IntSlider Black { get; } = new IntSlider
        {
        };
    }
    public partial class FloatSlider
    {
        public static FloatSlider White { get; } = new FloatSlider
        {
        };
        public static FloatSlider Gray { get; } = new FloatSlider
        {
        };
        public static FloatSlider Black { get; } = new FloatSlider
        {
        };
    }
    public partial class DoubleSlider
    {
        public static DoubleSlider White { get; } = new DoubleSlider
        {
        };
        public static DoubleSlider Gray { get; } = new DoubleSlider
        {
        };
        public static DoubleSlider Black { get; } = new DoubleSlider
        {
        };
    }
    public partial class Box
    {
        public static Box White { get; } = new Box
        {
        };
        public static Box Gray { get; } = new Box
        {
        };
        public static Box Black { get; } = new Box
        {
        };
    }
    public partial class HeaderBox
    {
        public static HeaderBox White { get; } = new HeaderBox
        {
        };
        public static HeaderBox Gray { get; } = new HeaderBox
        {
        };
        public static HeaderBox Black { get; } = new HeaderBox
        {
        };
    }
    public partial class FoldoutHeaderBox
    {
        public static FoldoutHeaderBox White { get; } = new FoldoutHeaderBox
        {
        };
        public static FoldoutHeaderBox Gray { get; } = new FoldoutHeaderBox
        {
        };
        public static FoldoutHeaderBox Black { get; } = new FoldoutHeaderBox
        {
        };
    }
    public partial class HelpBox
    {
        public static HelpBox White { get; } = new HelpBox
        {
        };
        public static HelpBox Gray { get; } = new HelpBox
        {
        };
        public static HelpBox Black { get; } = new HelpBox
        {
        };
    }
    public partial class Dropdown<T>
    {
        public static Dropdown<T> White { get; } = new Dropdown<T>
        {
        };
        public static Dropdown<T> Gray { get; } = new Dropdown<T>
        {
        };
        public static Dropdown<T> Black { get; } = new Dropdown<T>
        {
        };
    }
}