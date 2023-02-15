using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;
    }

    public void OnClickStart()
    {
        Time.timeScale = 1;
        // TODO: game loop spawns start menu
        // TODO: start game
        Destroy(this.gameObject);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
