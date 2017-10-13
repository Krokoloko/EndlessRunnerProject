using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour {

    public Rigidbody2D CameraRB_;
    public PlayerScript stalking;
    public GameObject player; 
    public float deathHeight;
    public float deathDistence;
    private float cameraSpeed;
    private BoxCollider2D CamCol;
    private float deadEnd;

    void Start()
    {        
        CameraRB_ = GetComponent<Rigidbody2D>();
        CamCol = GetComponent<BoxCollider2D>();
        deathHeight = transform.position.y - (CamCol.size.y);
        deathDistence = CameraRB_.transform.position.x - (CamCol.size.x*2);
    }

    void Update()
    {
        deathDistence = CameraRB_.transform.position.x - (CamCol.size.x);
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
       /* if (player.transform.position.x < deathDistence)
        {
            print("death by dist");
            SceneManager.LoadScene("GameRunner");            
        }*/
        if(player.transform.position.y < deathHeight)
        {
            print("death by height");
            SceneManager.LoadScene("GameRunner");
        }
        print(deathDistence);

    }
    private void setSpeed()
    {
       if (cameraSpeed <= stalking.PlayerPhysics_.velocity.x)
       {
           cameraSpeed = stalking.PlayerPhysics_.velocity.x;
       }
    }


}
