using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Rigidbody2D CameraRB_;
    public PlayerScript stalking;
    public GameObject player; 
    public float deathHeight;
    public float deathDistence;
    private float cameraSpeed;
    

    void Start()
    {        
        CameraRB_ = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        setSpeed();
        checkOutsideCamera();
    }

    void LateUpdate ()
    {
        CameraRB_.velocity = new Vector3(cameraSpeed - (cameraSpeed / 85),
                                         transform.position.y,
                                         transform.position.z);
    }

    void checkOutsideCamera()
    {
        if (player.transform.position.x < transform.position.x + deathDistence || player.transform.position.y > transform.position.y + deathHeight)
        {
            print("Game over");
        }
    
    }
    private void setSpeed()
    {
       if (cameraSpeed <= stalking.PlayerPhysics_.velocity.x)
       {
           cameraSpeed = stalking.PlayerPhysics_.velocity.x;
            print(cameraSpeed);
       }
    }


}
