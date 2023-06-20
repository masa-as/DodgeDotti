using UnityEngine;

public class AutoFallingWall : MonoBehaviour
{
    public float delayTime = 3f; // �|���܂ł̒x������
    public float fallSpeed = 5f; // �|��鑬�x

    private bool isFalling = false; // �|��邩�ǂ����̃t���O

    void Start()
    {
        Invoke("StartFalling", delayTime); // ��莞�Ԍ�ɓ|��鏈�����J�n����
    }

    void Update()
    {
        if (isFalling)
        {
            // �|��鏈�������s����
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-90f, 0f, 0f), fallSpeed * Time.deltaTime);
        }
    }

    void StartFalling()
    {
        isFalling = true;
    }
}
