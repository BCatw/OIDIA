using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Owner
{
    public string ValueType;
    public int Value;
}

public class GameCalculate : MonoBehaviour
{
    [SerializeField] int[] int_DoorsNow = new int[4];
    [SerializeField] bool bool_IsDoorOpen;
    [SerializeField] static public int int_HomeCount;
    [SerializeField] static public int int_CandyCount;
    [SerializeField] bool[] bool_IsLivedFurry = new bool[4] { true,true,false,false};
    [SerializeField] int int_HomeThisRound;
    [SerializeField] int[] int_CandyRange = new int[2];
    [SerializeField] static public float float_GameTime = 60;
    [SerializeField] bool bool_GameOn;
    [SerializeField] Owner[] owners = new Owner[5];
    [SerializeField] int int_OwnerThisRound;
    [SerializeField] int int_MaxCandy;
    [SerializeField] Vector2 vector2_MaskMaxPosition;
    [SerializeField] GameObject gameObject_Mask;

    static public event CustomizedEvent.NoneValueEvent IChangeHouse;
    static public event CustomizedEvent.IntValueEvent ICreateHouse;
    static public event CustomizedEvent.NoneValueEvent IGameOn;
    static public event CustomizedEvent.NoneValueEvent IGameOver;
    static public event CustomizedEvent.IntValueEvent IDoorOpen;

    #region

    void Update()
    {
        if (bool_GameOn && float_GameTime > 0)
        {
            float_GameTime -= Time.deltaTime;
        }
        else if(bool_GameOn && float_GameTime <= 0)
        {
            GameOver();
            float_GameTime = 0;
        }
        gameObject_Mask.transform.position = vector2_MaskMaxPosition * int_CandyCount / int_MaxCandy;
    }

    void Awake ()
    {
        //註冊控制事件
        PlayerController.IPlayerDrag += OnDrag;
        PlayerController.IPlayerTap += OnTap;
    }

    //解除註冊事件
    void OnDestroy()
    {
        PlayerController.IPlayerDrag -= OnDrag;
        PlayerController.IPlayerTap -= OnTap;
    }
    #endregion

    void OnTap()
    {
        if (!bool_GameOn)
        {
            GameOn();
        }
        else if (bool_GameOn)
        {
            switch (bool_IsDoorOpen)
            {
                case true:
                    break;

                case false:
                    bool_IsDoorOpen = !bool_IsDoorOpen;
                    OnActive();
                    break;
            }
        }
    }

    void OnDrag(float angle)
    {
        if (bool_GameOn)
        {
            OnChangeHome();
        }
    }

    void OnChangeHome()
    {
        int_HomeCount += 1;
        int_HomeThisRound = Random.Range(0, bool_IsLivedFurry.Length-1);
        bool_IsDoorOpen = false;
        IChangeHouse();
    }

    void OnActive()
    {
        int_OwnerThisRound = Random.Range(0, owners.Length);
        Debug.Log("ThisRound: " + int_OwnerThisRound + "/ Type: " + owners[int_OwnerThisRound].ValueType + "/ Value: " + owners[int_OwnerThisRound].Value);

        IDoorOpen(owners[int_OwnerThisRound].Value);

        switch (owners[int_OwnerThisRound].ValueType)
        {
            case "Candy":
                int_CandyCount += owners[int_OwnerThisRound].Value;
                if (int_CandyCount <= 0)
                {
                    int_CandyCount = 0;
                }
                break;
            case "Time":
                float_GameTime += owners[int_OwnerThisRound].Value;
                break;
        }
    }

    void GameOn()
    {
        bool_GameOn = true;
        IGameOn();
    }

    void GameOver()
    {
        bool_GameOn = false;
        IGameOver();
    }
}