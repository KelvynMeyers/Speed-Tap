using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePress : MonoBehaviour
{
    // VARIABLES
    public GameStats gameStats;

    private Rigidbody2D rgbd2d;

    // FUNCTIONS
    void Start()
    {
        rgbd2d = GetComponent<Rigidbody2D> ();
    }

    void OnMouseDown()
    {
        //Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0,Screen.width), Random.Range(0,Screen.height), Camera.main.farClipPlane/2));
        //var ScoreTextPosY = ScoreText.GetComponent<RectTransform>.position.y;

        // TODO: Limit tile from going below ScoreText so you can implement a nearby BackButton
        if(gameStats.IsGameFinished())
        {
            return;
        }
        var maxHeight = Screen.height;
        var maxWidth = Screen.width;
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0,maxWidth), Random.Range(0,maxHeight), Camera.main.farClipPlane/2));
        transform.position = screenPosition;
        gameStats.IncrementScoreValue();
    }
}
