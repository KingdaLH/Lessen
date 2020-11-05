using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    GameObject player;
    //public Transform target;
    int speed = 5;
    //public int rotationSpeed;
    Rigidbody rb;
   // public Transform targetTransform;
   
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
        Debug.Log("speler positie" + player.transform.position);
        Vector3 playerPos = player.transform.position;
        transform.rotation = Quaternion.LookRotation(playerPos);
    }

    private void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    
}
