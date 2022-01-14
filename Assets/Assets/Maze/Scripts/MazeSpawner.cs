using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MazeSpawner : MonoBehaviour
{
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    [SerializeField] private NavMeshSurface _meshSurface;
    public Cell CellPrefab;
    public Vector3 CellSize = new Vector3(1,1,0);
    public HintRenderer HintRenderer;

    public Maze maze;

    private void Start()
    {
        MazeGenerator generator = new MazeGenerator();
        maze = generator.GenerateMaze(_width, _height);

        for (int x = 0; x < maze.cells.GetLength(0); x++)
        {
            for (int y = 0; y < maze.cells.GetLength(1); y++)
            {
                Cell c = Instantiate(CellPrefab, new Vector3(x * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity);
                c.name = $"x{x} Y{y}";
                c.WallLeft.SetActive(maze.cells[x, y].WallLeft);
                c.WallBottom.SetActive(maze.cells[x, y].WallBottom);

                if (x + 2 == maze.cells.GetLength(0) && y + 2 == maze.cells.GetLength(1))
                    c.SetFinish();

                else if (x + 1 == maze.cells.GetLength(0) || y + 1 == maze.cells.GetLength(1))
                {
                    c.Floor.SetActive(false);
                }
                
                else c.DeleteComponentFinish();

                if (x < 2 || y < 2) c.DeleteComponentDeath();
            }
        }

        _meshSurface.BuildNavMesh();
      //  HintRenderer.DrawPath();
        // StartCoroutine(DelayBuildNavMesh());
    }

    private IEnumerator DelayBuildNavMesh()
    {
        yield return new WaitForSeconds(1f);
        _meshSurface.BuildNavMesh();
    }
}