using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation.Samples;

public class ARSceneController : MonoBehaviour
{
    [SerializeField]
    UnityEvent OnCarSpawned;
    [SerializeField]
    UnityEvent OnCarCleared;
    public void SetCarView(bool isCarSpawned){
        UnityEngine.XR.ARFoundation.Samples.Logger.Log("OnCarSpawned " + isCarSpawned);
        if(isCarSpawned)
            OnCarSpawned?.Invoke();
        else
            OnCarCleared?.Invoke();
    }
}
