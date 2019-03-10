using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {

    //Configuration Parameter
    [SerializeField] AudioClip loseSound;


    //Cach reference
    Ball myBall;
    Life myLife;
    AudioSource myLoseSound;

    void Start()
    {
        myBall = FindObjectOfType<Ball>();
        myLife = FindObjectOfType<Life>();
        myLoseSound = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        myLoseSound.PlayOneShot(loseSound);
        myLife.DelLife();

        if (myLife.lifeLeft>=1)
        {
            myBall.hasClicked = false;

        }

        else
        {
            FindObjectOfType<GameSession>().ResetGame();
            SceneManager.LoadScene("Game Over");
        }

    }


}

