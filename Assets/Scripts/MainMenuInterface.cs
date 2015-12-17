using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuInterface : MonoBehaviour {

    public Canvas quitMenu;
    public Canvas optionsMenu;
    public Button startText;
    public Button exitText;
	// Use this for initialization
	void Start () {

        quitMenu = quitMenu.GetComponent<Canvas>();
        optionsMenu = optionsMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        quitMenu.enabled = false;
        optionsMenu.enabled = false;
    }

    public void exitPress()
    {
        quitMenu.enabled = true;
        optionsMenu.enabled = false;
        startText.enabled = false;
        exitText.enabled = false;
    }

    public void optionsPress()
    {
        optionsMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }

    public void closePress()
    {
        optionsMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }

    public void noPress()
    {
        quitMenu.enabled = false;
        optionsMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }

    public void startLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void quitGame()
    {
        Application.Quit();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
