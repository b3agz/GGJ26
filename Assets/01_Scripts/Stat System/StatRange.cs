using UnityEngine;

namespace John {

    /// <summary>
    /// Holds data for a stat range that the player must hit. Minimum and
    /// maximum values are inclusive (so a range of 0-10 would include 0 and 10).
    /// </summary>
    [System.Serializable]
    public class StatRange {

        /// <summary>
        /// The minimum value in the range (the range is arbitrary, it just needs to be consistent).
        /// </summary>
        public const int RANGE_MIN = 0;

        /// <summary>
        /// The maximum value in the range (the range is arbitrary, it just needs to be consistent).
        /// </summary>
        public const int RANGE_MAX = 100;

        /// <summary>
        /// The minimum value in this range (inclusive).
        /// </summary>
        [Tooltip("The minimum value in this range (inclusive).")]
        [field: SerializeField, Range(RANGE_MIN, RANGE_MAX)] public int Min { get; private set; } = RANGE_MIN;

        /// <summary>
        /// The maximum value in this range (inclusive).
        /// </summary>
        [Tooltip("The maximum value in this range (inclusive).")]
        [field: SerializeField, Range(RANGE_MIN, RANGE_MAX)] public int Max { get; private set; } = RANGE_MAX;

        /// <summary>
        /// A default constructor is needed for Unity serialisation to work.
        /// </summary>
        public StatRange() { }

        /// <summary>
        /// Initialises a new StatRange instance.
        /// </summary>
        /// <param name="min">The minimum value in this range (inclusive).</param>
        /// <param name="max">The maximum value in this range (inclusive).</param>
        public StatRange(int min, int max) {
            Min = min;
            Max = max;
        }

        /// <summary>
        /// Returns true if the given value is within this StatRange.
        /// </summary>
        public bool IsValid(int value) => value >= Min && value <= Max;

        /// <summary>
        /// Validates the Min and Max values so that they are never outside of RANGE_MIN and
        /// RANGE_MAX, also ensuring Max is always greater than Min.
        /// </summary>
        public void ValidateValues() {
            Min = Mathf.Clamp(Min, RANGE_MIN, RANGE_MAX);
            Max = Mathf.Clamp(Max, Min, RANGE_MAX);
        }

    }
}
