using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject highScoreUI, optionsUI;
    private bool highScoreUIBool, optionsUIBool = false;
    

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
