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
    private Vector3 targetPos;
    public float speed = 2;
    public TextMeshProUGUI inventoryText;
    public Animator animator;
    public Rigidbody2D rb;
    // private Pause_Menu pauseSystem;

    void Start()
    {
        targetPos = transform.position;
        int inventoryCount = PlayerPrefs.GetInt("count", 0);
        inventory = new Items[inventoryCount];
    }

    private void Awake()
    {
    //    pauseSystem = GameObject.FindGameObjectWithTag("pause").GetComponent<Pause_Menu>();
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
        // if (pauseSystem.GetIsPaused()){return;}
        Debug.Log(inventory.Length);
        inventoryText.text = inventory.Length.ToString();

        if (Input.GetMouseButton(0))
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = transform.position.z;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
        Vector3 dir = targetPos - transform.position;
        dir.Normalize();

        animator.SetFloat("Horizontal", dir.x);
        animator.SetFloat("Vertical", dir.y);
        animator.SetFloat("Magnitude", dir.magnitude);
        if (dir.x == 0 && dir.y == 0)
        {
           animator.SetFloat("Magnitude", 0);
        }

        Debug.Log("X: " + dir.x);
        Debug.Log("y: " + dir.y);
        Debug.Log("magnitude: " + dir.magnitude);
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
