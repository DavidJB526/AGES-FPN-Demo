using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    public void LoadGameScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
