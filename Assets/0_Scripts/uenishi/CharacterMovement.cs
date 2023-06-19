using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 1.0f; // �ړ��X�s�[�h
    public float stoppingDistance = 2.0f; // ��~���鋗��

    private Animator animator;
    private Transform target;

    private bool isMoving = false; // ���f���̈ړ���Ԃ�ǐՂ���t���O

    private void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform; // �ڕW�̈ʒu�i�v���C���[�Ȃǁj���w��
    }

    private void Update()
    {
        // �ڕW�܂ł̋������v�Z
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > stoppingDistance)
        {
            // ���f����ڕW�Ɍ������Ĉړ�������
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            if (!isMoving)
            {
                // ���f�����ړ����J�n�������Ƃ������p�����[�^��ݒ�
                animator.SetBool("IsMoving", true);
                isMoving = true;
            }
        }
        else
        {
            if (isMoving)
            {
                // ���f������~�������Ƃ������p�����[�^��ݒ�
                animator.SetBool("IsMoving", false);
                isMoving = false;
            }
        }
    }
}
