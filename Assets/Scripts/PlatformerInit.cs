using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerInit : MonoBehaviour
{
    public static PlatformerInit instance;
    public GameObject plaformerPrefab;
    private float posForInit;
    [SerializeField] private GameObject player;
 

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        posForInit = -1;
    }    
    void Update()
    {
        InitPlatform();
    }

    public void InitPlatform()
    {
        if (posForInit < player.transform.position.y + 6)
        {
            float p = Random.Range(0.5f, 1);
            posForInit += p;
            Instantiate(plaformerPrefab, new Vector3(Random.Range(-2, 2), posForInit, 0), Quaternion.identity);
        }
    }

  
}
