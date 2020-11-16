using UnityEngine;
using DG.Tweening;

namespace Orchard.Game
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class BlockOverBox : Block
    {
        private SpriteRenderer _render;

        private void Awake()
        {
            _render = GetComponent<SpriteRenderer>();
        }

        public override void Init(TypeBoardObject type, Tile tile)
        {
            base.Init(type, tile);
            SetRender();
        }

        public override void HitBooster()
        {
            HitNear(TypeBoardObject.BoosterAny);
        }

        public override void HitNear(TypeBoardObject typeHit)
        {
            SoundMatch.Instance.PlayClip(Type, _dataBoardObject.GetAudioClip(TypeBoardObject.BlockOverBoxOne));

            switch (Type)
            {
                case TypeBoardObject.BlockOverBoxThree:
                    Type = TypeBoardObject.BlockOverBoxTwo;
                    break;
                case TypeBoardObject.BlockOverBoxTwo:
                    Type = TypeBoardObject.BlockOverBoxOne;
                    break;
                case TypeBoardObject.BlockOverBoxOne:
                    Tile.Board.TasksLevelInformation.DecreaseToTask(Type);
                    Tile.TileBlock.SetBlockOver(null);
                    AnimationHide();
                    return;
            }

            SetRender();
        }

        private void AnimationHide()
        {
            Tile.Actions.TileActivities.NewAction(() =>
            {
                _render.DOFade(0, 0.3f).OnComplete(delegate
                {
                    Destroy(gameObject);
                });
            },
            TypeActions.PieceDestroing, finishDelay: 0.3f);
        }

        private void SetRender()
        {
            _render.sprite = _dataBoardObject.GetSprite(Type);
        }
    }
}
