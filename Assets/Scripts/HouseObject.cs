using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseObject : MonoBehaviour
{
    [SerializeField] Sprite[] sprites_Houses;
    
    void Awake()
    {
        this.GetComponent<SpriteRenderer>().sprite = sprites_Houses[Random.Range(0,sprites_Houses.Length-1)];
    }
}
