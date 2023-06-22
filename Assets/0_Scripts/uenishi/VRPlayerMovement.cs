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
        // プレイヤーの位置を取得
        Vector3 playerPosition = playerTransform.position;

        // モデルをプレイヤーの方向に向ける
        transform.LookAt(playerPosition);

        // プレイヤーとモデルの距離を計算
        float distance = Vector3.Distance(transform.position, playerPosition);

        if (distance > stoppingDistance)
        {
            // モデルをプレイヤーの方向に移動させる
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            // アニメーションの動きを再生する
            animator.SetFloat("Moving", 1.0f);
        }
        else
        {
            // モデルの移動を停止し、アニメーションの動きも停止する
            transform.Translate(Vector3.zero);
            animator.SetFloat("Moving", 0.0f);
        }
    }
}
