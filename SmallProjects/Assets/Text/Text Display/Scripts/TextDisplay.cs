using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDisplay : MonoBehaviour
{
    [SerializeField] TextEntry text;

    [Header("Prefabs")]
    [SerializeField] TextMeshProUGUI header;
    [SerializeField] TextMeshProUGUI paragraph;
    [SerializeField] RectTransform spacer;

    Transform container;

    private void Awake()
    {
        if (container == null)
        { container = transform.Find("Content"); }
    }

    private void OnValidate()
    {
        if (container == null)
        { container = transform.Find("Content"); }
    }

    private void Start()
    {
        Generate();
    }

    public void Generate()
    {
        Clear();

        if (text == null) return;
        
        foreach (var entry in text.entries)
        {
            if (entry.GetType() == typeof(HeaderData))
            {
                HeaderData header = (HeaderData)entry;

                var obj = Instantiate(this.header, container);
                obj.text = header.Data;
                obj.fontSize = header.FontSize;
            }
            else if (entry.GetType() == typeof(ParagraphData))
            {
                ParagraphData paragraph = (ParagraphData)entry;

                var obj = Instantiate(this.paragraph, container);
                obj.text = paragraph.Data;
                obj.fontSize = paragraph.FontSize;
            }
            else if (entry.GetType() == typeof(SpacerData))
            {
                SpacerData spacer = (SpacerData)entry;

                var obj = Instantiate(this.spacer, container);
                obj.sizeDelta = new Vector2(obj.rect.width, spacer.Space);
            }
        }
    }

    private void Clear()
    {
        foreach (GameObject child in container)
        {
            Destroy(child);
        }
    }
}
