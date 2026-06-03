using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FlagRarity
{
    Common,
    Rare,
    Legendary
}

public class FlagType : MonoBehaviour
{
    public FlagRarity rarity = FlagRarity.Common;

    public int GetScore()
    {
        return rarity switch
        {
            FlagRarity.Common => 10,
            FlagRarity.Rare => 30,
            FlagRarity.Legendary => 100,
            _ => 10
        };
    }

    public Color GetColor()
    {
        return rarity switch
        {
            FlagRarity.Common => Color.white,
            FlagRarity.Rare => Color.blue,
            FlagRarity.Legendary => Color.yellow,
            _ => Color.white
        };
    }
}
