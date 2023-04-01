using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Drop Table", menuName = "Game Prog 1/Item Drop table")]
public class ItemDropTable : ScriptableObject
{
    public List<Item> itemList;    
    public Item GetRandomItem()
    {
        var totalDropRate = 0;
        foreach (var item in itemList)
        {
            totalDropRate += item.DropRate;
        }
        var randomValue = UnityEngine.Random.Range(0, totalDropRate);
        var currentDropRate = 0;
        foreach (var item in itemList)
        {
            currentDropRate += item.DropRate;
            if (randomValue < currentDropRate)
            {
                return item;
            }
        }
        return null;
    }

    public void AddItems()
    {
        itemList.Add(new ConsumableItem());

        foreach (var item in itemList)
        {
            item.UseItem();
        }
    }
}

[System.Serializable]
public class Item
{
    public string Name;
    public ItemType Type;
    public Sprite ItemIcon;
    public int DropRate;

    public virtual void UseItem()
    {
        Debug.Log("Item used");
    }
}

public enum ItemType
{
    Potion,
    Sword,
    Rock
}
[Serializable]
public class ConsumableItem : Item
{
    public int Quantity;

    public override void UseItem()
    {
        Debug.LogError("You can use this item");
    }
}
