using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{

    public GameObject playerPrefabs;
    public float playerCount;
    public ballBehavior ball;


    // Start is called before the first frame update
    void Start()
    {
        if(PhotonNetwork.IsMasterClient == true)
        {
            Vector2 p1position = new Vector2(-7.9497f, 0.1343f);
            playerPrefabs = PhotonNetwork.Instantiate(playerPrefabs.name, p1position, Quaternion.identity);
            playerCount += 1f;
        }
        else
        {
            Vector2 p2position = new Vector2(7.9497f, 0.1343f);
            playerPrefabs = PhotonNetwork.Instantiate(playerPrefabs.name, p2position, Quaternion.identity);
            playerCount += 1f;
        }

         
    }


    // Update is called once per frame
    void Update()
    {
        
    }




}
