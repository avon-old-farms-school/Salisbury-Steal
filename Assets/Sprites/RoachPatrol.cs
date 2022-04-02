using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoachPatrol : MonoBehaviour
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
        this.transform.position = new Vector3(this.transform.position.x + speed, 
                                            this.transform.position.y,
                                            this.transform.position.z); 
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "wall") {
            speed *= -1;
            Debug.Log("wall!");
        }

        else if(col.gameObject.tag == "playa") {
            Destroy(this.gameObject);
        }
    }
}
