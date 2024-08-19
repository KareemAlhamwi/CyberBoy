using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScaleObject : MonoBehaviour
{
    [SerializeField]private int hitCount = 0;
    [SerializeField] private int hitCountsmall = 0;
    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }
    void Update()
    {
        if (transform.localScale.x > 2f & transform.localScale.y > 2f & transform.localScale.z > 2f)
        {
            transform.localScale = new Vector3(1,1,1);

        }
        else if (transform.localScale.x < 0.3f & transform.localScale.y < 0.3f & transform.localScale.z <0.3f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    public void HandleHit()
    {
        hitCount++;

        switch (hitCount)
        {

            case 1:
                transform.localScale *= 1.2f; // Scale up
                break;
            case 2:
                transform.localScale *= 1.4f; // Reset to original scale
                hitCount = 0; // Reset hit count
                break;
        }

    }
    public void HandleHitSmall()
    {
        hitCountsmall++;
        switch (hitCountsmall)
        {
            case 1:
                transform.localScale *= 0.7f; // Scale up
                break;
            case 2:
                transform.localScale *= 0.5f; // Reset to original scale
                hitCountsmall = 0; // Reset hit count
                break;
        }
    }
}
