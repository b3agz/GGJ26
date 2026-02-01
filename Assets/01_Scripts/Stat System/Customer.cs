using UnityEngine;

namespace John {

    [System.Serializable]
    public class Customer {

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

        [field: SerializeField] public string Description { get; private set; }

        void OnValidate() {

            // Since the Stats of the customer are base stats, we validate them to range
            // to ensure they are never negative.
            Stats.ValidateToRange();
            Range.ValidateValues();

        }

        /// <summary>
        /// A list of names to randomly choose from for our customers.
        /// </summary>
        public static readonly string[] Names = new string[] {
            "Arthur", "Ben", "Caleb", "Daniel", "Elias",
            "Felix", "George", "Henry", "Isaac", "Jasper",
            "Kevin", "Leo", "Milo", "Noah", "Oliver",
            "Percy", "Quinn", "Riley", "Sebastian", "Theodore",
            "Victor", "Wyatt", "Xavier", "Yosef", "Zane"
        };

        // Get a random name from our Names array.
        public void SetRandomName() => Name = Names[Random.Range(0, Names.Length)];

        // Sets the base stats of this Customer to a "noise" level (1 or 2 in any direction)
        public void RandomiseBaseStats() {

            StatBlock stats = new(
                Random.Range(3, 7),
                Random.Range(3, 7),
                Random.Range(3, 7),
                Random.Range(3, 7),
                Random.Range(3, 7)
            );
            Stats = stats;

        }

        public Customer() { }

        public static Customer CreateRandom() {

            Customer customer = new();
            customer.SetRandomName();
            customer.RandomiseBaseStats();
            customer.Range = new(
                Random.Range(2, 4),
                Random.Range(5, 8),
                Random.Range(2, 4),
                Random.Range(5, 8),
                Random.Range(2, 4),
                Random.Range(5, 8),
                Random.Range(2, 4),
                Random.Range(5, 8),
                Random.Range(2, 4),
                Random.Range(5, 8)
            );

            customer.Range.ValidateValues();

            bool sign = UnityEngine.Random.value > 0.5f;
            int amount = sign ? -3 : 3;
            string modifier = sign ? "less " : "more ";

            int statIndex = Random.Range(0, 5);
            switch (statIndex) {
                case 0:
                    modifier += "old";
                    customer.Stats.Age += amount;
                    break;
                case 1:
                    modifier += "glamorous";
                    customer.Stats.Glamour += amount;
                    break;
                case 2:
                    modifier += "cool";
                    customer.Stats.Cool += amount;
                    break;
                case 3:
                    modifier += "rugged";
                    customer.Stats.Rugged += amount;
                    break;
                case 4:
                    modifier += "groomed";
                    customer.Stats.Groomed += amount;
                    break;
            }

            customer.Description = $"{customer.Name} wants you to make him look {modifier}.";

            //if (statIndex == 0) customer.Range.Age =
            return customer;

        }

    }

}
