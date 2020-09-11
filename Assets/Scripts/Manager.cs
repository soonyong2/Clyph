using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    public List<Module> Modules;
    public List<Enemy> Enemies;
    public Canvas Canvas;
    public GameObject HealthBar;

    void Start()
    {
        Manager.Instance = this;

        Modules = FindObjectsOfType<Module>().ToList();
        Enemies = FindObjectsOfType<Enemy>().ToList();

        foreach (Module each in Modules)
        {
            GameObject HPBar = Instantiate(HealthBar, Canvas.transform);
            HPBar.GetComponent<HealthBar>().Setup(each);
        }

        foreach (Enemy each in Enemies)
        {
            GameObject HPBar = Instantiate(HealthBar, Canvas.transform);
            HPBar.GetComponent<HealthBar>().Setup(each);
        }
    }

    void Update()
    {
        
    }
}
