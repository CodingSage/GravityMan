using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public int totalGoalCollectibles;
    public GameObject gameOverUi;
    public Text gameOverText;
    private Collector playerCollector;
    private Destructible playerDestructible;


    void Start()
    {
        playerCollector = player.GetComponent<Collector>();
        playerDestructible = player.GetComponent<Destructible>();
    }

    void Update()
    {
        if(playerCollector.GetCollectibleCount(CollectibleType.GoalMarker) >= totalGoalCollectibles)
        {
            ShowGameOverUI("You Win!");
        }
        else if(playerDestructible.GetCurrentHitPoints() <= 0)
        {
            ShowGameOverUI("Lol! Try again!");
        }
    }

    private void ShowGameOverUI(string message)
    {
        gameOverText.text = message;
        gameOverUi.SetActive(true);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
