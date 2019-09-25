using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Manager : MonoBehaviour
{
    #region Player prefs
    private const string MUSIC_VOLUME_PREF = "music-volume";
    private const string RESOLUTION_PREF = "resolution";
    private const string FULL_SCREEN_PREF = "fullScreen";
    private const string MOUSE_SENSITIVITY_PREF = "MouseSensitivity";
    private const string CINEMATICS_PREF = "cinematics";
    #endregion

    #region Ref to data
    public Slider musicSlider;
    public Toggle fullScreenToggle;
    public Slider sensitivitySlider;
    public Slider cinematicsSlider;
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;
    #endregion

    #region Ref to manager
    public Button playButton, settingsButton, exitButton, newGameButton, backButton, yesButton, noButton;
    public Canvas mainCanvas, playCanvas, settingsCanvas, exitCanvas;


    #endregion
    // Start is called before the first frame update
    void Start()
    {
        playButton = playButton.GetComponent<Button>();
        settingsButton = settingsButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();
        newGameButton = newGameButton.GetComponent<Button>();
        backButton = backButton.GetComponent<Button>();
        yesButton = yesButton.GetComponent<Button>();
        noButton = noButton.GetComponent<Button>();

        mainCanvas = mainCanvas.GetComponent<Canvas>();
        playCanvas = playCanvas.GetComponent<Canvas>();
        settingsCanvas = settingsCanvas.GetComponent<Canvas>();
        exitCanvas = exitCanvas.GetComponent<Canvas>();

        musicSlider.value = PlayerPrefs.GetFloat(MUSIC_VOLUME_PREF, 1);
        sensitivitySlider.value = PlayerPrefs.GetFloat(MOUSE_SENSITIVITY_PREF, 1);
        cinematicsSlider.value = PlayerPrefs.GetFloat(CINEMATICS_PREF, 1);
        fullScreenToggle.isOn = GetBoolPref(FULL_SCREEN_PREF);

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for(int i=0; i< resolutions.Length; i++ )
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        mainCanvas.enabled = true;
        playCanvas.enabled = false;
        settingsCanvas.enabled = false;
        exitCanvas.enabled = false;
    }

    #region  Canvas switch
    public void ButtonPlay()
    {
        mainCanvas.enabled = false;
        playCanvas.enabled = true;
        settingsCanvas.enabled = false;
        exitCanvas.enabled = false;
    }
    public void ButtonNewGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ButtonSettings()
    {
        mainCanvas.enabled = false;
        playCanvas.enabled = false;
        settingsCanvas.enabled = true;
        exitCanvas.enabled = false;
    }
    public void ButtonExit()
    {
        mainCanvas.enabled = false;
        playCanvas.enabled = false;
        settingsCanvas.enabled = false;
        exitCanvas.enabled = true;
    }
    public void ButtonYes()
    {
        Application.Quit();
    }
    public void ButtonNO()
    {
        mainCanvas.enabled = true;
        playCanvas.enabled = false;
        settingsCanvas.enabled = false;
        exitCanvas.enabled = false;
    }
    public void ButtonBack1()
    {
        mainCanvas.enabled = true;
        playCanvas.enabled = false;
        settingsCanvas.enabled = false;
        exitCanvas.enabled = false;
    }
    public void SetFullScreen(bool FullScreen)
    {
        Screen.fullScreen = FullScreen;
        OnToggleFullScreen(FullScreen);
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }


    #endregion
    #region Save
    private void SetPref(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }
    private void SetPref(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }
    private void SetPref(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }
    private void SetPref(string key, bool value)
    {
        PlayerPrefs.SetInt(key, Convert.ToInt32(value));
    }
    private bool GetBoolPref(string key, bool defaultValue=true)
    {
        return Convert.ToBoolean(PlayerPrefs.GetInt(key, Convert.ToInt32(defaultValue)));
    }
    #endregion
    #region Sliders,toggle,dropdown
    public void OnChangeMusicVolume(Single value)
    {
        SetPref(MUSIC_VOLUME_PREF, value);
    }
    public void OnChangeSensitivity(Single value)
    {
        SetPref(MOUSE_SENSITIVITY_PREF, value);
    }
    public void OnChangeCinematics(Single value)
    {
        SetPref(CINEMATICS_PREF, value);
    }
    public void OnToggleFullScreen(bool state)
    {
        SetPref(FULL_SCREEN_PREF, state);
    }
    public void OnDropResolution(Dropdown value)
    {
        SetPref(RESOLUTION_PREF, value);
    }

    #endregion



    // Update is called once per frame
    void Update()
    {
        
    }
}
