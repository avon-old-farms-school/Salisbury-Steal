using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WALKING : MonoBehaviour
{
    private float moveHorizontal = 1;
    private float moveVertical = 0;
    private Vector2 currentVelocity;

    private bool hasCollided = false;

    Animator animator;

    [SerializeField]
    private float playerSpeed = 3.0f;
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
        currentVelocity = characterRigidbody.velocity;
    }

    void FixedUpdate(){
        characterRigidbody.velocity = new Vector2 (moveHorizontal * playerSpeed, moveVertical * playerSpeed);
    }

    public void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag == "playa" && !hasCollided){
            animator.SetTrigger("COLLIDE");
            GameObject.FindGameObjectsWithTag("playa")[0].GetComponent<Player>().playerSpeed *= 2;
            //col.gameObject.playerSpeed = col.gameObject.playerSpeed * 2;
            playerSpeed = 0;
            hasCollided = true;
        } else {
            playerSpeed = -playerSpeed;
        }
    }
}
