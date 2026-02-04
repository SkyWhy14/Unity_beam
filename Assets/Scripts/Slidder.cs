using UnityEngine;
using UnityEngine.UI;   

public class Slidder : MonoBehaviour
{
    //ar slider palidzibu pamazina vai palielina skaļumu
    [SerializeField] private Slider volumeSlider; // FIX: Use Slider, not SliderJoint2D

    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(SetVolume);
        volumeSlider.value = AudioListener.volume;
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}
