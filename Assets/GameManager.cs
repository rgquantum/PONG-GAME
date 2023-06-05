using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public ballBehavior ball;
    public SpawnPlayers SpawnPlayers;
    public float player1score;
    public float player2score;
    public Text p1textscore;
    public Text p2textscore;
    public Button startGameButton;
    public Text p1wintext;
    public Text p2wintext;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        p1textscore.text = player1score.ToString();
        p2textscore.text = player2score.ToString();
        if(player1score >= 10f)
        {
            p1wins();
            ball.placeBallCenter();
            ball.stopBall();
            StartCoroutine(QuitGame());
        }
        if(player2score >= 10f)
        {
            p2wins();
            ball.placeBallCenter();
            ball.stopBall();
            StartCoroutine(QuitGame());
        }
    }

    IEnumerator QuitGame()
    {
        yield return new WaitForSeconds(2f);
        Application.Quit();
    }

    public void gameStartCountdown()
    {
        StartCoroutine(ball.StartGame());   

    }

    public void gameStartZero()
    {
        ball.moveBall();
        startGameButton.gameObject.SetActive(false);
    }

    public void p1wins()
    {
        p1wintext.gameObject.SetActive(true);
    }

    public void p2wins()
    {
        p2wintext.gameObject.SetActive(true);
    }
    
    

    


}
