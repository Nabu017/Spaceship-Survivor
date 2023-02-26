using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionMenu;
    private bool playgame = false;


    public void StartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void Pausemenu()
    {
   
        optionMenu.SetActive(false);
        Time.timeScale = 1;
      

    }
    public void Mainmenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }


    IEnumerator  Timer()
    {
        yield return new WaitForSeconds(5);
        Time.timeScale = 1;
    }
}
