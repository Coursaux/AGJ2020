using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float totalHealth;
    public float currentHealth;
    CameraFollow cameraShaker;
    PlayAgain playAgainCanvas;
    Score score;
    bool guiEnabled = false;

    [SerializeField] Material bgImage;
    [SerializeField] Material fgImage;

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
        guiEnabled = true;
        Invoke("HideGUI", 2f);
        die();
    }

    public void AddHealth(float health)
    { 
        currentHealth += health;
        if (currentHealth > totalHealth)
            currentHealth = totalHealth;
    }

    private void HideGUI()
    {
        guiEnabled = false;
    }

    void die()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
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

    private void OnGUI()
    {
        if(guiEnabled)
        {
            float maxWidth = Screen.width / 2;
            GUI.BeginGroup(new Rect(maxWidth/2, (Screen.height/4)*3, maxWidth, 32));
            GUI.Box(new Rect(0, 0, maxWidth, 32), bgImage.mainTexture);
            GUI.BeginGroup(new Rect(0, 0, currentHealth / totalHealth * maxWidth, 32));
            GUI.Box(new Rect(0, 0, currentHealth / totalHealth * maxWidth, 32), fgImage.mainTexture);
            GUI.EndGroup();
            GUI.EndGroup();
        }
        
    }
}