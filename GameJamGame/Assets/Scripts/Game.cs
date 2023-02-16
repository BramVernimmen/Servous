using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private int m_Difficulty = 0;
    private int m_CurrentDifficulty = 0;
    private bool m_RandomDifficulty = false;

    private int m_Score;

    [SerializeField] private GameObject m_Player;
    private Vector3 m_PlayerStartPosition;
    private Quaternion m_PlayerStartRotation;
    [SerializeField] HandMovement m_HandMovement;

    [SerializeField] private GameObject m_StartPrefab = null;
    [SerializeField] private GameObject m_PausePrefab = null;
    private const string PAUSEBUTTON = "Pause";

    private float returnTimer = 1.5f;
    private const string METHOD_SETDESTINATION = "SetPlayerDestination";
    private const string METHOD_REMOVEBOTTLES = "RemoveBottles";
    private bool m_DroppedBottles = false;

    private GameObject m_PauseMenu = null;

    private MovementBehaviour m_MovementController = null;

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

        Random.InitState((int)System.DateTime.Now.Ticks);
    }

    #endregion

    // Start is called before the first frame update
    private void Start()
    {
        m_PlayerStartPosition = m_Player.transform.position;
        m_PlayerStartRotation = m_Player.transform.rotation;
        Instantiate(m_StartPrefab);
        m_MovementController = FindObjectOfType<MovementBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(PAUSEBUTTON))
        {
            if (m_PauseMenu == null)
            {
                m_PauseMenu = Instantiate(m_PausePrefab);
                Debug.Log("Paused");
            }
            else
            {
                PauseMenu pause = m_PauseMenu.GetComponent<PauseMenu>();
                pause.OnClickContinue();
                Destroy(m_PauseMenu);
                m_PauseMenu = null;
            }
        }
    }


    public void OnDestinationArrival()
    {
        if(m_DroppedBottles)
        {
            m_CurrentDifficulty = 0;
            m_DroppedBottles = false;
        }
        else if (m_CurrentDifficulty > 0)
        {
            if (m_RandomDifficulty == false)
            {
                ++m_Difficulty;
                if (m_Difficulty == 5)
                {
                    m_RandomDifficulty = true;
                }
            }

            if (m_RandomDifficulty == true)
            {
                m_Difficulty = Random.Range(1, 5);
            }

            m_CurrentDifficulty = 0;
            Invoke(METHOD_REMOVEBOTTLES, 1.0f);
        }
        else
        {
            m_CurrentDifficulty = m_Difficulty;
            BottleSpawner.Instance.SpawnBottles(m_Difficulty);
        }

        Invoke(METHOD_SETDESTINATION, returnTimer);
    }
    private void SetPlayerDestination()
    {
        m_MovementController.SetGoal(PathGraph.Instance.GetRandomDestinationForDifficulty(m_CurrentDifficulty));
    }

    private void RemoveBottles()
    {
        m_Score += BottleSpawner.Instance.CountAndRemoveBottles();
    }

    public void DroppedAllBottles()
    {

        m_MovementController.ReturnToStart();
        
        m_DroppedBottles = true;
    }

    public void StartNewGame()
    {
        Debug.Log("new game started");

        m_CurrentDifficulty = m_Difficulty;
        m_Score = 0;

        BottleSpawner.Instance.CountAndRemoveBottles();

        m_Player.transform.position = m_PlayerStartPosition;
        m_Player.transform.rotation = m_PlayerStartRotation;
        m_HandMovement.ResetHandRotation();

        SetPlayerDestination();
        BottleSpawner.Instance.SpawnBottles(m_Difficulty);
    }
}
