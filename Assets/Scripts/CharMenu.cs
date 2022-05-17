using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharMenu : MonoBehaviour
{
    public Text levelText, hitpointText, moneyText;
    public Image weaponSprite;
    public RectTransform xpBar;

    public void UpdateMenu()
    {
        levelText.text = "Nao Implementado";
        hitpointText.text = GameManager.instance.player.hp.ToString();
        moneyText.text = GameManager.instance.money.ToString();

        xpBar.localScale = new Vector3(0.5f, 0, 0);
    }
}