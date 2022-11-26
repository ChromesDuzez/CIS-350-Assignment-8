/* 
 * Zach Wilson
 * Assignment 8
 * This script manages the game states
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    //public references
    public List<GameObject> targets;
    public TextMeshProUGUI scoreBoard;
    public TextMeshProUGUI gameOverScreen;
    public GameObject titleScreen;

    //public values
    public bool b_GameOver;

    //private values
    private float spawnRate = 1.0f;
    private int score;

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        titleScreen.SetActive(false);
        //score = 0;
        b_GameOver = false;
        UpdateScore(0);
        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        while(!b_GameOver)
        {
            //wait for the set spawnRate time
            yield return new WaitForSeconds(spawnRate);

            //now that we have waited, time to spawn a random target from list Targets
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreBoard.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverScreen.gameObject.SetActive(true);
        b_GameOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(b_GameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Start is called before the first frame update
    void Start()
    {
        //score = 0;
        //b_GameOver = false;
        //UpdateScore(0);
        //StartCoroutine(SpawnTarget());
    }
}
