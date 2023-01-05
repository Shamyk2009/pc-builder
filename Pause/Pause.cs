using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    private static bool pause = false;

    public GameObject panel;
    public Button resumeButton;
    public Button restartButton;
    public Button mainMenuButton;
   

	void Start () 
    {
        panel.transform.SetAsLastSibling();
        pauseOff();
        resumeButton.onClick.AddListener(resume);
        restartButton.onClick.AddListener(restart);
        mainMenuButton.onClick.AddListener(exitToMenu);
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause) pauseOff();
            else pauseOn();
        }
	}

    void pauseOff()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        panel.SetActive(false);
        Time.timeScale = 1;
        pause = false;
        foreach (GameObject ob in FindObjectsOfType<GameObject>())
        {
            if (ob.GetComponent<AudioSource>())
                ob.GetComponent<AudioSource>().mute = false;
        }
    }

    void pauseOn()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        panel.SetActive(true);
        pause = true;

        foreach (GameObject ob in FindObjectsOfType<GameObject>())
        {
            if (ob.GetComponent<AudioSource>())
                ob.GetComponent<AudioSource>().mute = false;
        }
    }
    public void resume()
    {
        pauseOff();
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void exitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public static bool isPaused()
    {
        return pause;
    }
}
