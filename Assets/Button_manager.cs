using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_manager : MonoBehaviour
{
    [SerializeField] Animator anm;
    [SerializeField] Canvas Cn;
    [SerializeField] Canvas Cn1;
    [SerializeField] GameObject player;
    [SerializeField] Animator ann;
    // Start is called before the first frame update
    void Start()
    {
        player.SetActive(false);
        Time.timeScale = 1f;
        Cn1.enabled = false;
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
    public void strt()
    {
        ann.SetTrigger("go");
        anm.SetTrigger("Go");
        Invoke("playergo", 1.5f);
    }
    public void credits()
    {
        Cn1.enabled = true;
    }
    public void backbtn()
    {
        Cn1.enabled = false;

    }
    public void quit()
    {
        Application.Quit();
    }
    void playergo()
    {
        player.SetActive(true);

    }
}
