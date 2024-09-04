using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HighscoreLogic : MonoBehaviour
{

    public int[] highScore = new int[5]; 
    public int currentRound;
    public int[] lowScore;

    private bool scoreCheck = false;
    public static bool achievedHighScore { get; private set; }
    // Update is called once per frame


    private void Start()
    {
        achievedHighScore = false;
        highScore[0] = 100;
        highScore[1] = 50; 
        highScore[2] = 10;
        highScore[3] = 0;
        highScore[4] = 0;
    }
    void Update()
    {
        if (Enemies.playerDead == true && scoreCheck == false)
        {
            CheckNewScore();
            PrintHighScores();
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
                Debug.Log("The value at Array index: " + i + " is lower so your current score: " + currentRound + " will be entered into this array index!");
                Debug.Log("the value at the Index " + i + " is " + highScore[i]);
                achievedHighScore = true;
                return;
            }
            else
            {
                Debug.Log("The value at Array index: " + i + " is greater or equal to " + currentRound + " checking the next index...");
            }

        }
    }

    void PrintHighScores()
    {
        for (int i = 0; i < highScore.Length; i++)
        {
            Debug.Log("The value at Array index: " + i + " " + highScore[i]);
        }
    }
}
