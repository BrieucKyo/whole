﻿using System.Collections;
using UnityEngine;

public class VoiceoverManager : Singleton<VoiceoverManager>
{
    private AudioSource audioSource;
    private AudioClip audioClip;
    private string path;
    private string audioName;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        path = "file://" + Application.streamingAssetsPath + "/Audio/Voiceover/";
    }

    public void PlayVoiceover(string actionName)
    {
        StartCoroutine(LoadAudio(actionName));
    }
    
    private WWW GetAudioFromFile(string path, string fileName)
    {
        string audioToLoad = path + fileName;
        WWW request = new WWW(audioToLoad);
        return request;
    }

    private IEnumerator LoadAudio(string actionName)
    {
        audioName = actionName + ".wav";
        
        WWW request = GetAudioFromFile(path, audioName);
        yield return request;
        
        audioClip = request.GetAudioClip(false, true, AudioType.WAV);
        audioClip.name = audioName;
        
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public bool IsPlaying()
    {
        return audioSource.isPlaying;
    }
}
