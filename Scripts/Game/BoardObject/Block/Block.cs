using UnityEngine;

namespace Orchard.Game
{
    public abstract class Block : MonoBehaviour
    {
        [SerializeField] protected DataBoardObject _dataBoardObject;

        public TypeBoardObject Type { get; protected set; }

        public Tile Tile { get; private set; }

        protected IBorderDisplay _borderDisplay = new StaticBorder();

        public virtual void Init(TypeBoardObject type, Tile tile)
        {
            Tile = tile;
            Type = type;
        }

        public void DisplayBorder()
        {
            _borderDisplay.Display();
        }

        public virtual void HitBooster() { }
        public virtual void HitMatch() { }
        public virtual void HitNear(TypeBoardObject typeHit) { }
    }
}
