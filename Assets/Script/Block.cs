using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    //Config parameters
    [SerializeField] AudioClip breakBlockSound;
    [SerializeField] AudioClip hitBlockSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;
   
    //Cached reference
    Level level;
    GameSession gamesession;

    //State variables
    [SerializeField] int timeHits; // only serialized for debug purpose

    private void Start()
    {
        CountBreakableBlocks();
        gamesession = FindObjectOfType<GameSession>();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();//call class level and have access to its public method.
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //in order not to destroy breakBlockSound, use PlayClipAtPoint method
        if(tag == "Breakable")
        {
            HandleHit();

        }

    }

    private void HandleHit()
    {
        timeHits++;
        int maxHits = hitSprites.Length + 1;

        if (timeHits >= maxHits)
        {
            DestroyBLock();
        }

        else 
        {
            AudioSource.PlayClipAtPoint(hitBlockSound, Camera.main.transform.position);
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
       
        int spriteIndex = timeHits - 1;

        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }

        else
        {
            Debug.LogError("Blcok Sprite is missing from array"+gameObject.name);
        }

    }

    private void DestroyBLock()
    {
        PlayBlockDestroySFX();
        level.BlockDestroyed();
        Destroy(gameObject, 0f);
        TriggerSparklesVFX();
    }

    private void PlayBlockDestroySFX()
    {
        gamesession.AddToScore();
        AudioSource.PlayClipAtPoint(breakBlockSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 0.8f);
    }
}
