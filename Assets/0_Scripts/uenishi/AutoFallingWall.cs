using UnityEngine;
using System.Collections; // 追加

public class AutoFallingWall : MonoBehaviour
{
    public float startDelay = 1.0f; // 回転が始まるまでの待機時間（秒）
    public float rotationSpeed = 90.0f; // 回転速度（度/秒）
    public Vector3 rotationAxis = Vector3.up; // 回転軸
    public float rotationAngle = 90.0f; // 回転角度（度）

    private bool rotating = false;

    void Start()
    {
        // 指定された秒数後に回転を開始するコルーチンを開始
        StartCoroutine(StartRotation());
    }

    void Update()
    {
        // 回転フラグが立っている場合にオブジェクトを回転させる
        if (rotating)
        {
            transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
        }
    }

    IEnumerator StartRotation()
    {
        // 指定された秒数待機
        yield return new WaitForSeconds(startDelay);

        // 回転フラグを立てることで回転を開始
        rotating = true;

        // 指定された角度まで回転したら回転を停止
        Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles + rotationAxis * rotationAngle);
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f)
        {
            yield return null;
        }

        // 回転を停止
        rotating = false;
    }
}
