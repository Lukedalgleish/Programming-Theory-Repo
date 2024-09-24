using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentRoundUIText;
    [SerializeField] private GameObject highscorePopUpObject;

    [SerializeField] private GameObject deathScreenUI;
    [SerializeField] private TextMeshProUGUI deathScreenRoundText;
    [SerializeField] TMP_InputField userInputField;
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
            highscorePopUpObject.SetActive(true);
        }
    }

    public void SaveHighscoreButton()
    {
        HighscoreLogic.Instance.InsertNewHighScore();
    }

    public void GetUserInput()
    {
        playerInputString = userInputField.text;
        //Debug.Log(playerInputString);
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
