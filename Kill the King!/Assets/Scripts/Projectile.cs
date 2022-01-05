using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float damage = 1;
    public GameObject Explosion;

    //Vector3 start;
    //Vector3 dir;
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }
    private void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);

        Debug.Log(collision.name);
        Instantiate(Explosion, gameObject.transform.position, gameObject.transform.rotation);
        collision.GetComponent<KingMovement>().health -= damage;
        collision.GetComponent<EnemyMovement>().health -= damage;

    }
}
