using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPlayerHit : MonoBehaviour
{
    Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = GameObject.Find("Image").GetComponent<Image> ();
		img.color = Color.clear;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        this.img.color = new Color (0.8f, 0f, 0f, 0.5f);
        Debug.Log("hit");
        Debug.Log(other.gameObject.name);
    }
	void Update () 
	{
        this.img.color = Color.Lerp (this.img.color, Color.clear, Time.deltaTime);
	}

}
