using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaBotao : MonoBehaviour
{
    private SpriteRenderer renderSprite, spriteRenderer;

    void Start ()
    {
        renderSprite = GameObject.Find ("botões_0").GetComponent<SpriteRenderer>();
        spriteRenderer = GameObject.Find ("botões_1").GetComponent<SpriteRenderer>();
    }
 
    void OnTriggerEnter2D (Collider2D col)
    {
        renderSprite.GetComponent<SpriteRenderer>().enabled = false;
        spriteRenderer.GetComponent<SpriteRenderer>().enabled = true;
    }
    
}
