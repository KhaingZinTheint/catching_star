using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------Audio Source---------")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    [Header("--------Audio Clip-------")]
    public AudioClip background;
    public AudioClip star;
    public AudioClip bomb;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    // Method to stop the background music
    public void StopBackgroundMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }
}


