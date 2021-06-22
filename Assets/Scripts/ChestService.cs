
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestService : MonoSingletonGeneric<ChestService>
{
    public Button addChest;
    private Transform parent;
    public List<ChestScriptableObject> chestList;
    public GameObject[] slotList;
    public float popUpTime;
    
    public ChestScriptableObject GetRandomChest()
    {
        int rand = Random.Range(0, chestList.Count);
        
        return chestList[rand];
    }

    private void Start()
    {
        addChest.onClick.AddListener(AddToSlot);
    }

    async private void AddToSlot()
    {
        for (int i = 0; i < slotList.Length; i++)
        {
            if (slotList[i].GetComponent<Chest>().isEmpty)
            {
                var x = slotList[i].GetComponent<Chest>();
                x.isEmpty = false;
                x.InitialiseChest();

                return;
            }
            else if (i == slotList.Length - 1)
            {
                GameService.Instance.allSlotsFull.SetActive(true);
                await new WaitForSeconds(popUpTime);
                GameService.Instance.allSlotsFull.SetActive(false);
                return;
            }
        }
        return;
    }
}
