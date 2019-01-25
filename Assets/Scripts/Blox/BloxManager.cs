using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class BloxManager : MonoBehaviour, IBlox
{
    public int startLives = 8;
    [SerializeField] SpriteAtlas _spriteAtlas;
    SpriteRenderer _spriteRenderer;

    Rigidbody2D _rigidbody2D;
    int _bloxId;
    int _bloxSize;

    int _bloxLives;


    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
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
            if (value <= 0)
            {
                value = 0;
                DestroyBlox();
            }
            else
            {
                UpdateBloxLive(_bloxLives);
            }
            _bloxLives = value;
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
        Destroy(gameObject);
    }

    private void UpdateBloxLive(int value)
    {
       int spriteNum = startLives - value;
       // Debug.Log("NAAMAAA: " + spriteNum.ToString());
        _spriteRenderer.sprite = _spriteAtlas.GetSprite(value.ToString());
        //Debug.Log(_spriteRenderer.ToString());
    }


    
}
