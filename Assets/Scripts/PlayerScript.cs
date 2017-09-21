using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    enum states { beginJump, midJump, falling, landing, running, dead, idle };

    private float xSpeed;

    private Sprite Character_;
    private Collider2D PlayerCollision_;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	    	
	}

    static float addSpeed()
    {
        return;
    }
}
