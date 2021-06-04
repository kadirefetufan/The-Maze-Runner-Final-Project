using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public void Mainmenu()
    {
        SceneManager.LoadScene(0);

    }
    

    public void Level1Button()
    {
        SceneManager.LoadScene(1);

    }

    public void Level2Button()
    {
        SceneManager.LoadScene(2);

    }
    public void Level3Button()
    {
        SceneManager.LoadScene(3);

    }
    public void Level4Button()
    {
        SceneManager.LoadScene(4);

    }
    public void Level5Button()
    {
        SceneManager.LoadScene(5);

    }


    public void QuitButton()
    {

        Application.Quit();

    }



}
