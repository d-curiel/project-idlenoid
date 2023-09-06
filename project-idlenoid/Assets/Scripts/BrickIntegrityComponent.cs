using System.Collections;
using TMPro;
using UnityEngine;

public class BrickIntegrityComponent : MonoBehaviour
{
    private int integrity;
    public int Integrity
    {
        get { return integrity; }
        set
        {
            integrity = value;
            text.SetText(integrity.ToString());
        }
    }
    [SerializeField]
    TextMeshPro text;
    AudioSource audioSource;
    SpriteRenderer _sr;
    Collider2D _collider;
    public delegate void BrickDestroyedDelegate();
    public static event BrickDestroyedDelegate BrickDestroyedReleased;

    public delegate void IntegrityDamagedDelegate(int damage);
    public static event IntegrityDamagedDelegate IntegrityDamagedReleased;
    public void Init(AudioClip clip)
    {
        if (!text)
        {
            text = transform.GetComponentInChildren<TextMeshPro>();
        }
        if (!audioSource)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            audioSource.volume = 0.1f;
            audioSource.clip = clip;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BouncerComponent bouncer = collision.gameObject.GetComponent<BouncerComponent>();
        if(bouncer != null)
        {
            CheckIntegrity(bouncer.GetBallStrength());
        }
        
    }

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        _sr.enabled = true;
        _collider.enabled = true;
        if (text)
        {
            text.gameObject.SetActive(true);
        }
    }
    public void CheckIntegrity(int intensity)
    {
        int coins = integrity - intensity < 0 ? integrity : intensity;
        IntegrityDamagedReleased(coins);
        integrity -= intensity;
        if (integrity <= 0)
        {
            StartCoroutine(DeativateAfterSound());
        }
        text.SetText(integrity.ToString());
    }

    IEnumerator DeativateAfterSound()
    {

        audioSource.Play();
        _sr.enabled = false;
        _collider.enabled = false;
        text.gameObject.SetActive(false);
        yield return new WaitWhile(() => audioSource.isPlaying);
        gameObject.SetActive(false);
        BrickDestroyedReleased?.Invoke();
    } 
}
