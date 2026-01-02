using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class menufunction : MonoBehaviour
{
 public GameObject loadcanvas;
 public Image loadingbar;
 public GameObject menucanvas;

 public void Startgame()
    {
        menucanvas.SetActive(false);
        loadcanvas.SetActive(true);
        StartCoroutine(loads(2));
    }

 public void quit()
    {
        Application.Quit();
    }
 public void credits()
    {
        SceneManager.LoadScene("Credit scene");
        Musicplayer.instance.SetState(audiostate.credit);
    }
 public void backtomenu()
    {
        SceneManager.LoadScene(0);
        Musicplayer.instance.SetState(audiostate.menu);
    }
    IEnumerator loads(int sceneindex)
{
    AsyncOperation load = SceneManager.LoadSceneAsync(sceneindex);
    load.allowSceneActivation = false;

    while (load.progress < 0.9f)
    {
        loadingbar.fillAmount = load.progress / 0.9f;
        yield return null;
    }
    loadingbar.fillAmount = 1f;
    Musicplayer.instance.SetState(audiostate.ambience);
    load.allowSceneActivation = true;
}
}
