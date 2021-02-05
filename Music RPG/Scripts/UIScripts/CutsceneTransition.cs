using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneTransition : MonoBehaviour {
    
    public UnityEngine.Animator timeline;
    public string sceneName;

    void Update(){
    
        if(Input.GetKeyDown(KeyCode.Space)){
            StartCoroutine(LoadScene());
        }
    }
    
    IEnumerator LoadScene()
    {

        timeline.SetTrigger("End");
        yield return new WaitForSeconds(1.5F);
        SceneManager.LoadScene(sceneName);
    }
}