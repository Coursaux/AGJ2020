using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    PlayerController player;
    [SerializeField] Canvas mainMenuCanvas;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void PlayGame()
    {
        mainMenuCanvas.enabled = false;
        player.StartGame();
    }

}
