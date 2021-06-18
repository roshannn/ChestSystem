using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public ChestService chestService;
    private ChestScriptableObject chest;
    private Animator animator;
    private Image chestImage;
    public Text timer;
    private int timeToUnlock;
    public Button startTimer;
    public Button buyWithGems;
    private void Start()
    {
        animator = GetComponent<Animator>();
        chest = chestService.GetRandomChest();
        chestImage = chest.chestImage;
        timeToUnlock = chest.timeToUnlock;
    }

    private void Update()
    {
        
        timer.text = timeToUnlock.ToString();
        startTimer.onClick.AddListener(StartTimer());

    }

    private void StartTimer()
    {
        if (GameService.Instance.canUnlock)
        {
            //addlogic to start time count
        }
        else
        {
            animator.SetBool("canUnlock",false);
        }
    }
}
