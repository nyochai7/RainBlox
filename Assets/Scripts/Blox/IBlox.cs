using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IBlox
{
	int BloxSize { get; set; }
	Sprite Sprite { get; }
	int BloxLives { get; }
}  
