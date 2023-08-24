using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Items
{
    public int type;
    public int amount;

    public void SetItems(int type, int amount)
    {
        this.type = type;
        this.amount = amount;
    }
}
public class PlayerScript : MonoBehaviour
{

    public Items[] inventory;
    private Vector2 targetPos;
    public float speed = 2;
    public TextMeshProUGUI inventoryText;

    void Start()
    {
        int inventoryCount = PlayerPrefs.GetInt("count", 0);
        inventory = new Items[inventoryCount];
    }

    private void Awake()
    {
        // int inventoryCount = PlayerPrefs.GetInt("count", 0);
        // for (int i = 0; i < inventoryCount; i++)
        // {
        //     int itemName = PlayerPrefs.GetInt("item" + i, -1);
        //     int itemAmount = PlayerPrefs.GetInt("amount" + i, 0);
        //     if (itemName == -1 || itemAmount == 0)
        //     {
        //         Debug.Log("inventory is empty");
        //     }
        //     else
        //     {
        //         inventory[i] = new Items();
        //         inventory[i].SetItems(itemName, itemAmount);
        //     }
        // }
    }
    void Update()
    {
            Debug.Log(inventory.Length);
            inventoryText.text = inventory.Length.ToString();


        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            targetPos = new Vector2(mousePos.x, mousePos.y);

        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);

        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            int itemType = collision.gameObject.GetComponent<ItemScript>().itemType;
            int amount = collision.gameObject.GetComponent<ItemScript>().amount;
            print("we have collected a: " + itemType + " with " + amount + " amount");

            switch (itemType)
            {
                case 0:
                    inventory[itemType] = new Items();
                    inventory[itemType].SetItems(itemType, amount);
                    PlayerPrefs.SetInt("item" + itemType, itemType);
                    PlayerPrefs.SetInt("amount" + itemType, amount);
                    break;
                case 1:
                    inventory[itemType] = new Items();
                    inventory[itemType].SetItems(itemType, amount);
                    PlayerPrefs.SetInt("item" + itemType, itemType);
                    PlayerPrefs.SetInt("amount" + itemType, amount);
                    break;
                case 2:
                    inventory[itemType] = new Items();
                    inventory[itemType].SetItems(itemType, amount);
                    PlayerPrefs.SetInt("item" + itemType, itemType);
                    PlayerPrefs.SetInt("amount" + itemType, amount);
                    break;
                case 3:
                    inventory[itemType] = new Items();
                    inventory[itemType].SetItems(itemType, amount);
                    PlayerPrefs.SetInt("item" + itemType, itemType);
                    PlayerPrefs.SetInt("amount" + itemType, amount);
                    break;
                case 4:
                    inventory[itemType] = new Items();
                    inventory[itemType].SetItems(itemType, amount);
                    PlayerPrefs.SetInt("item" + itemType, itemType);
                    PlayerPrefs.SetInt("amount" + itemType, amount);
                    break;
                default:
                    break;
            }

            PlayerPrefs.SetInt("count", inventory.Length);
            Debug.Log(inventory.Length);
            Destroy(collision.gameObject);
        }
    }
}
