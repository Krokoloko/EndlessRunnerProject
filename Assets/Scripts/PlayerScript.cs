using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    enum states { beginJump, midJump, uppperMomentum, falling, landing, running, dead, idle };

    public float _Speed_;
    public float maxFallspeed;
    public float xSpeed;
    public float ySpeed;
    [SerializeField]
    private float gravityForce;
    [SerializeField]
    private float maxHeight;
    private float originalPos;
    private states playerState;
    private Vector2 res;



    private SpriteRenderer Character_;
    private Collider2D PlayerCollision_;
    public Rigidbody2D PlayerPhysics_;


    void Start () {
        Character_ = GetComponent<SpriteRenderer>();
        PlayerCollision_ = GetComponent<Collider2D>();
        PlayerPhysics_ = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        PlayerPhysics_.velocity = new Vector2(xSpeed * _Speed_, PlayerPhysics_.velocity.y);

        //print(PlayerPhysics_.velocity.y);
        switch (playerState)
        {
            case states.uppperMomentum:
                jump();
                //print(playerState);
                break;
            case states.running:
                originalPos = transform.position.x;
                jump();
                //print(playerState);
                break;
            case states.falling:
                falling(maxFallspeed);
                checkGround();
                //print(playerState);
                break;
            case states.landing:
                //print(playerState);
                break;
            default:
                playerState = states.falling;
                //print(playerState);
                break;

        }
    }


    void falling(float max)
    {
            //res = Vector2.down * gravityForce *_Speed_;
            PlayerPhysics_.AddForce(Vector2.down * gravityForce * _Speed_);
            if (PlayerPhysics_.velocity.y <= max)
            {
                PlayerPhysics_.velocity = new Vector2(PlayerPhysics_.velocity.x, maxFallspeed);
            }
    }

    void checkGround()
    {
        if(PlayerPhysics_.velocity.y == 0)
        {
            playerState = states.running;
        }
    }

    void jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            print("pressing");
            //PlayerPhysics_.AddForce(Vector2.up * ySpeed * _Speed_);
            PlayerPhysics_.velocity = new Vector2(PlayerPhysics_.velocity.x, ySpeed * _Speed_);
            //res = Vector2.up * jumpPower *_Speed_;
            playerState = states.uppperMomentum;

        }
        if (Input.GetKeyUp(KeyCode.Space) || (originalPos + maxHeight) <= transform.position.x)
        {
            print("released");
            //res = Vector2.down * gravityForce *_Speed_;
            playerState = states.falling;
        }

    }
}
