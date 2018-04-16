using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    enum GameStates
    {
        Playing,
        Paused,
        GameOver
    }

    private GameStates CurrentGameState;
    public float scrollSpeed;
    public float score;
    private float hiscore;
    bool hasSaved = false;


    // Use this for initialization
    void Start()
    {
        CurrentGameState = GameStates.Playing;
        score = 0.0f;
        hiscore = LoadScores();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("hiscore" + hiscore);
  
        switch (CurrentGameState)
        {
            case GameStates.Playing:
                Time.timeScale = 1;
                Playing();
                break;

            case GameStates.Paused:
                Time.timeScale = 0;
                Paused();
                break;

            case GameStates.GameOver:
                Time.timeScale = 0;
                GameOver();
                break;
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void Playing()
    {
        scrollSpeed += 0.003f;
        score += 1 * Time.deltaTime;

        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");
        foreach (GameObject go in platforms)
        {
            go.GetComponent<PlatformMovement>().scrollSpeed = scrollSpeed;
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            CurrentGameState = GameStates.GameOver;
        }
    }

    private void Paused()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CurrentGameState = GameStates.Playing;
        }
    }

    private void GameOver()
    {
        if (hiscore < score)
        {
            if (!hasSaved)
            {
                SaveScores();
                hasSaved = true;
            }
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void SaveScores()
    {
        PlayerPrefs.SetFloat("Highest Score", score);
    }

    public float LoadScores()
    {
        return PlayerPrefs.GetFloat("Highest Score");
    }
}
