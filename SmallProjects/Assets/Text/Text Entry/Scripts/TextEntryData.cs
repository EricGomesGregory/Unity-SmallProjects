using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TextEntryData
{
    public string name;
}

[Serializable]
public class HeaderData : TextEntryData
{
    public enum Type
    {
        H1, H2, H3, H4
    }

    [Space]
    [SerializeField] Type type;
    [SerializeField] string data;

    public string Data { get { return data; } }
    public float FontSize { get { return GetFontSize(); } }

    public HeaderData()
    {
        name = "Header";
    }

    private float GetFontSize()
    {
        switch(type)
        {
            case Type.H1:
                return TextEntryHelper.H1Size;

            case Type.H2:
                return TextEntryHelper.H2Size;

            case Type.H3:
                return TextEntryHelper.H3Size;

            case Type.H4:
                return TextEntryHelper.H4Size;
        }

        return TextEntryHelper.PSize;
    }
}

[Serializable]
public class ParagraphData : TextEntryData
{
    [Space]
    [SerializeField, TextArea(1, 100)]
    string data;

    public string Data { get { return data; } }
    public float FontSize { get { return TextEntryHelper.PSize; } }

    public ParagraphData()
    {
        name = "Paragraph";
    }
}

[Serializable]
public class SpacerData : TextEntryData
{
    [Space]
    [SerializeField, Min(1f)] float space;

    public float Space { get { return 10 * space; } }

    public SpacerData()
    {
        name = "Spacer";
        space = 1f;
    }
}