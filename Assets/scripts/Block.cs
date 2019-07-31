using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // config prams
    [SerializeField] AudioClip BreakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] HitSprites;

    // cached reference
    Level level;
    GameStatus gameStatus;
    //states
    [SerializeField] int timesHit; //Only serialized for debug

    private void Start()
    {
        CountBreakableBlocks();
    }
    private void CountBreakableBlocks()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        level = FindObjectOfType<Level>();
        if (tag != "Unbreakable")
        {
            level.CountBreakableBlocks();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag != "Unbreakable")
        {
            HandleHit();
        }


    }
    private void HandleHit()
    {
        timesHit++;
        int maxHits = HitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }

    }
    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (HitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = HitSprites[spriteIndex];
        }
        else
        {
            UnityEngine.Debug.LogError("block sprite is missing from array"+ gameObject.name);   
        }
    }
    private void TriggerSparklesVFX()
    {
            GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
            Destroy(sparkles, 1f);
       
    }
    private void PlayBlockDestroySFX()
    {
        gameStatus.AddToScore();
        AudioSource.PlayClipAtPoint(BreakSound, Camera.main.transform.position);
    }
    private void DestroyBlock()
    {  
            PlayBlockDestroySFX();
            Destroy(gameObject);
            TriggerSparklesVFX();
            level.BlockDestroyed();
      
    }
}
