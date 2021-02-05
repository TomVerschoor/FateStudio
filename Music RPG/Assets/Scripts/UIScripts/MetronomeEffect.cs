using UnityEngine;
using UnityEngine.UI;

public class MetronomeEffect : MonoBehaviour
{
    public Sprite crystalOnBeat;
    public Sprite crystalOffBeat;

    void Update()
    {
        if (BeatManager.beat)
        {
            gameObject.GetComponent<Image>().sprite = crystalOnBeat;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = crystalOffBeat;
        }
    }
}
