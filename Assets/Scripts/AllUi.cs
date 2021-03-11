using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllUi : MonoBehaviour
{
   
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(InputManager.inputInstance.pauseGameKey))
        {
            Pause();
        }
    }

    public void Play()
    {
        loadLevel(1);
    }
    public void nextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex<=2)
          loadLevel(SceneManager.GetActiveScene().buildIndex + 1);
        else
        {
            loadLevel(0);
        }
    }
    public void loadMenu()
    {
        loadLevel(0);
    }
    public void Pause()
    {
        GameManager.gmInstance.gamePaused = true;
    }
    public void Resume()
    {
        GameManager.gmInstance.gamePaused = false;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void loadLevel(int levelindex)
    {
        SceneManager.LoadScene(levelindex);
    }
    public void reloadScene()
    {
        loadLevel(SceneManager.GetActiveScene().buildIndex);
    }

}
