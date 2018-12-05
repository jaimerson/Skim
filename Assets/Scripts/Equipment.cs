using UnityEngine;

public enum EquipmentType
{
    Helmet,
    Armor,
    Weapon,
}

[CreateAssetMenu]
public class Equipment : Item {
   
   
    public int strength = 10;
    public int magic = 0;   
    public int defense = 0;  
    public int maxHP = 100;
    public int maxMP = 100;

    public EquipmentType equipmentType;
}
