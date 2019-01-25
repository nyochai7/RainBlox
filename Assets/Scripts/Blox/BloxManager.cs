using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class BloxManager : MonoBehaviour, IBlox, IDamagable
{
    [SerializeField] int startLives = 1000;
    [SerializeField] SpriteAtlas _spriteAtlas;
    SpriteRenderer _spriteRenderer;

    Rigidbody2D _rigidbody2D;
    int _bloxId;
    int _bloxSize;
    int _bloxLives;

    private void Awake()
    {
        //Debug.Log("Awake");
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _bloxLives = startLives;
    }

    private void Start()
    {
        //Debug.Log("Start");
    }
    public int BloxID
    {
        get { return _bloxId; }
        set { _bloxId = value; }
    }

    public int BloxSize
    {
        get { return _bloxSize; }
        set
        {
            SetBloxSize(value);

             _bloxSize = value;
        }
    }

	public Sprite Sprite
	{
		get { return _spriteRenderer.sprite; }
	}

	public int BloxLives
    {
        get { return _bloxLives; }
        set
        {
            if (gameObject != null) {
                if (value <= 0)
                {
                    value = 0;
                    //Debug.Log("life is zero");
                    DestroyBlox();
                }
                else
                {
                    UpdateBloxLive(_bloxLives);
                    _bloxLives = value;
                }
                
            }
        }
    }

	private void SetBloxSize(int size)
    {
        transform.localScale = new Vector3(size,1,1);
        if( _rigidbody2D == null) _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.mass = size;
    }

    private void DestroyBlox()
    {
        //Debug.Log("Destroying!");
        Destroy(transform.parent.gameObject);
    }

    private void UpdateBloxLive(int value)
    {
        int spriteNum = value / (startLives / _spriteAtlas.spriteCount);
        _spriteRenderer.sprite = _spriteAtlas.GetSprite(spriteNum.ToString());
        Debug.Log("Setting spritenum: " + spriteNum.ToString());
    }


    public void Hurt(int damageAmount)
    {
       this.BloxLives -= 1;
        Debug.Log("Blox hurt");
    }
}
