using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ; 
public class ActionsWin1 : MonoBehaviour
{
    // Start is called before the first frame update
   public void StartGame()
    {
        SceneManager.LoadScene("level 2") ; 
    }
    public void ExitGame (){
        Application.Quit() ; 
    }
}
