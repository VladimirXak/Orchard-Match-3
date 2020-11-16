using System.Collections.Generic;
using UnityEngine;

namespace Orchard.Game
{
    public class DynamicBorder : IBorderDisplay
    {
        #region Border

        protected int[][] arrBorder = new int[][]
        {
        //0
        new int[9]
        {
            0,0,0,
            0,0,0,
            0,0,0
        },
        //1
        new int[9]
        {
            8,0,7,
            0,1,7,
            7,7,7
        },
        // 2
        new int[9]
        {
            7,0,8,
            7,1,0,
            7,7,7
        },
        // 3
        new int[9]
        {
            7,7,7,
            7,1,0,
            7,0,8
        },
        // 4
        new int[9]
        {
            7,7,7,
            0,1,7,
            8,0,7
        },
        // 5
        new int[9]
        {
            7,0,0,
            7,1,1,
            7,7,7
        },
        // 6
        new int[9]
        {
            0,0,7,
            1,1,7,
            7,7,7
        },
        // 7
        new int[9]
        {
            7,7,7,
            7,1,0,
            7,1,0
        },
        // 8
        new int[9]
        {
            7,1,0,
            7,1,0,
            7,7,7
        },
        // 9
        new int[9]
        {
            7,7,7,
            1,1,7,
            0,0,7
        },
        // 10
        new int[9]
        {
            7,7,7,
            7,1,1,
            7,0,0
        },
        // 11
        new int[9]
        {
            0,1,7,
            0,1,7,
            7,7,7
        },
        // 12
        new int[9]
        {
            7,7,7,
            0,1,7,
            0,1,7
        },
        //13
        new int[9]
        {
            7,7,7,
            7,1,1,
            7,1,0
        },
        //14
        new int[9]
        {
            7,7,7,
            1,1,7,
            0,1,7
        },
        //15
        new int[9]
        {
            0,1,7,
            1,1,7,
            7,7,7
        },
        //16
        new int[9]
        {
            7,1,0,
            7,1,1,
            7,7,7
        },
        //17
        new int[9]
        {
            7,7,7,
            1,1,7,
            1,0,7
        },
        //18
        new int[9]
        {
            7,7,7,
            7,1,1,
            7,0,1
        },
        //19
        new int[9]
        {
            1,1,7,
            0,1,7,
            7,7,7
        },
        //20
        new int[9]
        {
            7,7,7,
            0,1,7,
            1,1,7
        },
        //21
        new int[9]
        {
            7,0,1,
            7,1,1,
            7,7,7
        },
        //22
        new int[9]
        {
            1,0,7,
            1,1,7,
            7,7,7
        },
        //23
        new int[9]
        {
            7,7,7,
            7,1,0,
            7,1,1
        },
        //24
        new int[9]
        {
            7,1,1,
            7,1,0,
            7,7,7
        },
        //25
        new int[9]
        {
            7,7,7,
            7,1,1,
            7,1,1
        },
        //26
        new int[9]
        {
            7,7,7,
            1,1,7,
            1,1,7
        },
        //27
        new int[9]
        {
            1,1,7,
            1,1,7,
            7,7,7
        },
        //28
        new int[9]
        {
            7,1,1,
            7,1,1,
            7,7,7
        },
        };

        #endregion Border

        protected Block block;
        protected TypeBoardObject type;
        protected DataDynamicBorder dataDynamicBorder;

        private List<SpriteRenderer> _listRenderBorder;

        private System.Func<Tile, bool> OnCheckType;

        public DynamicBorder(Block block, DataDynamicBorder dataDynamicBorder, System.Func<Tile, bool> checkType)
        {
            this.block = block;
            type = block.Type;
            OnCheckType = checkType;

            this.dataDynamicBorder = dataDynamicBorder;

            _listRenderBorder = new List<SpriteRenderer>();
        }

        public List<SpriteRenderer> Display()
        {
            int[] arr = new int[9];
            List<PosXY> dPosXY = new List<PosXY>() { new PosXY(-1, -1), new PosXY(0, -1), new PosXY(1, -1), new PosXY(-1, 0),
            new PosXY(0, 0), new PosXY(1, 0), new PosXY(-1, 1), new PosXY(0, 1), new PosXY(1, 1) };

            Tile tile = block.Tile;

            for (int i = 0; i < dPosXY.Count; i++)
            {
                PosXY dp = dPosXY[i] + tile.PosXY;

                Tile tempTile = tile.Board.GetTile(dp.x, dp.y);

                if (OnCheckType?.Invoke(tempTile) ?? false)
                    arr[i] = 1;
                else
                    arr[i] = 0;
            }

            return SetupBorder(arr);
        }

        protected List<SpriteRenderer> SetupBorder(int[] arr)
        {
            List<int> list = GetListBorders(arr);

            if (list.Count != 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (i < _listRenderBorder.Count)
                    {
                        _listRenderBorder[i].sprite = dataDynamicBorder.GetSprite(list[i]);
                    }
                    else
                    {
                        GameObject go = new GameObject(list[i].ToString());

                        SpriteRenderer spr = go.AddComponent<SpriteRenderer>();

                        spr.sprite = dataDynamicBorder.GetSprite(list[i]);
                        spr.sortingLayerName = "BlockOver";

                        go.transform.SetParent(block.transform);
                        go.transform.localPosition = Vector3.zero;
                        go.transform.localScale = new Vector3(1.1f, 1.1f);

                        _listRenderBorder.Add(spr);
                    }
                }

                for (int i = list.Count; i < _listRenderBorder.Count; i++)
                {
                    _listRenderBorder[i].sprite = null;
                }
            }

            return _listRenderBorder;
        }

        private List<int> GetListBorders(int[] arr)
        {
            List<int> list = new List<int>();

            for (int i = 1; i < arrBorder.Length; i++)
            {
                int both = 0;

                for (int k = 0; k < 9; k++)
                {
                    if (arrBorder[i][k] == arr[k] || arrBorder[i][k] == 8)
                        both++;
                }

                if (both == 4)
                {
                    list.Add(i);
                }
            }

            return list;
        }
    }
}
