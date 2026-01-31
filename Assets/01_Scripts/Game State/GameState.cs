using UnityEngine;

namespace John {

    /// <summary>
    /// An enum for handling storing the current state of the game.
    /// </summary>
    public enum GameState {

        /// <summary>
        /// In the game menu (start, exit, any settings we have time for.)
        /// </summary>
        MainMenu,

        /// <summary>
        /// In the pause menu, regular game controls should be suspended.
        /// </summary>
        PauseMenu,

        /// <summary>
        /// In the game (not in a menu).
        /// </summary>
        InPlay

    }

}