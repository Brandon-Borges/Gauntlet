using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
	public void AddItem(InventoryItem item)
	{
		Debug.Log("Adding item to the cloud save version");
	}
	public void RemoveItem(InventoryItem item)
	{
		Debug.Log("Removing item to the cloud save version");
	}
	public List<InventoryItem> GetInventory()
	{
		Debug.Log("Returning an inventory item from the cloud version");
		return new List<InventoryItem>();
	}

}
