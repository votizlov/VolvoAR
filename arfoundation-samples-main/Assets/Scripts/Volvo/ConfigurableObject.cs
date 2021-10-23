using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigurableObject : GUIObject
{
    public int[] AdditionalCost;
    public string[] Tags;
    public int initState;
    public int currentState;

    void Awake(){
        if(AdditionalCost.Length!=Tags.Length){
            Debug.LogError("Wrong arrays length");
        }
    }

    public virtual void Change(int index){
        if(index>AdditionalCost.Length || index<0)
            return;
    }
}
