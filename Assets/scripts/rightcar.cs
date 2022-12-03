using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rightcar : MonoBehaviour
{
    private float z=0.43f;
    private float touchcount;
    private bool shouldmove=true;
    public GameObject gameovermenu;
    public Text scor;
    AudioSource[] sound;
    // Update is called once per frame
    void start()
    {
        
    }
    void FixedUpdate()
    {
        if (Input.touchCount == 0)
            shouldmove = true;
        if(Input.touchCount>0 && Input.GetTouch(0).position.x>Screen.width/2)
        {
            Debug.Log("touch happened in right side of screen");
            if(z==0.13f && shouldmove)
            {
                this.transform.localPosition = new Vector3(0.43f,this.transform.localPosition.y, this.transform.localPosition.z);
                Debug.Log("Move towards right");
                z = 0.43f;
                shouldmove = false;
            }
            else if(z==0.43f && shouldmove)
            {
                this.transform.localPosition = new Vector3(0.13f,this.transform.localPosition.y, this.transform.localPosition.z);
                Debug.Log("Move towards left");
                z = 0.13f;
                shouldmove = false;
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "pickup")
        {
            sound = GetComponents<AudioSource>();
            Destroy(other.gameObject);
            sound[0].Play();
            carmovement.score+=1;
            Debug.Log("score : " + carmovement.score);
            scor.text = ""+carmovement.score;
        }
        else if (other.gameObject.name == "obstacle")
        {
            sound = GetComponents<AudioSource>();
            roadmove.speed = 0;
            sound[1].Play();
            gameovermenu.SetActive(true);
        }
    }
}
