using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ObjText : MonoBehaviour
{
    public SceneScriptable Scene;
    public TextMeshProUGUI nama;
    public TextMeshProUGUI dialoguetext;
    public InputActionReference input;
    private bool inrange;
    public buttonholder button;
    public Image img;
    public TextMeshProUGUI tutorial;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator running()
    {
        nama.gameObject.SetActive(true);
        dialoguetext.gameObject.SetActive(true);
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
        nama.gameObject.SetActive(false);
        dialoguetext.gameObject.SetActive(false);
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
                StartCoroutine(running());
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inrange =true;
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
            inrange =false;
             img.gameObject.SetActive(false);
            tutorial.gameObject.SetActive(false);
        }
    }
}
