using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jumpscare : MonoBehaviour
{
    private string currentSceneName;
    public GameObject deathcanvas;
    public AudioSource source;
    public AudioClip clip;
    void Start()
    {
    currentSceneName = SceneManager.GetActiveScene().name;
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
        source.clip = clip;
        source.Play();
        StartCoroutine(death());
        }
    }

    IEnumerator death()
    {
        deathcanvas.SetActive(true);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(currentSceneName);
    }
}
