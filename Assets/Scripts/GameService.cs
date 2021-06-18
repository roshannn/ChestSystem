using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : MonoSingletonGeneric<GameService>
{
    public int coins;
    public int diamonds;
    public bool canUnlock = true;
    private void Start()
    {
        coins = 1000;
        diamonds = 20;
    }
}
