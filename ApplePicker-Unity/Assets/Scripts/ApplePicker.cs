using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPreFab;
    public int numBaskets =3;
    public float basketBottomY=-14f;
    public float basketSpacingY=2f;
    public List<GameObject> basketList;

    // Start is called before the first frame update
    void Start()
    {
        basketList= new List<GameObject>();
        for (int i=0; i<numBaskets; i++){
            GameObject tBasketGO = Instantiate<GameObject>(basketPreFab);
            Vector3 pos= Vector3.zero;
            pos.y = basketBottomY +(basketSpacingY*i);
            tBasketGO.transform.position=pos;
            basketList.Add(tBasketGO);
        }
        
    }
    public void AppleDestroyed(){
        //GameObject[] tAppleArray=GameObject.FindGameObjectWithTag("Apple");
        //foreach (GameObject tGO in tAppleArray){
        //    Destroy(tGO);
       // }
        int basketIndex = basketList.Count-1;
        GameObject tBasketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
