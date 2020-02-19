using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizedEvent : MonoBehaviour
{
    public delegate void NoneValueEvent();
    public delegate void FloatValueEvent(float value);
    public delegate void IntValueEvent(int value);
    public delegate void DoubleIntValueEvent(int value1, int value2);
    public delegate IEnumerator IntValueuEvent(int value);
}
