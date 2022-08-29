using TMPro;
using UnityEngine;

public class SpellLabel : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _spellLabel;

    private void OnEnable()
    {
        _player.SpellChanged.AddListener(ChangeLabel);
    }

    private void OnDisable()
    {
        _player.SpellChanged.RemoveListener(ChangeLabel);
    }

    private void ChangeLabel(Spell spell)
    {
        _spellLabel.text = spell.Name;
    }
}
