using UnityEngine;
using UnityEngine.UI;

namespace John {

    /// <summary>
    /// The logic for the UI element that displays a StatRangeBlock.
    /// </summary>
    public class StatRangeBar : MonoBehaviour {

        private RectTransform _parentRect;
        private RectTransform _fillRect;
        private RectTransform _rangeRect;
        private RectTransform _amountRect;

        void Awake() {

            // Get all the rects.
            _parentRect = transform as RectTransform;
            foreach (RectTransform child in transform) {
                if (child.name == "Fill") _fillRect = child;
                if (child.name == "Range") _rangeRect = child;
                if (child.name == "Amount") _amountRect = child;
            }

        }

        /// <summary>
        /// Updates the range bar to reflect the given values.
        /// </summary>
        /// <param name="range">The StatRange that is being represented.</param>
        /// <param name="value">The current value.</param>
        public void UpdateVisual(StatRange range, int value) {

            if (_parentRect == null) return;

            // Get the width of the parent Rect every call so the bar is always right,
            // even if the width of the parent changes.
            float parentWidth = _parentRect.rect.width;

            // Calculate the left and right position of the target range as a normalised percentage.
            float left = Normalise(range.Min);
            float right = Normalise(range.Max);

            // Set the left and right position of the range bar as a percentage of the overall width.
            _rangeRect.offsetMin = new(left * parentWidth, 0f);
            _rangeRect.offsetMax = new(right * parentWidth, 0f);

            // Calculate and apply the position of the marker.
            float markerPercent = Normalise(value);
            _amountRect.anchoredPosition = new(markerPercent * parentWidth, 0f);

        }

        /// <summary>
        /// A helper function to return a normalised value based on StatRange.RANGE_MIN-RANGE_MAX.
        /// </summary>
        private float Normalise(int value) => (float)(value - StatRange.RANGE_MIN) / (StatRange.RANGE_MAX - StatRange.RANGE_MIN);


    }

}