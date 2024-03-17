using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHP
{
    // Unit Fields
    int currentHP;
    int currentMaxHP;

    // Field Properties

    public int Health
    {
        get
        {
            return currentHP;
        }
        set
        {
            currentHP = value;
        }
    }

        public int MaxHealth
    {
        get
        {
            return currentMaxHP;
        }
        set
        {
            currentMaxHP = value;
        }
    }

    // constructor (for instantiating methods)

    public UnitHP(int health, int maxHealth)
    {
        currentHP = health;
        currentMaxHP = maxHealth;
    }

    // Methods

    public void DamageUnit(int dmgAmount)
    {
        if (currentHP > 0)
        {
            currentHP -= dmgAmount;
        }
    }

        public void HealUnit(int healAmount)
    {
        if (currentHP < currentMaxHP)
        {
            currentHP += healAmount;
        }
        if (currentHP > currentMaxHP)
        {
            currentHP = currentMaxHP;
        }
    }

}
