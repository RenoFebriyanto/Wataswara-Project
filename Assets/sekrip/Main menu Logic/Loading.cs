using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class Loading : MonoBehaviour
{
    public Image img;

    void Awake()
    {
        StartCoroutine(loads(2));
    }

    IEnumerator loads(int sceneindex)
    {
        AsyncOperation load = SceneManager.LoadSceneAsync(sceneindex);
        while (!load.isDone)
        {
            float progress = Mathf.Clamp01(load.progress/0.9f);
            img.fillAmount = progress;
            yield return null;
        }
    }
}
