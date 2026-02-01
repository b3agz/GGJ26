using UnityEngine;
using TMPro;

namespace John {

    public class NewCustomerMenu : MonoBehaviour {

        [SerializeField] private TextMeshProUGUI _text;

        void OnEnable() {

            if (Judger.Instance == null || Judger.Instance.Customer == null) {
                _text.text = "Your customer's are waiting. Make them a disguise that satisfies their needs. \n\n(get all the white bars into the green bits)";
            } else if (Judger.Instance.Success) {
                _text.text = $"{Judger.Instance.Customer.Name} is pleased with your disguise.";
            } else {
                _text.text = $"{Judger.Instance.Customer.Name} is NOT happy with your disguise.";
            }

        }

    }
}
