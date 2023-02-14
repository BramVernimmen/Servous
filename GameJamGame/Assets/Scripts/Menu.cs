using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    // text
    [SerializeField] private Text m_TextScore = null;
    [SerializeField] private Text m_TextHighscore = null;

    // buttons
    [SerializeField] private Button m_ButtonRetry = null;
    [SerializeField] private Button m_ButtonQuit = null;

    // varialbes
    int m_Score;
    int m_Highscore;

    bool m_Retry = false;
    public bool Retry { get { return m_Retry;} }

    private void Awake()
    {
        m_ButtonRetry.onClick.AddListener(OnClickRetry);
        m_ButtonQuit.onClick.AddListener(OnClickQuit);
    }

    public void OnClickRetry()
    {
        m_Retry = true;
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

    public void Initialize(int score, int highscore)
    {
        m_Score = score;
        m_Highscore = highscore;

        if(m_TextScore != null)
            m_TextScore.text = m_Score.ToString();

        if (m_TextHighscore != null)
            m_TextHighscore.text = m_Highscore.ToString();
    }
}
