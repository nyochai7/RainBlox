using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class BloxManager : MonoBehaviour ,IBox
{
    [SerializeField] SpriteAtlas _spriteAtlas;

    SpriteRenderer _spriteRenderer;

    int _bloxId;
    int _bloxSize;

    int _bloxLives;


    private void Start(){
        _spriteRenderer = GetComponent<SpriteRenderer>();
        this.BloxLives = 1;

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
            _bloxLives = value;
            UpdateBloxLive(_bloxLives);
        }
    }

    private void SetBloxSize(int size)
    {

    }

    private void UpdateBloxLive(int value){
        _spriteRenderer.sprite = _spriteAtlas.GetSprite(value.ToString());
        Debug.Log(_spriteRenderer.ToString());
    }
}
