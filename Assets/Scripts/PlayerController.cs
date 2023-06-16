using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce=0.0f;
    public float gravityModifier;
    public bool isOnGround=true;
    public bool WJump=false;
    public bool gameOver=false;
    private Animator playerAnim;

    void Start()
    {
        rb=GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0,-10,0);
        Physics.gravity*=gravityModifier;
        playerAnim=GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == false && WJump == false)
        {
            rb.AddForce(new Vector3(0, 0.75f, 0) * jumpForce, ForceMode.Impulse);
            WJump = true;
            playerAnim.SetTrigger("Jump_trig");
        }

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
            WJump=false;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver=true;
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int",1);
            Invoke("Load",2.0f);
        }
    }

    private void Load()
    {
        SceneManager.LoadScene("Prototype 3");
    }
}
