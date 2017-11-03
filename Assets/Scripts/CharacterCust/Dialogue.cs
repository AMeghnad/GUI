using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NPC/Dialogue")]
public class Dialogue : MonoBehaviour
{
    #region Variables
    [Header("References")]
    public bool showDlg;
    public int index, optionIndex;    
    public GameObject player;
    public MouseLook mainCam;
    [Header("Dialogue")]
    public string nPCName;
    public string[] text;
    #endregion
    #region Start
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mainCam = Camera.main.GetComponent<MouseLook>();
    }
    #endregion
    #region OnGUI
    // Update is called once per frame
    void OnGUI()
    {
        if (showDlg)
        {
            float scrW = Screen.width / 16;
            float scrH = Screen.height / 9;

            GUI.Box(new Rect(0, 6*scrH, Screen.width, 3*scrH),text[index]);
            if(!(index+1 >= text.Length || index == optionIndex))
            {
                if (GUI.Button(new Rect(15*scrW, 8.5f*scrH,scrW,0.5f*scrH ),"Next"))
                {
                    index++;
                }
            }
            else if(index == optionIndex)
            {
                if (GUI.Button(new Rect(15 * scrW, 8.5f * scrH, scrW, 0.5f * scrH), "Accept"))
                {
                    index++;
                }
                if (GUI.Button(new Rect(14 * scrW, 8.5f * scrH, scrW, 0.5f * scrH), "Decline"))
                {
                    index = text.Length - 1;
                }
            }
            else
            {
                if (GUI.Button(new Rect(15 * scrW, 8.5f * scrH, scrW, 0.5f * scrH), "Bye."))
                {
                    index = 0;
                    showDlg = false;
                    player.GetComponent<Movement>().enabled = true;
                    player.GetComponent<MouseLook>().enabled = true;
                    mainCam.enabled = true;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
            }
        }
    }
    #endregion
}
