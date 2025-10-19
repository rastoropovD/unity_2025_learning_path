using UnityEngine;
using UnityEngine.UI;

namespace ProjectAssets.Scripts
{
    public sealed class PlayerHealthController : MonoBehaviour
    {
        [SerializeField] private Slider _healthPointsBar; // progress HP
        [SerializeField] private Text _healthPointsText; // HP: 50
        [SerializeField] private Text _healthText; //  heartIcon: 2/3

        public void UpdateHealth(int value)
        {
            // _healthPointsBar.value = value;
            // _healthPointsText.text = $"HP: {value}";
            
            // some logic to track HP amount and update health count
            // if HP < maxHp -> decrease health count (_healthText) and reset _healthPointsText and _healthPointsBar
        }
    }
}