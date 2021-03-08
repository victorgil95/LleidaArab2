﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LAAudio : MonoBehaviour
{
    public Button audioButton;
    public Slider audioProgress;

    public AudioSource audioSource;

    private void Awake()
    {
        audioSource.Stop();
        audioButton.onClick.AddListener(AudioButtonOnClick);
        audioProgress.onValueChanged.AddListener(delegate { OnProgressValueChanged(); });
    }

    public void AudioButtonOnClick()
    {
        if (audioSource)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            else
            {
                audioSource.Play();
            }
        }
    }

    public void OnProgressValueChanged()
    {
        if (audioProgress.normalizedValue > 0 && audioProgress.normalizedValue < 1)
        {
            audioSource.time = audioProgress.normalizedValue * audioSource.clip.length;
        }
        else
            audioSource.time = 1;

        Debug.Log("Audio progress = " + audioSource.time);
    }
    
}
