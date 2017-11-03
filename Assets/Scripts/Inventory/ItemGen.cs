using UnityEngine;

public static class ItemGen
{
    public static Item CreateItem(int itemID)
    {
        Item temp = new Item();
        string name = "";
        int itemValue = 0;
        string description = "";
        string icon = "";
        string mesh = "";
        ItemType type = ItemType.Food;

        switch (itemID)
        {
            #region Food 0-99
            case 0:
                name = "Cheese Wheel";
                itemValue = 5;
                description = "A Wheel of Cheese";
                icon = "CheeseWheel";
                mesh = "CheeseWheel";
                type = ItemType.Food;
                break;
            case 1:
                name = "Apple";
                itemValue = 5;
                description = "Munchies and Crunchies";
                icon = "Apple";
                mesh = "Apple";
                type = ItemType.Food;
                break;
                #endregion
        }

        temp.ID = itemID;
        temp.Name = name;
        temp.Value = itemValue;
        temp.Description = description;
        temp.Icon = Resources.Load("Icons/" + icon) as Texture2D;
        temp.Mesh = mesh;
        temp.Type = type;
        return temp;
    }
}
