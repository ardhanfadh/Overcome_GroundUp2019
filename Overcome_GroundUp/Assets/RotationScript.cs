using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour {
    public GameObject player;
    public Direction playerDirection;
    public bool isHalfSize;
	// Use this for initialization
	void Start () {
        playerDirection = Direction.Bawah;
	}
	
	// Update is called once per frame
	void Update () {
        switch (playerDirection)
        {
            case Direction.Atas:
                if (!isHalfSize)
                {
                    this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1.2f, player.transform.position.z);
                }
                else
                {
                    this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + (1.2f/2), player.transform.position.z);
                }
                
                break;
            case Direction.Bawah:
                if (!isHalfSize)
                {
                    this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 1.2f, player.transform.position.z);
                }
                else
                {
                    this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - (1.2f/2), player.transform.position.z);
                }
                break;
            case Direction.Kanan:
                if (!isHalfSize)
                {
                    this.transform.position = new Vector3(player.transform.position.x + 1.2f, player.transform.position.y, player.transform.position.z);
                }
                else
                {
                    this.transform.position = new Vector3(player.transform.position.x + (1.2f/2), player.transform.position.y, player.transform.position.z);
                }
                break;
            case Direction.Kiri:
                if (!isHalfSize)
                {
                    this.transform.position = new Vector3(player.transform.position.x - 1.2f, player.transform.position.y, player.transform.position.z);
                }
                else
                {
                    this.transform.position = new Vector3(player.transform.position.x - (1.2f/2), player.transform.position.y, player.transform.position.z);
                }
                break;
        }
       
        this.transform.rotation = player.transform.rotation;
	}

    public void PutarKiri()
    {
        transform.eulerAngles = new Vector3 (0, 0, 270f);
    }

    public void PutarKanan()
    {
        transform.eulerAngles = new Vector3(0, 0, 90f);
    }

    public void PutarAtas()
    {
        transform.eulerAngles = new Vector3 (0, 0, 180f);
    }

    public void PutarBawah()
    {
        transform.eulerAngles = new Vector3 (0, 0, 0f);
    }
}
