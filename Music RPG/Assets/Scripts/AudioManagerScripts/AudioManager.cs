using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Diagnostics;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private Sound s;

    //private int scene = 0;


    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            Play("TitleScreenTheme");
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            Play("OverworldTheme");
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
        {
            Play("ArenaTheme1");
        }
    }

    private void Update()
    {
        if (PauseMenu.gameIsPaused)
        {
            s.source.volume = s.volume/2;
        }
        else
        {
            s.source.volume = s.volume;
        }
    }

    public void Play(string name)
    {
        s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            UnityEngine.Debug.LogWarning("Sound: " + name + " not found.");
            return;
        }

        s.source.Play();
    }
}
