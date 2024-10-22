using UnityEngine;

public class AudioScript : MonoBehaviour
{
    private GameObject[] MusicObject;

    private void Awake()
    {
        MusicObject = GameObject.FindGameObjectsWithTag("GPMusic");
        if(MusicObject.Length >= 2)
        {
            Destroy(MusicObject[1]);
        }
    }

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        
    }
}
