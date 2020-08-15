using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update\

    [SerializeField] Button backButton;
    [SerializeField] Button playGameButton;
    [SerializeField] Button instructionsButton;
    [SerializeField] TextMeshProUGUI instructionsText;

    private void Start()
    {
        backButton.gameObject.SetActive(false);
        instructionsText.gameObject.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void InstructionsClick()
    {
        backButton.gameObject.SetActive(true);
        instructionsText.gameObject.SetActive(true);
        playGameButton.gameObject.SetActive(false);
        instructionsButton.gameObject.SetActive(false);
    }

    public void BackClick()
    {
        backButton.gameObject.SetActive(false);
        instructionsText.gameObject.SetActive(false);
        playGameButton.gameObject.SetActive(true);
        instructionsButton.gameObject.SetActive(true);
    }

}
