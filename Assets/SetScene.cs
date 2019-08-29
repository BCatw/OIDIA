using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScene : MonoBehaviour
{
    [SerializeField] GameObject gObj_Element_;
    [SerializeField] List<GameObject> gObj_Pannels_;
    [SerializeField] List<Pannel> Pannel_Info_;
    [SerializeField] int i_PannelCount_;
    [SerializeField] Color32[] PannelSort = new Color32[3];
    
    void Awake()
    {
        for(int i = 0; i < i_PannelCount_; i++)
        {
            gObj_Pannels_.Add(Instantiate(gObj_Element_, this.transform));
            int x = Random.Range(0, 3);
            Pannel_Info_.Add(gObj_Pannels_[i].GetComponent<Pannel>().SetPannel(x, PannelSort[x]));
        }
        gObj_Element_.SetActive(false);
    }
}
