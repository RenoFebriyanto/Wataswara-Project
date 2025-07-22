using UnityEngine;

[CreateAssetMenu(fileName = "New-Sound", menuName = "ScriptableObjects/Sound-Event")]
public class SoundEvent : ScriptableObject
{
    public AudioClip[] sound;
}
