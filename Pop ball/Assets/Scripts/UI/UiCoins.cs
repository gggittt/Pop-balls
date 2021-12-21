using TMPro;
using UnityEngine;

namespace UI
{
    public class UiCoins : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private TMP_Text _tmpText;
        [SerializeField] private string _description = "Coins: ";

        private void Awake()
        {
            _player.OnCoinsChanged += UpdateUi;
        }

        private void OnDisable()
        {
            _player.OnCoinsChanged -= UpdateUi;
        }

        private void UpdateUi(int newValue)
        {
            _tmpText.text = _description + newValue.ToString();
        }
    }
}