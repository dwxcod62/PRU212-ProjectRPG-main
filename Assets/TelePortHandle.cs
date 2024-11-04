using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelePortHandle : MonoBehaviour
{

    [SerializeField] private int SceneId;
    [SerializeField] private Sprite itemNeed;
    [SerializeField] private InventoryBGController inventory;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (inventory.checkItemInInventory(itemNeed))
            {
                SceneManager.LoadScene(SceneId, LoadSceneMode.Single);
            }
            else
            {
                print("need key");
            }

        }
    }
}
