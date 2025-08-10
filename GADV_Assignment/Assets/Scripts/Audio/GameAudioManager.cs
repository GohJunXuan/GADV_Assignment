using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    public AudioClip GameMusic;
    public AudioClip JumpSFX;
    public AudioClip SwordSwingSFX;
    public AudioClip BounceSFX;
    public AudioClip DeathSFX;

    void Start()
    {
        musicSource.clip = GameMusic;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip SFXclip)
    {
        sfxSource.PlayOneShot(SFXclip);
    }
}
