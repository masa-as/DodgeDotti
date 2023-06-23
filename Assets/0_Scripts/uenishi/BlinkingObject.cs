using UnityEngine;

public class BlinkingObject : MonoBehaviour
{
    public Color color1; // インスペクターで指定する色1
    public Color color2; // インスペクターで指定する色2
    public float blinkInterval = 1.0f; // 点滅の間隔（秒）

    private Renderer objectRenderer;
    private float timer;
    private bool isColor1Active;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        timer = 0f;
        isColor1Active = true;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= blinkInterval)
        {
            // タイマーが指定の間隔を超えたら色を切り替える
            timer = 0f;
            isColor1Active = !isColor1Active;

            // 色を適用する
            objectRenderer.material.color = isColor1Active ? color1 : color2;
        }
    }
}
