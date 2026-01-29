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
        
        
        /// <summary>
        /// this is to designate which lock point then item can be placed (e.g hair noise, mouth, etc)
        /// NOTE: idk a better way to lock slots so its a string can't wait for this to cause pain down the line
        /// </summary>
        [Tooltip("this is where its going to be on the mask e.g eyebrows, noise, etc")]
        [field: SerializeField] public string Slot { get; set; }

    }

}
