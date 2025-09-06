using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class flashlight : MonoBehaviour
{
    public InputActionReference senter;
    public InputActionReference reload;
    public Light spotlight;
    public float Battery;
    private float power;
    public VarInventory baterai;
    private bool ispowered = true;
    public GameObject Bateraibar;
    private Slider slider;

    void OnEnable()
    {
        reload.action.performed += Reload;
        senter.action.performed += FlashOn;
        senter.action.Enable();
        reload.action.Enable();
    }

    void OnDisable()
    {
        reload.action.performed -= Reload;
        senter.action.performed -= FlashOn;
        senter.action.Disable();
        reload.action.Disable();
    }

    void FlashOn(InputAction.CallbackContext context)
    {
        if (context.interaction is UnityEngine.InputSystem.Interactions.TapInteraction)
        {
            ToggleFlashlight();
        }
    }

    void Reload(InputAction.CallbackContext context)
    {
        if (context.interaction is UnityEngine.InputSystem.Interactions.TapInteraction)
        {
            memuat();
        }
    }

    void ToggleFlashlight()
    {
        if (ispowered)
    {
        spotlight.enabled = !spotlight.enabled;
    }
    }
    void Start()
    {
        power = Battery;
        slider = Bateraibar.GetComponent<Slider>();
        slider.maxValue = Battery;
    }

    void memuat()
    {
        if (baterai.value > 0)
        {
            baterai.value -= 1;
            power = Battery;
            ispowered = true;
            spotlight.enabled = true;
        }
    }
    void Update()
    {
        slider.value = power;
        if (spotlight.enabled)
        {
            power -= Time.deltaTime;
        }

        if (power <= 0)
        {
            ispowered = false;
            power = 0;
        }

        if (!ispowered)
        {
            spotlight.enabled = false;
        }
    }
}
