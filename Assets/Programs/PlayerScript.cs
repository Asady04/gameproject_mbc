using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public List<string> inventory;
    private Vector2 targetPos;
    public float speed = 2;
    public TextMeshProUGUI inventoryText;
    void Start()
    {   
         
        inventory = new List<string>();
    }

    private void Awake()
    {
        string[] array = PlayerPrefs.GetString("InventoryItems").Split("/n");
        inventory.AddRange(array);

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
            print("we have collected a:" + itemType);
            inventory.Add(itemType);
            PlayerPrefs.SetString("InventoryItems", string.Join("/n", inventory.ToArray()));
            print("inventory length:" + inventory.Count);
            Destroy(collision.gameObject);
        }
    }
}
