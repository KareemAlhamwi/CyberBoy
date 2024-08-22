using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disable : MonoBehaviour
{
    [SerializeField]Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void dis()
    {
        canvas.enabled = false;
    }
}
