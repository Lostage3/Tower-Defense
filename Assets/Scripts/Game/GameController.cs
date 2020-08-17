using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool IsNewGame;
    public bool IsContinue;
    public bool IsExit;
    public bool IsLevelOnePreparation;
    public bool IsReturnToMenu;
    public bool IsLevelOne;
    public bool IsReturnToOverWorld;
    public bool IsReturnToPreparation;

    
    void OnMouseUp()
    {
        if (IsNewGame)
        {
            SceneManager.LoadScene("OverWorld",LoadSceneMode.Single);
        }
        if (IsContinue)
        {
            SceneManager.LoadScene("OverWorld", LoadSceneMode.Single);
        }
        if (IsExit)
        {
            Application.Quit();
        }
        if (IsLevelOnePreparation)
        {
            SceneManager.LoadScene("Preparation", LoadSceneMode.Single);
        }
        if (IsReturnToMenu)
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
        if (IsLevelOne)
        {
            SceneManager.LoadScene("Tower Defense", LoadSceneMode.Single);
        }
        if (IsReturnToOverWorld)
        {
            SceneManager.LoadScene("OverWorld", LoadSceneMode.Single);
        }
        if (IsReturnToPreparation)
        {
            SceneManager.LoadScene("Preparation", LoadSceneMode.Single);
        }
    }
}
