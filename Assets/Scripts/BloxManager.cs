using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
public class BloxManager : MonoBehaviour ,IBox
{
    [SerializeField] SpriteAtlas _spriteAtlas;

    SpriteRenderer _spritRenderer;

    int _bloxId;
    int _bloxSize;

    int _bloxLives;


    private void Start(){
    _spritRenderer = GetComponent<SpriteRenderer>();
    
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

    }
}
