using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject Pause_Menu;
    bool isPaused;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if(isPaused)
        {
            Pause_Menu.SetActive(true);
            Time.timeScale = 0;
            //Cursor.visible = true;

            

        }
        else
        {
            Pause_Menu.SetActive(false);
            Time.timeScale = 1;
            //Cursor.visible = false;

            
        }

    }

    public void ResumeGame()

    {
        isPaused = false;
    }
}
