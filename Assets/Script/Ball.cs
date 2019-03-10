﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    //config parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f, yPush = 10f;
    [SerializeField] AudioClip clickSound;
    [SerializeField] float randomFactor = 0.2f;

    // state
    Vector2 paddleToBallVector;
    public bool hasClicked = false;


    //Cache component references
    AudioSource myAudioSource;
    Rigidbody2D  myRigidBody2D;

    // Use this for initialization
    void Start () {
        paddleToBallVector = transform.position-paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        if (!hasClicked)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }

    }
    private void LockBallToPaddle(){

        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;

    }

    private void LaunchOnMouseClick(){

        if (Input.GetMouseButtonDown(0))
        {
            hasClicked = true;

            myAudioSource.PlayOneShot(clickSound);
            myRigidBody2D.velocity = new Vector2(xPush, yPush);

        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f,randomFactor), Random.Range(0f, randomFactor));
        if (hasClicked)
        {
            myRigidBody2D.velocity += velocityTweak;
        }
       
    }
}
