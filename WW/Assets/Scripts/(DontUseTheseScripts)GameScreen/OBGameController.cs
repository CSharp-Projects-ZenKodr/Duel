using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OBGameController : MonoBehaviour
{

    /*
     DONT USE THIS CLASS
     DONT USE THIS CLASS
     DONT USE THIS CLASS
     DONT USE THIS CLASS
     DONT USE THIS CLASS
     DONT USE THIS CLASS 
     DONT USE THIS CLASS
     DONT USE THIS CLASS 
     DONT USE THIS CLASS
     DONT USE THIS CLASS 
     DONT USE THIS CLASS
     DONT USE THIS CLASS
     DONT USE THIS CLASS
     DONT USE THIS CLASS
     DONT USE THIS CLASS
     DONT USE THIS CLASS
      */







    //PositionHolder lists: All of these lists contain only positions.
    public List<GameObject> barrier_pos;
    public List<GameObject> tiles_pos;
    public List<GameObject> enemy_tile_pos;
    public List<GameObject> scroll_pos;
    public List<GameObject> enemy_scroll_pos;
    
    public List<GameObject> P1Tiles; //List containing all tiles of player 1
    public List<GameObject> P2Tiles; //List containing all tiles of player 1

    public List<GameObject> symbol_prefabs; //List of all tiles' prefabs
    public GameObject scroll_prefab; //List of prefabs containing both scroll prefabs
    public List<GameObject> barrier_prefabs; //List of Prefabs of all barriers and an individual barrier 

    public GameObject quitDialogue;

    private int playerTurn; //denoting which player's turn it is to play | ==1 for player 1 or ==2 for player 2 

    void Start()
    {
        playerTurn = 1; 
        quitDialogue.SetActive(false); //Ensure quit dialogue is never visible at the start of the game
        scrollandBarrierSetup();
        tilesSetup();
        Screen.fullScreen = true;
        Screen.orientation = ScreenOrientation.Portrait;
        Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = Screen.autorotateToPortraitUpsideDown = false; //disabling rotation
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { //Exit dialogue on back button press.
            quitDialogue.SetActive(!quitDialogue.activeSelf);
        }
    }
    

    void scrollandBarrierSetup()
    {
        //Scrolls Setup
        int total_scrolls = 3;
        for (int i = 0; i < total_scrolls; i++)
        {
            Instantiate(scroll_prefab).transform.position = scroll_pos[i].transform.position; //P1 scrolls
            Instantiate(scroll_prefab).transform.position = enemy_scroll_pos[i].transform.position; //P2 Scrolls
        }

        //BarriersSetup
        Instantiate(barrier_prefabs[0], barrier_pos[0].transform); //P1 Barriers
        Instantiate(barrier_prefabs[0], barrier_pos[1].transform); //P2 Barriers
    }

    void tilesSetup()
    {
        //Setup tiles
        int maxTilesPerPlayer = 3;
        for (int i = 0; i < maxTilesPerPlayer; i++)
        {
            //P1 Tile
            GameObject p1 = Instantiate(symbol_prefabs[randomTileSelection()]);
            p1.transform.position = tiles_pos[i].transform.position;
            P1Tiles.Add(p1);

            //P2 Tile
            GameObject p2 = Instantiate(symbol_prefabs[randomTileSelection()]);
            p2.GetComponent<Tiles>().HideSymbol();
            p2.transform.position = enemy_tile_pos[i].transform.position;
            P2Tiles.Add(p2);
        }
    }

    public void CancelQuit()
    {
        quitDialogue.SetActive(false);
    }

    public void quit()
    {
        SceneManager.LoadScene(1);
    }

    public void generate_symbol()
    { //For the pouch on the screen 
        if (P1Tiles.Count < 4)
        {
            GameObject p1 = Instantiate(symbol_prefabs[randomTileSelection()]);
            p1.transform.position = tiles_pos[3].transform.position;
            P1Tiles.Add(p1);
        }
    }

    public int randomTileSelection(int varry = 1)
    {
        int x = Random.Range(0, 15 * varry);

        if (0 <= x && x < 2 * varry)
        {
            Debug.Log(x + " Generate Waqu");
            return 0;
        }
        else if (2 * varry <= x && x < 4 * varry)
        {
            Debug.Log(x + " Generate Spa");
            return 1;
        }
        else if (4 * varry <= x && x < 6 * varry)
        {
            Debug.Log(x + " Generate Rid");
            return 2;
        }
        else if (6 * varry <= x && x < 8 * varry)
        {
            Debug.Log(x + " Generate Floo");
            return 3;
        }
        else if (8 * varry <= x && x < 10 * varry)
        {
            Debug.Log(x + " Generate Dir");
            return 4;
        }
        else if (10 * varry <= x && x < 12 * varry)
        {
            Debug.Log(x + " Generate Di");
            return 5;
        }
        else if (12 * varry <= x && x < 14 * varry)
        {
            Debug.Log(x + " Generate Ackh");
            return 6;
        }
        else
        {
            Debug.Log(x + " Generate Ri");
            return 7;
        }
    }

}
