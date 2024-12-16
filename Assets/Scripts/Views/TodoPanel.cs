using UnityEngine;

public class TodoPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject todoPrefab;

    void Start()
    {
        CreateTodo();
        CreateTodo();
        CreateTodo();
    }

    private void CreateTodo()
    {
        Debug.Log("create todo");
        Instantiate(todoPrefab, transform.position, Quaternion.identity, transform);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
