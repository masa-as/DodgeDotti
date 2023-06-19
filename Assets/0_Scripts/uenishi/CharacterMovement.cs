using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 1.0f; // 移動スピード
    public float stoppingDistance = 2.0f; // 停止する距離

    private Animator animator;
    private Transform target;

    private bool isMoving = false; // モデルの移動状態を追跡するフラグ

    private void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform; // 目標の位置（プレイヤーなど）を指定
    }

    private void Update()
    {
        // 目標までの距離を計算
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > stoppingDistance)
        {
            // モデルを目標に向かって移動させる
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            if (!isMoving)
            {
                // モデルが移動を開始したことを示すパラメータを設定
                animator.SetBool("IsMoving", true);
                isMoving = true;
            }
        }
        else
        {
            if (isMoving)
            {
                // モデルが停止したことを示すパラメータを設定
                animator.SetBool("IsMoving", false);
                isMoving = false;
            }
        }
    }
}
