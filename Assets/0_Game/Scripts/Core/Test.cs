using UnityEngine;
using Match3Core;

public class Test : MonoBehaviour
{
    public int sizeX, sizeY;
    private GridPosition[,] grid;

    private void Awake()
    {
        grid = new GridPosition[sizeX, sizeY];
        for (int i = 0; i < sizeX; i++)
        {
            for(int j = 0; j < sizeY; j++)
            {
                grid[i, j] = new GridPosition(i,j);
                Debug.Log(grid[i, j].ToString());
            }
        }
    }


    [SerializeField] Gem gem;
    [SerializeField] GemType gemType;
    [SerializeField] GridPosition pos;

    [ContextMenu("Test")]
    void innitGem()
    {
        gem.Inittialize(gemType, pos);
    }
}
