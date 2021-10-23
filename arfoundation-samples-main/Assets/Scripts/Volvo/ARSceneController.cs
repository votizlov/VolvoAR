using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ARSceneController : MonoBehaviour
{
    [SerializeField]
    UnityEvent OnCarSpawned;
    [SerializeField]
    UnityEvent OnCarCleared;
    public void SetCarView(bool isCarSpawned){
        if(isCarSpawned)
            OnCarSpawned?.Invoke();
        else
            OnCarCleared?.Invoke();
    }
}
