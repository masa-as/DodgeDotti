using UnityEngine;

public class ModelMovement : MonoBehaviour
{
    public Transform player; // �v���C���[��Transform
    public float moveSpeed = 2f; // �ړ����x
    public float stoppingDistance = 2f; // ��~���鋗��

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // �v���C���[�Ɍ������Ă̈ړ������x�N�g�����v�Z
        Vector3 direction = player.position - transform.position;
        direction.y = 0f; // ���������̈ړ��͖���

        // �ړ����x���l�����ă��f�����ړ�������
        transform.position += direction.normalized * moveSpeed * Time.deltaTime;

        // ���f�����v���C���[������̋����Œ�~����悤�ɂ���
        if (direction.magnitude <= stoppingDistance)
        {
            // �A�j���[�V�����̃X�s�[�h��0�ɂ���
            animator.SetFloat("Speed", 0f);
        }
        else
        {
            // �A�j���[�V�����̃X�s�[�h���ړ����x�ɍ��킹��
            animator.SetFloat("Speed", moveSpeed);
        }
    }
}
