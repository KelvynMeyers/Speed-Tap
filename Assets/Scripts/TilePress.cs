using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePress : MonoBehaviour
{
    // VARIABLES
    public GameBehavior gameBehavior;

    private Rigidbody2D rgbd2d;

    // FUNCTIONS
    void Start()
    {
        rgbd2d = GetComponent<Rigidbody2D> ();
    }

    void OnMouseDown()
    {
        if(gameBehavior.IsGameFinished()) return;
        var maxHeight = Screen.height;
        var maxWidth = Screen.width;
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0,maxWidth), Random.Range(0,maxHeight), Camera.main.farClipPlane/2));
        transform.position = screenPosition;
        gameBehavior.IncrementScoreValue();
        AudioManager.instance.Play("TileTap");
    }
}
