using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    float speed = 0.30f;
    float speed_2 = 0.60f;
    public GameObject geo;
    bool tapToStart = false;
    public int health = 100;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (tapToStart == true)
        {
            transform.Translate(Vector3.forward * speed);//movement code
        }
            
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //GetComponent<Animator>().SetBool("Idle", false);
            GetComponent<Animator>().SetBool("RunForward", true);//reference to the warrior with a game object variable
            tapToStart = true;
        }
        if (Input.GetKeyDown(KeyCode.A))//if I press A it will slide to left
        {
            if(geo.transform.localPosition.x > -1.5f)
            {
                geo.transform.DOLocalMoveX(geo.transform.localPosition.x - 3.5f, 0.25f);//.SetDelay(0.2f);
                
            }
        }
        if (Input.GetKeyDown(KeyCode.D))//if I press D it will slide to right
        {
            if (geo.transform.localPosition.x < 1.5f)
            {
                geo.transform.DOLocalMoveX(geo.transform.localPosition.x + 3.5f, 0.25f);
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Damage")
        {
            health--;
            print("Saðlýk =" + health);
        }
        if (other.gameObject.tag == "LevelFinish")
        {
            print("trigged");
            geo.GetComponent<Animator>().SetBool("RunForward", false);
            geo.GetComponent<Animator>().SetBool("Idle", true);
            tapToStart = false;
            Invoke(nameof(Level2), 2);
        }
        
    }

    void Level2()
    {
        transform.Translate(Vector3.forward * speed_2);
        SceneManager.LoadScene(1);
    }
}
