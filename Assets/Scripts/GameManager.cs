using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    // this is to implement singleton method.
    public static GameManager gmInstance;

    //creating a refernce for playerControls which will be using at an instance.
    public Player playerControls;

    //On starting the game the player will spawn at this postion.
    public Transform playerSpawnPostion;

    //This is to instantiate player if need.
    public GameObject PlayerPrefabs;

    //player count for max lives.
    public int playerCount;

    //This bool is to check whether we have a player in game.
    public bool playerSpawned;

    public bool gamePaused;

    public bool gameOver;

    public bool gameWon;  

    public bool stopLevelTimer;
    [SerializeField] GameObject pauseUI, gameOverUi,timerUi,gameWonUI;


    public float LevelTimer;
    [SerializeField] float currentLevelTimer;
    public bool timerStarted;

    private void Awake()
    {
        if(gmInstance == null)
        {
            gmInstance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    [SerializeField] TextMeshProUGUI textCount;
    [SerializeField] TextMeshProUGUI timerText;
    void Start()
    {
        Time.timeScale = 1;
        // here is the first time the player will be spawned.
        if (playerControls == null && !playerSpawned)
        {
            SpawnPlayer(PlayerPrefabs, playerSpawnPostion);
            playerSpawned = true;  
            
        }
    }

    void Update()
    {
        textCount.text = playerCount.ToString();
        int currentTimerInt = (int)currentLevelTimer;
        timerText.text = currentTimerInt.ToString();
        //this time the spawn method gets called in update with some conditions.
        if (playerControls == null && !playerSpawned )
        {
            SpawnPlayer(PlayerPrefabs,playerSpawnPostion);
            playerSpawned = true;
            playerCount++;
        }

        if(gamePaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        pauseUI.SetActive(gamePaused);
         gameOverUi.SetActive(gameOver);
        gameWonUI.SetActive(gameWon);
         timerUi.SetActive(timerStarted);

        if(timerStarted && currentLevelTimer<=0)
        {
            gameOver = true;
            Time.timeScale = 0;
        }
        if(gameWon)
        {
            stopLevelTimer = true;
            gameWon = true;
        }

        if(currentLevelTimer>0&&!stopLevelTimer)
        {
            currentLevelTimer -= Time.deltaTime;
        }
    }
    void SpawnPlayer(GameObject _prefab,Transform _spawnPoint)
    {
         Instantiate(_prefab, _spawnPoint.position, _spawnPoint.rotation);
    }

    public void setLevelTimer()
    {
        currentLevelTimer = LevelTimer;
        timerStarted = true;
    }
}
