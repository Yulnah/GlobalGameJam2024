using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    //[SerializeField]
    //private GameObject comboOne;
    //[SerializeField]
    //private GameObject comboTwo;
    //[SerializeField]
    //private GameObject comboThree;
    //[SerializeField]
    //private GameObject comboFour;

    [SerializeField]
    private GameObject[] comboPrefabs;

    [SerializeField]
    private float spawnInterval = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNoteRoutine(spawnInterval));
    }

    // Update is called once per frame
    void Update()
    {
        // Your update logic, if any
    }

    private IEnumerator SpawnNoteRoutine(float spawnInterval)
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

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

}
