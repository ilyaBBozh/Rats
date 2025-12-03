using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public AudioMixerGroup mixer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchActive();
        }
    }

    public void SwitchActive()
    {
        mainMenu.active = !mainMenu.active;

        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void ChangeVolume(float value)
    {
        mixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, value));
    }
}
