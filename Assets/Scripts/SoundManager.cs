using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    
    private StartLevel _startLevel;
    private Finish _finish;
    private PlayerHealth _playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        _startLevel = FindObjectOfType<StartLevel>();
        _finish = FindObjectOfType<Finish>();
        _playerHealth = FindObjectOfType<PlayerHealth>();

        _startLevel.levelStart += PlayMusic;
        _finish.levelFinish += StopMusic;
        _playerHealth.levelFailed += StopMusic;
    }

    private void StopMusic()
    {
        audioSource.Stop();
    }

    private void PlayMusic()
    {
        audioSource.Play();
    }
}
