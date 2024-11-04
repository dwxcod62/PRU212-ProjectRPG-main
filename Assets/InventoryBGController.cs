using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBGController : MonoBehaviour
{

    private int inventorySize = 9;

    [SerializeField] private ItemBoxController itemBoxPrefab;
    [SerializeField] private RectTransform inventoryBackGround;


    List<ItemBoxController> listItems = new List<ItemBoxController>();

    public bool isActive = false;

    public void StartInventory()
    {
        for (int i = 0; i < inventorySize; i++)
        {
            ItemBoxController temp = Instantiate(itemBoxPrefab, Vector2.zero, Quaternion.identity);
            temp.transform.SetParent(inventoryBackGround);
            temp.transform.localScale = Vector3.one;
            listItems.Add(temp);
        }
    }


    public void AddItem(ItemController item)
    {

        bool isAdded = false;

        string name = item.ItemName;

        foreach (var uiItem in listItems)
        {
            if (uiItem._itemName == name)
            {
                uiItem.AddQuantity(1);
                isAdded = true;
                break;

            }
        }

        if (!isAdded)
        {
            int pos = GetFirstEmptySlot();
            listItems[pos].SetData(item.ImageItem, 1, item.ItemName);
        }

        Destroy(item.gameObject);

    }

    public int GetFirstEmptySlot()
    {
        for (int i = 0; i <= listItems.Count; i++)
        {
            if (listItems[i]._isEmpty)
            {
                return i;
            }
        }
        return -1;
    }

    public void Show()
    {
        gameObject.SetActive(true);
        isActive = true;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        isActive = false;
    }

    public bool checkItemInInventory(Sprite sprite)
    {
        foreach (var uiItem in listItems)
        {
            if (uiItem.ItemImage.sprite == sprite)
            {
                return true;
            }
        }

        return false;
    }

}
