using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]GameObject GUIButton;
    [SerializeField]Transform MenuRoot;
    [SerializeField]Text CostText;
    private string currentPath = string.Empty;

    public void OnRepaint(){
        for(int i = 0;i<MenuRoot.childCount;i++)
        {
            Destroy(MenuRoot.GetChild(i));
        }

        foreach (var GUIObject in FindObjectsOfType<GUIObject>())
        {
            if(GUIObject.Path.Contains(currentPath)){
                var t = Instantiate(GUIButton,MenuRoot);
                t.GetComponent<SpriteRenderer>().sprite = GetIconFromAssetBundle(GUIObject.Path);
            }
        }
    }
    public void TryGoUp(){

    }

    public void TryGoDown(string newPath){
        
    }
    public void CalculateTotalCost(){
        CostText.text = string.Empty;

        var carData = FindObjectOfType<CarDataContainer>();
        if(carData==null)
            return;

        int totalCost = carData.BaseCost;

        foreach (var confObject in FindObjectsOfType<ConfigurableObject>())
        {
            totalCost+=confObject.AdditionalCost[confObject.currentState];
        }
        CostText.text = totalCost.ToString();
    }

    private Sprite GetIconFromAssetBundle(string tag){
        //AssetBundle.LoadAsset
        return null;
    }
}
