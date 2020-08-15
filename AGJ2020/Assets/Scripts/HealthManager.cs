using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float totalHealth;
    private float currentHealth;
    CameraFollow cameraShaker;
    PlayAgain playAgainCanvas;
    Score score;

    void Start()
    {
        currentHealth = totalHealth;
        cameraShaker = FindObjectOfType<CameraFollow>();
        playAgainCanvas = FindObjectOfType<PlayAgain>();
        score = FindObjectOfType<Score>();
        playAgainCanvas.Hide();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        print(currentHealth);
        cameraShaker.ShakeCamera(0.1f, 0.5f);
        die();
    }

    public void AddHealth(float health)
    { 
        currentHealth += health;
        if (currentHealth > totalHealth)
            currentHealth = totalHealth;
    }

    void die()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            playAgainCanvas.Show();
            score.EndTimer(false);
        }
    }

    public void WinGame()
    {
        playAgainCanvas.Show();
        score.EndTimer(true);
    }
}