using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

namespace Orchard.Game
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class BlockOverHoney : Block
    {
        [SerializeField] private DataDynamicBorder _dataDynamicBorder;

        public event UnityAction<BlockOverHoney> OnDestroy;

        private List<SpriteRenderer> _listRender;
        private IBoardObjectChecking _blockObjectChecking;

        private SpriteRenderer _render;

        private void Awake()
        {
            _render = GetComponent<SpriteRenderer>();
            _render.enabled = false;

            _blockObjectChecking = new BlockOverHoneyChecking();
            _borderDisplay = new DynamicBorder(this, dataDynamicBorder, CheckTypeDynamicBorder);
        }

        public override void Init(TypeBoardObject type, Tile tile)
        {
            base.Init(type, tile);
            _listRender = _borderDisplay.Display();
            DisplayBorderNear();
        }

        public override void HitBooster()
        {
            DestroyBlock();
        }

        public override void HitNear(TypeBoardObject typeHit)
        {
            DestroyBlock();
        }

        private void DestroyBlock()
        {
            Tile.Board.TasksLevelInformation.DecreaseToTask(Type);
            Tile.TileBlock.SetBlockOver(null);
            DisplayBorderNear();

            foreach (var render in _listRender)
                render.sprite = null;

            _render.enabled = true;

            _render.DOFade(0, 0.3f).OnComplete(delegate
            {
                OnDestroy?.Invoke(this);
                _render.enabled = false;
                _render.SetAlpha(1);
            });
        }

        private void DisplayBorderNear()
        {
            List<PosXY> dPosXY = new List<PosXY>() { new PosXY(-1, -1), new PosXY(0, -1), new PosXY(1, -1), new PosXY(-1, 0),
            new PosXY(0, 0), new PosXY(1, 0), new PosXY(-1, 1), new PosXY(0, 1), new PosXY(1, 1) };

            for (int i = 0; i < dPosXY.Count; i++)
            {
                PosXY dp = dPosXY[i] + Tile.PosXY;

                Block tempBlock = Tile.Board.GetTile(dp.x, dp.y)?.TileBlock.BlockOver;

                if (tempBlock?.Type == Type)
                {
                    tempBlock.DisplayBorder();
                }
            }
        }

        private bool CheckTypeDynamicBorder(Tile tile)
        {
            return _blockObjectChecking.Check(tile?.TileBlock.BlockOver?.Type ?? TypeBoardObject.NULL);
        }
    }
}
