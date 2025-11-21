using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Story Scene", menuName ="Scriptable/Story Scene")]
public class SceneScriptable : ScriptableObject
{
    public List<Story> Dialog;
    [System.Serializable]
    public struct Story
    {
        public String Dialogue;
        public String Speaker;
    }
}
