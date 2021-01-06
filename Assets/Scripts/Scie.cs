using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scie : MonoBehaviour{
    public float speed;
    public GameObject gouttePrefab; 
    public Texture tache;

    void Update(){
       transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "FraiseBoy"){
        //Instantiate goutte...
        for (int i = 0; i < 10; i++){
            Vector3 motion = new Vector3(Random.Range(-2.0f, 2.0f),Random.Range(-2.0f, 2.0f),0);
            Instantiate(gouttePrefab, transform.position+motion*i, Quaternion.identity);
        }
        GetComponent<Renderer>().material.mainTexture = tache;
        other.gameObject.GetComponent<MeatBoy>().Die();
        }
    }
}
