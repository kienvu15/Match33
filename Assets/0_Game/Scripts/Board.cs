using Match3Core;
using UnityEngine;

public class Board : MonoBehaviour
{
    [Header("Board")]
    [SerializeField] int width;
    [SerializeField] int height;

    [Header("Gem")]
    [SerializeField] private Gem gemPrefab;
    [SerializeField] float gemSize;
    [SerializeField] float gemSpacing;

    [SerializeField] Transform gemContainer;

    private Gem[,] gems;

    private void Awake()
    {
        
    }

    private void Start()
    {
        Innitialize();
    }

    void Innitialize()
    {
        gems = new Gem[width, height];
        SnapCamera();
        for (int i = 0; i < width; i++)
        { 
            for (int j = 0; j < height; j++)
            {
                SpawnGem(new GridPosition(i, j));
            }
        }
    }

    void SpawnGem(GridPosition position)
    {
        GameObject gemObj = Instantiate(gemPrefab.gameObject, gemContainer);
        Gem gem = gemObj.GetComponent<Gem>();

        GemType type = (GemType)UnityEngine.Random.Range(0, 5);

        gem.Inittialize(type, position);
        gems[position.x, position.y] = gem;
    }

    void SnapCamera()
    {
        Camera cam = Camera.main;
        cam.transform.position = new Vector3(width/2 -0.5f, height/2-0.5f, -10);
        float verticalSize = height / 2f + 1f;
        float horizontal = (width / 2f + 1f) / cam.aspect;

        cam.orthographicSize = Mathf.Max(verticalSize, horizontal);
    }
}
