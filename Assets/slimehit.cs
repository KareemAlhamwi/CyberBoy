using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class slimehit : MonoBehaviour
{
    [SerializeField] Animator anm;
    [SerializeField] PlayerMovement pm;
    [SerializeField] GameObject guns;
    [SerializeField] Canvas trans;
    [SerializeField] Animator transanime;
    [SerializeField] Enemy_chase ec;
    // Start is called before the first frame update
    void Start()
    {
        ec.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            anm.SetTrigger("dead");
            pm.enabled = false;
            guns.SetActive(false);
            ec.enabled = false;
            Invoke("loadscene1", 1.5f);
        }
    }
    void loadscene1()
    {
        SceneManager.LoadScene(2);
    }
}
