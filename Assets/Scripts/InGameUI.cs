using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    public GameObject deathScreenUI;    
    public TextMeshProUGUI deathScreenRoundText;
    [SerializeField] private TextMeshProUGUI currentRoundUIText;
    [SerializeField] private GameObject highscorePopUpObject;

    public static string playerInputString { get; private set; }

    private void Update()
    {
        if(Enemies.playerDead == true)
        {
            DeathScreen();
        }

        currentRoundUIText.text = "Round: " + SpawnEnemies.currentRound;

    }
    public void DeathScreen()
    {
        deathScreenUI.SetActive(true);
        deathScreenRoundText.text = "Rounds Survived: " + SpawnEnemies.currentRound;

        if(HighscoreLogic.achievedHighScore == true)
        {
            // set the highscore screen to active
            highscorePopUpObject.SetActive(true);
        }

    }

    public void ReadPlayerStringInput(string input)
    {
        playerInputString = input;
        Debug.Log(playerInputString);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SaveData()
    {
        HighscoreLogic.Instance.Save();
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
