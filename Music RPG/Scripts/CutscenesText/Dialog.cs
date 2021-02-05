using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    public GameObject continueButton;

    [TextArea(3, 10)]
    public string[] sentences;

    public string newScene;

    private int index;
    public float typingSpeed;

    void Start()
    {
        StartCoroutine(Type());
    }

    void Update()
    {
        if (dialogueText.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
        Cursor.lockState = CursorLockMode.Confined;
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1) 
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Type());
        }
        else
        {
            dialogueText.text = "";
            continueButton.SetActive(false);
            SceneManager.LoadScene(newScene, LoadSceneMode.Single);
        }
    }

    void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
