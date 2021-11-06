using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    private GameObject player;
    public Vector3Int currentPlayerChunkPosition;
    private Vector3Int currentChunkCenter = Vector3Int.zero;

    public World world;

    float detectionTime = 1;
    public Camera mainCam;

    public UIManager uiManager;

    public static GameState currentState = GameState.GAME;

    public GameObject biomeIcon1;
    public GameObject biomeIcon2;
    public GameObject mainTitle;
    public GameObject biomeSelect;
    public GameObject aboutPage;
    public GameObject pausePanel;

    public enum GameState
    {
       TITLE,
       BIOMECHOOSE,
       GAME,
       MUSEUM,
       PAUSED,
       ABOUT,
       EXITGAME,
    }

    public void Start()
    {
        if(currentState == GameState.GAME)
        {
            world.GenerateWorld();
        }
    }
    public void SpawnPlayer()
    {
        if(player != null)
        {
            return;
        }
        Vector3Int raycastStartPosition = new Vector3Int(world.chunkSize / 2, 100, world.chunkSize / 2);
        RaycastHit hit;
        if (Physics.Raycast(raycastStartPosition, Vector3.down, out hit, 120))
        {
            player = Instantiate(playerPrefab, hit.point + Vector3Int.up, Quaternion.identity);
            StartCheckingTheMap();
        }
    }

    public void StartCheckingTheMap()
    {
        SetCurrentChunkCoordinates();
        StopAllCoroutines();
        StartCoroutine(CheckIfShouldLoadNextPosition());
    }

    IEnumerator CheckIfShouldLoadNextPosition()
    {
        yield return new WaitForSeconds(detectionTime);
        if (
            Mathf.Abs(currentChunkCenter.x - player.transform.position.x) > world.chunkSize ||
            Mathf.Abs(currentChunkCenter.z - player.transform.position.z) > world.chunkSize ||
            (Mathf.Abs(currentPlayerChunkPosition.y - player.transform.position.y) > world.chunkHeight)
            )
        {
            world.LoadAdditionalChunksRequest(player);
        }
        else
        {
            StartCoroutine(CheckIfShouldLoadNextPosition());
        }
    }

    private void SetCurrentChunkCoordinates()
    {
        currentPlayerChunkPosition = WorldDataHelper.ChunkPositionFromBlockCoords(world, Vector3Int.RoundToInt(player.transform.position));
        currentChunkCenter.x = currentPlayerChunkPosition.x + world.chunkSize / 2;
        currentChunkCenter.z = currentPlayerChunkPosition.z + world.chunkSize / 2;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            OnPause();
        }

        switch (currentState)
        {
            case GameState.TITLE:
                Time.timeScale = 1; 
                break;
            case GameState.BIOMECHOOSE:
                biomeSelect.SetActive(true);
                mainTitle.SetActive(false);
                biomeIcon1.SetActive(true);
                biomeIcon2.SetActive(true);
                break;
            case GameState.GAME:
                Time.timeScale = 1;
                //Cursor.lockState = CursorLockMode.Locked;
                break;
            case GameState.MUSEUM:
                break;
            case GameState.PAUSED:
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
                pausePanel.SetActive(true);
                break;
            case GameState.ABOUT:
                mainTitle.SetActive(false);
                aboutPage.SetActive(true);
                break;
            case GameState.EXITGAME:
                break;
            default:
                break;
        }
    }

    public void StartGameDesert()
    {
        currentState = GameState.GAME;
        SceneManager.LoadScene("TerrainGenTest");
    }

    public void StartGameMountain()
    {
        currentState = GameState.GAME;
        SceneManager.LoadScene("DesertGen");
    }

    public void SelectBiome()
    {
        currentState = GameState.BIOMECHOOSE;

    }

    public void AboutPage()
    {
        currentState = GameState.ABOUT;
    }

    public void BackButton()
    {
        currentState = GameState.TITLE;
    }

    public void OnPause()
    {
        currentState = GameState.PAUSED;
    }

    public void ReturnToTitle()
    {
        currentState = GameState.TITLE;
        SceneManager.LoadScene("MainMenu");

    }

    public void ReturnToGame()
    {
        currentState = GameState.GAME;
        pausePanel.SetActive(false);
    }

    public void ToMuseum()
    {
        currentState = GameState.MUSEUM;
        SceneManager.LoadScene("Museum");
    }

    public void PauseBackButton()
    {
        //Cursor.lockState = CursorLockMode.None;
        currentState = GameState.GAME;
        pausePanel.SetActive(false);
    }
}
