using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class HoverBg : MonoBehaviour
{
    public Image bghighlight;

    private Vector3 bgdefaultpos;
    private GraphicRaycaster raycaster;
    private EventSystem eventSystem;

    void Awake()
    {
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
            if (result.gameObject.CompareTag("Hoverable"))
            {
                TextMeshProUGUI hoveredText = result.gameObject.GetComponent<TextMeshProUGUI>();

                if (hoveredText != null)
                    bghighlight.rectTransform.position = hoveredText.rectTransform.position;

                hovered = true;
                break;
            }
        }

        if (!hovered)
        {
            bghighlight.rectTransform.position = bgdefaultpos;
        }
    }
}
