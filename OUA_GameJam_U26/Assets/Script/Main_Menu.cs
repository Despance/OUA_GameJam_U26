using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("Fatma");
    }
    public void mainMenu() 
    {
        SceneManager.LoadScene("Start");
    }

    public void quitMenu() 
    {
        Application.Quit();
    }



}
