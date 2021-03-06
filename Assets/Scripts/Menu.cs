﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    [Header("Screen Elements")]
    public bool showOptions;
    public int scrW, scrH;

    [Header("Keys")]
    public KeyCode forward;
    public KeyCode backward;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode crouch;
    public KeyCode interact;
    public KeyCode sprint;
    public KeyCode holdingKey;

    [Header("Resolutions")]
    public int index;
    public bool showRes;
    public bool fullScreenToggle;
    public int[] resX, resY;
    private Vector2 scrollPosRes;

    [Header("References")]
    public AudioSource mainMusic;
    public float volumeSlider, holdingVolume;
    public bool muteToggle;
    public Light brightness;
    public float brightnessSlider;

    [Header("Art")]
    public GUISkin menuSkin;
    public GUIStyle boxStyle;

    void Start()
    {
        scrW = Screen.width / 16;
        scrH = Screen.height / 9;
        fullScreenToggle = true;
        brightness = GameObject.FindGameObjectWithTag("Sun").GetComponent<Light>();
        mainMusic = GameObject.Find("MenuMusic").GetComponent<AudioSource>();
        volumeSlider = mainMusic.volume;
        brightnessSlider = brightness.intensity;      
    }

    void Update()
    {
        if (mainMusic != null)
        {
            if (muteToggle == false)
            {
                if (mainMusic.volume != volumeSlider)
                {
                    holdingVolume = volumeSlider;
                    mainMusic.volume = volumeSlider;
                }
            }
        }

        if (brightness != null)
        {
            if (brightnessSlider != brightness.intensity)
            {
                brightness.intensity = brightnessSlider;
            }
        }        
    }

    void OnGUI()
    {
        GUI.skin = menuSkin;

        if (!showOptions)//if we are on our menu
        {            
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "", boxStyle);//background
            GUI.Label(new Rect(4 * scrW, 0.25f * scrH, 8 * scrW, 2 * scrH), "Anshu's Secret Screen");//Title
            //Buttons
            if (GUI.Button(new Rect(6 * scrW, 4 * scrH, 4 * scrW, scrH), "Play"))
            {
                SceneManager.LoadScene(1);
            }
            if (GUI.Button(new Rect(6 * scrW, 5 * scrH, 4 * scrW, scrH), "Options"))
            {
                showOptions = true;
            }
            if (GUI.Button(new Rect(6 * scrW, 6 * scrH, 4 * scrW, scrH), "Exit"))
            {
                Application.Quit();
            }
            GUI.skin = null;
        }
        if (showOptions)//if we are in options
        {
            if (scrW != Screen.width / 16 || scrH != Screen.height / 9) // if screen was not already in 16:9 ratio...
            {
                scrW = Screen.width / 16;
                scrH = Screen.height / 9;
                // ... it certainly is now
            }
            if (GUI.Button(new Rect(14.5f * scrW, 8f * scrH, 1.5f * scrW, .75f * scrH), "Back")) // Back button
            {
                showOptions = !showOptions;
            }

            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");//background box
            
            #region Audio and Brightness
            int i = 0;
            GUI.Label(new Rect(4 * scrW, 0.25f * scrH, 8 * scrW, 2 * scrH), "Options");//Title

            GUI.Box(new Rect(0.5f * scrW, 3 * scrH + (i * 0.75f * scrH), 1.5f * scrW, 0.5f * scrH), "Volume");
            volumeSlider = GUI.HorizontalSlider(new Rect(2 * scrW, 3.25f * scrH + (i * 0.75f * scrH), 2f * scrW, 0.25f * scrH), volumeSlider, 0, 1);

            if (GUI.Button(new Rect(4.25f * scrW, 3 * scrH + (i * (scrH * 0.5f)), 1f * scrW, 0.5f * scrH), "Mute")) // Label
            {
                ToggleVolume();
            }

            i++;
            GUI.Box(new Rect(0.5f * scrW, 3 * scrH + (i * 0.75f * scrH), 1.5f * scrW, 0.5f * scrH), "Brightness");
            brightnessSlider = GUI.HorizontalSlider(new Rect(2 * scrW, 3.25f * scrH + (i * 0.75f * scrH), 2f * scrW, 0.25f * scrH), brightnessSlider, 0, 1);
            #endregion
            #region Resolution and Screen
            i++;
            
            if (GUI.Button(new Rect(0.5f * scrW, 3 * scrH + (i * 0.75f * scrH), 1.5f * scrW, 0.5f * scrH), "Resolutions"))
            {
                showRes = !showRes;
            }
            if (GUI.Button(new Rect(2f * scrW, 3 * scrH + (i * 0.75f * scrH), 1.5f * scrW, 0.5f * scrH), "Fullscreen"))
            {
                FullScreenToggle();
            }
            i++;
            i++;
            if (showRes)
            {
                GUI.Box(new Rect(0.25f * scrW, 3 * scrH + (i * (scrH * 0.5f)), 1.75f * scrW, 3.5f * scrH), "");

                scrollPosRes = GUI.BeginScrollView(new Rect(0.25f * scrW, 3 * scrH + (i * (scrH * 0.5f)), 1.75f * scrW, 3.5f * scrH), scrollPosRes, new Rect(0, 0, 1.75f * scrW, 3.5f * scrH));

                for (int resSize = 0; resSize < resX.Length; resSize++)
                {
                    if (GUI.Button(new Rect(0f * scrW, 0 * scrH + resSize * (scrH * 0.5f), 1.75f * scrW, 0.5f * scrH), resX[resSize].ToString() + "x" + resY[resSize].ToString()))
                    {
                        Screen.SetResolution(resX[resSize], resY[resSize], fullScreenToggle);
                        showRes = false;
                    }
                }
                GUI.EndScrollView();
            }
            #endregion

            #region Player Controls

            GUI.Button(new Rect(10f * scrW, 1 * scrH + (i * (scrH * 0.5f)), 1.5f * scrW, 0.5f * scrH), "Controls");
            #endregion
        }

    }

    bool ToggleVolume()
    {
        if (muteToggle == true)
        {
            muteToggle = false;
            volumeSlider = holdingVolume;
            return false;
        }
        else
        {
            muteToggle = true;
            holdingVolume = volumeSlider;
            volumeSlider = 0;
            mainMusic.volume = 0;
            return true;
        }
    }

    bool FullScreenToggle()
    {
        if (fullScreenToggle)
        {
            fullScreenToggle = false;
            Screen.fullScreen = false;
            return false;
        }
        else
        {
            fullScreenToggle = true;
            Screen.fullScreen = true;
            return true;
        }
    }   
}
