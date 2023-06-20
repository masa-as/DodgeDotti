using UnityEngine;

public class AutoFallingWall : MonoBehaviour
{
    public float delayTime = 3f; // “|‚ê‚é‚Ü‚Å‚Ì’x‰„ŠÔ
    public float fallSpeed = 5f; // “|‚ê‚é‘¬“x

    private bool isFalling = false; // “|‚ê‚é‚©‚Ç‚¤‚©‚Ìƒtƒ‰ƒO

    void Start()
    {
        Invoke("StartFalling", delayTime); // ˆê’èŠÔŒã‚É“|‚ê‚éˆ—‚ğŠJn‚·‚é
    }

    void Update()
    {
        if (isFalling)
        {
            // “|‚ê‚éˆ—‚ğÀs‚·‚é
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-90f, 0f, 0f), fallSpeed * Time.deltaTime);
        }
    }

    void StartFalling()
    {
        isFalling = true;
    }
}
