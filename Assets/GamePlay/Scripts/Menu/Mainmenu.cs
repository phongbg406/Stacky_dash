using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Mainmenu: MonoBehaviour
{
    private bool playerWon = false;
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;
    public GameObject nextlvMenuUI;
    public GameObject loseMenuUI;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void QuitGame()
    {
        //Debug.Log("quit");
        Application.Quit();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPause = false;

    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }
    public void LoadMenu()
    {
        pauseMenuUI.SetActive(false);
        GameIsPause = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !playerWon)
        {
            playerWon = true;
            StartCoroutine(ShowMenuAfterDelay(2f));
        }
    }

    IEnumerator ShowMenuAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);


       // UnityEngine.Debug.Log("Player won!");


        nextlvMenuUI.SetActive(true);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void Losegame()
    {
        
        
            loseMenuUI.SetActive(true);
       

    }

}


