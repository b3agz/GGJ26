using UnityEngine;

namespace John {

    /// <summary>
    /// Holds the stats for everything we are going to be judging the player on.
    /// StatBlocks can be added and subtracted from each other like regular ints.
    /// I haven't added multiplication or division because we shouldn't need it.
    ///
    /// Every disguise item will need one of these attached to it so the game knows
    /// what effect it has on the overall disguise.
    /// </summary>
    [System.Serializable]
    public class StatBlock {

        /// <summary>
        /// How old the client looks (number does not represent actual years).
        /// </summary>
        [Tooltip("How old the client looks (number does not represent actual years).")]
        [field: SerializeField, Range(-StatRange.RANGE_MAX, StatRange.RANGE_MAX)]
        public int Age { get; set; }

        /// <summary>
        /// Adding things like makeup, earrings, etc, increases glamour.
        /// </summary>
        [Tooltip("Adding things like makeup, earrings, etc, increases glamour.")]
        [field: SerializeField, Range(-StatRange.RANGE_MAX, StatRange.RANGE_MAX)]
        public int Glamour { get; set; }

        /// <summary>
        /// Cartoon cool; adding sunglasses, certain hairstyles, etc.
        /// </summary>
        [Tooltip("Cartoon cool; adding sunglasses, certain hairstyles, etc.")]
        [field: SerializeField, Range(-StatRange.RANGE_MAX, StatRange.RANGE_MAX)]
        public int Cool { get; set; }

        /// <summary>
        /// Things like facial hair, scars, an eyepatch, all add ruggedness.
        /// </summary>
        [Tooltip("Things like facial hair, scars, an eyepatch, all add ruggedness.")]
        [field: SerializeField, Range(-StatRange.RANGE_MAX, StatRange.RANGE_MAX)]
        public int Rugged { get; set; }

        /// <summary>
        /// Things like unkempt hair or beards, muck, etc.
        /// </summary>
        [Tooltip("Things like unkempt hair or beards, muck, etc.")]
        [field: SerializeField, Range(-StatRange.RANGE_MAX, StatRange.RANGE_MAX)]
        public int Groomed { get; set; }

        /// <summary>
        /// A default constructor is needed for Unity serialisation to work.
        /// </summary>
        public StatBlock() { }

        /// <summary>
        /// Creates a new StatBlock instance with the given values.
        /// </summary>
        public StatBlock(int age, int glamour, int cool, int rugged, int groomed) {

            Age = age;
            Glamour = glamour;
            Cool = cool;
            Rugged = rugged;
            Groomed = groomed;

        }

        /// <summary>
        /// Validates the values of this StatBlock keeping them within the min-max range.
        /// </summary>
        public void ValidateToRange() {
            Age = Mathf.Clamp(Age, StatRange.RANGE_MIN, StatRange.RANGE_MAX);
            Glamour = Mathf.Clamp(Glamour, StatRange.RANGE_MIN, StatRange.RANGE_MAX);
            Cool = Mathf.Clamp(Cool, StatRange.RANGE_MIN, StatRange.RANGE_MAX);
            Rugged = Mathf.Clamp(Rugged, StatRange.RANGE_MIN, StatRange.RANGE_MAX);
            Groomed = Mathf.Clamp(Groomed, StatRange.RANGE_MIN, StatRange.RANGE_MAX);
        }

        #region Operator overloads.

        public static StatBlock operator +(StatBlock a, StatBlock b) {

            if (a == null) return b ?? new StatBlock();
            if (b == null) return a ?? new StatBlock();

            return new StatBlock(
                a.Age + b.Age,
                a.Glamour + b.Glamour,
                a.Cool + b.Cool,
                a.Rugged + b.Rugged,
                a.Groomed + b.Groomed
            );
        }

        public static StatBlock operator -(StatBlock a, StatBlock b) {

            if (a == null) return b ?? new StatBlock();
            if (b == null) return a ?? new StatBlock();

            return new StatBlock(
                a.Age - b.Age,
                a.Glamour - b.Glamour,
                a.Cool - b.Cool,
                a.Rugged - b.Rugged,
                a.Groomed - b.Groomed
            );
        }

        #endregion

    }

}