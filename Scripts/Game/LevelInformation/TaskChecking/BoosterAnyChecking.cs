namespace Orchard
{
    public class BoosterAnyChecking : IBoardObjectChecking
    {
        public bool Check(TypeBoardObject type)
        {
            switch (type)
            {
                case TypeBoardObject.BoosterBomb:
                case TypeBoardObject.BoosterLine:
                case TypeBoardObject.BoosterFly:
                    return true;
            }

            return false;
        }
    }
}
