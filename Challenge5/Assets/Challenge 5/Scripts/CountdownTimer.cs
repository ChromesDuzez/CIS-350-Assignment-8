/* 
 * Zach Wilson
 * Assignment 8
 * This script manages the countdown timer
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;
    private TextMeshProUGUI timer;
    private GameManagerX gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerX>();
        timer = GetComponent<TextMeshProUGUI>();
        TimerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(TimerOn && gm.isGameActive)
        {
            if(TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                Debug.Log("Time is up!");
                TimeLeft = 0;
                TimerOn = false;
                gm.GameOver();
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timer.text = string.Format("Time Remaining: {0:00} : {1:00}", minutes, seconds);
    }
}
