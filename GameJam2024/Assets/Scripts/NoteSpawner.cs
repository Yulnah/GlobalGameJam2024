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

    public void StopSpawning()
    {
        isSpawning = false;
    }

    //private IEnumerator SpawnNoteRoutine(float spawnInterval)
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(spawnInterval);

    //        // Randomly select a combo prefab
    //        GameObject selectedCombo = comboPrefabs[Random.Range(0, comboPrefabs.Length)];

    //        // Get the gameObject and create it at the position of this spawner
    //        GameObject newNote = Instantiate(selectedCombo, transform.position, Quaternion.identity);

    //        // Store the original position
    //        Vector3 originalPosition = newNote.transform.position;

    //        // Set the new note as a child of the spawner's transform
    //        newNote.transform.SetParent(transform, false);

    //        // Restore the original position
    //        newNote.transform.position = originalPosition;
    //    }
    //}

}
















    //private IEnumerator SpawnNoteRoutine(float spawnInterval, GameObject notePrefab)
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(spawnInterval);

    //        // Get the gameObject and create it at the position of this spawner
    //        GameObject newNote = Instantiate(notePrefab, transform.position, Quaternion.identity);

    //        // Store the original position
    //        Vector3 originalPosition = newNote.transform.position;

    //        // Set the new note as a child of the spawner's transform
    //        newNote.transform.SetParent(transform, false);

    //        // Restore the original position
    //        newNote.transform.position = originalPosition;
    //    }
    //}