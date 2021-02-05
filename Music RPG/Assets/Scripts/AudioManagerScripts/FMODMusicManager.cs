using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FMODMusicManager : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string music;

    private static FMOD.Studio.EventInstance musicEvent;

    //public static FMODMusicManager instance;

    //void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }

    //    DontDestroyOnLoad(gameObject);
    //}

    void Start()
    {
        musicEvent = FMODUnity.RuntimeManager.CreateInstance(music);

        musicEvent.start();
        musicEvent.release();
    }

    public void Progress(float progressLevel)
    {
        musicEvent.setParameterByName("Progress", progressLevel);
    }

    public void IsPaused(float isPausedLevel)
    {
        musicEvent.setParameterByName("IsPaused", isPausedLevel);
    }

    public void IsChasing(float isChasingLevel)
    {
        musicEvent.setParameterByName("IsChasing", isChasingLevel);
        Debug.Log("Value: " + isChasingLevel);
    }

    private void OnDestroy()
    {
        musicEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public void SetVolumeOptions(float volume)
    {
        musicEvent.setVolume(volume);
    }
}
