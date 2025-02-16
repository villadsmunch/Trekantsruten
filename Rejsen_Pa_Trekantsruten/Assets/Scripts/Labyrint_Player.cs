using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Labyrint_Player : MonoBehaviour
{
    public GameObject door;
    public GameObject winPanel;
    public GameObject gameOverPanel;
    public GameObject arrows;
    public UnityEngine.UI.Button btn;
    
    public float speed = 2f;
    Rigidbody2D rb;


    private void Start()
    {
        btn.onClick.AddListener(TaskOnClick);
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(string button)
    {
        switch (button)
        {
            case "up":
                rb.velocity = new Vector2(0, 1 * speed);
                break;
            case "down":
                rb.velocity = new Vector2(0, -1 * speed);
                break;
            case "left":
                rb.velocity = new Vector2(-1 * speed, 0);
                break;
            case "right":
                rb.velocity = new Vector2(1 * speed, 0);
                break;
            case "stop":
                rb.velocity = new Vector2(0, 0);
                break;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            Destroy(collision.gameObject);
            Destroy(door);
        }

        if (collision.gameObject.tag == "Enemies")
        {
            gameOverPanel.SetActive(true);
        }

        if (collision.gameObject.tag == "Goal")
        {
            this.gameObject.SetActive(false);
            winPanel.SetActive(true);
            arrows.SetActive(false);
        }
    }

    public void TaskOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
