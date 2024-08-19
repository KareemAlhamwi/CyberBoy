using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_toggler : MonoBehaviour
{
    [SerializeField] Animator ctext;
    [SerializeField] Animator cam;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey) 
        {
            ctext.SetTrigger("Goo");
            cam.SetTrigger("Go");
            player.SetActive(true);

        }
    }
}
