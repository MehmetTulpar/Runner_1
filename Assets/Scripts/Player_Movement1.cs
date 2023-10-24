using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement1 : MonoBehaviour
{
    public float speed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.one * speed);
    }
}
