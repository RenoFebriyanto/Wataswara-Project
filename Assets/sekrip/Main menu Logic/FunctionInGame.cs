using UnityEngine;

public class FunctionInGame : MonoBehaviour
{
    public GameObject UIcanvas;
    public GameObject PauseCanvas;

    public void Resume()
    {
        UIcanvas.SetActive(true);
        PauseCanvas.SetActive(false);
        Time.timeScale =1;
    }
}
