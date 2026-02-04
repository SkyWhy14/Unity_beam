using UnityEngine;

public class SFX_Script : MonoBehaviour
{
    public AudioSource sfxSource;
    public AudioClip[] audioClips;

    void Awake()
    {
        if (sfxSource == null)
            sfxSource = GetComponent<AudioSource>();

        if (sfxSource == null)
            sfxSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlaySFX(int ix)
    {
        if (audioClips == null || audioClips.Length == 0) return;
        if (ix < 0 || ix >= audioClips.Length) return;

        sfxSource.PlayOneShot(audioClips[ix]);
    }


    public void StopSFX()
    {
        if (sfxSource != null)
            sfxSource.Stop();
    }

}
