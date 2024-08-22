using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_finisher : MonoBehaviour
{
    [SerializeField] PlayerMovement pm;
    [SerializeField] Canvas cn;
    [SerializeField] Animator anm;
    [SerializeField] Animator anm1;
    // Start is called before the first frame update
    void Start()
    {
        cn.enabled = false;
        anm.enabled = false;
        anm1.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            cn.enabled = true;
            anm.enabled = true;
            pm.enabled = false;
            anm1.enabled = true;
            Invoke("loadscene", 6f);
        }
    }
    void loadscene()
    {
        SceneManager.LoadScene(1);
    }
}
