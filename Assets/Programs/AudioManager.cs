 using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-----Audio Source-----")]
    [SerializeField] AudioSource Sound;
    [SerializeField] AudioSource Music;

    [Header("-----SFX-----")]
    public AudioClip smg;
    public AudioClip pistol;
    public AudioClip rifle;
    public AudioClip hit;
    public AudioClip heal;

    public void PlaySFX(AudioClip clip){
        Sound.PlayOneShot(clip);
    }
}
