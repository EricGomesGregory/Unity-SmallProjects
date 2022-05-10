using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextDisplay : MonoBehaviour
{
    [SerializeField] TextEntry text;

    [Header("Prefabs")]
    [SerializeField] TextMeshProUGUI header;
    [SerializeField] TextMeshProUGUI paragraph;
    [SerializeField] RectTransform spacer;
    [SerializeField] Transform image;

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
                
                LayoutElement layout = obj.GetComponent<LayoutElement>();

                layout.minHeight = spacer.Space;
                layout.preferredHeight = spacer.Space;
            }
            else if (entry.GetType() == typeof(ImageData))
            {
                ImageData image = (ImageData)entry;

                var obj = Instantiate(this.image, container);
                obj.GetComponent<Image>().sprite = image.Data;
                
                LayoutElement layout = obj.GetComponent<LayoutElement>();
                
                layout.preferredWidth = image.Size.x;
                layout.preferredHeight = image.Size.y;
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
