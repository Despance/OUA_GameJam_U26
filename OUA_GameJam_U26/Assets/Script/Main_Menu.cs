using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void mainMenu() 
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void quitMenu() 
    {
        Application.Quit();
    }



}
