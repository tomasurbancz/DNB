namespace SimpleEnemyFight2;

public class Inventory
{
    public Dictionary<int, Item> items;

    public Inventory()
    {;
        Clear();
    }

    public bool IsSameType(Item item, Type type)
    {
        return item.GetType().IsAssignableFrom(type);
    }
    
    public bool ContainsType(Type type)
    {
        foreach (var keyValuePair in items)
        {
            if (IsSameType(keyValuePair.Value, type)) return true;
        }
        return false;
    }

    public Dictionary<int, Item> GetItemsOfType(Type type)
    {
        Dictionary<int, Item> dictionary = new Dictionary<int, Item>();

        foreach (var keyValuePair in items)
        {
            if(IsSameType(keyValuePair.Value, type)) dictionary.Add(keyValuePair.Key, keyValuePair.Value);
        }
        return dictionary;
    }

    public List<Item> GetListItemsOfType(Type type)
    {
        List<Item> list = new List<Item>();

        foreach (var keyValuePair in items)
        {
            if(IsSameType(keyValuePair.Value, type)) list.Add(keyValuePair.Value);
        }
        return list;
    }
    
    public Item GetItemAtSlot(int i)
    {
        return items[i];
    }

    public void Clear()
    {
        items = new Dictionary<int, Item>();
        for (int i = 0; i < 30; i++)
        {
            items.Add(i, new ClearSlot());
        }
    }

    public void AddItem(Item item)
    {
        foreach (var slot in items)
        {
            if (IsSameType(slot.Value, typeof(ClearSlot)))
            {
                items.Remove(slot.Key);
                items.Add(slot.Key, item);
                Sort();
                SetWeaponOnFirstSlot();
                return;
            }
        }
    }

    public void SetItemAtSlot(int slot, Item item)
    {
        items[slot] = item;
    }

    public void SwapSlots(int slot1, int slot2)
    {
        Item item1 = items[slot1];
        Item item2 = items[slot2];
        SetItemAtSlot(slot1, item2);
        SetItemAtSlot(slot2, item1);
        Sort();
    }

    private void Sort()
    {
        items = items.OrderBy(dic => dic.Key).ToDictionary(dic => dic.Key, dic => dic.Value);
    }

    private bool IsEmpty()
    {
        return !(ContainsType(typeof(Weapon)) || ContainsType(typeof(Potion)));
    } 
    
    public void Print()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Máš prázdný inventář");
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                if(!items.ContainsKey(i)) continue;
                if (!IsSameType(items[i], typeof(ClearSlot)))
                {
                    Console.WriteLine("Slot " + i + " - " + items[i].GetName() + " (" + items[i].GetStat() + ")");
                }
            }
        }
    }

    public int GetIndexOfItem(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if(!items.ContainsKey(i)) continue;
            if (items[i].Equals(item)) return i;
        }
        return -1;
    }

    public void RemoveItem(Item item)
    {
        int index = GetIndexOfItem(item);
        if (index != -1) items.Remove(index);
    }

    public void SetWeaponOnFirstSlot()
    {
        if (ContainsType(typeof(Weapon)))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (IsSameType(items[i], typeof(Weapon)))
                {
                    SwapSlots(0, i);
                    return;
                }
            }
        }
    }
    
    public string PickStrongestWeapon()
    {
        string returnText = "Nemáš žádnou zbraň v inventáři";
        SetWeaponOnFirstSlot();
        if (IsSameType(items[0], typeof(Weapon)))
        {
            Weapon pickedWeapon = (Weapon)items[0];
            Weapon strongestWeapon = pickedWeapon;
            for (int i = 0; i < items.Count; i++)
            {
                if (IsSameType(items[i], typeof(Weapon)))
                {
                    if (strongestWeapon.GetStat() < items[i].GetStat())
                    {
                        strongestWeapon = (Weapon) items[i];
                    }
                }
            }

            if (pickedWeapon.Equals(strongestWeapon))
            {
                returnText = "Aktuálně držíš nejsilnější zbraň v inventáři";
            }
            else
            {
                SwapSlots(GetIndexOfItem(pickedWeapon), GetIndexOfItem(strongestWeapon));
                returnText = "Item: {\n" + pickedWeapon.GetName() + "\n(" + pickedWeapon.GetStat() + ")\n}" + "\nByl změněn za item: {\n" + strongestWeapon.GetName() + "\n(" + strongestWeapon.GetStat() + ")\n}";
            }
        }
        return returnText;
    }
}