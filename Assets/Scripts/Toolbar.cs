using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toolbar : MonoBehaviour {

    World world;
    public Player player;

    public RectTransform highlight;
    public ItemSlot[] itemSlots;

    int slotIndex = 0;

    private void Start()
    {
        world = GameObject.Find("World").GetComponent<World>();

        foreach (ItemSlot slot in itemSlots) {
            slot.icon.sprite = world.blockTypes[slot.ItemID].Icon;
            slot.icon.enabled = true;
        }

        player.selectedBlockIndex = itemSlots[slotIndex].ItemID;
    }

    private void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0) {
            // inverted so scroll up goes left in toolbar,            
            if (scroll > 0)
            {
                slotIndex--;
            }
            else {
                slotIndex++;
            }

            if (slotIndex > itemSlots.Length - 1) {
                slotIndex = 0;
            }
            if (slotIndex < 0) {
                slotIndex = itemSlots.Length - 1;
            }
            
            // set highlight position to be that of the selected ItemSlot icon.
            highlight.position = itemSlots[slotIndex].icon.transform.position;
            player.selectedBlockIndex = itemSlots[slotIndex].ItemID;
        }
    }
}

[System.Serializable]
public class ItemSlot {
    public byte ItemID;
    public Image icon;
}
