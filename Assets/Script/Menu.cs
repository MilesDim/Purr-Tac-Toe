using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
     public void EnterMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitSkin()
    {
      SceneManager.LoadScene(1);
    }
     public void EnterGame()
    {
        SceneManager.LoadScene(2);
    }
   public void ExitGame()
   {
    Application.Quit();
   }
}
