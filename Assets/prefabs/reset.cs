using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class reset : MonoBehaviour
{
    public string sceneName;

    void OnMouseDown()
    {
        transform.position += Vector3.down * 0.1f;
    }
    void OnMouseUp()
    {
        transform.position += Vector3.up * 0.1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
