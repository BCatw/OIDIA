using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Visualize : MonoBehaviour
{
    [SerializeField] Text text_Timer;
    [SerializeField] GameObject gameObject_StartMask;
    [SerializeField] GameObject gameObject_Tutorial;
    [SerializeField] Text text_CandyCount;
    [SerializeField] Text text_HouseCount;
    [SerializeField] GameObject gameObject_TimeUp;

    void Awake()
    {
        GameCalculate.IGameOn += OnGameOn;
        GameCalculate.IGameOver += OnGameOver;
    }

    void FixedUpdate()
    {
        text_CandyCount.text = "Candy: " + GameCalculate.int_CandyCount;
        text_HouseCount.text = "House: " + GameCalculate.int_HomeCount;
    }

    void OnGameOn()
    {
        gameObject_StartMask.SetActive(false);
        gameObject_Tutorial.SetActive(false);
    }
    void OnGameOver()
    {
        gameObject_StartMask.SetActive(false);
        gameObject_TimeUp.SetActive(true);
    }
    
    void Update()
    {
        int m = Mathf.FloorToInt(GameCalculate.float_GameTime / 60);
        int s = Mathf.FloorToInt(GameCalculate.float_GameTime % 60);
        text_Timer.text = s>=10? m + " : " + s : m +" : 0" +s;
    }
}