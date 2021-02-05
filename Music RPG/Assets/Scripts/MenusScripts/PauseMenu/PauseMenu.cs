using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI, resumeButton;

    public FMODMusicManager pauseMusic;

    void Start()
    {
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuUI.activeSelf)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Resume();
            }
            else
            {
                Cursor.lockState = CursorLockMode.Confined;
                Pause();
            }
        }

        if (pauseMenuUI.activeSelf)
        {
            if(EventSystem.current.currentSelectedGameObject == null)
            {
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(resumeButton);
            }
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        gameIsPaused = true;

        Time.timeScale = 0f;

        pauseMusic.IsPaused(1f);
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        gameIsPaused = false;

        Time.timeScale = 1f;

        pauseMusic.IsPaused(0f);
    }

    public void LoadMainMenu()
    {
        pauseMenuUI.SetActive(false);
        gameIsPaused = false;

        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScreen");
    }

    public void QuitGame()
    {
        UnityEngine.Debug.Log("Quitting Application...");
        Application.Quit();

        //Other option to Quit the Game.

        //#if UNITY_EDITOR
        //        UnityEditor.EditorApplication.isPlaying = false;
        //#else
        //        Application.Quit();
        //#endif
    }
}
