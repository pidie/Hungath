using System;
using System.Collections.Generic;
using UnityEngine;
using Hungath.UIManager;

namespace Hungath.Game
{
    public class TileManager : MonoBehaviour
    {
        public int numOfLandTiles;
        public int numOfFruitTiles;
        public int numOfLivestockTiles;
        public int numOfPredatorTiles;

        private int[] mapSize;
        private int width;
        private int height;

        private System.Random random;

        private float tileBuffer = 0.15f;

        [Header("Tile Percentages by Type")] [SerializeField]
        private float landPercentage = 0.4f;

        [SerializeField] private float fruitPercentage = 0.25f;
        [SerializeField] private float livestockPercentage = 0.15f;
        [SerializeField] private float predatorPercentage = 0.2f;

        private void Awake()
        {
            mapSize = GameManager.GetMapSize(Population.TotalPop);
            width = mapSize[0];
            height = mapSize[1];
            random = new System.Random();
            DetermineNumberOfTileTypes();
            GenerateTiles();
        }

        private void GenerateTiles()
        {
            GameObject tileContainer = GameObject.Find("Tiles");
            float[] startPositions = GetStartPositions();
            float xPosition = startPositions[0];
            float yPosition = startPositions[1];

            int lands = numOfLandTiles;
            int fruits = numOfFruitTiles;
            int livestocks = numOfLivestockTiles;
            int predators = numOfPredatorTiles;

            List<int> tilePool = new List<int>() {lands, fruits, livestocks, predators};

            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    GameObject tile = Resources.Load<GameObject>("Prefabs/Tile");
                    RandomAssign(tilePool, tile.GetComponent<TileBehavior>());

                    Instantiate(tile, new Vector3(xPosition, 0, yPosition), Quaternion.identity,
                        tileContainer.transform);
                    yPosition += 1.15f;
                }

                xPosition += 1.15f;
                yPosition = startPositions[1];
            }
        }

        private void RandomAssign(List<int> options, TileBehavior tile)
        {
            int selection = -1;
            bool looper = true;
            
            while (looper)
            {
                selection = random.Next(options.Count);
                if (options[selection] > 0)
                {
                    looper = false;
                }
            }

            switch (selection)
            {
                case 0:
                    tile.tileType = TileType.Land;
                    tile.tileImage = Resources.Load<Material>("Materials/TileFaceLand");
                    break;
                case 1:
                    tile.tileType = TileType.Berry;
                    tile.tileImage = Resources.Load<Material>("Materials/TileFaceForage");
                    break;
                case 2:
                    tile.tileType = TileType.Goat;
                    tile.tileImage = Resources.Load<Material>("Materials/TileFaceLivestock");
                    break;
                case 3:
                    tile.tileType = TileType.Predator;
                    tile.tileImage = Resources.Load<Material>("Materials/TileFacePredator");
                    break;
                default:
                    throw new NotImplementedException("No tile type here");
            }

            MeshRenderer meshRenderer = tile.face.GetComponent<MeshRenderer>();
            meshRenderer.material = tile.tileImage;
            options[selection] -= 1;
        }

        private float[] GetStartPositions()
        {
            float xPosition = (width + ((width - 1) * tileBuffer)) / -2;
            float yPosition = (height + ((height - 1) * tileBuffer)) / -2;

            return new float[] {xPosition + 0.5f, yPosition + 0.5f};
        }

        private void DetermineNumberOfTileTypes()
        {
            int sumOfTiles = height * width;

            numOfLandTiles = (int) Mathf.Round(sumOfTiles * landPercentage);
            numOfFruitTiles = (int) Mathf.Round(sumOfTiles * fruitPercentage);
            numOfLivestockTiles = (int) Mathf.Round(sumOfTiles * livestockPercentage);
            numOfPredatorTiles = (int) Mathf.Round(sumOfTiles * predatorPercentage);

            int sumOfCreatedTiles = numOfFruitTiles + numOfLandTiles + numOfLivestockTiles + numOfPredatorTiles;

            if (sumOfCreatedTiles < sumOfTiles)
            {
                numOfPredatorTiles++;
            }
        }
    }
}
