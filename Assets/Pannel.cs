using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Pannel : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] int i_PannelSort_;
    [SerializeField] bool b_IsFliped_;
    [SerializeField] Color32 color_Pannel_;
    [SerializeField] Image image_Pannel_;
    
    // Start is called before the first frame update
    void Awake()
    {
        image_Pannel_ = GetComponent<Image>();
    }

    public Pannel SetPannel(int i, Color32 c)
    {
        i_PannelSort_ = i;
        color_Pannel_ = c;
        return this;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        switch (b_IsFliped_)
        {
            case true:
                Debug.Log("It's Fliped");
                break;
            case false:
                PannelFlip();
                break;
        }
    }

    void PannelFlip()
    {
        switch (i_PannelSort_)
        {
            case 0:
                Debug.Log("Battle");
                break;
            case 1:
                Debug.Log("Nothing");
                break;
            case 2:
                Debug.Log("Material");
                break;
        }
        image_Pannel_.color = color_Pannel_;
        b_IsFliped_ = true;
    }
}
