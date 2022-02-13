using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioScript : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetVol (float sliderValue)
    {
        //Mathf.Log10 is in here cause after googling I gathered that AudioMixer uses logarithmic scale rather than linear, so we conveted it so the slider will work popreply
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue)*20); //we're just getting the exposed Parameter of such name and put this value into it
        PrefsScript.MusicVolume = Mathf.Log10(sliderValue)*20; //I've tried to set this thing through the mixer.GetFloat but it got too complicated and weird
        //it needed a value and returned bool, googling confused me even more and when I tried their methods it didn't let me use return and got me a mistake so I gave up
        // will ask this in a class if we're gonna do the audiosource attachment in here
    }
}

