using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI counterText;
    [SerializeField] Canvas scoreCanvas;
    PlayAgain playAgainCanvas;

    public float highScore;
    private float currentTime;
    public float seconds, minutes, milliseconds;

    private void Awake()
    {
        int numOfScore = FindObjectsOfType<Score>().Length;
        print(numOfScore);
        if (numOfScore > 1)
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
        highScore = Mathf.Infinity;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
    }

    private void UpdateTime()
    {
        currentTime = Time.timeSinceLevelLoad;
        counterText.text = FormatTime(currentTime);
    }

    private string FormatTime(float time)
    {
        minutes = (int)(time / 60f);
        seconds = (int)(time % 60f);
        milliseconds = (int)((time * 100f) % 100);
        return minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
    }

    public void EndTimer()
    {
        playAgainCanvas = FindObjectOfType<PlayAgain>();
        if (currentTime < highScore)
        {
            highScore = currentTime;
        }
        print(highScore);
        playAgainCanvas.currentScore.text = FormatTime(currentTime);
        playAgainCanvas.highScore.text = FormatTime(highScore);
        scoreCanvas.enabled = false;
    }
}
