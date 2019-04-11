using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesClicked : MonoBehaviour
{
    public GameObject TileInfo;

    // Start is called before the first frame update
    void Start()
    {
        TileInfo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void checkTileInfo()
    {
        TileInfo.SetActive(!TileInfo.activeSelf);
    }
}
