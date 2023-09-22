using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
   [SerializeField] public AudioMixer myMixer;
   [SerializeField] public Slider soundSlider;
   [SerializeField] public Slider musicSlider;

   public void Start()
   {
      if (PlayerPrefs.HasKey("musicVolume"))
      {
         LoadVolume();
      
      }
      else
      {

         SetMusicVolume();
         SetSoundVolume();
      }
   }
   
   public void SetMusicVolume()
   {
      float volume = musicSlider.value;
      myMixer.SetFloat("music", Mathf.Log10(volume)*20);
      PlayerPrefs.SetFloat("musicVolume", volume);

   }

   public void SetSoundVolume()
   {
      

   }

   public void LoadVolume()
   {
      musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
      soundSlider.value = PlayerPrefs.GetFloat("soundVolume");

      SetMusicVolume();
      SetSoundVolume();
   }
}
