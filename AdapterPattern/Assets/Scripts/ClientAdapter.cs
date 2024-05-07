using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientAdapter : MonoBehaviour
{
    public InventoryItem item;

    private InventorySystem _inventorySystem;
    private IInventorySystem _inventoryAdapter;
    // Start is called before the first frame update
    void Start()
    {
        _inventorySystem = new InventorySystem();
        _inventoryAdapter = new InventorySystemAdapter();
    }

    // Update is called once per frame
    void OnGUI()
    {
        if (GUILayout.Button("Add item (no adapter")) 
        _inventorySystem.AddItem(item);
        if (GUILayout.Button("Add item (with adapter"))
            _inventoryAdapter.AddItem(item, SaveLocation.Both);
            
	}
}
