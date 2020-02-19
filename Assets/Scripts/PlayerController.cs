using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Vector2 vector2_StartPosit;
    [SerializeField] Vector2 vector2_EndPosit;
    [SerializeField] float float_Timer;
    [SerializeField] float float_Threshold;
    [SerializeField] bool bool_IsDonwn;

    static public event CustomizedEvent.NoneValueEvent IPlayerTap;
    static public event CustomizedEvent.FloatValueEvent IPlayerDrag;
    
    //壓著的時候計時
    void Update()
    {
        if (bool_IsDonwn)
        {
            float_Timer += Time.deltaTime;
        }
    }
    
    void InputDetermine()
    {
        //時間超過 float_Threshold 就判斷是滑動
        if (Mathf.Abs(vector2_EndPosit.x -vector2_StartPosit.x) >= 100)
        {
            float angle = Vector2.Angle(vector2_StartPosit.normalized, vector2_EndPosit.normalized);
            IPlayerDrag(angle);
            float_Timer = 0;
        }
        else
        {
            IPlayerTap();
            float_Timer = 0;
        }
        
    }

    //手指下
    public void OnPointerDown(PointerEventData eventData)
    {
        bool_IsDonwn = true;
        vector2_StartPosit = Input.mousePosition;
    }

    //手指上
    public void OnPointerUp(PointerEventData eventData)
    {
        bool_IsDonwn = false;
        vector2_EndPosit = Input.mousePosition;
        InputDetermine();
    }
}