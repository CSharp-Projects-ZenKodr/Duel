using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScriptBackCall : MonoBehaviour
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

    public void goBack()
    {
        TileInfo.SetActive(!TileInfo.activeSelf);
    }
}
