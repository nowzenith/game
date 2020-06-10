using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    static public bool startGame;
    public GameObject startScene;
    public GameObject endScene;
    public GameObject player;
    public GameObject scoreboard;
    void Start()
    {
        player = GameObject.Find("player");
        startScene.gameObject.SetActive(true);
        endScene.gameObject.SetActive(false);
        scoreboard.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            endScene.gameObject.SetActive(true);
        }
    }

    public void ReplyGameBotton()
    {
        SceneManager.LoadScene("Game");
        scoreboard.gameObject.SetActive(false);
    }
    public void StartGameBotton()
    {
        startScene.gameObject.SetActive(false);
        scoreboard.gameObject.SetActive(true);

    }
    public void UpgradeBotton()
    {
        startScene.gameObject.SetActive(false);
    }
}
