
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using System.Collections;
using Unity.Cinemachine;
using Unity.VisualScripting;
public class doorcontroller : MonoBehaviour
{
    public buttonholder key;
    public Image img;
    public TextMeshProUGUI Text;

    [SerializeField]
    private InputActionReference input;
    private bool playerInRange = false;
    private bool isswitch = false;
    public CinemachineCamera Main;
    public CinemachineCamera head;
    private Animator anim;
    public Movement move;
    public MeshCollider collide;
    public CameraHandler cam;
    public Transform doorpov;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            img.sprite = key.icon;
            Text.SetText(key.Command);
            Text.gameObject.SetActive(true);
            img.gameObject.SetActive(true);
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Text.gameObject.SetActive(false);
            img.gameObject.SetActive(false);
            playerInRange = false;
            anim.SetBool("entering", false);
        }
    }

    void Start()
    {
        input.action.Enable();
        anim = GetComponent<Animator>();
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
        if (playerInRange)
        {
            StartCoroutine(Openingdoor());
        }
    }

    private void Update()
    {

    }


    IEnumerator Openingdoor()
    {
        move.anim.SetFloat("MoveSpeed",1);
        move.enabled = false;
        collide.enabled = false;
        cam.enabled = false;
        isswitch = true;
        Main.Priority.Value = 0;
        head.LookAt = doorpov;
        head.Priority.Value = 1;
        yield return new WaitForSeconds(1f);
        anim.SetBool("entering", true);
        yield return new WaitForSeconds(1.5f);
        Main.Priority.Value = 1;
        head.Priority.Value = 0;
        yield return new WaitForSeconds(1f);
        isswitch = false;
        cam.enabled = true;
        move.enabled = true;
        collide.enabled = true;

    }
}
