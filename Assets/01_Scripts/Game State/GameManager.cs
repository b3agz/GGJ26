using UnityEngine;
using UnityEngine.SceneManagement;

namespace John {

    public class GameManager : MonoBehaviour {

        // Singleton Access.
        public static GameManager Instance { get; private set; }
        void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        // Serialized private field so we can see/change it in the inspector while preventing
        // it from being changed outside of this script.
        [SerializeField] private GameState _state;

        /// <summary>
        /// The current state of the game (Paused, playing, etc).
        /// </summary>
        public GameState State { get => _state; }

        [SerializeField] private GameObject _pauseScreen;

        void Start() {
            _state = GameState.InPlay;
        }

        void Update() {

            if (Input.GetKeyDown(KeyCode.Escape)) {
                switch (_state) {
                    case GameState.MainMenu:
                        ExitGame();
                        break;
                    case GameState.PauseMenu:
                        ResumeGame();
                        break;
                    case GameState.InPlay:
                        PauseGame();
                        break;
                }
            }

        }

        public void PauseGame() {
            _state = GameState.PauseMenu;
            _pauseScreen.SetActive(true);
        }

        public void ResumeGame() {
            _state = GameState.InPlay;
            _pauseScreen.SetActive(false);
        }

        public void RestartGame() {
            _state = GameState.InPlay;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void ExitGame() {
            Application.Quit();
        }

    }

}
