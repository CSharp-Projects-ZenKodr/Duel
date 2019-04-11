using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellContainer : MonoBehaviour
{
    private List<GameObject> spellSymbols;
    private ScrollClick clickDetails;
    void Start()
    {
        clickDetails = GetComponent<ScrollClick>();

        int maxTilesPerSpell = 3;
        spellSymbols = new List<GameObject>(maxTilesPerSpell);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
