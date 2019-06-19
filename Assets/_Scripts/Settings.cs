using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{

    public static bool GamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        //gameObject.SetActive(true);
        //GamePaused = true;
        //Time.timeScale = 0f;

        if (GamePaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }

    }

    void Resume()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Pause()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }
}
