using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    public static bool OverlayOn;

    public GameObject tutorialOverlay, resumeButton;
    public float waitTime = 0.2f;

    //public FMODMusicManager pauseMusic;

    private IEnumerator coroutine;

    void Start()
    {
        OverlayOn = false;
        tutorialOverlay.SetActive(false);
        coroutine = WaitBeforeTimeScaleStop(waitTime);
        StartCoroutine(coroutine);
    }
    void Update()
    {
        if (tutorialOverlay.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OverlayOn = false;
                Destroy(gameObject);
            }
            if (EventSystem.current.currentSelectedGameObject == null)
                EventSystem.current.SetSelectedGameObject(resumeButton);
        }
    }

    private IEnumerator WaitBeforeTimeScaleStop(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        tutorialOverlay.SetActive(true);
        OverlayOn = true;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        tutorialOverlay.SetActive(false);
        OverlayOn = false;
        Time.timeScale = 1f;
        Destroy(gameObject);

        //pauseMusic.IsPaused(0f);
    }

    // if (!PauseMenu.gameIsPaused && !TutorialController.OverlayOn) in enemycontroller and playercontroller
}
