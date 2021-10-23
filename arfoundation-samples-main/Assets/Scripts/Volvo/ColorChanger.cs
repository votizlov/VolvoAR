using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    [SerializeField]Color[] colors;
    private Button button;
    private int currentColor;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in FindObjectsOfType<Button>())
        {
            if(item.gameObject.name == "ChangeColor")
                item.GetComponent<Button>().onClick.AddListener(ChangeColor);
        }

    }

    private void ChangeColor(){
        currentColor++;
        if(currentColor>=colors.Length){
            currentColor = 0;
        }
        GetComponent<MeshRenderer>().material.color = colors[currentColor];
    }
}
