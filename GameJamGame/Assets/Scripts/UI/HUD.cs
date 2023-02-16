using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    // text on hud
    //[SerializeField] private Text m_CounterScore = null;
    //[SerializeField] private Text m_CounterTime = null;
    [SerializeField] private TextMeshProUGUI m_CounterScore = null;
    [SerializeField] private TextMeshProUGUI m_CounterTime = null;

    [SerializeField] private float m_MaxTimeSeconds = 0;
    [SerializeField] private GameObject m_MenuPrefab = null;

    // variables
    float m_Timer = 0;
    int m_Highscore = 0;

    GameObject m_MenuObject = null;
    EndMenu m_Menu = null;
    bool m_InMenu = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Timer = m_MaxTimeSeconds;
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

                // reset Game
                Game.Instance.StartNewGame();
            }
        }
        else
        {
            // update timer
            m_Timer -= Time.deltaTime;

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

            int score = Game.Instance.Score;
            // update score
            if (m_CounterScore != null)
            {
                m_CounterScore.text = score.ToString();
            }

            // check game end
            if (m_Timer <= 0)
            {
                // pauze time
                Time.timeScale = 0;

                // update highscore
                if (score > m_Highscore)
                    m_Highscore = score;

                // spawn menu
                m_MenuObject = Instantiate(m_MenuPrefab);
                m_Menu = m_MenuObject.GetComponent<EndMenu>();
                m_Menu.Initialize(score, m_Highscore);
                m_InMenu = true;
            }
        }
    }

    void ResetHud()
    {
        m_Timer = m_MaxTimeSeconds;
    }
}
