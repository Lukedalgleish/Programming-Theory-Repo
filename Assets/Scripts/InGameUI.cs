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

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
