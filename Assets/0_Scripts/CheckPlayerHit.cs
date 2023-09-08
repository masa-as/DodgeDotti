using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPlayerHit : MonoBehaviour
{
    Image img;
    GameObject obj;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        obj = (GameObject)Resources.Load("Bad");
        img = GameObject.Find("Red").GetComponent<Image>();
        img.color = Color.clear;
        rb = gameObject.GetComponent<Rigidbody>();
        rb.sleepThreshold = 10;

    }

    public static IEnumerator Vibrate(float duration = 0.1f, float frequency = 0.1f, float amplitude = 0.1f, OVRInput.Controller controller = OVRInput.Controller.Active)
    {
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
        // 通行人と衝突したときの処理
        if (other.gameObject.tag == "Passerby")
        {
            float player_x = transform.parent.gameObject.transform.position.x;
            float enemy_x = other.gameObject.transform.position.x;
            if (enemy_x < player_x)
            {
                StartCoroutine(Vibrate(duration: 0.5f, controller: OVRInput.Controller.LTouch));
            }
            if (enemy_x >= player_x)
            {
                StartCoroutine(Vibrate(duration: 0.5f, controller: OVRInput.Controller.RTouch));
            }
            FindObjectOfType<ScoreScript>().ReducePoint();
            this.img.color = new Color(0.8f, 0f, 0f, 0.5f);

            Instantiate(obj, new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z + 1.0f), Quaternion.Euler(90f, 180f, 0f));
        }
        // Perfectなタイミングで避けたとき
        else if (other.gameObject.tag == "Perfect")
        {
            FindObjectOfType<ScoreScript>().AddPoint(3);
        }
        else if (other.gameObject.tag == "Good")
        {
            FindObjectOfType<ScoreScript>().AddPoint(1);
        }

    }
    void Update()
    {
        // if (rb.IsSleeping())
        // {
        //     Debug.Log("sleep");
        // }
        this.img.color = Color.Lerp(this.img.color, Color.clear, Time.deltaTime);

    }
}
