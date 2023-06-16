using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_Rock : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos;
    private float startDelay = 2.0f;
    private float repeatRate = 2.0f;
    private PlayerController pc;
    float x;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        pc =GameObject.Find("OZISAN").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void SpawnObstacle()
    {
        x = Random.Range(40.0f, 65.0f);
        spawnPos=new Vector3(x, 2, 0);
        //InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        startDelay =x;
        if (!pc.gameOver)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
        
    }
}
