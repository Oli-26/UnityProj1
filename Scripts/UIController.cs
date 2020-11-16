using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject coinText;
    // Update is called once per frame
    void Update()
    {
        int coins = GetComponent<Game>().getPlayer().GetComponent<Player>().coins;
        coinText.GetComponent<TextMeshPro>().text = coins+"";
    }
}
