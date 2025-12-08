using UnityEngine;

public enum audiostate
{
    menu,
    ambience,
    credit,
    stop
}
public class Musicplayer : MonoBehaviour
{
    public static Musicplayer instance;
    private audiostate state;
    public AudioSource audioSource;
    public AudioClip[] audio;
    private bool isfirst = true;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);   // Destroy the NEW duplicate
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }


        if (isfirst)
        {
            SetState(audiostate.menu);
            isfirst = false;
        }
    }
    public void SetState(audiostate newState)
    {
        state = newState;

        switch (state)
        {
            case audiostate.menu:
                audioSource.clip = audio[0];
                break;

            case audiostate.ambience:
                audioSource.clip = audio[2];
                break;

            case audiostate.credit:
                audioSource.clip = audio[1];
                break;
        }

        audioSource.Play();
    }
}
