using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifetime : MonoBehaviour
{
    [SerializeField]
    private float m_LifeTime = 10;
    public AudioSource audioClip1;
    public AudioSource audioClip2;
    public AudioSource audioClip3;
    public AudioSource audioClip4;
    public AudioSource audioClip5;
    public AudioSource audioClip6;

    // Update is called once per frame
    private void Awake()
    {

        switch (Random.Range(0, 5))
        {
            case 0:
                audioClip1.Play();
                break;
            case 1:
                audioClip2.Play();
                break;
            case 2:
                audioClip3.Play();
                break;
            case 3:
                audioClip4.Play();
                break;
            case 4:
                audioClip5.Play();
                break;
            case 5:
                audioClip6.Play();
                break;
        }
        }
    void Update()
    {
        m_LifeTime -= Time.deltaTime;
        if(m_LifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
