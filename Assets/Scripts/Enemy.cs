using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D physic;

    public Transform player;
    public float speed;
    public float agroDistance;

    public int health;
    
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    void Start()
    {
        physic = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if(distToPlayer < agroDistance)
        {
            StartHunting();
        }
        else
        {
            StopHunting();
        }

        if(health <= 0)
        {

            Destroy(gameObject);
            Teleport.countEnemys --;

        }
    }
    
    void StartHunting()
    {
     transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.fixedDeltaTime);   
    }
    void StopHunting()
    {
        physic.velocity = new Vector3 (0, 0, -2);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
      StopHunting();
    }
}
