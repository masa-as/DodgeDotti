using UnityEngine;

public class BlinkingObject : MonoBehaviour
{
    public Color blinkColor = Color.red; // �_�Ŏ��̐F
    public float blinkInterval = 1.0f; // �_�ł̊Ԋu�i�b�j

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
            // �_�ł��J�n
            StartCoroutine(Blink());
        }
    }

    private System.Collections.IEnumerator Blink()
    {
        isBlinking = true;

        // �_�Ń��[�v
        while (true)
        {
            objectRenderer.material.color = blinkColor;
            yield return new WaitForSeconds(blinkInterval);

            objectRenderer.material.color = originalColor;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
