using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    [SerializeField] Canvas PlayAgainCanvas;

    public void PlayAgainClick()
    {
        SceneManager.LoadScene(1);
    }
    
    public void MainMenuClick()
    {
        SceneManager.LoadScene(0);
    }
}
