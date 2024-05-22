using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class IventSounds : MonoBehaviour
{
    public AudioSource mySourse;
    AudioClip myClip;
    // Start is called before the first frame update
    void Start()
    {
        mySourse = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void EventSounds()
    {
        mySourse.PlayOneShot(myClip);
    }
}
