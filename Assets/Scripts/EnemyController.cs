using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   public float vel = 2f;

   float timer;
   int direction = 1;
   public float changeTime = 1f;

   Rigidbody2D rigidboddy;
   Animator animController;

   void Start()
   {
       timer = changeTime;
       rigidboddy = GetComponent<Rigidbody2D>();
       animController = GetComponent<Animator>();
   }

   void Update()
   {
       timer -= Time.deltaTime;
       if(timer < 0)
       {
           direction *= -1;
           timer = changeTime;
       }

       Vector2 position = rigidboddy.position;
       animController.SetFloat("dirX", direction);
       position.x = position.x + Time.deltaTime * vel * direction;
       rigidboddy.MovePosition(position);
   }

   void OnCollisionEnter2D(Collision2D other)
   {
       ClawController cController = other.gameObject.GetComponent<ClawController>();
       if(cController != null)
       {
           cController.updateHealth(-1);
       }
   }

   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.tag == "Espada")
       {
           Debug.Log("Sou inimigo e morri");
       }
   }
}
