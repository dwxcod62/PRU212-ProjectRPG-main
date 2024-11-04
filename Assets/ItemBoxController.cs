using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemBoxController : MonoBehaviour
{
    [SerializeField] public Image ItemImage;
    [SerializeField] private TMP_Text QuantityTxt;
    [SerializeField] private Image SelectBorder;

    public string _itemName;
    private int _quantity;
    public bool _isEmpty = true;


    public void SetData(Sprite sprite, int quantity, string name)
    {
        _itemName = name;
        _quantity = quantity;

        ItemImage.sprite = sprite;
        QuantityTxt.text = quantity + "";

        ItemImage.gameObject.SetActive(true);
        _isEmpty = false;
    }

    public void AddQuantity(int quantity)
    {
        _quantity += quantity;
        QuantityTxt.text = _quantity + "";
    }

}
