using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class itempickup : MonoBehaviour
{
    public InputActionReference input;
    public buttonholder icon;
    public Image img;
    public TextMeshProUGUI text;
    private bool inrange;
    private GameObject item;
    private itemIdentifier detail;
    public VarInventory[] inventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            img.sprite = icon.icon;
            text.SetText(icon.Command);
            text.gameObject.SetActive(true);
            img.gameObject.SetActive(true);
            item = other.gameObject;
            detail = item.GetComponent<itemIdentifier>();
            inrange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            text.gameObject.SetActive(false);
            img.gameObject.SetActive(false);
            inrange = false;
            item = null;
            detail = null;
        }
    }
    void OnEnable()
    {
        input.action.performed += singletap;
        input.action.Enable();
    }

    void OnDisable()
    {
        input.action.performed -= singletap;
        input.action.Disable();
    }
    void singletap(InputAction.CallbackContext context)
    {
        Debug.Log("tap tap");
        Debug.Log(item);
        if (inrange && item != null)
        {
            if (detail.item.Name == "Battery")
            {
                inventory[0].value += 1;
                item.SetActive(false);
                text.gameObject.SetActive(false);
                img.gameObject.SetActive(false);
                inrange = false;
                item = null;
                detail = null;
            }
        }
    }
}
