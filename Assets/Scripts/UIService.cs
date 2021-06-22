using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIService : MonoBehaviour
{
    public Text coins;
    public Text diamonds;

    private void Update()
    {
        coins.text = GameService.Instance.coins.ToString();
        diamonds.text = GameService.Instance.diamonds.ToString();
    }
}
