using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
    public float xSpeed = 0.0f;
    public float ySpeed = 0.0f;
    public float zSpeed = 0.0f;
    public int health = -10;
    public Transform rewardItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xSpeed, ySpeed, zSpeed);
    }
    void OnTriggerEnter(Collider hitInfo) {
    MeatBoy player = hitInfo.GetComponent<MeatBoy>();
        //FraiseBoy player  = hitInfo.GetComponent<FraiseBoy>();
        Debug.Log(hitInfo);
         if (player != null){
             player.TakeDamage(health);
             Destroy(gameObject);
         }
    }
}
