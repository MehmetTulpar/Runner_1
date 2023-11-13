using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    public float speed = 0.2f;
    bool tapToStart = false;
    public GameObject geo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (tapToStart)
        {
            transform.Translate(Vector3.forward * speed);
        }
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Enter Pressed");
            GetComponent<Animator>().SetBool("RunStart", true);
            tapToStart = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (geo.transform.localPosition.x > 26)
            {
                geo.transform.localPosition -= new Vector3(2, 0, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (geo.transform.localPosition.x < 29)
            {
                geo.transform.localPosition += new Vector3(2, 0, 0);
            }
        }
    }
}
