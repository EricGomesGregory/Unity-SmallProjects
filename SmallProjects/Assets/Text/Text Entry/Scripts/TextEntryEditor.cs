using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TextEntry))]
public class TextEntryEditor : Editor
{
    TextEntry myTarget;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        myTarget = (TextEntry)target;

        DisplayButtons();
    }

    private void DisplayButtons()
    {
        if (GUILayout.Button("Add Header"))
        {
            myTarget.entries.Add(new HeaderData());
        }

        if (GUILayout.Button("Add Paragraph"))
        {
            myTarget.entries.Add(new ParagraphData());
        }

        if (GUILayout.Button("Add Spacer"))
        {
            myTarget.entries.Add(new SpacerData());
        }

        GUILayout.Space(25f);

        if (GUILayout.Button("Clear"))
        {
            myTarget.entries = new List<TextEntryData>();
        }
    }
}
