﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    [SerializeField] Canvas playAgainCanvas;
    [SerializeField] Canvas scoreCanvas;

    public TextMeshProUGUI currentScore;
    public TextMeshProUGUI highScore;

    private void Awake()
    {
        int numOfPlayAgain = FindObjectsOfType<PlayAgain>().Length;
        print(numOfPlayAgain);
        if (numOfPlayAgain > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        playAgainCanvas = GetComponent<Canvas>();
    }

    public void PlayAgainClick()
    {
        scoreCanvas.enabled = true;
        SceneManager.LoadScene(1);
    }
    
    public void MainMenuClick()
    {
        SceneManager.LoadScene(0);
    }

    public void Hide()
    {
        playAgainCanvas.enabled = false;
    }

    public void Show()
    {
        playAgainCanvas.enabled = true;
    }
}
