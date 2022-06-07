using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float ActiveTime = 2f;
    [SerializeField] GameObject ExplosionEffect;
    void Start()
    {
        Invoke("DestroyMyself", ActiveTime);
    }

    void DestroyMyself()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject explosion = Instantiate(ExplosionEffect);
        explosion.transform.position = this.transform.position;
        Destroy(this.gameObject); //自分自身のオブジェクトを消去
    }

    void Update()
    {
        
    }
}
