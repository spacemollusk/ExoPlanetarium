using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GenerateStarPointCloud : MonoBehaviour
{
    [SerializeField] string filePath = "Assets/Data_CSVs/gaia_star_data_test.csv"; //Location for dataset inside Unity project we are currently working with
    [SerializeField] GameObject starPrefab; // Assign the prefab used to visually render star objects
    [SerializeField] float scaleFactor = 1000f; // Adjusting position scale for in-game perspective

    // Start is called before the first frame update
    void Start()
    {
        //Read through the CSV file and add it to an array
        string[] csvData = File.ReadAllLines(filePath);
        
        //Skip header, row 0
        for (int i = 1; i< csvData.Length; i++)
        {
            string[] row = csvData[i].Split(',');

            //Parse through ra, dec, and parallax 
            float ra = float.Parse(row[1]);
            float dec = float.Parse(row[2]);
            float parallax = float.Parse(row[3]);
            float magnitude = float.Parse(row[4]);

            // Convert ra/dec to Cartesian coordinates
            Vector3 position = ConvertToCartesian(ra, dec, parallax);

            // Star instatiation at the calculated postion above
            GameObject star = Instantiate(starPrefab, position * scaleFactor, Quaternion.identity);

            // Scale the size of the star based on its magnitude
            float starScale = Mathf.Clamp(1.0f / magnitude, 0.1f, 1.0f);
            star.transform.localScale = new Vector3(starScale, starScale, starScale);
        }
    }

    // Function for converting the ra, dec, and parallax to 3D Cartesian coordinates
    Vector3 ConvertToCartesian(float ra, float dec, float parallax)
    {
        // to radian conversion
        float raRad = ra * Mathf.Deg2Rad;
        float decRad = dec * Mathf.Deg2Rad;

        // Convert parallax to distance defined in parsecs
        float distance = 1.0f / parallax;

        // establish variables to house each cartesian coordinate 
        float x = distance * Mathf.Cos(decRad) * Mathf.Cos(raRad);
        float y = distance * Mathf.Cos(decRad) * Mathf.Sin(raRad);
        float z = distance * Mathf.Sin(decRad);

        return new Vector3(x, y, z);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
