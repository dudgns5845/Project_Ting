using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTest : MonoBehaviour
{

    public GameObject[] cube_1;
    Vector3 dir0;
    Vector3 dir1;
    Vector3 dir2;
    Vector3 dir3;
    Vector3 velo;

    float instance = 2.5f;
    Vector3 sideInstance;
    

    public bool cubeposition;

    // Start is called before the first frame update
    void Start()
    {
        dir0 = new Vector3(transform.position.x - instance, transform.position.y + instance, 0);
        dir1 = new Vector3(transform.position.x - instance, transform.position.y - instance, 0);
        dir2 = new Vector3(transform.position.x + instance, transform.position.y + instance, 0);
        dir3 = new Vector3(transform.position.x + instance, transform.position.y - instance, 0);
        cubeposition = true;
       

    }

    // Update is called once per frame
    void Update()
    {


        CopyCube();

        if (cube_1[0].transform.position.x < -2.49f || cube_1[0].transform.position.x > 2.49f)
        {
            StartCoroutine(DestroyTime());
            cubeposition = false;
            print(cubeposition);

            transform.Rotate(Vector3.forward * 500 * Time.deltaTime);
        }

    }



    IEnumerator DestroyTime()
    {
        yield return new WaitForSeconds(10f);

        Destroy(gameObject);
    }

    void CopyCube()
    {
        if (cubeposition == true)
        {
            cube_1[0].transform.position = Vector3.Lerp(cube_1[0].transform.position, dir0, 0.05f);
            cube_1[1].transform.position = Vector3.Lerp(cube_1[1].transform.position, dir1, 0.05f);
            cube_1[2].transform.position = Vector3.Lerp(cube_1[2].transform.position, dir2, 0.05f);
            cube_1[3].transform.position = Vector3.Lerp(cube_1[3].transform.position, dir3, 0.05f);

        }

    }
}
