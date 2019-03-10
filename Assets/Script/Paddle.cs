using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    //configuration Parameters
    [SerializeField] float screenWidthInUnit = 16f;
    [SerializeField] float minX = 1.6f, maxX = 14.4f;
    [SerializeField] AudioClip paddleSound;


    //Cache Component Reference

    GameSession myGameSession;
    Ball myBall;
    AudioSource myAudioSource;

    //State

    // Use this for initialization
    void Start () {
        myGameSession = FindObjectOfType<GameSession>();
        myBall = FindObjectOfType<Ball>();
        myAudioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;

    }

    private float GetXPos()
    {
        if (myGameSession.IsAutoPlayEnabled()){
            return myBall.transform.position.x;
        }

        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnit;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (myBall.hasClicked == true)
        {
            myAudioSource.PlayOneShot(paddleSound);
        }
            
    }

}
