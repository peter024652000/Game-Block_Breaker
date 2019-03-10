using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour {
    //Configuration Parameter

    [SerializeField] public Image[] lifeStatus;
    [SerializeField] public Sprite[] emptyLife;
    [SerializeField] public int lifeLeft;

    private void Start()
    {
        lifeLeft = lifeStatus.Length;
    }

    public void DelLife()
    {
        lifeStatus[lifeLeft - 1].sprite = emptyLife[0];
        lifeLeft--;

    }
}
