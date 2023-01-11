using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    
    public GameObject Player ;   //reference for the sphere
    private Vector3 cameraLocation ; 
    void Start(){
        //cameraLocation = this.transform.position ; 

    }
    void LateUpdate()
    {
        this.transform.position = Player.transform.position + cameraLocation;
    }
}
