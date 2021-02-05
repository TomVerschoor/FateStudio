using UnityEngine;

public class BeatManager : MonoBehaviour
{
    //public AudioSource music;
    public float bpm = 120f;
    public static bool beat;

    private Animator[] animators;
    private float beatTime;
    private float beatTimer;
    private float animationSpeed;
    
    void Awake()
    {
        beatTimer = 0.0f;
        beat = true;
        beatTime = 60.0f / bpm;
        animationSpeed = (2.33333f / beatTime) / 2;
        animators = GetComponentsInChildren<Animator>();
        foreach (Animator animator in animators)
        {
            animator.speed = animationSpeed;
        }
    }

    void Update()
    {
        beatTimer += Time.unscaledDeltaTime;
            
        if(beatTimer >= beatTime)
        {
            BeatSwitch();
            //Debug.Log(beatTimer);

            beatTimer -= beatTime;
        }
    }

    private void BeatSwitch()
    {
        if(beat) { beat = false; }
        else { beat = true; }
    }
}
