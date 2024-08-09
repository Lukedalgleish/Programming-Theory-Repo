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

    // Start is called before the first frame update
    void GoBackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if(SpawnEnemies.gameover == true)
        {
            DeathScreen();
        }

        currentRoundUIText.text = "Round: " + SpawnEnemies.currentRound;

    }
    public void DeathScreen()
    {
        deathScreenUI.SetActive(true);
        deathScreenRoundText.text = "Rounds Survived: " + SpawnEnemies.currentRound;

    }
}
