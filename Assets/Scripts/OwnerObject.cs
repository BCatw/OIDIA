using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnerObject : MonoBehaviour
{
    [SerializeField] Sprite[] sprites_Treat = new Sprite[3];
    [SerializeField] Sprite[] sprites_Trick = new Sprite[3];
    [SerializeField] Sprite sprite_Owner;
    [SerializeField] Sprite[] sprites_Door;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites_Door[Random.Range(0, sprites_Door.Length - 1)];
    }

    void SetSprite(int value)
    {
        int n = Random.Range(0, 3);

        Debug.Log("Owner: " + value);

        if(value > 0)
        {
            spriteRenderer.sprite = sprites_Treat[n];
        }else if (value < 0)
        {
            spriteRenderer.sprite = sprites_Trick[n];
        }
        //spriteRenderer.sprite = value > 0 ? sprites_Treat[n] : sprites_Trick[n];
    }
}
