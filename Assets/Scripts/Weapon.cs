using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            Shoot();
            animator.SetBool("shoot", true);
            
            }else if (Input.GetButtonUp("Fire1")){
                 animator.SetBool("shoot", false);
            }

        
    }
    void Shoot(){
        //shooting logic
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }
}
