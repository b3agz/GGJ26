using UnityEngine;


namespace John {

    /// <summary>
    /// The disguise items that the player can use to build their disguise.
    /// </summary>
    [CreateAssetMenu(fileName = "Item", menuName = "MoD/New Disguise Item")]
    public class Item : ScriptableObject {

        /// <summary>
        /// The display name of the item (what we show in the UI, etc)
        /// </summary>
        [Tooltip("The display name of the item (what we show in the UI, etc)")]
        [field: SerializeField] public string Name { get; private set; }

        /// <summary>
        /// The image (in sprite form) that represents this item in the UI.
        /// </summary>
        [Tooltip("The image (in sprite form) that represents this item in the UI.")]
        [field: SerializeField] public Sprite Image { get; private set; }

        /// <summary>
        /// The stats that this image applies to the disguise.
        /// NOTE: We do not validate these Stats because they are additive and applied
        /// to the current stat score. So we allow them to go into the negative. For
        /// example, an unkempt beard might be +19 Rugged but -25 Groomed.
        /// </summary>
        [Tooltip("The stats that this image applies to the disguise.")]
        [field: SerializeField] public StatBlock Stats { get; private set; }

    }

}
