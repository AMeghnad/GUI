using UnityEngine;

public class Item
{
    #region Private Var
    private int idNum;
    private string name;
    private int itemValue;
    private string description;
    private Texture2D icon;
    private string mesh;
    private ItemType type;
    #endregion
    public void ItemConstructor(int itemId, string itemName, Texture2D itemIcon, ItemType itemType)
    {
        idNum = itemId;
        name = itemName;
        icon = itemIcon;
        type = itemType;
    }
    #region Public Var
    public int ID
    {
        get { return idNum; }
        set { idNum = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public int Value
    {
        get { return itemValue; }
        set { itemValue = value; }
    }
    public string Description
    {
        get { return description; }
        set { description = value; }
    }
    public Texture2D Icon
    {
        get { return icon; }
        set { icon = value; }
    }
    public ItemType Type
    {
        get { return type; }
        set { type = value; }
    }
    public string Mesh
    {
        get { return mesh; }
        set { mesh = value; }
    }
    #endregion
}
public enum ItemType
{
    Food,
    Weapon,
    Apparel,
    Crafting,
    Quest,
    Money,
    Ingredients,
    Potions,
    Scrolls
}
