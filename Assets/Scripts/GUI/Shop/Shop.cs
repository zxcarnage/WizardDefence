using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Spell> _spells;
    [SerializeField] private ShopItem _itemTemplate;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _itemContainer;


    private void Start()
    {
        foreach (var spell in _spells)
        {
            AddItem(spell);
        }
    }

    private void AddItem(Spell spell)
    { 
        var item = Instantiate(_itemTemplate, _itemContainer.transform);
        item.SellButtonClicked.AddListener(TrySellItem);
        TryRenderItem(spell,item);
    }

    private void TryRenderItem(Spell spell, ShopItem item)
    {
        item.Render(spell);
        if (spell.IsBought)
            item.Lock();
    }

    private void TrySellItem(Spell spell, ShopItem item)
    {
        if (_player.Money < spell.Cost)
            return;
        item.SellButtonClicked.RemoveListener(TrySellItem);
        spell.Sell();
        _player.BuySpell(spell);
    }
}
