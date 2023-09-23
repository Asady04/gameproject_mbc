using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class PlayerScript : MonoBehaviour
{
    // NavMeshAgent agent;

    private Vector3 targetPos;
    public float speed = 2;
    public Animator animator;
    public Rigidbody2D rb;


    void Start()
    {
        targetPos = transform.position;
        // agent = GetComponent<NavMeshAgent>();
        // agent.updateRotation = false;
        // agent.updateUpAxis = false;
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
           targetPos = transform.position;
        }
        else
        {
            if (Input.GetMouseButton(1))
            {
                targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetPos.z = transform.position.z;
            }

            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
            // agent.SetDestination(targetPos);
        }

        Vector3 dir = transform.position - targetPos;
        double x = transform.position.x - targetPos.x;
        double y = transform.position.y - targetPos.y;
        double a, b;
        a = 3.15;
        b = 3.15;
        double tes = a - b;
        dir.Normalize();

        if (x > 0 && y > 1)
        {
            animator.SetBool("TopRight", true);
            animator.SetBool("TopLeft", false);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
            animator.SetBool("BottomRight", false);
            animator.SetBool("BottomLeft", false);
            animator.SetBool("Idle", false);
        }
        else if (x < 0 && y > 1)
        {
            animator.SetBool("TopRight", false);
            animator.SetBool("TopLeft", true);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
            animator.SetBool("BottomRight", false);
            animator.SetBool("BottomLeft", false);
            animator.SetBool("Idle", false);
        }
        else if (x > 0 && y < 1 && y > -1)
        {
            animator.SetBool("TopRight", false);
            animator.SetBool("TopLeft", false);
            animator.SetBool("Right", true);
            animator.SetBool("Left", false);
            animator.SetBool("BottomRight", false);
            animator.SetBool("BottomLeft", false);
            animator.SetBool("Idle", false);
        }
        else if (x < 0 && y < 1 && y > -1)
        {
            animator.SetBool("TopRight", false);
            animator.SetBool("TopLeft", false);
            animator.SetBool("Right", false);
            animator.SetBool("Left", true);
            animator.SetBool("BottomRight", false);
            animator.SetBool("BottomLeft", false);
            animator.SetBool("Idle", false);
        }
        else if (x > 0 && y < -1)
        {
            animator.SetBool("TopRight", false);
            animator.SetBool("TopLeft", false);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
            animator.SetBool("BottomRight", true);
            animator.SetBool("BottomLeft", false);
            animator.SetBool("Idle", false);
        }
        else if (x > 0 && y < -1)
        {
            animator.SetBool("TopRight", false);
            animator.SetBool("TopLeft", false);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
            animator.SetBool("BottomRight", false);
            animator.SetBool("BottomLeft", true);
            animator.SetBool("Idle", false);
        }
        else
        {
            animator.SetBool("Idle", true);
            animator.SetBool("TopRight", false);
            animator.SetBool("TopLeft", false);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
            animator.SetBool("BottomRight", false);
            animator.SetBool("BottomLeft", false);
        }

        Debug.Log("x:" + x);
        Debug.Log("y:" + y);
        Debug.Log("mouse:" + targetPos);
        Debug.Log("player:" + transform.position);
        Debug.Log("tes:" + tes);
        // Debug.Log("y: " + dir.y);
        // Debug.Log("magnitude: " + dir.magnitude);
    }
}
