using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Projectile))]
public abstract class Spell : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private bool _isBought = false;
    [SerializeField] private int _cost;
    [SerializeField] private int _manaCost;
    [SerializeField] private Sprite _spellIcon;

    protected Projectile Projectile;
    public int ManaCost => _manaCost;

    public string Name => _name;
    public bool IsBought => _isBought;
    public int Cost => _cost;
    public Sprite SpellIcon => _spellIcon;

    abstract public void Cast(Transform castPoint);

    private void OnApplicationQuit()
    {
        _isBought = false;
    }
    public void Sell()
    {
        _isBought = true;
    }

}
