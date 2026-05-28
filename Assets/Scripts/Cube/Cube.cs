using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [Header("Cube")]
    public GameObject cubePrefab;

    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;

    private Vector3 moveDirection;
    private Vector3 rotationDirection;

    private float limitX = 2f;
    private float limitY = 4f;

    // Guarda posições já utilizadas
    private static List<Vector3> usedPositions = new List<Vector3>();

    void Start()
    {
        ChooseNewDirections();
    }

    public void CreateCube()
    {
        Vector3 randomPosition;

        int safety = 0;

        do
        {
            float randomX = Random.Range(-limitX, limitX);
            float randomY = Random.Range(-limitY, limitY);

            randomPosition = new Vector3(
                Mathf.Round(randomX * 10f) / 10f,
                Mathf.Round(randomY * 10f) / 10f,
                0f
            );

            safety++;

        } while (usedPositions.Contains(randomPosition) && safety < 100);

        usedPositions.Add(randomPosition);

        Instantiate(cubePrefab, randomPosition, Quaternion.identity);
    }

    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        Vector3 pos = transform.position;

        if (pos.x >= limitX || pos.x <= -limitX)
        {
            moveDirection.x *= -1;
        }

        if (pos.y >= limitY || pos.y <= -limitY)
        {
            moveDirection.y *= -1;
        }

        transform.position = new Vector3(pos.x, pos.y, 0f);

        transform.Rotate(rotationDirection * rotationSpeed * Time.deltaTime);
    }

    void ChooseNewDirections()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);

        moveDirection = new Vector3(randomX, randomY, 0f).normalized;

        rotationDirection = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        ).normalized;
    }
}