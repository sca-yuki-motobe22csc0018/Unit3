using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(35,2,0);
    private float startDelay = 2.5f;
    private float repeatRate = 2.5f;
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
        if (!pc.gameOver)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
        
    }
}
