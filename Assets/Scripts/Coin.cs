using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Packages.Rider.Editor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : MonoBehaviour
{
   public GameObject wall;
   public Transform target;
   int speed = 30;
   public int rotationSpeed;
   public Rigidbody rb;
   public Transform targetTransform;
   
   private void Start()
   {
      rb = GetComponent<Rigidbody>();
      wall = GameObject.FindWithTag("Wall");
      LaunchCoin();
   }

   // Targets a gameobject and launches the coin like a projectile
   private void LaunchCoin()
   {
      transform.LookAt(wall.transform.position);
      //Transform.rotation = Quaternion.Slerp(transform.position, rotation, rotationSpeed);
      //transform.rotation = rotation;
      rb.AddForce(0,0, -speed, ForceMode.Impulse);
   }
   
   private void OnTriggerEnter(Collider Player)
   {
      if (Player.CompareTag("Player"))
      {
         Debug.Log(Player.name);
         GameManager.score++;
         Debug.Log(GameManager.score);
         Destroy(gameObject);
      }
   }
}
