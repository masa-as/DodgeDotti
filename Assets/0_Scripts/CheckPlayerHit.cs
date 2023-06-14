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

    public static IEnumerator Vibrate(float duration = 0.1f, float frequency = 0.1f, float amplitude = 0.1f, OVRInput.Controller controller = OVRInput.Controller.Active) {
        Debug.Log("test");
        //コントローラーを振動させる
        OVRInput.SetControllerVibration(frequency, amplitude, controller);

        //指定された時間待つ
        yield return new WaitForSeconds(duration);

        //コントローラーの振動を止める
        OVRInput.SetControllerVibration(0, 0, controller);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        float player_x = transform.parent.gameObject.transform.position.x;
        float enemy_x = other.gameObject.transform.position.x;
        if(enemy_x<player_x){
            StartCoroutine(Vibrate(duration:0.5f, controller:OVRInput.Controller.LTouch));
        }
        if(enemy_x>=player_x){
            StartCoroutine(Vibrate(duration:0.5f, controller:OVRInput.Controller.RTouch));
        }
        this.img.color = new Color (0.8f, 0f, 0f, 0.5f);
        Debug.Log("hit");
        Debug.Log(other.gameObject.name);
    }
	void Update () 
	{
        this.img.color = Color.Lerp (this.img.color, Color.clear, Time.deltaTime);
	}

}
