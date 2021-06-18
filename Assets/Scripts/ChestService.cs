
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestService : MonoBehaviour
{
    public List<ChestScriptableObject> chestList;

    public ChestScriptableObject GetRandomChest()
    {
        int rand = Random.Range(0, chestList.Count);
        
        return chestList[rand];
    }

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
