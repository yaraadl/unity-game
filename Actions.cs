using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ; 
public class Actions : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene") ; 
    }
    public void ExitGame (){
        Application.Quit() ; 
    }
    public void mainmenu (){
         SceneManager.LoadScene("Menu") ; 
    }
   
}
