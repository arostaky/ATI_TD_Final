using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour{

    public float speed = 30f;
    public CharacterController CharCont;
    public Rigidbody rb;
    public Vector3 currentVector = Vector3.up;
    public float CurrentForce = 0f;
    public float MaxForce = 50f;

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            UseJetPack();
        }
        // if(Input.GetKeyDown(KeyCode.Space) && MaxForce > 0f){
        //     MaxForce -= Time.deltaTime;
        //     if(CurrentForce < 1f){
        //         CurrentForce += Time.deltaTime * 10f;
        //     }else{
        //         CurrentForce = 1f;
        //     }
        // }
        // if(MaxForce<0 && CurrentForce > 0f){
        //     CurrentForce -= Time.deltaTime;
        // }
        // if(!Input.GetKeyDown(KeyCode.Space)){
        //     if(CurrentForce > 0f){
        //         CurrentForce -= Time.deltaTime;
        //     }else{
        //         CurrentForce = 0f;
        //     }
        //     if(MaxForce<5f){
        //         MaxForce += Time.deltaTime;

        //     }else{
        //         MaxForce = 5f;
        //     }
        //     if(CurrentForce > 0f){
        //         UseJetPack();
        //     }
        // }

    }
    public void UseJetPack(){
        // currentVector = Vector3.up;
        // rb.AddForce(currentVector * speed);
        // currentVector += transform.up * Input.GetAxis("Horizontal");
        // currentVector += transform.up * Input.GetAxis("Vertical");

        // CharCont.Move((currentVector * speed * Time.fixedDeltaTime - CharCont.velocity * Time.fixedDeltaTime)* CurrentForce);

    }
}