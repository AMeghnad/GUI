using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldSpaceGUI : MonoBehaviour
{
    public int enemyCurHealth, enemyMaxHealth;
    public Vector2 targetPos;
    public Transform target;
    // Update is called once per frame
    void LateUpdate()
    {
        targetPos = Camera.main.WorldToScreenPoint(transform.position);
        if (enemyCurHealth < 0)
        {
            enemyCurHealth = 0;
        }
        if (enemyCurHealth > enemyMaxHealth)
        {
            enemyCurHealth = enemyMaxHealth;
        }
    }

    void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;
        float size = CalculateSize();
        if (size != 0)
            GUI.Box(new Rect(targetPos.x - 0.5f * scrW * size, -targetPos.y / size + scrH * 8f, (enemyCurHealth * scrW / enemyMaxHealth) * size, (scrH * 0.25f) * size), "");
    }

    float CalculateSize()
    {
        float size = 2f;
        float playerDistance = Vector3.Distance(target.position, transform.position);
        if (playerDistance <= 15f)
        {
            size -= playerDistance * 0.1f;
        }
        else if (playerDistance < 16f)
            size -= 1.5f;
        else
        {
            size = 0;
        }
        return size;

    }
}
