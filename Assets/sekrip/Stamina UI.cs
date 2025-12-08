using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StaminaUI : MonoBehaviour
{
    public RectTransform leftscroll;
    public RectTransform rightscroll;
    public RectTransform stamina;
    public GameObject midright;
    public GameObject midleft;
    private Animator anim;
    public Movement movement;

    //inventory
    public VarInventory[] data;
    public Image img;
    public TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();

        img.sprite = data[0].UIIcon;
        text.SetText(data[0].value.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText(data[0].value.ToString());

        if (anim != null)
        {
            anim.SetFloat("Stamina", movement.stamina);
        }
        Vector2 newSize = stamina.sizeDelta;
        newSize.x = movement.stamina * 2;
        stamina.sizeDelta = newSize;

        Vector3 rightPos = rightscroll.anchoredPosition;
        rightPos.x = movement.stamina;
        rightscroll.anchoredPosition = rightPos;

        Vector3 leftPos = leftscroll.anchoredPosition;
        leftPos.x = -movement.stamina;
        leftscroll.anchoredPosition = leftPos;

        if (movement.stamina <= 250f)
        {
            midright.SetActive(false);
            midleft.SetActive(false);
        }
        else
        {
            midright.SetActive(true);
            midleft.SetActive(true);
        }
    }
}
