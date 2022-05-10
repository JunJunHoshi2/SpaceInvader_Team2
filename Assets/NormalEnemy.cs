using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] GameObject bullet;
    private Rigidbody2D rb;
    [SerializeField] GameObject ExplosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        InvokeRepeating("Shoot", 0f, 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject explosion = Instantiate(ExplosionEffect);
        explosion.transform.position = this.transform.position;
        GameSceneManager.Score++;
        Destroy(this.gameObject); //自分自身のオブジェクトを消去
    }

    void Shoot()
    {
        GameObject b = Instantiate(bullet);
        b.transform.position = transform.position + new Vector3(0f, -0.5f, 0f);
        Rigidbody2D bulletRigid = b.GetComponent<Rigidbody2D>();
        bulletRigid.AddForce(new Vector2(0f, -200f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
