using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI HighscoreRankings;
    [SerializeField] private GameObject highScoreUI, optionsUI;
    private bool highScoreUIBool, optionsUIBool = false;
    private string HighscoresScoresAndNames;
    

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
    }

    public void HighScoreUIEnabled()
    {
        highScoreUI.SetActive(true);
        highScoreUIBool = true;

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < HighscoreLogic.highscoreNames.Length; i++)
        {
             sb.Append(HighscoreLogic.highscoreNames[i] + " --- " + " Rounds Survived: " + HighscoreLogic.highscores[i] + "\n");
        }

        HighscoreRankings.text = sb.ToString();

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
