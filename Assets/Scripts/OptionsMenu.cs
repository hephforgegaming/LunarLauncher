using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public Toggle fullScreenTog, vsyncTog;

    public Text resolutionLabel;
    public ResItem[] resolutions;

    private int selectedResolution;

    public AudioMixer theMixer;

    public Slider masterSlider, musicSlider, sfxSlider;

    public Text masterLabel, musicLabel, sfxLabel;

    public AudioSource sfxLoop;

    // Start is called before the first frame update
    void Start()
    {
        fullScreenTog.isOn = Screen.fullScreen;

        if(QualitySettings.vSyncCount == 0)
        {
            vsyncTog.isOn = false;
        } else {
            vsyncTog.isOn = true;
        }

        // Search for Resolution
        bool foundRes = false;
        for(int i = 0; i < resolutions.Length; i++)
        {
            if(Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;

                selectedResolution = i;
                
                UpdateResLabel();
            }
        }

        if(!foundRes)
        {
            resolutionLabel.text = Screen.width.ToString() + " x " + Screen.height.ToString();
        }

        if(PlayerPrefs.HasKey("MasterVol"))
        {
            theMixer.SetFloat("masterVol", PlayerPrefs.GetFloat("MasterVol"));
            masterSlider.value = PlayerPrefs.GetFloat("MasterVol");
        }

        if(PlayerPrefs.HasKey("MusicVol"))
        {
            theMixer.SetFloat("musicVol", PlayerPrefs.GetFloat("MusicVol"));
            musicSlider.value = PlayerPrefs.GetFloat("MusicVol");
            
        }

        if(PlayerPrefs.HasKey("SFXVol"))
        {
            theMixer.SetFloat("sfxVol", PlayerPrefs.GetFloat("SFXVol"));
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVol");
            
        }
            
            masterLabel.text = (masterSlider.value + 80).ToString();
            musicLabel.text = (musicSlider.value + 80).ToString();
            sfxLabel.text = (sfxSlider.value + 80).ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResLeft()
    {
        selectedResolution--;
        if(selectedResolution < 0)
        {
            selectedResolution = 0;
        }
        UpdateResLabel();        
    }

    public void ResRight()
    {
        selectedResolution++;
        if(selectedResolution > resolutions.Length - 1)
        {
            selectedResolution = resolutions.Length - 1;
        }
        
        UpdateResLabel();
    }

    public void UpdateResLabel()
    {
        resolutionLabel.text = resolutions[selectedResolution].horizontal.ToString() + " x " + resolutions[selectedResolution].vertical.ToString();
    }   
    public void ApplyGraphics()
    {
        // Apply Full Screen
        //Screen.fullScreen = fullScreenTog.isOn;
        
        // Apply Vsync
        if(vsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        } else {
            QualitySettings.vSyncCount = 0;
        }

        // Set Resolution
        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, fullScreenTog.isOn);
    }

    public void SetMasterVolume()
    {
        masterLabel.text = (masterSlider.value + 80).ToString();
        theMixer.SetFloat("masterVol", masterSlider.value);
        PlayerPrefs.SetFloat("MasterVol",masterSlider.value);
    }

    public void setMusicVolume()
    {
        musicLabel.text = (musicSlider.value + 80).ToString();
        theMixer.SetFloat("musicVol", musicSlider.value);
        PlayerPrefs.SetFloat("MusicVol",musicSlider.value);

    }

    public void setSFXVolume()
    {
        sfxLabel.text = (sfxSlider.value + 80).ToString();
        theMixer.SetFloat("sfxVol", sfxSlider.value);
        PlayerPrefs.SetFloat("SFXVol",sfxSlider.value);

    }

    public void PlaySFXLoop()
    {
        sfxLoop.Play();
    }

    public void StopSFXLoop()
    {
        sfxLoop.Stop();
    }

        public void ResetProgress()
    {
        PlayerPrefs.SetInt("shots", 0);
        for(int i = 0; i < 11; i++)
        {
            PlayerPrefs.SetInt("Stage" + i, 0);
            PlayerPrefs.SetInt("Stage" + i + "-completed", 0);
            PlayerPrefs.SetInt("Stage" + i + "-shots", 0);
        }
        
        //PlayerPrefs.SetInt("Stage2", 0);
        //PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("All game values reset");
    }
}

[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}
