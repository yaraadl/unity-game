using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement ; 
public class PlayerCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreText ;
    public Text countdowntext ; 
    public Text HealthText  ; 
    public Slider slider ; 
    public AudioClip pickSound ; 
    public AudioClip danger ; 
    private int HealthCounter = 100 ; 
    public Camera myCamera ; 
    int scoreCounter = 11 ; 
    float t  ; 
 
    void Start()
    {
       t = 60 ; 
        
    }

    //Update is called once per frame
    void Update()
    {
      
        t-=1 * Time.deltaTime ; 
        string minutes = ((int) t / 60).ToString() ; 
        string seconds = (t %60).ToString("f2");  
        countdowntext.text = minutes+" : "+seconds ; 
        if (this.transform.position.y < 25 || HealthCounter <  0 ||  (((int) t / 60) ==0 && ((int)(t %60))  == 0) ){
           SceneManager.LoadScene("Lose1") ; 
        }
    }
    void OnTriggerEnter(Collider x){
       
       
        if(x.tag == "pickup"){
            x.gameObject.SetActive(false);
            scoreCounter-- ; 
            scoreText.text = "potions Remaining : " +  scoreCounter ;
            AudioSource s = myCamera.GetComponent<AudioSource>();
            s.PlayOneShot(pickSound);
        }   
        if (scoreCounter == 0 ){
             SceneManager.LoadScene("Win1") ; 
        }
        if(x.tag == "Red"){
            x.gameObject.SetActive(false);
            HealthCounter -= 40 ; 
            AudioSource s = myCamera.GetComponent<AudioSource>();
            s.PlayOneShot(danger);
            if(HealthCounter > 0 ){
               HealthText.text = "Health : "+ HealthCounter +"%" ; 
                slider.value =HealthCounter ; 
            }
            else{
                HealthText.text = "Health :0%" ; 
                slider.value = 0 ; 
            }
            
        }

    }
}
