using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestStates : MonoBehaviour
{
    public virtual void OnStateEnter()
    {
        this.enabled = true;
    }
    public virtual void OnStateExit()
    {
        this.enabled = false;
    }

}
