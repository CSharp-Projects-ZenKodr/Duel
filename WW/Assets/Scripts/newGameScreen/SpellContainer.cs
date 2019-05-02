using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Applied on Scrolls, to contain the spell tiles.


public class SpellContainer : MonoBehaviour
{
    //Attributes
    public List<GameObject> TilePrefabs; //List of the 4 elements
    private bool p1Ready, p2Ready;
    private List<GameObject> P1spellSymbols;
    private List<GameObject> P2spellSymbols;
    public Sprite ReadyScroll;
    private Sprite DefaultScroll;
    private SpriteRenderer renderer;
    public static bool Attacked;

    //Functions
    void Start()
    {
        P1spellSymbols = new List<GameObject>();
        P2spellSymbols = new List<GameObject>();
        p1Ready = p2Ready = false;
        renderer = GetComponent<SpriteRenderer>();
        DefaultScroll = renderer.sprite;
        Attacked = false;
    }

    public bool switchPlayers(int playerNumber)
    { //Called from gameState.turnOver()
        return switchSpellView(playerNumber);
    }

    private bool switchSpellView(int playerTurn)
    {//Called by Switch Players
        Attacked = false;
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
            ChangeSprite(playerTurn);
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
            ChangeSprite(playerTurn);
            return true;
        }
        return false;
    }

    public List<GameObject> getP1spellSymbols
    {
        get
        {
            return P1spellSymbols;
        }
    }

    public List<GameObject> getP2SpellSymbols
    {
        get
        {
            return P2spellSymbols;
        }
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

            if (referencePlayerList.Count == 3)
            {
                if (playerNumber == 1)
                {
                    p1Ready = true;
                }
                else if (playerNumber == 2)
                {
                    p2Ready = true;
                }
                ChangeSprite(playerNumber);
            }

            return true;
        }
        return false;
    }   

    void ChangeSprite(int playerNumber)
    {//Called in switchSpellView and Addtile
        renderer.sprite = ((playerNumber == 1 ? p1Ready : p2Ready) ? ReadyScroll : DefaultScroll);
    }

    private void OnMouseDown()
    {
        if (!GameState.tileAdded && !Controller.TurnChanging && !Attacked)
        {
            Attacked = true;
            int turnOfPlayer = GameState.getPlayerturn();
            if (turnOfPlayer == 1 && p1Ready || turnOfPlayer == 2 && p2Ready)
            {
                GetComponent<ScrollClick>().OnMouseDown();
                CastSpell(turnOfPlayer);
            }
        }
    }

    void CastSpell(int playerTurn)
    {
        if (playerTurn == 1)
        {
            GameState.callAttack(System.Convert.ToInt32(name));
            foreach (GameObject tile in P1spellSymbols)
            {
                tile.SetActive(false);
            }
            P1spellSymbols.Clear();
            p1Ready = false;
            ChangeSprite(playerTurn);
        }
        else if (playerTurn == 2)
        {
            GameState.callAttack(System.Convert.ToInt32(name));
            foreach (GameObject tile in P2spellSymbols)
            {
                tile.SetActive(false);
            }
            P2spellSymbols.Clear();
            p2Ready = false;
            ChangeSprite(playerTurn);
        }
        
    }
}