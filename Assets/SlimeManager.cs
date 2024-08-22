using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeManager : MonoBehaviour
{
    public Animator anm;
    [SerializeField] Collider2D cl;
    [SerializeField] Enemy_chase ec;
    // Start is called before the first frame update
    void Start()
    {
        cl.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x <= 0.7)
        {
            ec.mindist = 1.7f;
        }
        else if (transform.localScale.x > 12)
        {
            ec.mindist = 3.4f;

        }
        else
        {
            ec.mindist = 2.7f;
        }
    }
    public void attack()
    {
        cl.enabled = true;
    }
    public void notattack()
    {
        cl.enabled = false;

        anm.SetTrigger("nothit");
    }
}
