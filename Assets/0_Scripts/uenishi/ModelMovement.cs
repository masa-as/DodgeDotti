using UnityEngine;

public class ModelMovement : MonoBehaviour
{
    public Transform player; // プレイヤーのTransform
    public float moveSpeed = 2f; // 移動速度
    public float stoppingDistance = 2f; // 停止する距離

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // プレイヤーに向かっての移動方向ベクトルを計算
        Vector3 direction = player.position - transform.position;
        direction.y = 0f; // 高さ方向の移動は無視

        // 移動速度を考慮してモデルを移動させる
        transform.position += direction.normalized * moveSpeed * Time.deltaTime;

        // モデルがプレイヤーから一定の距離で停止するようにする
        if (direction.magnitude <= stoppingDistance)
        {
            // アニメーションのスピードを0にする
            animator.SetFloat("Speed", 0f);
        }
        else
        {
            // アニメーションのスピードを移動速度に合わせる
            animator.SetFloat("Speed", moveSpeed);
        }
    }
}
