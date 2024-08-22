using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_collect : MonoBehaviour
{
    [SerializeField] Gun_Manager gm;
    [SerializeField] GameObject guns;
    [SerializeField] GameObject gunscollecter;
    [SerializeField] Collider2D col;
    [SerializeField] Canvas tut;
    [SerializeField] AudioSource pick;

    private void Awake()
    {
        tut.enabled = false;
    }
    private void Start()
    {
        tut.enabled = false;
        col.enabled = true;
        guns.SetActive(false);
        gm.enabled = false;
        gunscollecter.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Guns"))
        {
            tut.enabled = true;
            guns.SetActive(true);
            gm.enabled = true;
            gunscollecter.SetActive(false);
            col.enabled = false;
            pick.Play();
            Time.timeScale = 0;

        }
    }
}
