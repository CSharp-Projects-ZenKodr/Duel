using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public List<GameObject> P2Barriers; //Access to the Enemy's light barriers
    public List<GameObject> P1Barriers; //Access to the Player's light barriers
    public List<GameObject> P1Scrolls; //Access to scroll gameobjects
    public GameObject TilePositions; //Access to gameObject that is the parent of all tile placement positions;

    public List<GameObject> TilePrefabs; //List of 4 elements

    private int p1BarrierCount;
    private int p2BarrierCount;

    public List<GameObject> P1HandTiles; 
    public List<GameObject> P2HandTiles;

    private int turnOfPlayer; //Which player's turn it is
    private bool turnComplete; 

    // Start is called before the first frame update
    void Start()
    {
        turnOfPlayer = 1; //Player1 goes first, of course. 
        turnComplete = false;

        p1BarrierCount = p2BarrierCount = 5;

        //Set Hand Cards for each Player
        tileGeneration(1); 
        tileGeneration(2);
        
        ShowTiles(turnOfPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        if (turnComplete)
        {
            ShowTiles(turnOfPlayer);
            turnComplete = false;
        }


    }

    public void addTile()
    {
        Debug.Log("addTile called");
        int temp = Random.Range(0, 9999) % 4;
        if (turnOfPlayer == 1)
        {
            if (P1HandTiles.Count < 4)
            {
                P1HandTiles.Add(Instantiate(TilePrefabs[temp]));
                P1HandTiles[P1HandTiles.Count - 1].name = TilePrefabs[temp].name + (P1HandTiles.Count - 1).ToString();
                P1HandTiles[P1HandTiles.Count - 1].transform.position = TilePositions.transform.GetChild(P1HandTiles.Count - 1).transform.position;
                P1HandTiles[P1HandTiles.Count - 1].SetActive(true);
            }
        }
        else if (turnOfPlayer == 2)
        {
            P2HandTiles.Add(Instantiate(TilePrefabs[temp]));
            P2HandTiles[P2HandTiles.Count - 1].name = TilePrefabs[temp].name + (P2HandTiles.Count - 1).ToString();
            P2HandTiles[P2HandTiles.Count - 1].transform.position = TilePositions.transform.GetChild(P2HandTiles.Count - 1).transform.position;
            P2HandTiles[P2HandTiles.Count - 1].SetActive(true);
        }
    }

    public void turnOver()
    {//Function called by a temporary turn complete button
        if (turnOfPlayer == 1)
        {
            turnOfPlayer = 2;
        }
        else 
        {
            turnOfPlayer = 1;
        }
        turnComplete = true;
    }

    void tileGeneration(int playerNumber)
    { //Stores properly positioned instances of tiles in hand of respective players in their HandTiles arrays 
        
        int initial_tiles = 3;
        for (int i = 0; i < initial_tiles; i++)
        {
            int temp = Random.Range(0, 9999) % 4;

            if (playerNumber == 1)
            {
                P1HandTiles.Add(Instantiate(TilePrefabs[temp]));
                P1HandTiles[i].name = TilePrefabs[temp].name + i.ToString(); //sets the index as their name. To be used in deselecting all other tiles.
                P1HandTiles[i].transform.position = TilePositions.transform.GetChild(i).transform.position;
                P1HandTiles[i].SetActive(false);
                
            }
            else if (playerNumber == 2)
            {
                P2HandTiles.Add(Instantiate(TilePrefabs[temp]));
                P2HandTiles[i].name = TilePrefabs[temp].name + i.ToString(); //sets the index as their name. To be used in deselecting all other tiles.
                P2HandTiles[i].transform.position = TilePositions.transform.GetChild(i).transform.position;
                P2HandTiles[i].SetActive(false);
            }
            else
            {
                Debug.Log("Invalid Player number. Only two players.");
            }
        }
    }
    
    void ShowTiles(int playerNumber)
    {
        if (playerNumber == 1)
        {
            //Hide Tiles of the opponent
            for (int i = 0; i < P2HandTiles.Count; i++)
                P2HandTiles[i].SetActive(false);

            //Show tiles of the player
            for (int i = 0; i < P1HandTiles.Count; i++)
                P1HandTiles[i].SetActive(true);
            
        }
        else if (playerNumber == 2)
        {
            //Hide Tiles of the opponent
            for (int i = 0; i < P1HandTiles.Count; i++)
                P1HandTiles[i].SetActive(false);
            
            //Show tiles of the player
            for (int i = 0; i < P2HandTiles.Count; i++)
                P2HandTiles[i].SetActive(true);
        }
        else
        {
            Debug.Log("Invalid Player number. Only two players.");
        }
    }
}
