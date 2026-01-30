using UnityEngine;

namespace John {

    public class StatWindow : MonoBehaviour {

        [SerializeField] private StatRangeBar _ageBar;
        [SerializeField] private StatRangeBar _glamourBar;
        [SerializeField] private StatRangeBar _coolBar;
        [SerializeField] private StatRangeBar _ruggedBar;
        [SerializeField] private StatRangeBar _groomedBar;

        public void UpdateBars(Customer customer, StatBlock stats) {

            _ageBar.UpdateVisual(customer.Range.Age, stats.Age);
            _glamourBar.UpdateVisual(customer.Range.Glamour, stats.Glamour);
            _coolBar.UpdateVisual(customer.Range.Cool, stats.Cool);
            _ruggedBar.UpdateVisual(customer.Range.Rugged, stats.Rugged);
            _groomedBar.UpdateVisual(customer.Range.Groomed, stats.Groomed);

        }

    }

}
