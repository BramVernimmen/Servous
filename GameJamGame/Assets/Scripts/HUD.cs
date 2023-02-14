using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    // text on hud
    [SerializeField] private Text m_CounterScore = null;
    [SerializeField] private Text m_CounterTime = null;

    [SerializeField] private float m_MaxTimeSeconds = 0;
    [SerializeField] private GameObject m_MenuPrefab = null;

    // variables
    float m_Timer = 0;
    int m_Score = 0;
    int m_Highscore = 0;

    GameObject m_MenuObject = null;
    Menu m_Menu = null;
    bool m_InMenu = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Timer = m_MaxTimeSeconds;
        m_Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_InMenu)
        {
            if (m_Menu.Retry)
            {
                // unpauze time
                Time.timeScale = 1;

                // reset hud
                ResetHud();

                // remove menu
                Destroy(m_MenuObject);
                m_MenuObject = null;
                m_Menu = null;
                m_InMenu = false;

                // TODO: Reset Game
            }
        }
        else
        {
            // update timer
            m_Timer -= Time.deltaTime;
            m_Score += 1;

            if (m_Timer < 0)
                m_Timer = 0;

            // update timer text
            if (m_CounterTime != null)
            {
                int time = Mathf.FloorToInt(m_Timer);
                int minutes = time / 60;
                int seconds = time - 60 * minutes;

                String[] strings = new String[4];
                strings[0] = minutes.ToString();
                strings[1] = ":";

                if (seconds < 10)
                    strings[2] = "0";
                else
                    strings[2] = "";

                strings[3] = seconds.ToString();
                String timerText = String.Join("", strings);

                m_CounterTime.text = timerText;
            }

            // TODO: update score
            if (m_CounterScore != null)
            {
                m_CounterScore.text = m_Score.ToString();
            }

            // check game end
            if (m_Timer <= 0)
            {
                // pauze time
                Time.timeScale = 0;

                // update highscore
                if (m_Score > m_Highscore)
                    m_Highscore = m_Score;

                // spawn menu
                m_MenuObject = Instantiate(m_MenuPrefab);
                m_Menu = m_MenuObject.GetComponent<Menu>();
                m_Menu.Initialize(m_Score, m_Highscore);
                m_InMenu = true;
            }
        }
    }

    void ResetHud()
    {
        m_Timer = m_MaxTimeSeconds;
        m_Score = 0;
    }
}
