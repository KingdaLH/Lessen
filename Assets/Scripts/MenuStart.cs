using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuStart : MonoBehaviour
{
   public void StartButton()
   {
      SceneManager.LoadScene(1);
   }

   public void QuitButton()
   {
      Application.Quit();
   }

   public void RestartButton()
   {
      SceneManager.LoadScene(1);
   }
}
