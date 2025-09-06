using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public VarInventory[] data;
    public Image img;
    public TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        img.sprite = data[0].UIIcon;
        text.SetText(data[0].value.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText(data[0].value.ToString());
    }
}



