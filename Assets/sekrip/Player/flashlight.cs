using UnityEngine;
using UnityEngine.InputSystem;

public class flashlight : MonoBehaviour
{
    public InputActionReference senter;
    public Light spotlight;

    void OnEnable()
    {
        senter.action.performed += FlashOn;
        senter.action.Enable();
    }

    void OnDisable()
    {
        senter.action.performed -= FlashOn;
        senter.action.Disable();
    }

    void FlashOn(InputAction.CallbackContext context)
    {
        if (context.interaction is UnityEngine.InputSystem.Interactions.TapInteraction)
        {
            ToggleFlashlight();
        }
    }

    void ToggleFlashlight()
    {
        spotlight.enabled = !spotlight.enabled;
    }
    void Start()
    {

    }
}
