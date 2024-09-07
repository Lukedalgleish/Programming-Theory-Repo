using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class HighscoreLogic : MonoBehaviour
{
    public static HighscoreLogic Instance;

    private int currentRound;
    private string currentPlayerName = InGameUI.playerInputString;

    private bool scoreCheck = false;
    public static bool achievedHighScore { get; private set; }

    public int[] highscores = new int[5];
    public string[] highscoreNames = new string[5];

    // Update is called once per frame

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

        Load();
    }
    private void Start()
    {
        achievedHighScore = false;
        PrintHighScoresAndNames();

    }
    void Update()
    {
        if (Enemies.playerDead == true && scoreCheck == false)
        {
            CheckNewScore();
            PrintHighScoresAndNames();
        }
    }

    [System.Serializable]
    class HighscoreData
    {
        public string firstPlaceName, secondPlaceName, thirdPlaceName, fourthPlaceName, fifthPlaceName;
        public int firstPlaceRounds, secondPlaceRounds, thirdPlaceRounds, fourthPlaceRounds, fifthPlaceRounds;
    }

    public void Save()
    {
        HighscoreData data = new HighscoreData();

        data.firstPlaceName = highscoreNames[0];
        data.secondPlaceName = highscoreNames[1];
        data.thirdPlaceName = highscoreNames[2];
        data.fourthPlaceName = highscoreNames[3];
        data.fifthPlaceName = highscoreNames[4];

        data.firstPlaceRounds = highscores[0];
        data.secondPlaceRounds = highscores[1];
        data.thirdPlaceRounds = highscores[2];
        data.fourthPlaceRounds = highscores[3];
        data.fifthPlaceRounds = highscores[4];
        
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

            highscoreNames[0] = data.firstPlaceName;
            highscoreNames[1] = data.secondPlaceName;
            highscoreNames[2] = data.thirdPlaceName;
            highscoreNames[3] = data.fourthPlaceName;
            highscoreNames[4] = data.fifthPlaceName;

            highscores[0] = data.firstPlaceRounds;
            highscores[1] = data.secondPlaceRounds;
            highscores[2] = data.thirdPlaceRounds;
            highscores[3] = data.fourthPlaceRounds;
            highscores[4] = data.fifthPlaceRounds;

            Debug.Log(path);
        }
    }
    public void CheckNewScore()
    {
        scoreCheck = true;
        currentRound = SpawnEnemies.currentRound;

        if (highscores[4] > currentRound)
        {
            Debug.Log("The round you got to wasnt high enough to get into the highscores you loser, git gud");
            return;
        }
        
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

                highscores[i] = currentRound;
                highscoreNames[i] = currentPlayerName;
                achievedHighScore = true;
                Save();
                return;
            }

            else
            {
                Debug.Log("The value at Array index: " + i + " is greater or equal to " + currentRound + " checking the next index...");
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
