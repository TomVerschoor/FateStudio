using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelchanger : MonoBehaviour {

    public Animator animator;
    public string newscene;

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButton(0))
        {
            FadeToLevel();
        }
    }

    public void FadeToLevel ()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete ()
    { 
        SceneManager.LoadScene(newscene);
    }
}