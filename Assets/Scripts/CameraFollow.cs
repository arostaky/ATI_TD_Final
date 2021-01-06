using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public bool lookAtTarget = false;
    void Start(){
        transform.position = target.position + offset;
    }
    void FixedUpdate() {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothPosition;
        if(lookAtTarget){
             transform.LookAt(target);
        }
       
    }
}
