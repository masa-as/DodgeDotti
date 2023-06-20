using UnityEngine;

public class AutoFallingWall : MonoBehaviour
{
    public float delayTime = 3f; // 倒れるまでの遅延時間
    public float fallSpeed = 5f; // 倒れる速度

    private bool isFalling = false; // 倒れるかどうかのフラグ

    void Start()
    {
        Invoke("StartFalling", delayTime); // 一定時間後に倒れる処理を開始する
    }

    void Update()
    {
        if (isFalling)
        {
            // 倒れる処理を実行する
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-90f, 0f, 0f), fallSpeed * Time.deltaTime);
        }
    }

    void StartFalling()
    {
        isFalling = true;
    }
}
