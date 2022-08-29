using TMPro;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _moneyCount;

    private void OnEnable()
    {
        _player.MoneyChanged.AddListener(ChangeMoneyCount);
    }

    private void ChangeMoneyCount(int playerMoney)
    {
        _moneyCount.text = playerMoney.ToString();
    }

    private void OnDisable()
    {
        _player.MoneyChanged.RemoveListener(ChangeMoneyCount);
    }
}
