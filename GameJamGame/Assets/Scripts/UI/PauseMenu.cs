using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;
    }

    public void OnClickContinue()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
