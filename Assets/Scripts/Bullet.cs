using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    public GameObject dude;
    public GameObject bullet;


    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if(hitInfo.collider != null)
        {
            if(hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);



        Vector3 v = dude.transform.position - bullet.transform.position;
        float sqrX = v.x * v.x;     
        float sqrY = v.y * v.y;     
        float distance1 = Mathf.Sqrt(sqrX + sqrY);

        if(distance1 > 600)
        {
            Destroy(gameObject);
        }
    }
}
