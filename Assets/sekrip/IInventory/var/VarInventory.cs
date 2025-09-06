using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

[CreateAssetMenu(fileName = "NewVar", menuName = "ScriptableObjects/Var Inventory")]
public class VarInventory : ScriptableObject
{
    public Sprite UIIcon;
    public int value;
}
