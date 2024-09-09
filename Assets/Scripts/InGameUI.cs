using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public GameObject deathScreenUI;    
    public TextMeshProUGUI deathScreenRoundText;
    public TextMeshProUGUI userInputField;  // Assign InputField from the Inspector
    [SerializeField] private TextMeshProUGUI currentRoundUIText;
    [SerializeField] private GameObject highscorePopUpObject;

    public static string playerInputString { get; private set; }

    private void Update()
    {
        //Debug.Log(userInputField.text);
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

    public void SaveHighscoreButton()
    {
        HighscoreLogic.Instance.InsertNewHighScore();
    }

    public void GetUserInput()
    {
        playerInputString = userInputField.text; // Get the text from the InputField
        Debug.Log(playerInputString);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
