using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDown : MonoBehaviour
{
    public float CoolDownTime = 2; //laser gun?
    public float nextJetPackTime = 0;
    MeatBoy meatboy;

   public Animator animator;
    void Start(){
        meatboy = GameObject.FindGameObjectWithTag("FraiseBoy").GetComponent<MeatBoy>();
    }
    private void Update() {
        if(Time.time > nextJetPackTime){
            meatboy.jetPackHeat -= Time.time + CoolDownTime;
            if (meatboy.jetPackHeat <= 0){
                meatboy.jetPackHeat = 0;
            }

         }
        if(Input.GetKey(KeyCode.Space)){
            
                print("jetpack started....");
                print(nextJetPackTime);
                
                nextJetPackTime = Time.time + CoolDownTime/4;
                meatboy.Fly();
                meatboy.playSound(true);
                meatboy.jetPackHeat+= Time.time/1000 + meatboy.jetPackHeatCount;
                
        
        }else{
            meatboy.playSound(false);
            animator.SetBool("lift", false);
        }

}
}