using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerScript : MonoBehaviour
{
    
    public List<Tuple<string, int>> inventory;
    public string itemName;
    public int itemAmount;
    public int inventoryCount;
    private Vector2 targetPos;
    public float speed = 2;
    public TextMeshProUGUI inventoryText;
    void Start()
    {
        inventory = new List<Tuple<string, int>>();
    }

    private void Awake()
    {
        // inventoryCount = PlayerPrefs.GetInt("count", 0);
        // for (int i = 0; i < inventoryCount; i++)
        // {
        //     itemName = PlayerPrefs.GetString("", "unknown");
        //     itemAmount = PlayerPrefs.GetInt("", 0);
        //     inventory.Add(Tuple.Create(itemName, itemAmount));
        // }
    }
    void Update()
    {
        Debug.Log(inventory.Count);
        inventoryText.text = inventory.Count.ToString();

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
            string itemType = collision.gameObject.GetComponent<ItemScript>().itemType;
            int amount = collision.gameObject.GetComponent<ItemScript>().amount;
            print("we have collected a: " + itemType + " with " + amount + " amount");
            inventory.Add(Tuple.Create(itemType, amount));
            // PlayerPrefs.SetString(itemType, itemType);
            // PlayerPrefs.SetInt(itemType+"amount", amount);
            // PlayerPrefs.SetInt("count", inventory.Count);
            print("inventory length:" + inventory.Count);
            Destroy(collision.gameObject);
        }
    }
}
