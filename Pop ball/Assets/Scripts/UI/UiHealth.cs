using TMPro;
using UnityEngine;

namespace UI
{
    public class UiHealth : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private TMP_Text _tmpText;
        [SerializeField] private string _description = "Health: ";

        private void Awake()
        {
            _player.OnHealthChanged += UpdateUi;
        }

        private void OnDisable()
        {
            _player.OnHealthChanged -= UpdateUi;
        }

        private void UpdateUi(int newValue)
        {
            _tmpText.text = _description + newValue.ToString();
        }
    }
}