using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauzeMenu : MonoBehaviour
{
    public void OnClickContinue()
    {
        // TODO: spawn pauze menu

        Time.timeScale = 1;
        Destroy(gameObject);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
