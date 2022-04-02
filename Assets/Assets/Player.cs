using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Timers;

public class Player : MonoBehaviour
{
    private float moveHorizontal;
    private float moveVertical;
    private Vector2 currentVelocity;
    private Timer fourSecondTimer;

    Animator animator;

    [SerializeField]
    public float playerSpeed = 6.0f;
    private bool sprintKey = false;
    private Rigidbody2D characterRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        characterRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            sprintKey = true;
        } else if (Input.GetKeyUp(KeyCode.LeftShift)){
            sprintKey = false;
        }
        
        if (sprintKey == true){
            characterRigidbody.velocity = new Vector2(moveHorizontal * playerSpeed * 2, moveVertical * playerSpeed * 2);
        } else {
            characterRigidbody.velocity = new Vector2(moveHorizontal * playerSpeed, moveVertical * playerSpeed);
        }



        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        currentVelocity = characterRigidbody.velocity;

        animator.SetFloat("Player Speed", currentVelocity.magnitude);
    }
    
    public void OnCollisionEnter2D(Collision2D col){
        /*
        if (collision/gameObject.tag == "Enemy"){
            animator.SetTrigger("COLLIDE");
        }

        */
        animator.SetTrigger("COLLIDE");
    }

    public void OnCollisionStay2D(Collision2D col){
        // fourSecondTimer = new System.Timers.Timer();
        // fourSecondTimer.Interval = 4000;
        // fourSecondTimer.enabled = true;
        // if (fourSecondTimer.Elapsed){
        //     animator.SetTrigger("COLLIDE");
        //     animator.ResetTrigger("COLLIDE");
        // }
        // fourSecondTimer.enabled = false;
        // fourSecondTimer.AutoReset = true;
        animator.SetTrigger("COLLIDE");
    }

    public void OnCollisionExit2D(Collision2D col){
        animator.ResetTrigger("COLLIDE");
    }
}
