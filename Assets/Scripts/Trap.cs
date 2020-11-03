using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject player;
    //public Transform target;
    public int speed;
    //public int rotationSpeed;
    public Rigidbody rb;
   // public Transform targetTransform;
   
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
    }

    private void FixedUpdate()
    {
        LaunchTrap();
    }

    // Targets a gameobject and launches the coin like a projectile
    private void LaunchTrap()
    {
        Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position);
        //Transform.rotation = Quaternion.Slerp(transform.position, rotation, rotationSpeed);
        transform.rotation = rotation;
        rb.AddForce(0,0, -speed * Time.deltaTime, ForceMode.Impulse);
    }
}
