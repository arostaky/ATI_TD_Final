using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Goutte : MonoBehaviour{
    public Vector3 velocity;
    public int force;
    private float cptGoutte;
    private Rigidbody ridigbody;
    
    private void Awake() {
        ridigbody = GetComponent<Rigidbody>();
        if (ridigbody == null){
            Debug.LogError("Rigidbody not found.");
            enabled = false;
        }
    }
    void Start(){
       ridigbody.AddForce(velocity*force);
    }
    void OnCollisionEnter(Collision collision) {
        Destroy(this);
    }
    void OnBecameInvisible(){
        Destroy(gameObject);
    }
    void DestroyObjectDelayed(){
        // Kills the game object in 1 seconds after loading the object
        Destroy(gameObject, 1);
    }
}
