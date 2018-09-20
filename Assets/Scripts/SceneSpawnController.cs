﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SceneSpawnController : MonoBehaviour
{
    // Designer fields
    [SerializeField][ReadOnly] private string type = "";
    [SerializeField] private int maxSceneWeight = 0;
    [SerializeField] private float spawnTimerBase = 0.0f;
    [SerializeField] private float spawnTimerVariation = 0.0f;
    [SerializeField] private float spawnMagnitude = 0.0f;
    [SerializeField] private Arrangement[] arrangements = new Arrangement[0];

    // Logic fields
    private List<GameObject> currentSceneArrangements = new List<GameObject>();

    void Start()
    {
        SetTypeInEditor();

        StartCoroutine(Spawn());
    }

    private void SetTypeInEditor ()
    {
        if (arrangements.Length > 0)
        {
            type = CheckArrangementType();
        }
        else
        {
            type = "No arrangements found!";
        }
    }

    private string CheckArrangementType ()
    {
        string _type = arrangements[0].tag;

        foreach(Arrangement arrangement in arrangements)
        {
            if (arrangement.tag != _type)
            {
                return "Incompatable arrangement types!";
            }
        }

        return _type;
    }

    // Spawning Coroutine
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(spawnTimerBase - spawnTimerVariation, spawnTimerBase + spawnTimerVariation));

        var spawnableArrangements = SpawnableArrangements();

        if (spawnableArrangements.Count > 0)
        {
            var arrangementToSpawn = WeightedSpawner.GetChanceArrangement(spawnableArrangements);
            Instantiate(arrangementToSpawn, GetSpawnLoc(arrangementToSpawn.GetComponent<Arrangement>()), Quaternion.identity);
            currentSceneArrangements.Add(arrangementToSpawn);
        }

        StartCoroutine(Spawn());
    }

    // Determine spawnable arrangement list
    private List<Arrangement> SpawnableArrangements()
    {
        List<Arrangement> spawnableArrangements = new List<Arrangement>();
        var currentSceneWeight = CurrentSceneWeight();

        foreach (Arrangement arrangement in arrangements)
        {
            if (arrangement.SpawnWeight < maxSceneWeight - currentSceneWeight)
            {
                spawnableArrangements.Add(arrangement);
            }
        }

        return spawnableArrangements;
    }

    private float CurrentSceneWeight()
    {
        int currentSceneWeight = 0;
        Arrangement[] sceneArrangements = FindObjectsOfType<Arrangement>();

        foreach (Arrangement sceneArrangement in sceneArrangements)
        {
            if (sceneArrangement.gameObject.tag == type)
            {
                currentSceneWeight += sceneArrangement.SpawnWeight;
            }
        }

        return currentSceneWeight;
    }


    // Location determination to be moved later
    // For testing, spawns center screen
    private Vector2 GetSpawnLoc(Arrangement arrangement)
    {
        return SpawnLocations.GetSpawnLocation(arrangement, spawnMagnitude);
    }

    public class ReadOnlyAttribute : PropertyAttribute
    {

    }




    /* This custom drawer is used to show the arrangemnt type for each instance of this class in the editor for readability */
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property,
                                                GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }

        public override void OnGUI(Rect position,
                                   SerializedProperty property,
                                   GUIContent label)
        {
            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = true;
        }
    }
}