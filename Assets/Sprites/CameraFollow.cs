using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private float camY, camX, camOrthSize, cameraRatio;
    private Camera mainCam;
    [SerializeField]
    private Transform followTransform;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        camY = followTransform.position.y;
        camX = followTransform.position.x;
        this.transform.position = new Vector3(camX, camY, this.transform.position.z);
    }
}
