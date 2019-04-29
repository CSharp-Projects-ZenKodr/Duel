using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{

    //Attributes
    private int turnOfPlayer; //turn of: P1 or P2
    private bool turnComplete;

    private int P1BarriersCount;          //Number of barrier P1 has
    private int P2BarriersCount;          //Number Of Barrier P2 Has

    public static bool tileTaken;
    public GameObject PlayerScrolls;      //Access to scroll gameobjects
    public GameObject EnemyScrolls;       //Enemy Scroll GameObject
    public GameObject TilePositions;      //Access to gameObject that is the parent of all tile placement positions;
    public GameObject PopUpTurnChange;    //Pop up View Game object when the turn is changed
    public GameObject PLBarriers;         //Current turn Barriers
    public GameObject ENBarriers;         //Opponent Display Barriers
    
    public List<GameObject> TilePrefabs;  //List of 4 elements prefabs 
    public List<GameObject> P1HandTiles;
    public List<GameObject> P2HandTiles;
    public List<GameObject> pdsa;

    protected List<int> P1TilesOnScroll = new List<int> { 0, 0, 0 };  //0th index represent scroll 0 for enemy, 1th scroll 1 and 2nd scroll 2
    protected List<int> P2TilesOnScroll = new List<int> { 0, 0, 0 };  //0th index represent scroll 0 for enemy, 1th scroll 1 and 2nd scroll 2
    
    //Functions
    void Start()
    {
        P1BarriersCount = 5;
        P2BarriersCount = 5;

        tileTaken = false;
        turnOfPlayer = 1;
        turnComplete = false;
        PopUpTurnChange.SetActive(false);
        
        HandSetup(1); 
        HandSetup(2);
        
        ShowTiles(turnOfPlayer);
        BarriersSetup(turnOfPlayer);

    }
    void Update()
    {
        if (turnComplete)
        {
            turnOver();
        }
    }

    public void addTile()
    { //Called by the tilePouch
        if (!tileTaken)
        {
            ScrollClick.selectedScroll = "none"; //to unselect any selected scroll when pouch is pressed
            int temp = Random.Range(0, 9999) % 4;
            if (turnOfPlayer == 1 && P1HandTiles.Count < 4)
            {
                P1HandTiles.Add(Instantiate(TilePrefabs[temp]));
                P1HandTiles[P1HandTiles.Count - 1].name = TilePrefabs[temp].name + (P1HandTiles.Count - 1).ToString();
                P1HandTiles[P1HandTiles.Count - 1].SetActive(true);
            }
            else if (turnOfPlayer == 2 && P2HandTiles.Count < 4)
            {
                P2HandTiles.Add(Instantiate(TilePrefabs[temp]));
                P2HandTiles[P2HandTiles.Count - 1].name = TilePrefabs[temp].name + (P2HandTiles.Count - 1).ToString();
                P2HandTiles[P2HandTiles.Count - 1].SetActive(true);
            }

            ShowTiles(turnOfPlayer);
            tileTaken = true;
        }
    }
    
    void HandSetup(int playerNumber)
    { //to set tiles in each player's hand. Called in the Start function above.
        
        int initial_tiles = 3;
        for (int i = 0; i < initial_tiles; i++)
        {
            int temp = Random.Range(0, 9999) % 4;

            if (playerNumber == 1)
            {
                P1HandTiles.Add(Instantiate(TilePrefabs[temp]));
                P1HandTiles[i].name = TilePrefabs[temp].name + i.ToString(); //appends the index to the element name. To be used in deselecting all other tiles.
                P1HandTiles[i].SetActive(false);
                
            }
            else if (playerNumber == 2)
            {
                P2HandTiles.Add(Instantiate(TilePrefabs[temp]));
                P2HandTiles[i].name = TilePrefabs[temp].name + i.ToString(); //appends the index to the element name. To be used in deselecting all other tiles.
                P2HandTiles[i].SetActive(false);
            }
        }
    }
    void ShowTiles(int playerNumber)
    {//To display the tiles in hand of the player whose turn it is. Called in the Start function and turnOver function
        if (playerNumber == 1)
        {
            //Hide Tiles of the opponent
            for (int i = 0; i < P2HandTiles.Count; i++)
                P2HandTiles[i].SetActive(false);

            //Show tiles of the player
            for (int i = 0; i < P1HandTiles.Count; i++)
            {
                P1HandTiles[i].transform.position = TilePositions.transform.GetChild(i).transform.position;
                P1HandTiles[i].SetActive(true);
            }
            EnemyScrollSetup(playerNumber);
            ResetBarriers();
            BarriersSetup(playerNumber);
        }
        else if (playerNumber == 2)
        {
            //Hide Tiles of the opponent
            for (int i = 0; i < P1HandTiles.Count; i++)
                P1HandTiles[i].SetActive(false);
            
            //Show tiles of the player
            for (int i = 0; i < P2HandTiles.Count; i++)
            {
                P2HandTiles[i].transform.position = TilePositions.transform.GetChild(i).transform.position;
                P2HandTiles[i].SetActive(true);
            }
            EnemyScrollSetup(playerNumber);
            ResetBarriers();
            BarriersSetup(playerNumber);
        }
    }

    public static void addToScroll(GameObject tile)
    {   //Called by the Select function in tileSpriteChanger
        FindObjectOfType<GameState>().tileToScroll(tile);
    }

    void tileToScroll(GameObject tile)
    {//Called by the static function addToScroll
        int temp = System.Convert.ToInt32(ScrollClick.selectedScroll);
        SpellContainer scrollToAddTo = PlayerScrolls.transform.GetChild(temp).GetComponent<SpellContainer>();

        TileCompatibility tileComp = tile.GetComponent<TileCompatibility>();
        bool added = false;
        if (tileComp.IsCompatible( turnOfPlayer == 1 ? scrollToAddTo.getP1spellSymbols : scrollToAddTo.getP2SpellSymbols))
        {
            added = scrollToAddTo.addTile(turnOfPlayer, tile.name);
        }

        //bool added = scrollToAddTo.addTile(turnOfPlayer, tile.name);

        if (added)
        {
            if (turnOfPlayer == 1)
            {
                P1HandTiles.Remove(tile);
                Destroy(tile);
                // This Updates the List that keps track which scroll have how many tiles
                // Which will help us in showing enemy flipped tile 
                if (scrollToAddTo.gameObject.name == "0")
                {
                    P1TilesOnScroll[0] += 1;
                }
                if (scrollToAddTo.gameObject.name == "1")
                {
                    P1TilesOnScroll[1] += 1;
                }
                if (scrollToAddTo.gameObject.name == "2")
                {
                    P1TilesOnScroll[2] += 1;
                }
            }
            else
            {
                P2HandTiles.Remove(tile);
                Destroy(tile);
                // This Updates the List that keps track which scroll have how many tiles
                if (scrollToAddTo.gameObject.name == "0")
                {
                    P2TilesOnScroll[0] += 1;
                }
                if (scrollToAddTo.gameObject.name == "1")
                {
                    P2TilesOnScroll[1] += 1;
                }
                if (scrollToAddTo.gameObject.name == "2")
                {
                    P2TilesOnScroll[2] += 1;
                }
            }
            StartCoroutine(delayEnumerator(3));
            //turnComplete = true; //Once a tile is placed, switch players.
         }
    }

    IEnumerator delayEnumerator(float newDelayTime)
    {
        //waits for the seconds sent from the
        yield return new WaitForSeconds(2);
        PopUpTurnChange.SetActive(true);
        //delayTime in StartCoroutine
        yield return new WaitForSeconds(newDelayTime);
        //do the logic which you want to occur 
        PopUpTurnChange.SetActive(false);
        //after the delay
        turnComplete = true; //Once a tile is placed, switch players.
    }

    public void turnOver()
    {//Called in Update when turnOver bool is true

        //reset values: 
        tileTaken = false;
        turnComplete = false;
        ScrollClick.selectedScroll = "none";
        tileSpriteChanger.selectedTile = "none";

        //Set turn to the other Player
        turnOfPlayer = (turnOfPlayer == 1) ? 2 : 1;

        for (int i = 0; i < PlayerScrolls.transform.childCount; i++)
        {
            PlayerScrolls.transform.GetChild(i).GetComponent<SpellContainer>().switchPlayers(turnOfPlayer);
        }
        ShowTiles(turnOfPlayer);
    }

    void ResetBarriers()
    {
        for (int i = 0; i < 5; i++)
        {
            PLBarriers.transform.GetChild(i).gameObject.SetActive(false);
            ENBarriers.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    void BarriersSetup(int playerNumber)
    {
        if (playerNumber == 1)
        {
            for(int i = 0; i < P1BarriersCount; i++)
            {
                PLBarriers.transform.GetChild(i).gameObject.SetActive(true);
            }
            for (int i = 0; i < P2BarriersCount; i++)
            {
                ENBarriers.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        if (playerNumber == 2)
        {
            for (int i = 0; i < P1BarriersCount; i++)
            {
                ENBarriers.transform.GetChild(i).gameObject.SetActive(true);
            }
            for (int i = 0; i < P2BarriersCount; i++)
            {
                PLBarriers.transform.GetChild(i).gameObject.SetActive(true);
            }
        }

    }

    void EnemyScrollSetup(int playerNumber)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
                EnemyScrolls.transform.GetChild(i).GetChild(j).gameObject.SetActive(false);
        }

        List<int> referenceList = (playerNumber == 1 ? P2TilesOnScroll : P1TilesOnScroll);

        for (int j = 0; j < 3; j++)
        {
            GameObject temp = EnemyScrolls.transform.GetChild(j).gameObject;

            if (referenceList[j] == 0)
            {
                for (int i = 0; i < 3; i++)
                    temp.transform.GetChild(i).gameObject.SetActive(false);
            }
            else
            {
                for (int i = 0; i < referenceList[j]; i++)
                    temp.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
