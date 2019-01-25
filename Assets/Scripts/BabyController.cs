using System.Collections;
using UnityEngine;


public class BabyController : MonoBehaviour, IDamagable
{
    private static int MIN_HEALTH = 0;

    public int Health { get; private set; }

    [SerializeField]
    private int _baseHealth;
    [SerializeField]
    private int _damagePerCollision;
    [SerializeField]
    private float _hurtAnimationTime;
    [SerializeField]
    private Color _hurtColor;
    [SerializeField]
    private float _usedForceMultiplier;
    [SerializeField]
    private float _chooseDirectionInterval;
    [SerializeField]
    private Collider2D _walkBounds;

    private bool _isHurtAnimationPlaying = false;
    private bool _isDead = false;
    private SpriteRenderer _spriteRenderer;
    private Color _originalColor;
    private Rigidbody2D _rigidbody;
    Vector3 usedDirection = Vector3.zero;

    public void Hurt(int damageAmount)
    {
        if (_isDead) return;

        int postDamageHealth = Health - damageAmount;
        Health = Mathf.Clamp(postDamageHealth, MIN_HEALTH, _baseHealth);

        if (_isHurtAnimationPlaying == false)
        {
            StartCoroutine(HurtAnimation());
        }

        if (Health == 0)
        {
            Die();
        }
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _originalColor = _spriteRenderer.color;
        Health = _baseHealth;
    }

    public void Start()
    {
        StartCoroutine(RandomMovement());
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(usedDirection * _usedForceMultiplier, ForceMode2D.Force);
        _rigidbody.MovePosition(_walkBounds.bounds.ClosestPoint(transform.position));
    }

    private IEnumerator RandomMovement()
    {
        while (true)
        {
            float randomNumber = Random.Range(0f, 1f);

            if (randomNumber < 0.5f)
            {
                usedDirection = Vector3.left;
                _spriteRenderer.flipX = false;
            }
            else
            {
                usedDirection = Vector3.right;
                _spriteRenderer.flipX = true;
            }

            yield return new WaitForSeconds(_chooseDirectionInterval);
        }
    }

    private IEnumerator HurtAnimation()
    {
        float animationTimeSeconds = 0;
        float animationProgress = 0;
        float animationStartTime = Time.time;

        _isHurtAnimationPlaying = true;

        while (animationProgress < 1f)
        {
            animationTimeSeconds += Time.deltaTime;
            animationProgress = animationTimeSeconds / (_hurtAnimationTime / 2f);

            float redValue = Mathf.Lerp(_originalColor.r, _hurtColor.r, animationProgress);
            float greenValue = Mathf.Lerp(_originalColor.g, _hurtColor.g, animationProgress);
            float blueValue = Mathf.Lerp(_originalColor.b, _hurtColor.b, animationProgress);

            _spriteRenderer.color = new Color(redValue, greenValue, blueValue);
            yield return new WaitForEndOfFrame();
        }

        animationTimeSeconds = 0;
        animationProgress = 0;
        animationStartTime = Time.time;

        while (animationProgress < 1f)
        {
            animationTimeSeconds += Time.deltaTime;
            animationProgress = animationTimeSeconds / (_hurtAnimationTime / 2f);

            float redValue = Mathf.Lerp(_hurtColor.r, _originalColor.r, animationProgress);
            float greenValue = Mathf.Lerp(_hurtColor.g, _originalColor.g, animationProgress);
            float blueValue = Mathf.Lerp(_hurtColor.b, _originalColor.b, animationProgress);

            _spriteRenderer.color = new Color(redValue, greenValue, blueValue);
            yield return new WaitForEndOfFrame();
        }

        _isHurtAnimationPlaying = false;
    }

    private void Die()
    {
        _isDead = true;
    }
}
