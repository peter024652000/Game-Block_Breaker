using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {
    //config parameters
    [Range(0.1f,10f)][SerializeField] float gameSpeed = 0.7f;
    [SerializeField] int HpPerBlockDestroyed = 10;
    [SerializeField] TextMeshProUGUI bossCurrentHp;
    [SerializeField] TextMeshProUGUI bossMaxHp;
    [SerializeField] bool isAutoPlayEnabled;

    //State varible
    [SerializeField] int currentHp = 0;

    //Cache reference
    Level myLevel;
    Life myLife;

    private void Awake()
    {
        //For accumulate life status (InTest)
        /*myLife = FindObjectOfType<Life>();
        int lifeCount = FindObjectsOfType<Life>().Length;
        if (lifeCount > 1)
        {
            myLife.gameObject.SetActive(false);
            Destroy(myLife.gameObject);
        }
        else
        {
            DontDestroyOnLoad(myLife.gameObject);
        }*/

        //For accumulate all status
        /*int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount>1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }*/
    }

    // Use this for initialization
    public int Start() 
    {
        myLevel = FindObjectOfType<Level>();
        currentHp = myLevel.breakableBlocks* HpPerBlockDestroyed;
        bossCurrentHp.text = (myLevel.breakableBlocks* HpPerBlockDestroyed).ToString();
        bossMaxHp.text = (myLevel.breakableBlocks* HpPerBlockDestroyed).ToString();
        return currentHp;
	}
	
	// Update is called once per frame
	void Update () {
        Time.timeScale = gameSpeed;

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void DamageToBoss()
    {
        currentHp -= HpPerBlockDestroyed;
        bossCurrentHp.text = currentHp.ToString();
    }


    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
;