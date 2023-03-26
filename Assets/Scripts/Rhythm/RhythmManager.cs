using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RhythmManager : MonoBehaviour
{
    [SerializeField] private SongData currentSong;
    [SerializeField] private InputAction performBeatAction;

    private AudioSource SongPlayer;
    private AudioSettings songSettings;

    private float bpm;
    private float crochet;
    private float songPosition;
    private float offset;
    private float lastbeat = 0;
    //private float dspTimeSong;


    private bool bStarted = false;
    private void Awake()
    {
        SongPlayer = GetComponent<AudioSource>(); 
    }

    private void OnEnable()
    {
        performBeatAction.Enable();
        performBeatAction.performed += PerformBeat;
    }

    private void OnDisable()
    {
        performBeatAction.performed-= PerformBeat;
        performBeatAction.Disable();    
    }

    private void Start()
    {
        if (currentSong)
        {
            SongPlayer.clip = currentSong.song;
            bpm = currentSong.bpm;
            crochet = 60 / bpm;
        }
    }

    private void Update()
    {
        if (!bStarted)
            return;

        songPosition = (float)AudioSettings.dspTime * SongPlayer.pitch - offset;

        if(songPosition> lastbeat + crochet)
        {
            lastbeat += crochet;
        }

    }

    private void PerformBeat(InputAction.CallbackContext context)
    {
        if(!currentSong) return;

        if (!bStarted)
        {
            SongPlayer.Play();
            bStarted = true;
            return;
        }

        songPosition = (float)AudioSettings.dspTime * SongPlayer.pitch - offset;
        
        float properBeatTime = lastbeat + crochet;

        Debug.LogError("Next beat :" + properBeatTime);
        Debug.LogError("Current beat :" + songPosition);
        if (songPosition > properBeatTime) 
        {
            //perform beat!
            Debug.Log("ProperBeatPerformed");

        }


    }
}
