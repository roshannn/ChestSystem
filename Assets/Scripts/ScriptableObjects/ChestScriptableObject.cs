using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum ChestType { None, Common, Rare, Legendary }
[CreateAssetMenu(fileName = "ScriptableChest", menuName = "ScriptableObject/Chest/NewChestScriptableObject")]
public class ChestScriptableObject : ScriptableObject
{
    
    public ChestType chestType;
    public string chestTypeText;

    public float timeToUnlock;

    public int coinUpperLimit;
    public int coinLowerLimit;

    public int diamondUpperLimit;
    public int diamondLowerLimit;

    
    public int CoinReward()
    {
        return Random.Range(coinLowerLimit, coinUpperLimit + 1);
    }

    public int DiamondReward()
    {
        return Random.Range(diamondLowerLimit, diamondUpperLimit + 1);
    }

}
