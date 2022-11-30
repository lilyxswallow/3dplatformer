using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
   public void PlayGame()
   {
      UnityEngine.SceneManagement.SceneManager.LoadScene(0);
   }
   
   public void QuitGame()
   {
      Application.Quit();
   }
}
