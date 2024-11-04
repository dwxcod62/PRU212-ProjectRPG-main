using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    [SerializeField] private List<ItemController> LootLists = new List<ItemController>();

    ItemController GetDropItem()
    {
        int randomNumber = Random.Range(1, 100);
        List<ItemController> possibleItems = new List<ItemController>();

        // Random vat pham co the rot
        foreach (ItemController item in LootLists)
        {
            if (randomNumber < item.DropChange)
            {
                possibleItems.Add(item);
            }
        }

        // Random vat pham rot
        if (possibleItems.Count > 0)
        {
            randomNumber = Random.Range(0, possibleItems.Count);
            ItemController itemDrop = possibleItems[randomNumber];
            return itemDrop;
        }
        return null;
    }

    public void InstantiateLoot(Vector3 spawnPosition)
    {
        ItemController dropItem = GetDropItem();

        if (dropItem != null)
        {
            Instantiate(dropItem, spawnPosition, Quaternion.identity);
        }
    }

}
