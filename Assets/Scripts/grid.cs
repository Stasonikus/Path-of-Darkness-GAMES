using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Buildgrid : MonoBehaviour
{
    public Vector2Int GridSize = new Vector2Int(100, 100);

    private build[,] grid;
    private build flyingbuilding;
    private Camera mainCamera;

    private void Awake()
    {
        grid = new build[GridSize.x, GridSize.y];

        mainCamera = Camera.main;       
    }
    public void StartPlacingBuilding(build bedPreFab)
    {
        if (flyingbuilding != null)
       
       {
            Destroy(flyingbuilding.gameObject);
        }
        
        flyingbuilding = Instantiate(bedPreFab);

    }

    private void Update()
    {
        if (flyingbuilding != null)
        {
            var groundPlane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (groundPlane.Raycast(ray, out float position)) 
            {
                Vector3 worldPosition = ray.GetPoint(position);

                int x = Mathf.RoundToInt(worldPosition.x);
                int y = Mathf.RoundToInt(worldPosition.z);

                bool available = true;

                if (x < 0|| x > GridSize.x - flyingbuilding.Size.x - 4) available = false;
                if (y < 0|| y > GridSize.x - flyingbuilding.Size.y - 4) available = false;
                
               if (available && IsPlaceTaken(x ,y)) available= false;

                flyingbuilding.transform.position = new Vector3(x, 0, y);
                flyingbuilding.SetTransperent(available);
               

                if (available && Input.GetMouseButtonDown(0))
                {
                    
                    placeFlyingBuilding(x, y);
                }

            }
             
        } 
    }



   private bool IsPlaceTaken(int placeX, int placeY) 
    {
        for (int x = 0; x < flyingbuilding.Size.x; x++)
        {
            for (int y = 0; y < flyingbuilding.Size.y; y++)
            {
                if (grid[placeX + x, placeY + y] != null) return true;
                    }
           
        }
        return false;
    }

    private void placeFlyingBuilding(int placeX, int placeY)
    {
        for(int x = 0; x<flyingbuilding.Size.x; x++)
        {
            for (int y = 0; y < flyingbuilding.Size.y; y++)
            {
                grid[placeX + x, placeY + y]= flyingbuilding;   
            }
                
        }
        flyingbuilding.SetNormal();
        flyingbuilding = null;
    }
}