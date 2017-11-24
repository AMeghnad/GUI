using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> inv = new List<Item>();
    public bool showInv;
    public Item selectedItem;
    public int money;
    public Vector2 scrollPos;
    public GameObject wHand, curWeapon;
    public MouseLook mainCam, playerCam;

    // Use this for initialization
    void Start()
    {
        wHand = GameObject.FindGameObjectWithTag("weaponHandler");
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseLook>();
        playerCam = this.GetComponent<MouseLook>();
        inv.Add(ItemGen.CreateItem(0));
        inv.Add(ItemGen.CreateItem(1));
        inv.Add(ItemGen.CreateItem(100));
        inv.Add(ItemGen.CreateItem(101));
        inv.Add(ItemGen.CreateItem(200));
        inv.Add(ItemGen.CreateItem(201));
        inv.Add(ItemGen.CreateItem(202));
        inv.Add(ItemGen.CreateItem(0));
        inv.Add(ItemGen.CreateItem(1));
        inv.Add(ItemGen.CreateItem(100));
        inv.Add(ItemGen.CreateItem(101));
        inv.Add(ItemGen.CreateItem(200));
        inv.Add(ItemGen.CreateItem(201));
        inv.Add(ItemGen.CreateItem(202));
        inv.Add(ItemGen.CreateItem(0));
        inv.Add(ItemGen.CreateItem(1));
        inv.Add(ItemGen.CreateItem(100));
        inv.Add(ItemGen.CreateItem(101));
        inv.Add(ItemGen.CreateItem(200));
        inv.Add(ItemGen.CreateItem(201));
        inv.Add(ItemGen.CreateItem(202));
        inv.Add(ItemGen.CreateItem(0));
        inv.Add(ItemGen.CreateItem(1));
        inv.Add(ItemGen.CreateItem(100));
        inv.Add(ItemGen.CreateItem(101));
        inv.Add(ItemGen.CreateItem(200));
        inv.Add(ItemGen.CreateItem(201));
        inv.Add(ItemGen.CreateItem(202));
        inv.Add(ItemGen.CreateItem(0));
        inv.Add(ItemGen.CreateItem(1));
        inv.Add(ItemGen.CreateItem(100));
        inv.Add(ItemGen.CreateItem(101));
        inv.Add(ItemGen.CreateItem(200));
        inv.Add(ItemGen.CreateItem(201));
        inv.Add(ItemGen.CreateItem(202));
        inv.Add(ItemGen.CreateItem(0));
        inv.Add(ItemGen.CreateItem(1));
        inv.Add(ItemGen.CreateItem(100));
        inv.Add(ItemGen.CreateItem(101));
        inv.Add(ItemGen.CreateItem(200));
        inv.Add(ItemGen.CreateItem(201));
        inv.Add(ItemGen.CreateItem(202));
        inv.Add(ItemGen.CreateItem(0));
        inv.Add(ItemGen.CreateItem(1));
        inv.Add(ItemGen.CreateItem(100));
        inv.Add(ItemGen.CreateItem(101));
        inv.Add(ItemGen.CreateItem(200));
        inv.Add(ItemGen.CreateItem(201));
        inv.Add(ItemGen.CreateItem(202));
        inv.Add(ItemGen.CreateItem(0));
        inv.Add(ItemGen.CreateItem(1));
        inv.Add(ItemGen.CreateItem(100));
        inv.Add(ItemGen.CreateItem(101));
        inv.Add(ItemGen.CreateItem(200));
        inv.Add(ItemGen.CreateItem(201));
        inv.Add(ItemGen.CreateItem(202));
        inv.Add(ItemGen.CreateItem(0));
        inv.Add(ItemGen.CreateItem(1));
        inv.Add(ItemGen.CreateItem(100));
        inv.Add(ItemGen.CreateItem(101));
        inv.Add(ItemGen.CreateItem(200));
        inv.Add(ItemGen.CreateItem(201));
        inv.Add(ItemGen.CreateItem(202));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInv();
        }
    }

    public bool ToggleInv()
    {
        if (showInv)
        {
            showInv = false;
            Time.timeScale = 1;
            // turn back on char and cam movement/mouseLook
            Camera.main.GetComponent<MouseLook>().enabled = true;
            gameObject.GetComponent<Movement>().enabled = true;
            gameObject.GetComponent<MouseLook>().enabled = true;

            // lock and hide our cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            return (false);
        }
        else
        {
            showInv = true;
            Time.timeScale = 0;
            //turn back off char and cam movement/mouseLook
            Camera.main.GetComponent<MouseLook>().enabled = false;
            gameObject.GetComponent<Movement>().enabled = false;
            gameObject.GetComponent<MouseLook>().enabled = false;
            // unlock and show our cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            return (true);
        }
    }

    void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;
        if (showInv)
        {
            // Background for inventory labelled Inventory
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Inventory");
            // If less than or equal to x items no scroll view
            if (inv.Count <= 35)
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(0.5f * scrW, 0.25f * scrH * (1 + i), 3 * scrW, 0.3f * scrH), inv[i].Name))
                    {
                        selectedItem = inv[i];
                        Debug.Log(selectedItem.Name);
                    }
                }
            }
            else
            {
                // if more then we can scroll and add the same space according to the same rulez
                scrollPos = GUI.BeginScrollView(new Rect(0, 0, 6 * scrW, 9 * scrH), scrollPos, new Rect(0, 0, 0, 9 * scrH + ((inv.Count - 35) * 0.25f * scrH)), false, true);
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(0.5f * scrW, 0.25f * scrH * (1 + i), 3 * scrW, 0.3f * scrH), inv[i].Name))
                    {
                        selectedItem = inv[i];
                        Debug.Log(selectedItem.Name);
                    }
                }
                GUI.EndScrollView();
            }
            if (selectedItem != null)
            {
                if (selectedItem.Type == ItemType.Food)
                {
                    GUI.Box(new Rect(8 * scrW, 5 * scrH, 8 * scrW, 3 * scrH), selectedItem.Name + "\n" + selectedItem.Value);
                    GUI.DrawTexture(new Rect(11 * scrW, 1.5f * scrH, 2 * scrW, 2 * scrH), selectedItem.Icon);
                    if (GUI.Button(new Rect(15 * scrW, 8.75f * scrH, scrW, 0.25f * scrH), "Eat"))
                    {
                        Debug.Log("Om nom nom, I love " + selectedItem.Name);
                        inv.Remove(selectedItem);
                        selectedItem = null;
                    }
                }
                if (selectedItem.Type == ItemType.Weapon)
                {
                    GUI.Box(new Rect(8 * scrW, 5 * scrH, 8 * scrW, 3 * scrH), selectedItem.Name + "\n" + selectedItem.Value);
                    GUI.DrawTexture(new Rect(11 * scrW, 1.5f * scrH, 2 * scrW, 2 * scrH), selectedItem.Icon);
                    if (GUI.Button(new Rect(15 * scrW, 8.75f * scrH, scrW, 0.25f * scrH), "Equip"))
                    {
                        Debug.Log("Ahh, my Mighty " + selectedItem.Name);
                        if (curWeapon != null)
                        {
                            Destroy(curWeapon);
                        }
                        curWeapon = Instantiate(Resources.Load("Prefabs/" + selectedItem.Mesh) as GameObject, wHand.transform.position, Quaternion.identity, wHand.transform);
                        selectedItem = null;
                    }
                }
                if (selectedItem.Type == ItemType.Apparel)
                {

                }
                if (selectedItem.Type == ItemType.Crafting)
                {

                }
                if (selectedItem.Type == ItemType.Quest)
                {

                }
                if (selectedItem.Type == ItemType.Ingredients)
                {

                }
            }
        }
    }
}
