using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class Girl : MonoBehaviour{
    private CharacterController girlcontroller;
    private Vector3  mouvement; 
    public float gravity;
    public float speed;
    void Awake() {
        girlcontroller = GetComponent<CharacterController>();
        if (girlcontroller == null){
            Debug.LogError("Character Controller not found.");
            enabled = false;
        }
    }
     void Update() {
           mouvement.y -= gravity * Time.deltaTime;
        if(girlcontroller.isGrounded){
            mouvement.y = 2f;
        }
        girlcontroller.Move(mouvement * Time.deltaTime);
     }
}
