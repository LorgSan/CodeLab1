using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefsScript : MonoBehaviour
{

    const string MUSIC_VOL_KEY = "musicVolKey";
    private static float musicVolume;

    public static float MusicVolume //property for the soundVolume value
    {
        get 
        {
            musicVolume = PlayerPrefs.GetFloat(MUSIC_VOL_KEY, 20);
            return musicVolume;
        }
        set
        {
            musicVolume = value;
            PlayerPrefs.SetFloat(MUSIC_VOL_KEY, musicVolume);
            //Debug.Log(PlayerPrefs.GetFloat("musicVolKey")); //it returns decibels so it looks weird in the console!
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        MusicVolume = 0.15f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
