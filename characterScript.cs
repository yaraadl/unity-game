using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterScript: MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController controller ; 
    private Vector3 movement ; 
    public float speed = 5 ; 
    public float  gravity = 20 ; 
    public float jump = 7 ; 
    public float rotationSpeed = 100 ; 
    private float rotation ; 
    private Animator animator ; 
    void Start()
    {
        controller = this.GetComponent<CharacterController>(); 
        animator = this.GetComponent<Animator>() ; 
    }

    // Update is called once per frame
    void Update()
    {   
        float moveHorizontal = Input.GetAxis("Horizontal") ; 
        float moveVertical =Input.GetAxis("Vertical") ; 
        if(controller.isGrounded){
            movement = new Vector3(0 ,0 ,moveVertical ) ; 
            movement = this.transform.TransformDirection(movement) ; 
            if(Input.GetButton("Jump")){
              movement.y = jump ; 
              animator.SetBool("isJumping" ,true) ;
            }
            else{
                animator.SetBool("isJumping" ,false) ;
            }
        }
        if(moveVertical != 0 ){
           animator.SetBool("isWalking" ,true) ;
        }
        else{
            animator.SetBool("isWalking" ,false) ;
        }
        if(Input.GetKey(KeyCode.LeftShift)){
            speed = 10 ; 
            animator.SetBool("isRunning" , true) ;
        }
        else{
            animator.SetBool("isRunning" , false) ;
            speed = 5 ;
        }
        rotation+= rotationSpeed * moveHorizontal * Time.deltaTime ; 
        this.transform.eulerAngles = new Vector3 (0,rotation,0) ; 
        movement.y -= gravity*Time.deltaTime ; 
        controller.Move(movement*speed*Time.deltaTime) ; 

    }
}
