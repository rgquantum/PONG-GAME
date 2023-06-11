using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GameManager : MonoBehaviourPun
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
    public Text timer;
    public float maxTimer = 60f;
    public bool timerStart = false;



    // Start is called before the first frame update
    void Start()
    {
        if(PhotonNetwork.IsMasterClient == false)
        {
            timer.gameObject.SetActive(false);
        }
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

        
        timer.text = maxTimer.ToString();



        if(maxTimer <= 0f)
        {
            player1score ++;
            player2score ++;
        }
    }

    void FixedUpdate()
    {
        if(timerStart == true)
        {
            maxTimer -= Time.deltaTime;
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
        timerStart = true;
    }

    public void p1wins()
    {
        p1wintext.gameObject.SetActive(true);
    }

    public void p2wins()
    {
        p2wintext.gameObject.SetActive(true);
    }

    public void timerReset()
    {
        maxTimer = 60f;
    }
    
    

    


}
