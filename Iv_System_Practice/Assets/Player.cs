using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryObject inventory;
    
    public void OnTriggerEnter(Collider other) {
        var item = other.GetComponent<GroundItem>();
        if(item)
        {
            inventory.AddItem(new Item(item.item),1);
            Destroy(other.gameObject);
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            inventory.Save();
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            inventory.Load();
        }
    }

    private void OnApplicationQuit()
    {
      inventory.Container.Items.Clear();
    }
}
