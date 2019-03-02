using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
    //Config parameters
    [SerializeField] AudioClip wallSound;
    //Cache component reference
    AudioSource myAudioSource;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        myAudioSource.PlayOneShot(wallSound);
    }

}
