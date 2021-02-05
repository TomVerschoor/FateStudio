using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu, optionsMenu;

    public GameObject continueButton, quitOptionsButton;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.Confined;
        PlayerPrefs.DeleteKey("playerX");
        PlayerPrefs.DeleteKey("playerY");
        PlayerPrefs.DeleteKey("playerZ");
    }

    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {     
            if (mainMenu.activeSelf)
            {
                SelectContinueButton();
            }
            else if (optionsMenu.activeSelf)
            {
                SelectQuitOptionsButton();
            }        
        }
    }

    public void ContinueGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(PlayerPrefs.GetString("scene", "CutsceneApartment"), LoadSceneMode.Single);
    }

    public void NewGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("IntroVideo", LoadSceneMode.Single);
    }
    
    public void Options()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);

        SelectQuitOptionsButton();
    }

    public void CloseOptions()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);

        SelectContinueButton();
    }

    public void QuitGame()
    {
        Debug.Log("Game has been shut down.");
        Application.Quit();
    }

    private void SelectContinueButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(continueButton);
    }

    private void SelectQuitOptionsButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(quitOptionsButton);
    }
}
