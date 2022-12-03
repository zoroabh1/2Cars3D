using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadmove : MonoBehaviour {

    // Use this for initialization
    public static float speed = 2f;
	void Start () {
        speed = 2f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate((new Vector3(1, 0, 0)) * speed * Time.deltaTime);
        if (transform.localPosition.z < -1.2f)
        {
            Reset();
        }
	}
    private void Reset()
    {
        for (int i = 0; i < 23; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 8.86f);
        int index = Random.Range(0, 10);
        int index2 = Random.Range(10, 24);
        transform.GetChild(index).gameObject.SetActive(true);
        transform.GetChild(index2).gameObject.SetActive(true);
    }

}
