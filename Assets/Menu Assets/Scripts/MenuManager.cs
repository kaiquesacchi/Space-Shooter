using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    public Slider mainVolumeSlider;
    public Slider effectsVolumeSlider;
    public Slider spawnWaitSlider;
    public Slider playerSpeedSlider;

    void Start()
    {
        mainVolumeSlider.value = PlayerPrefs.GetFloat("mainVolume", 1f);
        effectsVolumeSlider.value = PlayerPrefs.GetFloat("effectsVolume", 1f);
        spawnWaitSlider.value = PlayerPrefs.GetFloat("spawnWait", 1.5f);
        playerSpeedSlider.value = PlayerPrefs.GetFloat("playerSpeed", 8f);

    }


    public void StartGame()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    /* Audio Configs */
    public void SetMainVolume(Slider mainVolumeSlider) 
    {
        PlayerPrefs.SetFloat("mainVolume", mainVolumeSlider.value);
    }
    public void SetEffectsVolume(Slider effectsVolumeSlider)
    {
        PlayerPrefs.SetFloat("effectsVolume", effectsVolumeSlider.value);
    }

    /* Gameplay Configs */
    public void SetSpawnWait(Slider spawnWaitSlider)
    {
        PlayerPrefs.SetFloat("spawnWait", spawnWaitSlider.value);
    }

    public void SetPlayerSpeed(Slider playerSpeedSlider)
    {
        PlayerPrefs.SetFloat("playerSpeed", playerSpeedSlider.value);
    }
}
