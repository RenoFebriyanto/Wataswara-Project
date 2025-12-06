using UnityEngine;
using UnityEngine.SceneManagement;
public class menufunction : MonoBehaviour
{
 
 public void Startgame()
    {
        SceneManager.LoadScene(1);
    }

 public void quit()
    {
        Application.Quit();
    }
 public void credits()
    {
        SceneManager.LoadScene("Credit scene");
    }
 public void backtomenu()
    {
        SceneManager.LoadScene(0);
    }
}
