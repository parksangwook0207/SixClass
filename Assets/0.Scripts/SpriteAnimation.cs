using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using UnityEngine.UI;
//[RequireComponent(typeof(SpriteRenderer))] 

public class SpriteAnimation : MonoBehaviour
{
    private List<Sprite> sprites = new List<Sprite>();
    private SpriteRenderer sr;
    private Image image;

    private float spriteDelayTime;
    private float delayTime = 0f;

    private int spriteAnimationIndex = 0;

    private UnityAction action = null;

    public bool isCanvas = false;

    private void Start()
    {      
       
        if(isCanvas)
            image = GetComponent<Image>();
        else
            sr = GetComponent<SpriteRenderer>();
       
    }
    private void Update()
    {
        if (sprites.Count == 0)
        {
            return;
        }
        delayTime += Time.deltaTime;
        if (delayTime > spriteDelayTime)
        {
            delayTime = 0;
            if (isCanvas)
            {
                sr.sprite = sprites[spriteAnimationIndex];
                spriteAnimationIndex++;
            }
             if(isCanvas)
                 image.sprite = sprites[spriteAnimationIndex];
             else
                 sr.sprite = sprites[spriteAnimationIndex];
             spriteAnimationIndex++;
            

            if (spriteAnimationIndex > sprites.Count - 1)
            {
                if (action == null)
                    spriteAnimationIndex = 0;
                else
                {
                    sprites.Clear();
                    action();
                    action = null;
                }
            }
        }
    }

    void Init()
    {
        delayTime = float.MaxValue;
        sprites.Clear();
        spriteAnimationIndex = 0;
    }

    public void SetSprite(List<Sprite> argSprites, float delayTime)
    {
        Init();
        sprites = argSprites.ToList();
        spriteDelayTime = delayTime;
    }
                                                     // 오버라이드
    public void SetSprite(List<Sprite> argSprites, float delayTime, UnityAction action)
    {
        Init();
        this.action = action;
        sprites = argSprites.ToList();
        spriteDelayTime = delayTime;
    }

    IEnumerator ReturnSprite(List<Sprite> argSprites, float delayTime)
    {
        yield return new WaitForSeconds(0.01f);
        SetSprite(argSprites, delayTime);
    }
}
