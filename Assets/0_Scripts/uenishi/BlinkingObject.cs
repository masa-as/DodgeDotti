using UnityEngine;

public class BlinkingObject : MonoBehaviour
{
    public Color color1; // �C���X�y�N�^�[�Ŏw�肷��F1
    public Color color2; // �C���X�y�N�^�[�Ŏw�肷��F2
    public float blinkInterval = 1.0f; // �_�ł̊Ԋu�i�b�j

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
            // �^�C�}�[���w��̊Ԋu�𒴂�����F��؂�ւ���
            timer = 0f;
            isColor1Active = !isColor1Active;

            // �F��K�p����
            objectRenderer.material.color = isColor1Active ? color1 : color2;
        }
    }
}
