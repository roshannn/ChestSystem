using UnityEngine.UI;
using UnityEngine;
using System;

public class GameService : MonoSingletonGeneric<GameService>
{
    public int coins;
    public int diamonds;
    public Text coinText;
    public Text diamondText;
    public GameObject allSlotsFull;
    public bool canUnlock = true;
    private void Start()
    {
        coins = 1000;
        diamonds = 20;
    }

    private void Update()
    {
        coinText.text = coins.ToString();
        diamondText.text = diamonds.ToString();
    }

   
}
