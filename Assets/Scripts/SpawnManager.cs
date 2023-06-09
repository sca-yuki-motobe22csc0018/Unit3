using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos;
    float x;
    float z;
    private float startDelay = 1.5f;
    private float repeatRate = 1.5f;
    private PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("SpawnObstacle",startDelay,repeatRate);
        pc=GameObject.Find("OZISAN").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void SpawnObstacle()
    {
        x = Random.Range(45.0f, 65.0f);
        z = Random.Range(-15.5f, -4.5f);
        spawnPos = new Vector3(x, 2, z);
        if (!pc.gameOver)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
        
    }
}
