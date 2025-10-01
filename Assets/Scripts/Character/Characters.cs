using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum characters { happy,sad,mad,angry,hatey,bomby,evily };

public class Characters : MonoBehaviour
{
    public characters charct; // Type of Character
    [HideInInspector]
    public int level;

    [SerializeField]
    Material[] charSprites;
    
    [SerializeField]
    MeshRenderer charRenderer;

    bool hit = true;
    private void Awake()
    {

        SetCharacterFunctionality(charct);
        
    }

    private void OnEnable()
    {
        //charRenderer = GetComponent<MeshRenderer>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(hit)
        {
            hit = false;
            //Hit by Happy OR Player
            Characters character = collision.gameObject.GetComponent<Characters>();
            
            if (collision.gameObject.tag == "Player" )
            {
                if (level > 1)
                {
                    level--;
                    SetCharacterFunctionality((characters)level - 1);
                }

            }

            if (character)
            {
                //Hit By Happy
                if (character.level == 1)
                {
                    if (level > 1)
                    {
                        level--;
                        SetCharacterFunctionality((characters)level - 1);
                    }

                }


                //Hit By Hatey
                if (character.level == 5)
                {
                    if (level > 1)
                    {
                        SetCharacterFunctionality(characters.hatey);
                    }

                }

                //Hit by Bomby
                if (character.level == 6)
                {
                    Destroy(character.gameObject);
                    Destroy(gameObject);
                }
            }
        }

        StartCoroutine(TimeBeforeHitAgain());
        

        
    }

    IEnumerator TimeBeforeHitAgain()
    {
        yield return new WaitForSeconds(0.1f);
        hit = true;
    }
    void SetCharacterFunctionality(characters character)
    {
        switch (character)
        {
            case characters.happy: level = 1;
                charRenderer.sharedMaterial = charSprites[0];
                break;

            case characters.sad: level = 2;
                charRenderer.sharedMaterial = charSprites[1];
                break;

            case characters.mad:
                level = 3;
                charRenderer.sharedMaterial = charSprites[2];
                break;

            case characters.angry:
                level = 4;
                charRenderer.sharedMaterial = charSprites[3];
                break;

            case characters.hatey:
                level = 5;
                charRenderer.sharedMaterial = charSprites[4];
                break;

            case characters.bomby:
                level = 6;
                charRenderer.sharedMaterial = charSprites[5];
                break;

        }

    }

    private void OnMouseDown()
    {
        if(GameCanvasManager.instance.tapKill)
        {
            SetCharacterFunctionality(characters.happy);
            GameCanvasManager.instance.tapKill = false;
        }
    }

    private void OnDestroy()
    {
        if(charct == characters.bomby)
        {
            //Play Bomb Animation
        }
    }
}
