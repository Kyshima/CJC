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
        weaponSprite.sprite = GameManager.instance.weaponSprite[GameManager.instance.weapon.weaponLevel];

        levelText.text = GameManager.instance.getLevel().ToString();
        hitpointText.text = GameManager.instance.player.hp.ToString();
        moneyText.text = GameManager.instance.money.ToString();


        int currLevel = GameManager.instance.getLevel();
        if(currLevel == GameManager.instance.xpTable.Count)
        {
            xpBar.localScale = Vector3.one;
        }
        else
        {
            int prevLevelXp = GameManager.instance.getXPLevel(currLevel - 1);
            int currLevelXp = GameManager.instance.getXPLevel(currLevel);

            int diff = currLevelXp - prevLevelXp;
            int currXpIntoLevel = GameManager.instance.xp - prevLevelXp;

            float completion = (float)currXpIntoLevel / (float) diff;
            xpBar.GetComponent<RectTransform>().sizeDelta = new Vector2(400*completion, 15);
        }
        
    }
}