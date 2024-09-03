using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreLogic : MonoBehaviour
{
    public int[] highScore = new int[5]; 
    public int currentRound;
    public int[] lowScore;

    private bool scoreCheck = false;
    // Update is called once per frame

    private void Start()
    {
        /*for (int i = 0; i < highScore.Length; i++)
        {
            Debug.Log("The value at Array index: " + i + " " +highScore[i]); 
        }*/
    }
    void Update()
    {
        if (Enemies.playerDead == true && scoreCheck == false)
        {
            CheckNewScore();
        }

    }

    public void CheckNewScore()
    {
        scoreCheck = true;
        currentRound = SpawnEnemies.currentRound;

        if (highScore[4] > currentRound)
        {
            Debug.Log("The round you got to wasnt high enough to get into the highscores you loser, git gud");
            return;
        }

        for (int i = 0; i < highScore.Length; i++)
        {
            if (highScore[i] < currentRound)
            {
                highScore[i] = currentRound;
                Debug.Log("The value at Array index: " + i + " is higher so your current score: " + currentRound + " will be entered into this array index!");
                Debug.Log("the value at the Index " + i + " is " + highScore[i]);
                return;
            }
            else
            {
                Debug.Log("The value at Array index: " + i + " is  less than or equal to " + currentRound + " checking the next index...");
            }

        }

        
    }

}
