using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _maxMana;
    [SerializeField] private List<Spell> _spells;
    [SerializeField] private Transform _castPoint;

    private int _currentHealth;
    private int _currentMana;
    private int _currentSpellNum = 0;
    private bool _isPaused;
    private Spell _currentSpell;
    private Animator _animator;


    [HideInInspector] public UnityEvent<int, int> HealthChanged;
    [HideInInspector] public UnityEvent<Spell> SpellChanged;
    [HideInInspector] public UnityEvent<int,int> ManaChanged;
    [HideInInspector] public UnityEvent<int> MoneyChanged;

    public int Money { get; private set; }

    public bool IsPaused { private get; set; }

    private void Start()
    {
        _currentHealth = _maxHealth;
        _currentMana = _maxMana;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        TryCastSpell();
    }

    private void TryCastSpell()
    {
        if (_currentSpell == null)
            return;
        if (Input.GetMouseButtonDown(0) && _currentMana >= _currentSpell.ManaCost && IsPaused == false)
        {
            _animator.SetTrigger("Attack");
            _currentSpell.Cast(_castPoint);
            _currentMana -= _currentSpell.ManaCost;
            ManaChanged.Invoke(_currentMana, _maxMana);
        }
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged.Invoke(_currentHealth, _maxHealth);
        if (_currentHealth <= 0)
            Die();
    }

    public void AddMoney(int moneyCount)
    {
        Money += moneyCount;
        MoneyChanged.Invoke(Money);
    }

    public void BuySpell(Spell spell)
    {
        Money -= spell.Cost;
        _spells.Add(spell);
        TrySetSpell(spell);
    }

    public void NextSpell()
    {
        if (_currentSpellNum == _spells.Count - 1)
            _currentSpellNum = 0;
        else
            _currentSpellNum++;
        ChangeSpell(_spells[_currentSpellNum]);
        SpellChanged.Invoke(_spells[_currentSpellNum]);
    }

    public void PreviousSpell()
    {
        if (_currentSpellNum == 0)
            _currentSpellNum = _spells.Count - 1;
        else
            _currentSpellNum--;
        ChangeSpell(_spells[_currentSpellNum]);
        SpellChanged.Invoke(_spells[_currentSpellNum]);
    }

    public void FullfillMana()
    {
        _currentMana = _maxMana;
        ManaChanged.Invoke(_currentMana,_maxMana);
    }

    private void ChangeSpell(Spell spell)
    {
        _currentSpell = spell;
    }

    private void TrySetSpell(Spell spell)
    {
        if (_currentSpell == null)
        {
            _currentSpell = spell;
            SpellChanged.Invoke(spell);
        }
            
    }

    private void Die()
    {
        if(gameObject)
            Destroy(gameObject);
    }
}
