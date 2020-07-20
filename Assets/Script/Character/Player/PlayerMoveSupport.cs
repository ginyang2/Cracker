using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSupport : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            switch (name)
            {
                case "Right":
                    player.isTouchRight = true;
                    break;
                case "Left":
                    player.isTouchLeft = true;
                    break;
                case "Up":
                    player.isTouchUp = true;
                    break;
                case "Down":
                    player.isTouchDown = true;
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            switch (name)
            {
                case "Right":
                    player.isTouchRight = false;
                    break;
                case "Left":
                    player.isTouchLeft = false;
                    break;
                case "Up":
                    player.isTouchUp = false;
                    break;
                case "Down":
                    player.isTouchDown = false;
                    break;
            }
        }
    }
}
