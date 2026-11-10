using UnityEngine;

public class ArraysTutorial : MonoBehaviour
{
    string[] programmingLanguages = new string[5];
    void Start()
    {
        programmingLanguages[0] = "C#";
        programmingLanguages[1] = "Java";
        programmingLanguages[2] = "Python";
        programmingLanguages[3] = "JavaScript";
        programmingLanguages[4] = "C++";
        programmingLanguages[4] = "C#";

        print(programmingLanguages[4]);
    }
}
