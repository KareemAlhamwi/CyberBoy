using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeveLoader : MonoBehaviour
{
    [SerializeField] Canvas CN;
    [SerializeField] Animator C;
    // Start is called before the first frame update
    void Start()
    {
        CN.enabled = false;
        C.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            CN.enabled = true;
            C.enabled = true;
            StartCoroutine(loadscene());
        }
    }
    IEnumerator loadscene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(2);
    }
}
