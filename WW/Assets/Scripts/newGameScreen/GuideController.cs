using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideController : MonoBehaviour
{
    public List<GameObject> GuidePages;

    void Start()
    {}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GuidePages[0].activeSelf && !GuidePages[1].activeSelf)
        {
            ElementDetails("default");
        }
    }

    public void Roll()
    {
        GuidePages[0].SetActive(!GuidePages[0].activeSelf);
        GuidePages[1].SetActive(!GuidePages[1].activeSelf);
    }

    public void ResetPage()
    {
        for (int i = 0; i < GuidePages.Count; i++)
        {
            GuidePages[i].SetActive(false);
        }
        GuidePages[0].SetActive(true);
    }

    public void ElementDetails(string Element)
    {
        switch (Element.ToLower())
        {
            case "flame":
                GuidePages[1].SetActive(!GuidePages[1].activeSelf);
                GuidePages[2].SetActive(!GuidePages[2].activeSelf);
                break;
            case "spark":
                GuidePages[1].SetActive(!GuidePages[1].activeSelf);
                GuidePages[3].SetActive(!GuidePages[3].activeSelf);
                break;
            case "wave":
                GuidePages[1].SetActive(!GuidePages[1].activeSelf);
                GuidePages[4].SetActive(!GuidePages[4].activeSelf);
                break;
            case "strength":
                GuidePages[1].SetActive(!GuidePages[1].activeSelf);
                GuidePages[5].SetActive(!GuidePages[5].activeSelf);
                break;
            default:
                for (int i = 2; i < GuidePages.Count; i++)
                    GuidePages[i].SetActive(false);

                GuidePages[1].SetActive(!GuidePages[1].activeSelf);
                break;
        }
    }
}
