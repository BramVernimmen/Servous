using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BottleSpawner : MonoBehaviour
{
    [SerializeField] int nrTypes = 0;
    [SerializeField] GameObject m_Type0 = null;
    [SerializeField] GameObject m_Type1 = null;
    [SerializeField] GameObject m_Type2 = null;
    [SerializeField] GameObject m_Type3 = null;
    [SerializeField] GameObject m_Type4 = null;

    [SerializeField] GameObject m_Plate = null;
    [SerializeField] GameObject m_Player = null;

    [SerializeField] float m_RadiusPlate = 0.17f;
    [SerializeField] float m_MinBottleDistance = 0.5f;

    private List<GameObject> m_Bottles;

    //[SerializeField] int nr_Spawns = 0;

    #region SINGLETON
    private static BottleSpawner m_Instance;
    private static string m_SingletonInstance = "Singleton_BottleSpawner";

    public static BottleSpawner Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = FindObjectOfType<BottleSpawner>();
                if (m_Instance == null)
                {
                    GameObject newObject = new GameObject(m_SingletonInstance);
                    m_Instance = newObject.AddComponent<BottleSpawner>();
                }
            }
            return m_Instance;
        }
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

    private void Start()
    {
        //Random.InitState((int)System.DateTime.Now.Ticks);
        m_Bottles = new List<GameObject>();
    }

    public void SpawnBottles(int nrBottles)
    {
        // safety checks
        if (nrBottles < 0) return;
        if(nrTypes <= 0)   return;
        if(m_Plate == null) return;
        if(m_Player == null) return;
     
        List<Vector2> bottlePositions = new List<Vector2>();

        // spawn bottle
        for(int i = 0; i < nrBottles; i++)
        //for(int i = 0; i < nr_Spawns; i++)
        {
            int type = Random.Range(0, nrTypes);
            GameObject spawnType = m_Type0;
            switch(type)
            {
                case 0:
                    spawnType = m_Type0;
                    break;
                case 1:
                    spawnType = m_Type1;    
                    break;
                case 2:
                    spawnType = m_Type2;
                    break;
                case 3:
                    spawnType = m_Type3;
                    break;
                case 4:
                    spawnType = m_Type4;
                    break;
                default:
                    spawnType = m_Type0;
                    break;        
            }
       
            Vector3 position = m_Plate.transform.position;
            position.y -= 0.2f;

            bool goodPosition = false;
            int maxAttempts = 20;

            while(!goodPosition)
            {
                --maxAttempts;

                float randomRadius = Random.Range(0, m_RadiusPlate);
                position.x += Mathf.Sin(Random.Range(0, 3.14f)) * randomRadius;
                position.z += Mathf.Cos(Random.Range(0, 3.14f)) * randomRadius;

                // test
                //float randomRadius = m_RadiusPlate;
                //position.x += Mathf.Sin(90) * randomRadius;
                //position.z += Mathf.Cos(90) * randomRadius;

                Vector2 newPos = new Vector2(position.x, position.z);

                goodPosition = true;
                for(int j = 0; j < bottlePositions.Count; j++)
                {
                    if (Vector2.Distance(bottlePositions[j], newPos) < m_MinBottleDistance)
                    {
                        goodPosition = false;
                    }
                }

                // safety exit to avoid endless loop
                if (maxAttempts == 0)
                {
                    goodPosition = true;
                    Debug.Log("no good pos");
                }
            }

            bottlePositions.Add(new Vector2(position.x, position.z));

            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            GameObject newBottle = Instantiate(spawnType, position, rotation);
            newBottle.transform.SetParent(m_Player.transform, true);

            //newBottle.transform.localPosition += new Vector3(0.5f, 0, 0);
            //newBottle.transform.localPosition += new Vector3(0, 0, 0.5f);

            m_Bottles.Add(newBottle);
        }
    }

    public int CountAndRemoveBottles()
    {
        int score = 0;

        for (int i = 0; i < m_Bottles.Count; ++i)
        {
            if (m_Bottles[i] != null)
            {
                ++score;
                Destroy(m_Bottles[i].gameObject);
            }
        }
        m_Bottles.Clear();
     
        return score;
    }

    public void DestroyedBottle(GameObject bottle)
    {
        for (int i = 0; i < m_Bottles.Count; ++i)
        {
            if(bottle == m_Bottles[i])
            {
                m_Bottles[i] = null;
            }
        }

        int count = 0;
        for (int i = 0; i < m_Bottles.Count; ++i)
        {
            if (m_Bottles[i] != null)
            {
                ++count;
            }
        }

        if(count == 0)
        {
            Game.Instance.DroppedAllBottles();
        }
    }
}
