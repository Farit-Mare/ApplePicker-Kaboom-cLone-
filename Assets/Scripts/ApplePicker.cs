using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    public GameObject basketPrefab;
    public int numBasket = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i =0; i<numBasket; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AppleDestroyed()
    {
        //Delet all falling apples
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach(GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }
        //Delet 1 basket
        //Get index of last basket from basketList
        int basketIndex = basketList.Count - 1;
        //Get url on this basket obj
        GameObject tBasketGO = basketList[basketIndex];
        //Delete basket from list and del game obj
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        //When we lose 3 basket restart game
        if (basketList.Count == 0)
            SceneManager.LoadScene("Scene_1");
    }

}
