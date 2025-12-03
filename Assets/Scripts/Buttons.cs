using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
   public void PlayButton()
    {
        Application.LoadLevel(1);
    }

    public void ExitButton()
    {
        if(Application.loadedLevel == 1) this.gameObject.GetComponent<Score>().SaveHighScore();
        
        Application.Quit();
    }

    public void ExitToMainMenuButton()
    {
        this.gameObject.GetComponent<Score>().SaveHighScore();

        Application.LoadLevel(0);
    }
}
