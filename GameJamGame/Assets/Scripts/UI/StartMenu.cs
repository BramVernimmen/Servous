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
        Game.Instance.StartNewGame();
        Destroy(this.gameObject);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
