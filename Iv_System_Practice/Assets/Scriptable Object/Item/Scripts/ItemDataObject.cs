using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Inventory", menuName = "Inventory System/Items/Database")]
public class ItemDataObject : ScriptableObject , ISerializationCallbackReceiver
{
    public ItemObject[] Items;
    public Dictionary<int,ItemObject> GetItem = new Dictionary<int, ItemObject>();


    public void OnAfterDeserialize()
    {

        
        for(int i=0; i< Items.Length; i++)
        {
            Items[i].Id = i;
            GetItem.Add(i,Items[i]);
        }
    }

    public void OnBeforeSerialize()
    {
        GetItem = new Dictionary<int, ItemObject>();
    }
}
