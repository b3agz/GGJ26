using UnityEngine;

/// <summary>
/// add new sounds here before putting them in the sound list otherwise you can't access them
/// sorry to who ever has to do this for the design team if its willow though screw you lmfao - willow
/// </summary>
public enum Soundtype
{
     PICKUP,
     PLACE
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundList;
    private static SoundManager Instance { get; set; }
    private AudioSource audioSource;
    
    private void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    /// <summary>
    ///     there needs to be a sound that both matches the enum in the same position as the sound list array
    ///     its called just like the Juger script 
    ///"TODO: make a doc you stupid mfr willow - willow\"
    /// </summary>
    /// <param name="soundtype"></param>
    /// <param name="volume"></param>
    public static void PlaySound(Soundtype soundtype, float volume = 1)
    {
        Instance.audioSource.PlayOneShot(Instance.soundList[(int)soundtype], volume);
    }
}