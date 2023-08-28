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
    public TextMeshProUGUI inventoryText0;
    public TextMeshProUGUI inventoryText1;
    public TextMeshProUGUI inventoryText2;
    public TextMeshProUGUI inventoryText3;
    public TextMeshProUGUI inventoryText4;
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
        int currentAmount0 = PlayerPrefs.GetInt("amount0", 0);
        inventoryText0.text = currentAmount0.ToString();
        int currentAmount1 = PlayerPrefs.GetInt("amount1", 0);
        inventoryText1.text = currentAmount1.ToString();
        int currentAmount2 = PlayerPrefs.GetInt("amount2", 0);
        inventoryText2.text = currentAmount2.ToString();
        int currentAmount3 = PlayerPrefs.GetInt("amount3", 0);
        inventoryText3.text = currentAmount3.ToString();
        int currentAmount4 = PlayerPrefs.GetInt("amount4", 0);
        inventoryText4.text = currentAmount4.ToString();

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

        // Debug.Log("X: " + dir.x);
        // Debug.Log("y: " + dir.y);
        // Debug.Log("magnitude: " + dir.magnitude);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            int itemType = collision.gameObject.GetComponent<ItemScript>().itemType;
            int amount = collision.gameObject.GetComponent<ItemScript>().amount;
            print("we have collected a: " + itemType + " with " + amount + " amount");
            int currentAmount = PlayerPrefs.GetInt("amount" + itemType, 0);
            int newAmount = amount + currentAmount;

            inventory[itemType] = new Items();
            inventory[itemType].SetItems(itemType, newAmount);
            PlayerPrefs.SetInt("item" + itemType, itemType);
            PlayerPrefs.SetInt("amount" + itemType, newAmount);


            Debug.Log("item" + itemType + ":" + inventory[itemType].amount);
            PlayerPrefs.SetInt("count", inventory.Length);

            Destroy(collision.gameObject);
        }
    }
}
