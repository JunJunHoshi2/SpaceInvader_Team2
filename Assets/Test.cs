using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer MySprite;
    void Start()
    {
        MySprite = gameObject.GetComponent<SpriteRenderer>();
        MySprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}