using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class HighscoreLogic : MonoBehaviour
{
    public static HighscoreLogic Instance;

    private int currentRound;

    private bool scoreCheck = false;
    public static bool achievedHighScore { get; private set; }

    public int[] highscores = new int[5];

    public static string firstPlaceName { get; private set; } 
    public static string secondPlaceName { get; private set; }
    public static string thirdPlaceName { get; private set; }
    public static int firstPlaceRounds { get; private set; }
    public static int secondPlaceRounds { get; private set; }
    public static int thirdPlaceRounds { get; private set; }

    // Update is called once per frame

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance);

        highscores[0] = 5; highscores[1] = 3; highscores[2] = 1;

        // I'll need to load the data when the game first loads when there is actually data
        //Load();
    }

    [System.Serializable]
    class HighscoreData
    {
        public string firstPlaceName, secondPlaceName, thirdPlaceName;
        public int firstPlaceRounds, secondPlaceRounds, thirdPlaceRounds;
    }

    private void Start()
    {
        achievedHighScore = false;
        Save();

    }
    void Update()
    {
        if (Enemies.playerDead == true && scoreCheck == false)
        {
            CheckNewScore();
            //PrintHighScores();
            // I'll need to save and load the data here i think. 
        }

    }

    public void Save()
    {
        HighscoreData data = new HighscoreData();

        /*data.firstPlaceName = firstPlaceName;
        data.secondPlaceName = secondPlaceName;
        data.thirdPlaceName = thirdPlaceName;*/
        data.firstPlaceRounds = highscores[0];
        data.secondPlaceRounds = highscores[1];
        data.thirdPlaceRounds = highscores[2];

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

            /*firstPlaceName = data.firstPlaceName;
            secondPlaceName = data.secondPlaceName;
            thirdPlaceName = data.thirdPlaceName;*/
            firstPlaceRounds = data.firstPlaceRounds;
            secondPlaceRounds = data.secondPlaceRounds;
            thirdPlaceRounds = data.thirdPlaceRounds;

            Debug.Log(path);
        }
    }
    public void CheckNewScore()
    {
        scoreCheck = true;
        currentRound = SpawnEnemies.currentRound;

        if (thirdPlaceRounds > currentRound)
        {
            Debug.Log("The round you got to wasnt high enough to get into the highscores you loser, git gud");
            return;
        }
        
        for (int i = 0; i < highscores.Length; i++)
        {
            if (highscores[i] < currentRound)
            {
                highscores[i] = currentRound;
                Debug.Log("The value at Array index: " + i + " is lower so your current score: " + currentRound + " will be entered into this array index!");
                Debug.Log("the value at the Index " + i + " is " + highscores[i]);
                achievedHighScore = true;
                return;
            }

            if (highscores[i] == currentRound)
            {

            }

            else
            {
                Debug.Log("The value at Array index: " + i + " is greater or equal to " + currentRound + " checking the next index...");
            }
            


        }
    }

    /*void PrintHighScores()
    {
        for (int i = 0; i < highScore.Length; i++)
        {
            Debug.Log("The value at Array index: " + i + " " + highScore[i]);
        }
    }*/
}
