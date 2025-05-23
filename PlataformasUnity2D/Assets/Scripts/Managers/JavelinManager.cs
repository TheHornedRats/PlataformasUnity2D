using System.Collections.Generic;
using UnityEngine;

public class JavelinManager : MonoBehaviour
{
    public static List<GameObject> javelinasClavadas = new List<GameObject>();
    public static int maxJavelinas = 3;

    public static void RegisterClavada(GameObject javelina)
    {
        javelinasClavadas.Add(javelina);

        if (javelinasClavadas.Count > maxJavelinas)
        {
            GameObject antigua = javelinasClavadas[0];
            javelinasClavadas.RemoveAt(0);
            Destroy(antigua);
        }
    }
}
