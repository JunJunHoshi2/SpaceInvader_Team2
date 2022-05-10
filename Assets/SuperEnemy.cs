using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperEnemy : MonoBehaviour
{
    [SerializeField] public float speed = 1f;
    [SerializeField] GameObject bullet;
    private Rigidbody2D rb;
    [SerializeField] GameObject ExplosionEffect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        InvokeRepeating("Shoot", 0.5f, 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject explosion = Instantiate(ExplosionEffect);
        explosion.transform.position = this.transform.position;
        GameSceneManager.Score++;
        Destroy(this.gameObject);
    }

    void Shoot()
    {
        for(int i = -50; i <= 50; i+=10)
        {
            GameObject b = Instantiate(bullet);
            b.transform.position = transform.position + new Vector3(0f, -0.5f, 0f);
            Rigidbody2D bulletRigid = b.GetComponent<Rigidbody2D>();
            bulletRigid.AddForce(new Vector2(i, -100f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
