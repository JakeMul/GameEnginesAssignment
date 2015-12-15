using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInterface : MonoBehaviour {

    public Button exitText;

    // Use this for initialization
    void Start () {
        exitText = exitText.GetComponent<Button>();
        exitText.enabled = true;
    }

    public void exitLevel()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
