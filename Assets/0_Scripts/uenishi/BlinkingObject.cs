using UnityEngine;

public class BlinkingObject : MonoBehaviour
{
    public Color blinkColor = Color.red; // 点滅時の色
    public float blinkInterval = 1.0f; // 点滅の間隔（秒）

    private Renderer objectRenderer;
    private Color originalColor;
    private bool isBlinking = false;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;
    }

    private void Update()
    {
        if (!isBlinking)
        {
            // 点滅を開始
            StartCoroutine(Blink());
        }
    }

    private System.Collections.IEnumerator Blink()
    {
        isBlinking = true;

        // 点滅ループ
        while (true)
        {
            objectRenderer.material.color = blinkColor;
            yield return new WaitForSeconds(blinkInterval);

            objectRenderer.material.color = originalColor;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
