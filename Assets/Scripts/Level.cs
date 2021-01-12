using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    int currentSceneIndex;
    [SerializeField] float timeToWait = 4f;
    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(LoadStartScreen());
        }
    }

    IEnumerator LoadStartScreen()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadMainMenu();
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("1StartScreen1");
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("XGameOverScreen");
    }

    public void LoadOptionScreen()
    {
        SceneManager.LoadScene("XOptionScreen");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                    Application.Quit();
        #endif
    }
}
