using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class HoverBg : MonoBehaviour
{
    public Image bghighlight;

    private TextMeshProUGUI text;
    private Vector3 bgdefaultpos;
    private GraphicRaycaster raycaster;
    private EventSystem eventSystem;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        bgdefaultpos = bghighlight.rectTransform.position;

        raycaster = GetComponentInParent<Canvas>().GetComponent<GraphicRaycaster>();
        eventSystem = EventSystem.current;
    }

    void Update()
    {
        PointerEventData pointer = new PointerEventData(eventSystem);
        pointer.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(pointer, results);

        bool hovered = false;

        foreach (RaycastResult result in results)
        {
            if (result.gameObject == gameObject)
            {
                hovered = true;
                break;
            }
        }

        if (hovered)
        {
            bghighlight.rectTransform.position = text.rectTransform.position;
        }
        else
        {
            bghighlight.rectTransform.position = bgdefaultpos;
        }
    }
}
