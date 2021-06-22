using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    //UIGameObject
    public GameObject[] slotComponents;


    //slot can be accessed
    public bool isEmpty = true;

    //diamond cost
    public Button buyWithDiamonds;
    public Text diamondCostText;
    public int diamondCost;

    //rewards
    public int coinReward;
    public int diamondReward;
    
    //buttons
    public Button chestButton;
    public Button startTimer;
    

    //popups
    public GameObject cantUnlock;
    public GameObject notEnoughDiamonds;
    public GameObject timerNotComplete;

    //chest ui
    ChestScriptableObject chestScriptableObject;
    public Text chestTypeText;

    //time
    public float popUpTime;
    private float timeToUnlock;
    public Text timeText;
    public TimeSpan time;


    //check if chest can be opened
    public bool canOpen;

    //check if chest is opening
    public bool isOpening=false;

    private void Start()
    {
        
        CheckForButtonClick();
    }
    public void InitialiseChest()
    {
        canOpen = false;
        chestScriptableObject = ChestService.Instance.GetRandomChest();
        chestTypeText.text = chestScriptableObject.chestTypeText;
        timeToUnlock = chestScriptableObject.timeToUnlock;
        time = TimeSpan.FromSeconds(timeToUnlock);
        GetDiamondCost();
    }

    private void ActivateUIComponents()
    {
        for(int i = 0; i < slotComponents.Length; i++)
        {
            slotComponents[i].SetActive(true);
        }
    }
    private void DeactivateUIComponents()
    {
        for(int i = 0; i < slotComponents.Length; i++)
        {
            slotComponents[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (!isEmpty)
        {
            ActivateUIComponents();
            time = TimeSpan.FromSeconds(timeToUnlock);
            timeText.text = time.Hours.ToString() + ":" + time.Minutes.ToString() + ":" + time.Seconds.ToString();
            GetDiamondCost();
            if (isOpening)
            {
                StartClock();
            }
        }
    }

    private void GetDiamondCost()
    {
        diamondCost = ((int)timeToUnlock / 60)/10;
        diamondCostText.text = diamondCost.ToString();
    }

    private void StartClock()
    {
        if (!canOpen)
        {
            timeToUnlock -= Time.deltaTime;
            if (timeToUnlock == 0)
            {
                canOpen = true;
                isOpening = false;
                GameService.Instance.canUnlock = true;
                buyWithDiamonds.gameObject.SetActive(false);
                startTimer.gameObject.SetActive(false);
                return;
            }
        }
        else
        {
            timeToUnlock = 0;
        }
    }

    private void CheckForButtonClick()
    {
        buyWithDiamonds.onClick.AddListener(Buy);
        startTimer.onClick.AddListener(CanOpen);
        chestButton.onClick.AddListener(Unlock);
    }

    async private void Unlock()
    {
        if (canOpen)
        {
            coinReward = chestScriptableObject.CoinReward();
            diamondReward = chestScriptableObject.DiamondReward();
            CollectRewards();
            DeactivateUIComponents();
            isEmpty = true;
        }
        else
        {
            timerNotComplete.SetActive(true);
            await new WaitForSeconds(popUpTime);
            timerNotComplete.SetActive(false);
        }
    }

    async private void Buy()
    {
        if(GameService.Instance.diamonds > diamondCost)
        {
            GameService.Instance.diamonds -= diamondCost;
            canOpen = true;
        }
        else
        {
            notEnoughDiamonds.SetActive(true);
            await new WaitForSeconds(popUpTime);
            notEnoughDiamonds.SetActive(false);
        }
    }

    
    async public void CanOpen() 
    {
        if (GameService.Instance.canUnlock)
        {
            isOpening = true;        
        }
        else
        {
            cantUnlock.SetActive(true);
            await new WaitForSeconds(popUpTime);
            cantUnlock.SetActive(false);
        }
    }

    public void CollectRewards()
    {
        GameService.Instance.coins += coinReward;
        GameService.Instance.diamonds += diamondReward;

    }
}
