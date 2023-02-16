using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    // text
    [SerializeField] private TextMeshProUGUI m_TextScore = null;
    [SerializeField] private TextMeshProUGUI m_TextHighscore = null;
    //[SerializeField] private Text m_TextScore = null;
    //[SerializeField] private Text m_TextHighscore = null;

    // varialbes
    int m_Score;
    int m_Highscore;

    bool m_Retry = false;
    public bool Retry { get { return m_Retry;} }

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
