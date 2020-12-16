using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using UnityEngine.Android;


public class MenuManager : MonoBehaviour
{
    public Slider mainVolumeSlider;
    public Slider effectsVolumeSlider;
    public Slider spawnWaitSlider;
    public Slider playerSpeedSlider;

    public InputField email, password;

    void Start()
    {
        #if PLATFORM_ANDROID
            if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            {
                Permission.RequestUserPermission(Permission.Camera);
            }
        #endif

        mainVolumeSlider.value = PlayerPrefs.GetFloat("mainVolume", 1f);
        effectsVolumeSlider.value = PlayerPrefs.GetFloat("effectsVolume", 1f);
        spawnWaitSlider.value = PlayerPrefs.GetFloat("spawnWait", 1.5f);
        playerSpeedSlider.value = PlayerPrefs.GetFloat("playerSpeed", 8f);
        email.text = PlayerPrefs.GetString("loginEmail", "");
        password.text = PlayerPrefs.GetString("loginPassword", "");
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

    public void DoLogin()
    {
        PlayerPrefs.SetString("loginEmail", email.text);
        PlayerPrefs.SetString("loginPassword", password.text);
    }
}
