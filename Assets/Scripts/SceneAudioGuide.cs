using UnityEngine;

public class SceneAudioGuide : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
    }
}
