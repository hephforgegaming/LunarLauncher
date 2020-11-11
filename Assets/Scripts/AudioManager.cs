using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer theMixer;
    // Start is called before the first frame update
    void Start()
    {
        
        if(PlayerPrefs.HasKey("MasterVol"))
        {
            theMixer.SetFloat("masterVol", PlayerPrefs.GetFloat("MasterVol"));
        }

        if(PlayerPrefs.HasKey("MusicVol"))
        {
            theMixer.SetFloat("musicVol", PlayerPrefs.GetFloat("MusicVol"));
            
        }

        if(PlayerPrefs.HasKey("SFXVol"))
        {
            theMixer.SetFloat("sfxVol", PlayerPrefs.GetFloat("SFXVol"));
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
