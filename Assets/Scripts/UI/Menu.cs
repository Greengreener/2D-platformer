using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private float masterVol;
    public AudioMixer masterAudio;
    public bool muted;
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
}