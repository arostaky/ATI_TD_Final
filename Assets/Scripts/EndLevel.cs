using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider hitInfo) {
        SceneManager.LoadScene("Menu");
    }
   
}
