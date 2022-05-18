using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text moneyText;   
    public void Update()
    {
        moneyText.text = GameManager.instance.money.ToString();
    }
    
}
