using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControllerHandler : MonoBehaviour
{

    public bool dead;

    public float maxHealth, curHealth;
    public float maxStamina, curStamina;
    public float maxMana, curMana;

    public int level, maxExp, curExp;

    public GUIStyle healthBarRed;
    public GUIStyle manaBarBlue;
    public GUIStyle expBarGreen;

    public Slider staminaSlider;

    // Use this for initialization
    void Start()
    {
        maxHealth = 100f;
        curHealth = maxHealth;
        maxStamina = 100f;
        curStamina = maxStamina;
        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = curStamina;
        maxMana = 100f;
        curMana = maxMana;
        maxExp = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (staminaSlider.maxValue != maxStamina)
        {
            staminaSlider.maxValue = maxStamina;
        }
        if (staminaSlider.value != curStamina)
        {
            staminaSlider.value = curStamina;
        }

        // LEVELS
        if(curExp >= maxExp)
        {
            curExp -= maxExp;
            level++;
            maxHealth += 10;
            maxStamina += 7;
            maxMana += 5;
            maxExp += 50;
        }
        else if (curExp < 0)
        {
            curExp = 0;
        }
    }

    // LateUpdate is called after Update
    void LateUpdate()
    {
        // HEALTH
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if (curHealth <= 0 && !dead)
        {
            curHealth = 0;
            dead = true;
        }
        else if (curHealth < 0)
        {
            curHealth = 0;
        }
        // STAMINA
        if (curStamina > maxStamina)
        {
            curStamina = maxStamina;
        }
        if (curStamina <= 0)
        {
            curStamina = 0;
        }
        // MANA
        if (curMana > maxMana)
        {
            curMana = maxMana;
        }
        if (curMana <= 0)
        {
            curMana = 0;
        }

    }
    void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;
        // GUI element type Box
        // new Rect
        // x Start point, y Start point
        // x Size and y Size
        // elements constant
        GUI.Box(new Rect(6 * scrW, scrH, 4 * scrW, 0.5f * scrH), ""); // BackGround
        GUI.Box(new Rect(6 * scrW, scrH, curHealth * (4 * scrW) / maxHealth, 0.5f * scrH), "", healthBarRed); // Health bar
        // GUI element type Box
        // new Rect
        // x Start point, y Start point
        // x Size and y Size
        // elements constant
        GUI.Box(new Rect(6 * scrW, 1.5f * scrH, 4 * scrW, 0.5f * scrH), ""); // BackGround
        GUI.Box(new Rect(6 * scrW, 1.5f * scrH, curMana * (4 * scrW) / maxMana, 0.5f * scrH), "", manaBarBlue); // Mana bar
         // GUI element type Box
        // new Rect
        // x Start point, y Start point
        // x Size and y Size
        // elements constant
        GUI.Box(new Rect(6 * scrW, 2f * scrH, 4 * scrW, 0.25f * scrH), ""); // BackGround
        GUI.Box(new Rect(6 * scrW, 2f * scrH, curExp * (4 * scrW) / maxExp, 0.25f * scrH), "", expBarGreen); // Experience bar

    }
}
