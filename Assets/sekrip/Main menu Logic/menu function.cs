using UnityEngine;
using UnityEngine.SceneManagement;
public class menufunction : MonoBehaviour
{
 
 public void Startgame()
    {
        SceneManager.LoadScene(1);
        Musicplayer.instance.SetState(audiostate.ambience);
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
}
