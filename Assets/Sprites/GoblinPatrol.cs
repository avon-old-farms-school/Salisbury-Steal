using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinPatrol : MonoBehaviour
{

    [SerializeField] 
    private float speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(this.transform.position.x , 
                                            this.transform.position.y+speed,
                                            this.transform.position.z); 
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "wall") {
            speed *= -1;
            Debug.Log("wall!");
        }

        else if(col.gameObject.tag == "playa") {
            GameObject playa = GameObject.FindGameObjectsWithTag("playa")[0];
            Destroy(playa);
        }
    }
}
