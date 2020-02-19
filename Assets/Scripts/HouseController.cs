using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour
{
    [SerializeField] GameObject[] gameObject_Houses = new GameObject[4];
    [SerializeField] Transform[] transform_Houses = new Transform[5];
    [SerializeField] Vector3 vector3s_HouseOffser;
    [SerializeField] GameObject prefab_HouseDefault;
    [SerializeField] GameObject gameObject_Owner;
    [SerializeField] bool bool_IsChanging = false;
    [SerializeField] float float_MovingTime;
    [SerializeField] GameObject prefab_Owner;

    void Awake()
    {
        for(int n = 0; n < gameObject_Houses.Length; n++)
        {
            OnCreateHouse(n);
        }
        GameCalculate.IChangeHouse += HouseChange;
        GameCalculate.IDoorOpen += OnDoorOpen;

    }

    //在第 value1 個房子創造一個外觀是 value2 的房子
    void OnCreateHouse(int value)
    {
        gameObject_Houses[value] = Instantiate(prefab_HouseDefault, transform_Houses[value + 1].position, Quaternion.identity, this.transform);
        Instantiate(prefab_Owner, gameObject_Houses[value].transform);
    }
    
    void Update()
    {
        //在移動的時候移動房子
        if (bool_IsChanging)
        {
            for (int i = 0; i < gameObject_Houses.Length; i++)
            {
                gameObject_Houses[i].transform.position += vector3s_HouseOffser * Time.deltaTime / float_MovingTime;
            }
        }
    }

    //移動房子，新增刪除房子
    void HouseChange()
    {
        if (!bool_IsChanging)
        {
            StartCoroutine("HouseMoving");
        }
    }

    IEnumerator HouseMoving()
    {
        bool_IsChanging = true;
        yield return new WaitForSeconds(float_MovingTime);

        Destroy(gameObject_Houses[0]);
        for (int i = 0; i < gameObject_Houses.Length; i++)
        {
            gameObject_Houses[i].transform.position = transform_Houses[i].position;
        }
        for (int x = 0; x < gameObject_Houses.Length - 1; x++)
        {
            gameObject_Houses[x] = gameObject_Houses[x + 1];
        }

        OnCreateHouse(3);

        bool_IsChanging = false;
    }

    //開門
    void OnDoorOpen(int value)
    {
        gameObject_Owner = gameObject_Houses[1].transform.GetChild(0).gameObject;
        gameObject_Owner.SendMessage("SetSprite",value);
    }
}