/* 
 * Zach Wilson
 * Assignment 8
 * This script manages the difficulty buttons
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    //public values
    public int difficulty;

    //private references
    private Button button;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        //get the GameManager
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        //get the button the script is attached to
        button = GetComponent<Button>();

        button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty()
    {
        Debug.Log("[DifficultyButton.cs] - " + gameObject.name + " was clicked.");
        gm.StartGame(difficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
