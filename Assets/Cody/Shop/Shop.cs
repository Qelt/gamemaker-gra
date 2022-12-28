using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public shopSave shopsave = new shopSave();
    [SerializeField] GameObject buyButtonitem1;
    [SerializeField] GameObject setButtonitem1;
    [SerializeField] GameObject buyButtonitem2;
    [SerializeField] GameObject setButtonitem2;
    [SerializeField] GameObject buyButtonitem3;
    [SerializeField] GameObject setButtonitem3;

public void Awake()
{
    shopLoadFromJson();
    item1Start();
    item2Start();
    item3Start();
    setButtonitem1.SetActive(false);
}

void Start()
{
    item1Start();
    item2Start();
    item3Start();
}

public void shopSaveToJson()
{     
    string shopData = JsonUtility.ToJson(shopsave);
    string filePath = Application.persistentDataPath + "/ShopSave.json";
    Debug.Log(filePath);
    System.IO.File.WriteAllText(filePath, shopData);
    Debug.Log("Save Sukces");
}

public void shopLoadFromJson()
{
    string filePath = Application.persistentDataPath + "/ShopSave.json";
    string shopData = System.IO.File.ReadAllText(filePath);

    shopsave = JsonUtility.FromJson<shopSave>(shopData);
    Debug.Log("Sukces Load Shop Data");
}

public void item1()
{
    shopsave.boughtItem1 = true;
    item1Start();
}
public void item2()
{
    shopsave.boughtItem2 = true;
    item2Start();
}
public void item3()
{
    shopsave.boughtItem3 = true;
    item3Start();
}


void item1Start()
{
    if (shopsave.boughtItem1 == true)
    {
        buyButtonitem1.SetActive(false);
        setButtonitem1.SetActive(true);
    }else if (shopsave.boughtItem1 == false)
    {
        buyButtonitem1.SetActive(true);
        setButtonitem1.SetActive(false);
    }
}
void item2Start()
{
    if (shopsave.boughtItem2 == true)
    {
        buyButtonitem2.SetActive(false);
        setButtonitem2.SetActive(true);
    }else if (shopsave.boughtItem2 == false)
    {
        buyButtonitem2.SetActive(true);
        setButtonitem2.SetActive(false);
    }
}
void item3Start()
{
    if (shopsave.boughtItem3 == true)
    {
        buyButtonitem3.SetActive(false);
        setButtonitem3.SetActive(true);
    }else if (shopsave.boughtItem3 == false)
    {
        buyButtonitem3.SetActive(true);
        setButtonitem3.SetActive(false);
    }
}


}

[System.Serializable]
public class shopSave
{
    public bool boughtItem1;
    public bool boughtItem2;
    public bool boughtItem3;

}