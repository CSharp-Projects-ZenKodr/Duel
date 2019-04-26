using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCompatibility : MonoBehaviour
{
    //public GameObject TileSelected;
    private string incompatibleTile;
    // Start is called before the first frame update
    void Start()
    {
        incompatibleTile = "empty";
        if (this.name.Contains("flame"))
        {
            incompatibleTile = "wave";
        }
        else if (this.name.Contains("wave"))
        {
            incompatibleTile = "flame";
        }
        else if (this.name.Contains("spark"))
        {
            incompatibleTile = "strength";
        }
        else if (this.name.Contains("strength"))
        {
            incompatibleTile = "spark";
        }

    }

    public bool IsCompatible(List<GameObject> Container)
    {
        foreach (GameObject tile in Container)
        {
            if (tile.name.Contains(incompatibleTile))
            {
                return false;
            }
        }
        return true;
    }
}
