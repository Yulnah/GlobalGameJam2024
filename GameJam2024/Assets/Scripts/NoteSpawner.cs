using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] comboPrefabs;

    [SerializeField]
    private float spawnInterval;

    private bool isSpawning = true;
    public GameManager gameManager; // Get game state

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNoteRoutine(spawnInterval));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SpawnNoteRoutine(float spawnInterval)
    {
        // Spawn the first note immediately
        SpawnNote();

        while (isSpawning)
        {
            // Wait for the specified interval before spawning the next note
            yield return new WaitForSeconds(spawnInterval);

            if (!gameManager.isGameOver)
            {
                // Spawn the next note
                SpawnNote();
            }
        }
    }

    private void SpawnNote()
    {
        // Randomly select a combo prefab
        GameObject selectedCombo = comboPrefabs[Random.Range(0, comboPrefabs.Length)];

        // Get the gameObject, create it at the position of spawner
        GameObject newNote = Instantiate(selectedCombo, transform.position, Quaternion.identity);

        // Store the original position
        Vector3 originalPosition = newNote.transform.position;

        // Set the new note as a child of the spawner's transform
        newNote.transform.SetParent(transform, false);

        // Restore the original position
        newNote.transform.position = originalPosition;


        Debug.Log("Spawning " + selectedCombo + " at " + Time.time);
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }

}

/*
 
 private IEnumerator SpawnNoteRoutine(float spawnInterval)
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (!gameManager.isGameOver)
            {
                // Randomly select a combo prefab
                GameObject selectedCombo = comboPrefabs[Random.Range(0, comboPrefabs.Length)];

                // Get the gameObject and create it at the position of this spawner
                GameObject newNote = Instantiate(selectedCombo, transform.position, Quaternion.identity);

                // Store the original position
                Vector3 originalPosition = newNote.transform.position;

                // Set the new note as a child of the spawner's transform
                newNote.transform.SetParent(transform, false);

                // Restore the original position
                newNote.transform.position = originalPosition;
            }
        }
    }

 */