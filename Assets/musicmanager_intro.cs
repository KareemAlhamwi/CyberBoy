using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class musicmanager_intro : MonoBehaviour
{

    void Start()
    {
    
    }

    private void Update()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}
