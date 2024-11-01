using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class HighscoreLogic : MonoBehaviour
{
    public static HighscoreLogic Instance;
    public static bool achievedHighScore { get; private set; }
    public static int[] highscores { get; private set; }
    public static string[] highscoreNames { get; private set; }

    private int currentRound;

    private void Awake()
    {

        // Check if an instance of the singleton already exists
        if (Instance == null)
        {
            // If not, set the instance to this instance
            Instance = this;

            // Optional: Prevent this object from being destroyed when a new scene loads
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists and it's not this, destroy this object
            Destroy(gameObject);
        }
        highscores = new int[5];
        highscoreNames = new string[5];
        Load();
    }
    private void Start()
    {
        achievedHighScore = false;
        PrintHighScoresAndNames();
    }

    [System.Serializable]
    class HighscoreData
    {
        public string[] highscoreNames = new string[5];
        public int[] highscoreValues = new int[5];
    }

    public void Save()
    {
        HighscoreData data = new HighscoreData();

        for (int i = 0; i < highscoreNames.Length; i++)
        {
            data.highscoreNames[i] = highscoreNames[i];
            data.highscoreValues[i] = highscores[i];

        }
        
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log(json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighscoreData data = JsonUtility.FromJson<HighscoreData>(json);

            for (int i = 0; i < highscoreNames.Length; i++)
            {
                highscoreNames[i] = data.highscoreNames[i];
                highscores[i] = data.highscoreValues[i];

            }

            Debug.Log(path);
        }
    }
    public void CheckScore()
    {
        currentRound = SpawnEnemies.currentRound;

        if (highscores[4] >= currentRound)
        {
            Debug.Log("The round you got to wasnt high enough to get into the highscores you loser, git gud");
            return;
        }
        achievedHighScore = true;
    }


    public void InsertNewHighScore()
    {
        for (int i = 0; i < highscores.Length; i++)
        {
            // checks if the the round the player got to is greater than the current round. 
            if (highscores[i] < currentRound)
            {
                // We need to move all the highscores down one
                for (int j = highscores.Length - 1; j > i; j--)
                {
                    highscores[j] = highscores[j - 1];
                    highscoreNames[j] = highscoreNames[j - 1];
                }

                highscoreNames[i] = InGameUI.playerInputString;
                highscores[i] = currentRound;

                Save();

                achievedHighScore = false; // We need to set this back to false here to not mess up the states when we restart the scene.

                return;
            }
        }
    }

    void PrintHighScoresAndNames()
    {
        for (int i = 0; i < highscores.Length; i++)
        {
            Debug.Log("Name: " + highscoreNames[i] + " Rounds: " + highscores[i]);
        }
    }
}
