using UnityEngine;

public class VRPlayerMovement : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 1.0f;
    public float stoppingDistance = 2.0f;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // �v���C���[�̈ʒu���擾
        Vector3 playerPosition = playerTransform.position;

        // ���f�����v���C���[�̕����Ɍ�����
        transform.LookAt(playerPosition);

        // �v���C���[�ƃ��f���̋������v�Z
        float distance = Vector3.Distance(transform.position, playerPosition);

        if (distance > stoppingDistance)
        {
            // ���f�����v���C���[�̕����Ɉړ�������
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            // �A�j���[�V�����̓������Đ�����
            animator.SetFloat("Moving", 1.0f);
        }
        else
        {
            // ���f���̈ړ����~���A�A�j���[�V�����̓�������~����
            transform.Translate(Vector3.zero);
            animator.SetFloat("Moving", 0.0f);
        }
    }
}
