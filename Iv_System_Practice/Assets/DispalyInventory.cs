using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using TMPro;
public class DispalyInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEM;
    public int NUMBER_OF_COLUMN;
    public int Y_SPACE_BETWEEN_ITEM;
    Dictionary<InventorySlot,GameObject> itemDisplayed = new Dictionary<InventorySlot, GameObject>(); 
    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateDisplay();
    }

    public void CreateDisplay()
    {
        for(int i=0; i<inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.perfab,Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMesh>().text = inventory.Container[i].amount.ToString("n0");
        }
    }

    public Vector3 GetPosition(int i )
    {
        return new Vector3(X_START+(X_SPACE_BETWEEN_ITEM *(i % NUMBER_OF_COLUMN)),Y_START+(-Y_SPACE_BETWEEN_ITEM *(i/NUMBER_OF_COLUMN)),0);
    }
}
