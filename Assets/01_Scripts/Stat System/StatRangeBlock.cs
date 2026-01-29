using UnityEngine;

namespace John {

    /// <summary>
    /// Holds a complete block of StatRanges. Every client has one of these so the game
    /// knows what goals the player is trying to achieve (eg, between 40 and 60 age score, etc).
    /// </summary>
    [System.Serializable]
    public class StatRangeBlock {

        // All ranges default to maximum range unless set otherwise.

        /// <summary>
        /// How old the client looks (number does not represent actual years).
        /// </summary>
        [Tooltip("How old the client looks (number does not represent actual years).")]
        [field: SerializeField] public StatRange Age { get; private set; } = new(StatRange.RANGE_MIN, StatRange.RANGE_MAX);

        /// <summary>
        /// Adding things like makeup, earrings, etc, increases glamour.
        /// </summary>
        [Tooltip("Adding things like makeup, earrings, etc, increases glamour.")]
        [field: SerializeField] public StatRange Glamour { get; private set; } = new(StatRange.RANGE_MIN, StatRange.RANGE_MAX);

        /// <summary>
        /// Cartoon cool; adding sunglasses, certain hairstyles, etc.
        /// </summary>
        [Tooltip("Cartoon cool; adding sunglasses, certain hairstyles, etc.")]
        [field: SerializeField] public StatRange Cool { get; private set; } = new(StatRange.RANGE_MIN, StatRange.RANGE_MAX);

        /// <summary>
        /// Things like facial hair, scars, an eyepatch, all add ruggedness.
        /// </summary>
        [Tooltip("Things like facial hair, scars, an eyepatch, all add ruggedness.")]
        [field: SerializeField] public StatRange Rugged { get; private set; } = new(StatRange.RANGE_MIN, StatRange.RANGE_MAX);

        /// <summary>
        /// Things like unkempt hair or beards, muck, etc.
        /// </summary>
        [Tooltip("Things like unkempt hair or beards, muck, etc.")]
        [field: SerializeField] public StatRange Groomed { get; private set; } = new(StatRange.RANGE_MIN, StatRange.RANGE_MAX);

        /// <summary>
        /// A default constructor is needed for Unity serialisation to work.
        /// </summary>
        public StatRangeBlock() { }

        /// <summary>
        /// Initialises a new instance of a StatRange block with the given values.
        /// </summary>
        public StatRangeBlock(int minAge, int maxAge, int minGlamour, int maxGlamour, int minCool, int maxCool, int minRugged, int maxRugged, int minGroomed, int maxGroomed) {

            Age = new(minAge, maxAge);
            Glamour = new(minGlamour, maxGlamour);
            Cool = new(minCool, maxCool);
            Rugged = new(minRugged, maxRugged);
            Groomed = new(minGroomed, maxGroomed);

        }

        /// <summary>
        /// Validates the values of each range in the block.
        /// </summary>
        public void ValidateValues() {
            Age.ValidateValues();
            Glamour.ValidateValues();
            Cool.ValidateValues();
            Rugged.ValidateValues();
            Groomed.ValidateValues();
        }

        /// <summary>
        /// Compares a StatBlock against this StatRangeBlock, returns true if all stats are within range.
        /// </summary>
        public bool IsStatBlockValid(StatBlock stats) {

            // Return true only if ALL stats are within range.
            return Age.IsValid(stats.Age) &&
                    Glamour.IsValid(stats.Glamour) &&
                    Cool.IsValid(stats.Cool) &&
                    Rugged.IsValid(stats.Rugged) &&
                    Groomed.IsValid(stats.Groomed);

        }


    }
}