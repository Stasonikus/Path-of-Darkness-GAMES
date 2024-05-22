using UnityEngine;

namespace StarterAssets
{
    public class Buildgrid : MonoBehaviour
    {
        public Vector2Int GridSize = new Vector2Int(100, 100);
        public int cost;
        private build[,] grid;
        private build flyingbuilding;
        private Camera mainCamera;
        private bool isPlacementActive = false;
        public static bool shoot = true;
        public GameObject guiTextLink;
        public bool destroy = false;

        // Добавляем массив переменных для коллайдеров, которые определяют зоны строительства
        public Collider[] buildZoneColliders = new Collider[10];

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
            shoot = false;
        }

        private void Update()
        {
            // Проверяем наличие коллайдеров для зон строительства
            foreach (var collider in buildZoneColliders)
            {
                if (collider == null)
                {
                    Debug.LogError("Не установлены все коллайдеры для зон строительства.");
                    return;
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                isPlacementActive = true;
            }

            if (Input.GetMouseButtonDown(1)) // ПКМ для удаления объекта
            {
                if (flyingbuilding != null)
                {
                    Destroy(flyingbuilding.gameObject);
                    flyingbuilding = null;
                    isPlacementActive = false;
                    shoot = true;
                    destroy = true;

                    // Проверяем, нужно ли добавлять деньги
                    if (destroy == true)
                    {
                        Money.Instance._money += 50;
                        destroy = false;
                    }
                }
            }

            if (flyingbuilding != null && isPlacementActive)
            {
                var groundPlane = new Plane(Vector3.up, Vector3.zero);
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

                if (groundPlane.Raycast(ray, out float position))
                {
                    Vector3 worldPosition = ray.GetPoint(position);

                    // Проверяем, что мы находимся в пределах хотя бы одной из зон строительства
                    bool inBuildZone = false;
                    foreach (var collider in buildZoneColliders)
                    {
                        if (collider.bounds.Contains(worldPosition))
                        {
                            inBuildZone = true;
                            break;
                        }
                    }

                    if (!inBuildZone)
                    {
                        Debug.Log("Выход за пределы зон строительства.");
                        return;
                    }

                    int x = Mathf.RoundToInt(worldPosition.x);
                    int y = Mathf.RoundToInt(worldPosition.z);

                    bool available = true;

                    // Проверяем, не выходит ли объект за границы сетки
                    if (x < 0 || x > GridSize.x - flyingbuilding.Size.x) available = false;
                    if (y < 0 || y > GridSize.y - flyingbuilding.Size.y) available = false;

                    if (available && IsPlaceTaken(x, y)) available = false;

                    flyingbuilding.transform.position = new Vector3(x, 0, y);
                    flyingbuilding.SetTransperent(available);

                    if (available && Input.GetMouseButtonDown(0))
                    {
                        placeFlyingBuilding(x, y);
                        shoot = true;
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
            for (int x = 0; x < flyingbuilding.Size.x; x++)
            {
                for (int y = 0; y < flyingbuilding.Size.y; y++)
                {
                    grid[placeX + x, placeY + y] = flyingbuilding;
                }
            }
            flyingbuilding.SetNormal();
            flyingbuilding = null;
            isPlacementActive = false;
        }
    }
}
