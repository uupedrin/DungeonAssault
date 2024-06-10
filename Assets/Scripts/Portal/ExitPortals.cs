using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPortals : MonoBehaviour
{
    public GameObject[] portal;

    private void Start()
    {
        GameManager.instance.exitPortal = this;
        for(int i = 0; i < portal.Length; i++)
            portal[i].SetActive(false);
    }

    public void OpenPortal()
    {
        int i = Random.Range(0, portal.Length-1);
        portal[i].SetActive(true);
        GameManager.instance.uiManager.GetComponent<GameUI>().PortalActive();
    }
}
