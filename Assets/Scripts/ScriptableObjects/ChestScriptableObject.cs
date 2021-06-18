using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ScriptableChest", menuName = "ScriptableObject/Chest/NewChestScriptableObject")]
public class ChestScriptableObject : ScriptableObject
{
    public ChestType chestType;

    public Image chestImage;

    public int timeToUnlock;

    public int coinCostToBuy;

    public int coinUpperLimit;
    public int coinLowerLimit;

    public int diamondUpperLimit;
    public int diamondLowerLimit;

    private Button interactButton;
    
    public int CoinReward()
    {
        return Random.Range(coinLowerLimit, coinUpperLimit + 1);
    }

    public int DiamondReward()
    {
        return Random.Range(diamondLowerLimit, diamondUpperLimit + 1);
    }

}
