using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 20;
    private PlayerController pc;
    private float leftBound=-15;
    private void Start()
    {
        pc=GameObject.Find("OZISAN").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!pc.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
