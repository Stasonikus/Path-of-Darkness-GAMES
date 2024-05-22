using UnityEngine;

public class build : MonoBehaviour
{
    public Renderer MainRenderer;
    public Vector2Int Size = Vector2Int.one;
    public int cost;
    public static int _cost;


    private void Start()
    {
        _cost = cost; 
    }
    public void SetTransperent(bool available)
    {
        
        
            if (available)
            {
                
                MainRenderer.material.color = Color.green;
               

            }
            else
            {
              MainRenderer.material.color = Color.red;
            }



       

    }

    public void SetNormal()
    {
        MainRenderer.material.color = Color.white;
       
    }
  
	
   

    private void OnDrawGizmos()
    {
        for (int x = 0; x < Size.x; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                if ((x + y) % 2 == 0) Gizmos.color = Color.red;
                else Gizmos.color = Color.blue;

                    Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, 0.01f, 1));
            }
        }

    }
}
