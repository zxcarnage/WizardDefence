using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class ShopItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private TMP_Text _damage;
    [SerializeField] private TMP_Text _manaCost;
    [SerializeField] private Button _sellButton;
    [SerializeField] private Image _icon;
    [SerializeField] private GameObject _lockImage;

    [HideInInspector] public UnityEvent<Spell,ShopItem> SellButtonClicked;

    private Spell _spell;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClicked);
    }

    public void Render(Spell spell)
    {
        _spell = spell;
        _label.text = spell.Name;
        _damage.text = spell.GetComponent<Projectile>().Damage.ToString();
        _manaCost.text = spell.ManaCost.ToString();
        _price.text = spell.Cost.ToString();
        _icon.sprite = spell.SpellIcon;
    }

    public void Lock()
    {
        _sellButton.interactable = false;
        _lockImage.SetActive(true);
    }

    private void OnButtonClicked()
    {
        Lock();
        SellButtonClicked.Invoke(_spell,this);
    }
}
