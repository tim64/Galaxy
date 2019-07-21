using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLaserSprite : MonoBehaviour
{
	public Sprite[] lasersSpites;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = lasersSpites[Random.Range(0, lasersSpites.Length)];
	}
}
