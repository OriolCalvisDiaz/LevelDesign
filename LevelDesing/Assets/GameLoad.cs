using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoad : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene("LvL01", LoadSceneMode.Single);
    }
}
