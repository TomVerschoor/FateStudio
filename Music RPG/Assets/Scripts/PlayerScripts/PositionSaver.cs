using UnityEngine;

class PositionSaver
{
    // Start is called before the first frame update
    /*
    void Start()
    {
        gameObject.SetActive(false);
        gameObject.transform.position = new Vector3(PlayerPrefs.GetFloat("playerX", gameObject.transform.position.x), PlayerPrefs.GetFloat("playerY", gameObject.transform.position.y), PlayerPrefs.GetFloat("playerZ", gameObject.transform.position.z));
        gameObject.SetActive(true);
        Debug.Log("X loaded at: " + PlayerPrefs.GetFloat("playerX", 0));
        Debug.Log("Y loaded at: " + PlayerPrefs.GetFloat("playerY", 0));
        Debug.Log("Z loaded at: " + PlayerPrefs.GetFloat("playerZ", 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        PlayerPrefs.SetFloat("playerX", gameObject.transform.position.x);
        Debug.Log("X saved at: " + gameObject.transform.position.x);
        PlayerPrefs.SetFloat("playerY", gameObject.transform.position.y);
        Debug.Log("Y saved at: " + gameObject.transform.position.y);
        PlayerPrefs.SetFloat("playerZ", gameObject.transform.position.z);
        Debug.Log("Z saved at: " + gameObject.transform.position.z);
    }
    */

    private GameObject gameObject;

    public PositionSaver(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }

    public void LoadPosition()
    {
        gameObject.SetActive(false);
        gameObject.transform.position = new Vector3(PlayerPrefs.GetFloat("playerX", gameObject.transform.position.x), PlayerPrefs.GetFloat("playerY", gameObject.transform.position.y), PlayerPrefs.GetFloat("playerZ", gameObject.transform.position.z));
        gameObject.SetActive(true);
        Debug.Log("X loaded at: " + PlayerPrefs.GetFloat("playerX", 0));
        Debug.Log("Y loaded at: " + PlayerPrefs.GetFloat("playerY", 0));
        Debug.Log("Z loaded at: " + PlayerPrefs.GetFloat("playerZ", 0));
    }
    
    public void SavePosition()
    {
        PlayerPrefs.SetFloat("playerX", gameObject.transform.position.x);
        Debug.Log("X saved at: " + gameObject.transform.position.x);
        PlayerPrefs.SetFloat("playerY", gameObject.transform.position.y);
        Debug.Log("Y saved at: " + gameObject.transform.position.y);
        PlayerPrefs.SetFloat("playerZ", gameObject.transform.position.z);
        Debug.Log("Z saved at: " + gameObject.transform.position.z);
    }
}
