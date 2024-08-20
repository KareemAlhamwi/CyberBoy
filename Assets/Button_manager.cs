using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_manager : MonoBehaviour
{
    [SerializeField] Canvas Cn;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        Cn.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void okbtn()
    {
        Cn.enabled = false;
        Time.timeScale = 1f;
    }
}
