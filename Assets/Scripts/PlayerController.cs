using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround=true;
    public bool gameOver=false;
    private Animator playerAnim;

    void Start()
    {
        rb=GetComponent<Rigidbody>();
        Physics.gravity*=gravityModifier;
        playerAnim=GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isOnGround=false;
            playerAnim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver=true;
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int",1);
        }
    }
}
