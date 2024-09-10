using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject highScoreUI, optionsUI;
    private bool highScoreUIBool, optionsUIBool = false;
    [SerializeField] TextMeshProUGUI HighscoreRankings;

    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && highScoreUIBool == true) 
        {
            HighScoreUIDisabled();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && optionsUIBool == true)
        {
            OptionsUIDisabled();
        }

        HighscoreRankings.text = 
            HighscoreLogic.Instance.highscoreNames[0] + " --- " +  " Rounds Survived: " + HighscoreLogic.Instance.highscores[0] + "\n" +
            HighscoreLogic.Instance.highscoreNames[1] + " --- " + " Rounds Survived: " + HighscoreLogic.Instance.highscores[1] + "\n" +
            HighscoreLogic.Instance.highscoreNames[2] + " --- " + " Rounds Survived: " + HighscoreLogic.Instance.highscores[2] + "\n" +
            HighscoreLogic.Instance.highscoreNames[3] + " --- " + " Rounds Survived: " + HighscoreLogic.Instance.highscores[3] + "\n" +
            HighscoreLogic.Instance.highscoreNames[4] + " --- " + " Rounds Survived: " + HighscoreLogic.Instance.highscores[4];

    }

    public void HighScoreUIEnabled()
    {
        highScoreUI.SetActive(true);
        highScoreUIBool = true;

    }
    public void HighScoreUIDisabled()
    {
        highScoreUI.SetActive(false);
        highScoreUIBool = false;
    }
    public void OptionsUIEnabled()
    {
        optionsUI.SetActive(true);
        optionsUIBool = true;
    }

    public void OptionsUIDisabled()
    {
        optionsUI.SetActive(false);
        optionsUIBool = false;
    }




    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
