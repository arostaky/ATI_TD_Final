using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fin : MonoBehaviour{
    public Chronometer chronoScript;
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "FraiseBoy"){
            chronoScript.End();
        }
    }

}
