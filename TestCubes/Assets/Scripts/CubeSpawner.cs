using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float distanceOfCube;
    [SerializeField] private float timeOfSpawn;

    private List<GameObject> listOfAllCubes = new List<GameObject>();

    public GameObject pointOfSpawn;
    public GameObject prefabCube;

    private void Start()
    {
        StartCoroutine(SpawnCube());
    }

    IEnumerator SpawnCube()
    {
        yield return new WaitForSeconds(timeOfSpawn);

        bool fromPool = false;

        for (int i = 0; i < listOfAllCubes.Count; i++)
        {
            if (listOfAllCubes[i].activeSelf == false)
            {
                fromPool = true;
                listOfAllCubes[i].SetActive(true);
                listOfAllCubes[i].transform.position = pointOfSpawn.transform.position;
                CubeMovement cubeMove = listOfAllCubes[i].GetComponent<CubeMovement>();
                cubeMove.SetStartPosition();
                cubeMove.SetDistanceOfCube(distanceOfCube);
                cubeMove.SetSpeed(speed);
                break;
            }
        }

        if (fromPool == false)
        {
            GameObject cube = Instantiate(prefabCube, pointOfSpawn.transform.position, Quaternion.identity);
            cube.SetActive(true);
            CubeMovement cubeMove = cube.GetComponent<CubeMovement>();
            cubeMove.SetDistanceOfCube(distanceOfCube);
            cubeMove.SetSpeed(speed);
            listOfAllCubes.Add(cube);
        }

        StartCoroutine(SpawnCube());
    }


    public void SetSpeedFromInput(float speed)
    {
        this.speed = speed;
    }
    public void SetTimeFromInput(float timeOfSpawn)
    {
        this.timeOfSpawn = timeOfSpawn;
    }
    public void SetDistanceFromInput(float distanceOfCube)
    {
        this.distanceOfCube = distanceOfCube;
    }
}
