using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Systems/Text/Entry", fileName = "new Text Entry")]
public class TextEntry : ScriptableObject
{
    [SerializeReference]
    public List<TextEntryData> entries = new List<TextEntryData>();
}
