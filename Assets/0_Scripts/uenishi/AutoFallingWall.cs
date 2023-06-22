using UnityEngine;
using System.Collections; // �ǉ�

public class AutoFallingWall : MonoBehaviour
{
    public float startDelay = 1.0f; // ��]���n�܂�܂ł̑ҋ@���ԁi�b�j
    public float rotationSpeed = 90.0f; // ��]���x�i�x/�b�j
    public Vector3 rotationAxis = Vector3.up; // ��]��
    public float rotationAngle = 90.0f; // ��]�p�x�i�x�j

    private bool rotating = false;

    void Start()
    {
        // �w�肳�ꂽ�b����ɉ�]���J�n����R���[�`�����J�n
        StartCoroutine(StartRotation());
    }

    void Update()
    {
        // ��]�t���O�������Ă���ꍇ�ɃI�u�W�F�N�g����]������
        if (rotating)
        {
            transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
        }
    }

    IEnumerator StartRotation()
    {
        // �w�肳�ꂽ�b���ҋ@
        yield return new WaitForSeconds(startDelay);

        // ��]�t���O�𗧂Ă邱�Ƃŉ�]���J�n
        rotating = true;

        // �w�肳�ꂽ�p�x�܂ŉ�]�������]���~
        Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles + rotationAxis * rotationAngle);
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f)
        {
            yield return null;
        }

        // ��]���~
        rotating = false;
    }
}
