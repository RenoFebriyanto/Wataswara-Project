using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class RunningText : MonoBehaviour
{
    public InputActionReference input;
    public SceneScriptable Scene;
    public TextMeshProUGUI dialoguetext;
    public TextMeshProUGUI nama;
    private bool inrange;
    public GameObject GameCanvas;
    public GameObject TextCanvas;
    public buttonholder button;
    public Image img;
    public TextMeshProUGUI tutorial;
    public Movement playermovement;
    public CameraHandler cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator Running()
    {
        input.action.Disable();
        GameCanvas.SetActive(false);
        TextCanvas.SetActive(true);
        playermovement.enabled = false;
        cam.enabled = false;
        for (int i = 0; i < Scene.Dialog.Count; i++)
        {
            nama.text = Scene.Dialog[i].Speaker;
            String conversiation = Scene.Dialog[i].Dialogue;
            dialoguetext.text = "";
            for (int j = 0; j < conversiation.Length; j++)
            {
                dialoguetext.text += conversiation[j];
            yield return new WaitForSeconds(0.03f);
            }
            yield return new WaitForSeconds(1f);
        }
        TextCanvas.SetActive(false);
        GameCanvas.SetActive(true);
        playermovement.enabled = true;
        input.action.Enable();
        cam.enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inrange = true;
            img.sprite = button.icon;
            tutorial.SetText(button.Command);
            img.gameObject.SetActive(true);
            tutorial.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inrange = false;
            img.sprite = button.icon;
            tutorial.SetText("");
            img.gameObject.SetActive(false);
            tutorial.gameObject.SetActive(false);
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
        if (inrange)
        {
            StartCoroutine(Running());
        }
    }
}
