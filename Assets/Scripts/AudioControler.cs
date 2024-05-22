using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControler : MonoBehaviour
{
    public Slider slider;
    public AudioClip clip;
    public AudioSource audio;
    public GameObject buttonAudio;
    public Sprite on;
    public Sprite off;


    // Start is called before the first frame update
    void Start()
    {
        audio.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
        audio.volume = slider.value;
        
    }

    public void onOffAudio()
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            buttonAudio.GetComponent<Image>().sprite = off;
        }
        else
        {
            AudioListener.volume = 1;
            buttonAudio.GetComponent<Image>().sprite = on;
        }
    }
    public void PlaySound()
    {
        
    }
}
