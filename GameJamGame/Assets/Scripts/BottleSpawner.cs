using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleSpawner : MonoBehaviour
{
    [SerializeField] int nrTypes = 0;
    [SerializeField] GameObject m_Type0 = null;
    [SerializeField] GameObject m_Type1 = null;
    [SerializeField] GameObject m_Type2 = null;
    [SerializeField] GameObject m_Type3 = null;
    [SerializeField] GameObject m_Type4 = null;

    [SerializeField] GameObject m_plate = null;
    [SerializeField] GameObject m_player = null;

    [SerializeField] float m_RadiusPlate = 0.17f;

    private void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
    }

    public void SpawnBottles(int nrBottles)
    {
        // safety checks
        if (nrBottles < 0) return;
        if(nrTypes <= 0)   return;
        if(m_plate == null) return;
        if(m_player == null) return;
     
        // spawn bottle
        for(int i = 0; i < nrBottles; i++)
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

            Vector3 position = m_plate.transform.position;
            position.y -= 0.2f;
            float randomRadius = Random.Range(0, m_RadiusPlate);
            position.x += Mathf.Sin(Random.Range(0, 3.14f)) * randomRadius;
            position.z += Mathf.Cos(Random.Range(0, 3.14f)) * randomRadius;

            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            GameObject newBottle = Instantiate(spawnType, position, rotation);
            newBottle.transform.SetParent(m_player.transform, true);
        }
    }
}
