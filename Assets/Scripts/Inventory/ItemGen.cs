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
                name = "Meat";
                itemValue = 5;
                description = "Medium Rare";
                icon = "Meat";
                mesh = "Meat";
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
            #region Weapon 100-199
            case 100:
                name = "Axe";
                itemValue = 15;
                description = "Gimli's sole contribution";
                icon = "Axe";
                mesh = "Axe";
                type = ItemType.Weapon;
                break;

            case 101:
                name = "Bow";
                itemValue = 15;
                description = "Pew pew pew";
                icon = "Bow";
                mesh = "Bow";
                type = ItemType.Weapon;
                break;

            case 102:
                name = "Sword";
                itemValue = 15;
                description = "Stick them with the pointy end";
                icon = "Sword";
                mesh = "Sword";
                type = ItemType.Weapon;
                break;

            case 103:
                name = "Shield";
                itemValue = 15;
                description = "How is this a weapon!?";
                icon = "Shield";
                mesh = "Shield";
                type = ItemType.Weapon;
                break;
            #endregion
            #region Apparel 200-299
            case 200:
                name = "Armour";
                itemValue = 15;
                description = "Keeps your insides on the inside";
                icon = "Armour";
                mesh = "Armour";
                type = ItemType.Apparel;
                break;

            case 201:
                name = "Belt";
                itemValue = 15;
                description = "Ten more and you could be a Final Fantasy character";
                icon = "Belt";
                mesh = "Belt";
                type = ItemType.Apparel;
                break;

            case 202:
                name = "Boots";
                itemValue = 15;
                description = "Tough and sturdy, just worn enough to be comfortable";
                icon = "Boots";
                mesh = "Boots";
                type = ItemType.Apparel;
                break;

            case 203:
                name = "Bracers";
                itemValue = 15;
                description = "Made of stiff leather, keeps your wrists moist and supple";
                icon = "Bracers";
                mesh = "Bracers";
                type = ItemType.Apparel;
                break;

            case 204:
                name = "Cloak";
                itemValue = 15;
                description = "Warm and snug";
                icon = "Cloak";
                mesh = "Cloak";
                type = ItemType.Apparel;
                break;

            case 205:
                name = "Gloves";
                itemValue = 15;
                description = "Keeps your fingers attached to the rest of you";
                icon = "Gloves";
                mesh = "Gloves";
                type = ItemType.Apparel;
                break;

            case 206:
                name = "Helmet";
                itemValue = 15;
                description = "Made from fine dwarven steel, designed with function in mind";
                icon = "Helmet";
                mesh = "Helmet";
                type = ItemType.Apparel;
                break;

            case 207:
                name = "Necklace";
                itemValue = 15;
                description = "Chokers are back in fashion, you know. Though I suppose that doesn't mean much to you";
                icon = "Necklace";
                mesh = "Necklace";
                type = ItemType.Apparel;
                break;

            case 208:
                name = "Pants";
                itemValue = 15;
                description = "Protects the important bits";
                icon = "Pants";
                mesh = "Pants";
                type = ItemType.Apparel;
                break;

            case 209:
                name = "Rings";
                itemValue = 15;
                description = "Rules them all, finds them, brings them all, in the darkness binds them";
                icon = "Rings";
                mesh = "Rings";
                type = ItemType.Apparel;
                break;
            #endregion
            #region Crafting 300-399
            case 300:
                name = "Ingots";
                itemValue = 50;
                description = "";
                icon = "Ingots";
                mesh = "Ingots";
                type = ItemType.Crafting;
                break;
            case 301:
                name = "Gem";
                itemValue = 60;
                description = "";
                icon = "Gem";
                mesh = "Gem";
                type = ItemType.Crafting;
                break;
            #endregion
            #region Quest 400-499
            case 400:
                break;
            #endregion
            #region Money 500-599
            case 500:
                name = "Coins";
                itemValue = 1;
                description = "";
                icon = "Coins";
                mesh = "Coins";
                type = ItemType.Money;
                break;
            #endregion
            #region Ingredients 600-699
            case 600:
                break;
            #endregion
            #region Potions 700-799
            case 700:
                name = "HP";
                itemValue = 100;
                description = "";
                icon = "HP";
                mesh = "HP";
                type = ItemType.Potions;
                break;
            case 701:
                name = "MP";
                itemValue = 100;
                description = "";
                icon = "MP";
                mesh = "MP";
                type = ItemType.Potions;
                break;
            #endregion
            #region Scrolls 800-899
            case 800:
                name = "Scroll";
                itemValue = 75;
                description = "";
                icon = "Scroll";
                mesh = "Scroll";
                type = ItemType.Scrolls;
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
