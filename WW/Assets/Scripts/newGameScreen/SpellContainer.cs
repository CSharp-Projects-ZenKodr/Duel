using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Applied on Scrolls, to contain the spell tiles.


public class SpellContainer : MonoBehaviour
{
    //Attributes
    public List<GameObject> TilePrefabs; //List of the 4 elements
    private List<GameObject> P1spellSymbols;
    private List<GameObject> P2spellSymbols;
 
    //Functions
    void Start()
    {
        P1spellSymbols = new List<GameObject>();
        P2spellSymbols = new List<GameObject>();
    }

    public bool switchPlayers(int playerNumber)
    { //Called from gameState.turnOver()
        return switchSpellView(playerNumber);
    }

    private bool switchSpellView(int playerTurn)
    {//Called by Switch Players
        if (playerTurn == 1)
        {
            foreach (GameObject tile in P2spellSymbols)
            {
                tile.SetActive(false);
            }
            foreach (GameObject tile in P1spellSymbols)
            {
                tile.SetActive(true);
            }
            return true;
        }
        else if (playerTurn == 2)
        {
            foreach (GameObject tile in P1spellSymbols)
            {
                tile.SetActive(false);
            }
            foreach (GameObject tile in P2spellSymbols)
            {
                tile.SetActive(true);
            }
            return true;
        }
        return false;
    }

    public bool addTile(int playerNumber, string tileName)
    {//Called in GameState by tileToScroll
        List<GameObject> referencePlayerList = (playerNumber == 1) ? P1spellSymbols : P2spellSymbols;

        if (referencePlayerList.Count < 3)
        {
            if (tileName.Contains("strength")) { referencePlayerList.Add(Instantiate(TilePrefabs[0])); }

            else if (tileName.Contains("flame")) { referencePlayerList.Add(Instantiate(TilePrefabs[1])); }

            else if (tileName.Contains("spark")) { referencePlayerList.Add(Instantiate(TilePrefabs[2])); }

            else if (tileName.Contains("wave")) { referencePlayerList.Add(Instantiate(TilePrefabs[3])); }
    
            int i = referencePlayerList.Count - 1;
            Vector3 tileScale = new Vector3(0.4f, 0.4f);

            referencePlayerList[i].transform.parent = gameObject.transform;
            referencePlayerList[i].transform.position = transform.GetChild(i).transform.position;
            referencePlayerList[i].GetComponent<SpriteRenderer>().sortingOrder = 3; //A sorting order higher than the sorting order of the scroll.
            referencePlayerList[i].transform.localScale = tileScale; //Rescale tile to a size that fits the scroll.
            referencePlayerList[i].GetComponent<BoxCollider2D>().enabled = false; //Dont remove this line. Atleast not without asking me(shahrom). 

            return true;
        }
        return false;
    }   
}