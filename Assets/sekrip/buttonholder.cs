using System;
using UnityEngine;


[CreateAssetMenu(fileName = "tutorial butoon", menuName = "ScriptableObjects/Tutorial button")]
public class buttonholder : ScriptableObject
{
    public Sprite icon;
    public String Command;
}
