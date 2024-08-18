using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CoinManager : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    int pointsForCoinPickup;
    GameSession gameSession;
    Tilemap coinTileMap;
    void Start()
    {
        pointsForCoinPickup = 10;
        coinTileMap = GetComponent<Tilemap>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Coin trigger");
        // Debug.Log()
        if (other.tag == "Player")
        {
            Vector3Int gridPosition1 = coinTileMap.WorldToCell(other.transform.position - new Vector3(0, 0.3f, 0));
            Vector3Int gridPosition2 = coinTileMap.WorldToCell(other.transform.position + new Vector3(0, 0.3f, 0));
            Vector3Int gridPosition3 = coinTileMap.WorldToCell(other.transform.position - new Vector3(0.3f, 0, 0));
            Vector3Int gridPosition4 = coinTileMap.WorldToCell(other.transform.position + new Vector3(0.3f, 0, 0));
            TileBase coinTile1 = coinTileMap.GetTile(gridPosition1);
            TileBase coinTile2 = coinTileMap.GetTile(gridPosition2);
            TileBase coinTile3 = coinTileMap.GetTile(gridPosition3);
            TileBase coinTile4 = coinTileMap.GetTile(gridPosition4);
            Debug.Log(other.transform.position);
            // Debug.Log(gridPosition);
            // Debug.Log(coinTile);
            if (coinTile1 != null)
            {
                coinTileMap.SetTile(gridPosition1, null);
                Debug.Log("Selected");
                AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position, 1);
                gameSession.AddToScore(pointsForCoinPickup);
                return;
            }
            if (coinTile2 != null)
            {
                coinTileMap.SetTile(gridPosition2, null);
                Debug.Log("Selected");
                AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position, 1);
                gameSession.AddToScore(pointsForCoinPickup);
                return;
            }
            if (coinTile3 != null)
            {
                coinTileMap.SetTile(gridPosition3, null);
                Debug.Log("Selected");
                AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position, 1);
                gameSession.AddToScore(pointsForCoinPickup);
                return;
            }
            if (coinTile4 != null)
            {
                coinTileMap.SetTile(gridPosition4, null);
                Debug.Log("Selected");
                AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position, 1);
                gameSession.AddToScore(pointsForCoinPickup);
                return;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Coin trigger");
        // Debug.Log()
        if (other.tag == "Player")
        {
            Vector3Int gridPosition1 = coinTileMap.WorldToCell(other.transform.position - new Vector3(0, 0.3f, 0));
            Vector3Int gridPosition2 = coinTileMap.WorldToCell(other.transform.position + new Vector3(0, 0.3f, 0));
            Vector3Int gridPosition3 = coinTileMap.WorldToCell(other.transform.position - new Vector3(0.3f, 0, 0));
            Vector3Int gridPosition4 = coinTileMap.WorldToCell(other.transform.position + new Vector3(0.3f, 0, 0));
            TileBase coinTile1 = coinTileMap.GetTile(gridPosition1);
            TileBase coinTile2 = coinTileMap.GetTile(gridPosition2);
            TileBase coinTile3 = coinTileMap.GetTile(gridPosition3);
            TileBase coinTile4 = coinTileMap.GetTile(gridPosition4);
            Debug.Log(other.transform.position);
            // Debug.Log(gridPosition);
            // Debug.Log(coinTile);
            if (coinTile1 != null)
            {
                coinTileMap.SetTile(gridPosition1, null);
                Debug.Log("Selected");
                AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position, 1);
                gameSession.AddToScore(pointsForCoinPickup);
                return;
            }
            if (coinTile2 != null)
            {
                coinTileMap.SetTile(gridPosition2, null);
                Debug.Log("Selected");
                AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position, 1);
                gameSession.AddToScore(pointsForCoinPickup);
                return;
            }
            if (coinTile3 != null)
            {
                coinTileMap.SetTile(gridPosition3, null);
                Debug.Log("Selected");
                AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position, 1);
                gameSession.AddToScore(pointsForCoinPickup);
                return;
            }
            if (coinTile4 != null)
            {
                coinTileMap.SetTile(gridPosition4, null);
                Debug.Log("Selected");
                AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position, 1);
                gameSession.AddToScore(pointsForCoinPickup);
                return;
            }
        }
    }


}
