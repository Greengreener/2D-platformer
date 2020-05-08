using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private float masterVol;
    public AudioMixer masterAudio;
    public bool muted;
    public bool isFullScreen;
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    public void ChangeMaster(float volume)
    {
        masterVol = volume;
        if (!muted)
        {
            masterAudio.SetFloat("mastervol", volume);
        }
    }
    public void ChangeMusic(float volume)
    {
        if (!muted)
        {
            masterAudio.SetFloat("musicvol", volume);
        }
    }
    public void ChangeSounds(float volume)
    {
        if (!muted)
        { 
            masterAudio.SetFloat("soundvol", volume);
        }
    }
    public void ToggleMute(bool isMuted)
    {
        muted = isMuted;
        if(isMuted)
        {
            masterAudio.GetFloat("mastervol", out masterVol);
            masterAudio.SetFloat("mastervol", -80);
        }
        else
        {
            masterAudio.SetFloat("mastervol", masterVol);
        }
    }
    public void Quality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public Resolution[] resolutions;
    public Dropdown resolution;
    private void Start()
    {
        resolutions = Screen.resolutions;
        resolution.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolution.AddOptions(options);
        resolution.value = currentResolutionIndex;
        resolution.RefreshShownValue();
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
}