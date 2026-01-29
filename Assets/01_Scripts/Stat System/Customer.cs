using UnityEngine;

namespace John {

    [CreateAssetMenu(fileName = "Customer", menuName = "MoD/New Customer")]
    public class Customer : ScriptableObject {

        /// <summary>
        /// The name of this customer.
        /// </summary>
        [Tooltip("The name of this customer.")]
        [field: SerializeField] public string Name { get; private set; }

        /// <summary>
        /// How difficult we consider this customer to be so we can ensure
        /// the player gets easier customers at the start.
        /// </summary>
        [Tooltip("How difficult we consider this customer to be.")]
        [field: SerializeField] public int Difficulty { get; private set; }

        /// <summary>
        /// The starting stats of this customer.
        /// </summary>
        [Tooltip("The starting stats of this customer.")]
        [field: SerializeField] public StatBlock Stats { get; private set; }

        /// <summary>
        /// The stat range that this customer wants the player to hit.
        /// </summary>
        [Tooltip("The stat range that this customer wants the player to hit.")]
        [field: SerializeField] public StatRangeBlock Range { get; private set; }

        void OnValidate() {

            // Since the Stats of the customer are base stats, we validate them to range
            // to ensure they are never negative.
            Stats.ValidateToRange();
            Range.ValidateValues();

        }

    }

}
