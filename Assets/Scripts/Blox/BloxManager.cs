using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class BloxManager : MonoBehaviour
{
    public int startLives = 1000;
    [SerializeField] SpriteAtlas _spriteAtlas;
    SpriteRenderer _spriteRenderer;

    Rigidbody2D _rigidbody2D;
    int _bloxId;
    int _bloxSize;

    int _bloxLives;

    AudioSource ac;


    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _bloxLives = startLives;
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

   public int BloxLives
    {
        get { return _bloxLives; }
        set
        {
            if (gameObject != null) {
                if (value <= 0)
                {
                    _bloxLives =0;
                    Debug.Log("life is zero");
                }
                else
                {
                     _bloxLives = value;
                    UpdateBloxLive(_bloxLives);
                }
                
            }
        }
    }
    public void PlaySound(){
        if(ac == null){
        ac =  SoundManager.Instance.Play("drop_in_Water");
        } 
    }

    private void SetBloxSize(int size)
    {
        transform.localScale = new Vector3(size,1,1);
        if( _rigidbody2D == null) _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.mass = size;
    }

    public GameObject GetParent(){

        return transform.parent.gameObject;
    }
   private void UpdateBloxLive(int value)
    {
        float spriteNum = ((float)value / startLives);
        int num = (int)(spriteNum*_spriteAtlas.spriteCount);
      //  Debug.Log("boxlives "+ spriteNum);
        _spriteRenderer.sprite = _spriteAtlas.GetSprite(num.ToString());
      //  Debug.Log("Setting spritenum: " + spriteNum.ToString());
    }

}
