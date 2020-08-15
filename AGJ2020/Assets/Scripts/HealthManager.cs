using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float totalHealth;
    private float currentHealth;
    CameraFollow cameraShaker;
    [SerializeField] Canvas playAgainCanvas;

    void Start()
    {
        currentHealth = totalHealth;
        cameraShaker = FindObjectOfType<CameraFollow>();
        playAgainCanvas.enabled = false;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        print(currentHealth);
        cameraShaker.ShakeCamera();
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
            playAgainCanvas.enabled = true;
        }
    }
}