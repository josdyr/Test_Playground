using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    public GameObject plane;
    public GameObject snakeHead;
    public GameObject applePrefab;
    private MeshRenderer myPlaneRenderer;
    private List<Color> planeColors = new List<Color>() {
        Color.red, Color.green, Color.blue, Color.yellow
    };
    private Color currentColor;
    public GameObject parentObject;
    Renderer rend;
    public Material orange;

    private void Start()
    {
        snakeHead = GameObject.CreatePrimitive(PrimitiveType.Cube);
        snakeHead.name = "snakeHead";
        snakeHead.transform.Translate(new Vector3(0.5f, 0, 0.5f));

        parentObject = new GameObject("parentObject");
        myPlaneRenderer = plane.GetComponent<MeshRenderer>();
        currentColor = myPlaneRenderer.material.GetColor("_Color");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(snakeHead, "right");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(snakeHead, "left");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Move(snakeHead, "up");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Move(snakeHead, "down");
        }
    }

    public void OnClickToggle()
    {
        Debug.Log("OnClickToggle");

        myPlaneRenderer.enabled = !myPlaneRenderer.enabled;
    }

    public void OnClickRandomColor()
    {
        while (currentColor == myPlaneRenderer.material.GetColor("_Color"))
        {
            currentColor = planeColors[Random.Range(0, planeColors.Count)];
            //Debug.Log("Same Color.");
        }

        myPlaneRenderer.material.SetColor("_Color", currentColor);
    }

    public void OnClickSpawnCube()
    {
        
        //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //cube.transform.parent = parentObject.transform;
        //movePrimitiv(cube);


        GameObject newApple = Instantiate(applePrefab, new Vector3(Mathf.Floor(Random.value * 10) + 0.5f, 0, Mathf.Floor(Random.value * 10) + 0.5f), Quaternion.identity);
        newApple.name = "Apple";
    }

    public void movePrimitiv(GameObject primitiveCube)
    {
        primitiveCube.transform.Translate(new Vector3(Mathf.Floor(Random.value * 10) + 0.5f, 0, Mathf.Floor(Random.value * 10) + 0.5f));
    }

    public void OnClickClear()
    {
        //remove all primitiveCubes
        Destroy(parentObject);
        parentObject = new GameObject("parentObject");
    }

    public void OnClickSpawnSnake()
    {
        //snakeHead = GameObject.CreatePrimitive(PrimitiveType.Cube);
        snakeHead.transform.SetPositionAndRotation(new Vector3(0 + 0.5f, 0, 0 + 0.5f), new Quaternion(0, 0, 0, 0));
    }

    public void OnClickMoveRight()
    {
        Debug.Log("Move(\"right\")");
        Move(snakeHead, "right");
    }

    public void OnClickMoveLeft()
    {
        Debug.Log("Move(\"left\")");
        Move(snakeHead, "left");
    }

    public void OnClickMoveUp()
    {
        Debug.Log("Move(\"up\")");
        Move(snakeHead, "up");
    }

    public void OnClickMoveDown()
    {
        Debug.Log("Move(\"down\")");
        Move(snakeHead, "down");
    }

    public void Move(GameObject gameObj, string direction)
    {
        Debug.Log("Move: Up");
        if (direction == "right")
        {
            gameObj.transform.Translate(new Vector3(1.0f, 0, 0));
        }
        else if (direction == "left")
        {
            gameObj.transform.Translate(new Vector3(-1.0f, 0, 0));
        }
        else if (direction == "up")
        {
            gameObj.transform.Translate(new Vector3(0, 0, 1.0f));
        }
        else // down
        {
            gameObj.transform.Translate(new Vector3(0, 0, -1.0f));
        }
    }
}