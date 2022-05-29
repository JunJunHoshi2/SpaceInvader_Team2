using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int HP = 5;
    [SerializeField] GameObject bullet;
    AudioSource BullesSE;
    [SerializeField] GameObject ExplosionEffect;
    [SerializeField] GameSceneManager mygameManager;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 0f, 1f);
        BullesSE = GetComponent<AudioSource>();
    }

    void Shoot()
    {
        GameObject b = Instantiate(bullet);
        b.transform.position = transform.position + new Vector3(0f, 0.5f, -1f);
        Rigidbody2D bulletRigid = b.GetComponent<Rigidbody2D>();
        bulletRigid.AddForce(new Vector2(0f, 200f));
        BullesSE.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HP -= 1;
        if(HP <= 0)
        {
            GameObject explosion = Instantiate(ExplosionEffect);
            explosion.transform.position = this.transform.position;
            mygameManager.AddScoreToText();
            Destroy(this.gameObject); //自分自身のオブジェクトを消去
        }
    }
    void Update()
    {
        transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y);
    }
}
