using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    [SerializeField] float ScrollSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();

        if(transform.position.y < -11f)
        {
            ResetPosition();
        }
    }
    void Scroll()
    {
        Vector3 pos = transform.position;
        pos.y -= ScrollSpeed;
        transform.position = pos;
    }

    void ResetPosition()
    {
        Vector3 pos = transform.position;
        //pos.y -= 30f;
        pos.y += 30f;
        transform.position = pos;
    }
}
