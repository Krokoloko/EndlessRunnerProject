using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Rigidbody2D CameraRB_;
    public PlayerScript stalking;
    private float cameraSpeed;

    void Start()
    {
        CameraRB_ = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        setSpeed();
    }

    void LateUpdate ()
    {
        CameraRB_.velocity = new Vector3(cameraSpeed,
                                         transform.position.y,
                                         transform.position.z);
    }

    void setSpeed()
    {
       if (cameraSpeed <= stalking.PlayerPhysics_.velocity.x)
       {
           cameraSpeed = stalking.PlayerPhysics_.velocity.x;
            print(cameraSpeed);
       }
    }


}
