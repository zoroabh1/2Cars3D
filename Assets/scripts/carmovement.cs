using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class carmovement : MonoBehaviour
{
    private float z = -0.53f;
    private float touchcount;
    private bool shouldmove = true;
    public static int score;
    public GameObject gameovermenu;
    public Text scor;
    AudioSource[] sounds;

    void Start()
    {
        score = 0;
        sounds = GetComponents<AudioSource>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount == 0)
            shouldmove = true;
        if (Input.touchCount > 0 && Input.GetTouch(0).position.x <= Screen.width / 2)
        {
            if (z == -0.53f && shouldmove)
            {
                this.transform.localPosition = new Vector3(-0.23f,this.transform.localPosition.y, this.transform.localPosition.z);
                Debug.Log("Move towards right");
                z = -0.23f;
                shouldmove = false;
            }
            else if (z == -0.23f && shouldmove)
            {
                this.transform.localPosition = new Vector3(-0.53f,this.transform.localPosition.y, this.transform.localPosition.z);
                Debug.Log("Move towards left");
                z = -0.53f;
                shouldmove = false;
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "pickup")
        {
            sounds[0].Play();
            Destroy(other.gameObject);
            score += 1;
            Debug.Log("score : " + score);
            scor.text = "" + score;
        }
        else if(other.gameObject.name == "obstacle")
        {
            sounds[1].Play();
            roadmove.speed = 0;
            gameovermenu.SetActive(true);
        }
    }
}
