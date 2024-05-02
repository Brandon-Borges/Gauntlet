using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystemAdapter : InventorySystem, IInventorySystem
{
	private List<InventoryItem> _cloudInventory;

	public void SyncInventories()
	{
		var _cloudInventory = GetInventory();

		Debug.Log("Synchronizing local drive and cloud inventories");
	}

	public void AddItem(InventoryItem item, SaveLocation location)
	{
		if (location == SaveLocation.Cloud)
			AddItem(item);

		if (location == SaveLocation.Local)
			Debug.Log("Adding item to local version");
		if (location == SaveLocation.Both)
			Debug.Log("Adding item to the local and the cloud version");


	}

	public void RemoveItem(InventoryItem item, SaveLocation location)
	{
		Debug.Log("Remove item from local/Cloud/Both");
	}
	public List<InventoryItem> GetInventory(SaveLocation location)
	{
		Debug.Log("Get inventory local/cloud/both");

		return new List<InventoryItem>();
	}
}
