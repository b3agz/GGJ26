using UnityEngine;
using System.Collections.Generic;
using TMPro;

namespace John {

    public class Judger : MonoBehaviour {

        // Singleton Access.
        public static Judger Instance { get; private set; }
        void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        /// <summary>
        /// True if the current disguise meets the customer's requirements.
        /// </summary>
        [field: SerializeField] public bool Success { get; private set; }

        /// <summary>
        /// The customer currently getting a disguise.
        /// </summary>
        public Customer Customer { get; private set; }

        // The list of disguise items currently applied to the customer.
        [SerializeField] private List<Item> _items = new();

        [SerializeField] private TextMeshProUGUI _description;

        /// <summary>
        /// A readonly list of disguise items to allow external access while
        /// preventing anything from modifying it externally.
        /// </summary>
        public IReadOnlyList<Item> Items => _items;

        [SerializeField] StatWindow _statWindow;

        [SerializeField] GameObject _newCustomerWindow;

        // The current stats factoring in all applied disguses.
        [SerializeField] private StatBlock _currentStats;

        [SerializeField] private Transform _face;

        /// <summary>
        /// Starts a new round with the given customer.
        /// </summary>
        public void NewCustomer() {

            ClearItems();
            foreach (Transform child in _face) child.gameObject.SetActive(false);
            Customer = Customer.CreateRandom();
            Success = false;
            _description.text = Customer.Description;
            Judge();
            Timer.Instance.ResetTimer(15);
            _newCustomerWindow.SetActive(false);
            GameManager.Instance.State = GameState.InPlay;

        }

        /// <summary>
        /// Adds a new Item to the current disguise.
        /// </summary>
        public void AddItem(Item item) {

            // TODO: Do we want to prevent duplicate items? Maybe that's better done in the item selection area.
            _items.Add(item);
            Judge();

        }

        /// <summary>
        /// Removes an Item from the current disguise.
        /// </summary>
        /// <returns>Returns false if Item was not in the disguise.</returns>
        public bool RemoveItem(Item item) {
            bool success = _items.Remove(item);
            Judge();
            return success;
        }

        /// <summary>
        /// Clears the current disguise of all items.
        /// </summary>
        public void ClearItems() {

            // TODO: Any visual aspects, such as making the items *pop* out of existence or fly away.
            _items.Clear();
            Judge();

        }

        /// <summary>
        /// Updates _currentStats based on the items stored in _items.
        /// </summary>
        public void Judge() {

            // Sanity check. If we don't have a customer, we can't judge anything.
            if (Customer == null) return;
            // TODO: Error handling for if we don't have a customer.

            // Make a new StatBlock with our Customer's base stats.
            StatBlock stats = new();
            stats += Customer.Stats;

            // Loop through each Item currently applied and add its stats to the score.
            for (int i = 0; i < _items.Count; i++) {

                // Null check to avoid NullReferenceExceptions in-editor.
                if (_items[i] != null) {
                    stats += _items[i].Stats;
                }
            }

            // Make sure all the stats are within range. An Item can have negative Cool, but
            // the customer should be clamped to the minimum/maximum Cool.
            stats.ValidateToRange();

            // Apply the stats.
            _currentStats = stats;

            Success = Customer.Range.IsStatBlockValid(_currentStats);

            _statWindow.UpdateBars(Customer, _currentStats);


        }

    }

}
