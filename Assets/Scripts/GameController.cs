using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject tapToStart;
    public GameObject scoreText;
    //public PlayerMovement playerMovement;
    // Start is called before the first frame update
    private void Start()
    {
        gameOverPanel.SetActive(false);
        //playerMovement.StartMusic();
        PauseGame();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartGame();
            tapToStart.SetActive(false);
        }
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        scoreText.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void StartGame()
    {
        Time.timeScale = 1f;
    }
}
