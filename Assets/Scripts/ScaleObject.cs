using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject : MonoBehaviour
{
    [SerializeField]private int hitCount = 0;
    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void HandleHit()
    {
        hitCount++;
        switch (hitCount)
        {
            case 2:
                transform.localScale *= 1.4f; // Scale up
                break;

            case 4:
                transform.localScale *= 1.6f; // Scale up
                break;
            case 6:
                transform.localScale *= 1.8f; // Scale up

                break;

            case 8:
                transform.localScale *= 2f; // Scale up
                break;
            case 10:
                transform.localScale = originalScale; // Reset to original scale
                hitCount = 0; // Reset hit count
                break;
        }
    }
}
