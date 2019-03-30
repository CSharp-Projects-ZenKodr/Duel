using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //PositionHolder lists: All of these lists contain only positions.
    public List<GameObject> barrier_pos;
    public List<GameObject> tiles_pos;
    public List<GameObject> enemy_tile_pos;
    public List<GameObject> scroll_pos;
    public List<GameObject> enemy_scroll_pos;

    public List<GameObject> symbol_prefabs;
    public List<GameObject> scroll_prefabs;
    public List<GameObject> barrier_prefabs;
    public GameObject flippedTile_prefab;

    public GameObject quitDialogue;

    void Start()
    {
        quitDialogue.SetActive(false); //Ensure quit dialogue is never visible at the start of the game
        //barrier setup
        Instantiate(barrier_prefabs[0], barrier_pos[0].transform);
        Instantiate(barrier_prefabs[0], barrier_pos[1].transform);

        //scroll setup
        for (int i = 0; i < 3; i++)
        {
            Instantiate(scroll_prefabs[0]).transform.position = scroll_pos[i].transform.position;
        }

        //enemy scrolls: 
        for (int i = 0; i < 3; i++)
        {
            Instantiate(scroll_prefabs[1]).transform.position = enemy_scroll_pos[i].transform.position;
        }

        //Setup tiles
        for (int i = 0; i < 3; i++)
        {
            Instantiate(symbol_prefabs[generate_symbol()]).transform.position = tiles_pos[i].transform.position;
            Instantiate(flippedTile_prefab).transform.position = enemy_tile_pos[i].transform.position;

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { //Exit dialogue on back button press.
            quitDialogue.SetActive(!quitDialogue.activeSelf);
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


    public int generate_symbol(int varry = 1)
    {
        Debug.Log("Generate Symbols Called");
        int x = Random.Range(0, 15*varry);
       
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
        else if (14 * varry <= x && x < 15 * varry)
        {
            Debug.Log(x + " Generate Ri");
            return 7; 
        }
        return -1;
    }

}
