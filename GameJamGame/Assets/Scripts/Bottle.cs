using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    [SerializeField]
    public GameObject m_DestroyedVersion;
    public AudioSource audioClip1;
    public AudioSource audioClip2;
    public AudioSource audioClip3;
    public AudioSource audioClip4;
    public AudioSource audioClip5;
    public AudioSource audioClip6;

    const string m_Tag = "Bottles";
    bool destroyed = false;

    private void Awake()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!other.gameObject.CompareTag(m_Tag))
        {
            if(!destroyed)
            {
                BreakObject();

                //Debug.Log("Destroy bottle");
                BottleSpawner.Instance.DestroyedBottle(gameObject);
                destroyed = true;
                Destroy(gameObject);
            }
        }
    }

    public void KillBottle()
    {
        if (!destroyed)
        {
            BreakObject();

            //Debug.Log("Destroy bottle on ground");
            BottleSpawner.Instance.DestroyedBottle(gameObject);
            destroyed = true;
            Destroy(gameObject);
        }
    }

    public void BreakObject()
    {
        GameObject brokenBottle = Instantiate(m_DestroyedVersion, transform.position, transform.rotation);
        brokenBottle.transform.localScale = new Vector3(5, 5, 5);
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
}
