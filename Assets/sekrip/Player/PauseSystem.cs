using UnityEngine;
using UnityEngine.InputSystem;
public class PauseSystem : MonoBehaviour
{
        [SerializeField]
    private InputActionReference input;
    public GameObject UIcanvas;
    public GameObject PauseCanvas;
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
        UIcanvas.SetActive(false);
        PauseCanvas.SetActive(true);
        Time.timeScale = 0;
    }

}
