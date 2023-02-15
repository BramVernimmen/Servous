using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private int m_StartingDifficulty = 1;

    private int m_Score;

    [SerializeField] private GameObject m_StartPrefab = null;
    [SerializeField] private GameObject m_PausePrefab = null;
    private const string PAUSEBUTTON = "Pause";

    public int Score
    {
        get { return m_Score; }
    }

    #region SINGLETON
    private static Game m_Instance;
    private static string m_SingletonInstance = "Singleton_Game";
    private static bool m_ApplicationQuitting = false;

    public static Game Instance
    {
        get
        {
            if (m_Instance == null && !m_ApplicationQuitting)
            {
                m_Instance = FindObjectOfType<Game>();
                if (m_Instance == null)
                {
                    GameObject newObject = new GameObject(m_SingletonInstance);
                    m_Instance = newObject.AddComponent<Game>();
                }
            }
            return m_Instance;
        }
    }

    public void OnApplicationQuit()
    {
        m_ApplicationQuitting = true;
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (m_Instance == null)
        {
            m_Instance = this;
        }
        else if (m_Instance != this)
        {
            Destroy(gameObject);
        }
    }

    #endregion

    // Start is called before the first frame update
    private void Start()
    {
        Instantiate(m_StartPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(PAUSEBUTTON))
        {
            Instantiate(m_PausePrefab);
            Debug.Log("Paused");
        }
    }
    
    public void OnDestinationArrival()
    {

    }

    public void StartNewGame()
    {
        Debug.Log("new game started");
    }
}
