using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class BloxManager : MonoBehaviour, IBox
{
    [SerializeField]
    int startLives;
    [SerializeField] SpriteAtlas _spriteAtlas;

    SpriteRenderer _spriteRenderer;

    int _bloxId;
    int _bloxSize;

    int _bloxLives;


    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        this.BloxLives = startLives;

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
            _bloxSize = value;
            SetBloxSize(_bloxSize);
        }
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

    }

    private void DestroyBlox()
    {
        //TODO
    }

    private void UpdateBloxLive(int value)
    {
        int spriteNum = value / (startLives / _spriteAtlas.spriteCount);
        Debug.Log("NAAMAAA: " + spriteNum.ToString());
        _spriteRenderer.sprite = _spriteAtlas.GetSprite(spriteNum.ToString());
        Debug.Log(_spriteRenderer.ToString());
    }
}
