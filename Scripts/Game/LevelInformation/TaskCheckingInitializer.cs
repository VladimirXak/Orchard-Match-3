using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orchard.Game
{
    public class TaskCheckingInitializer : MonoBehaviour
    {
        public static IBoardObjectChecking GetTaskCheking(TypeTask typeTask)
        {
            switch (typeTask)
            {
                case TypeTask.PieceRnd:
                    return new PieceGeneralChecking();
                case TypeTask.PieceRed:
                    return new PieceRedChecking();
                case TypeTask.PieceYellow:
                    return new PieceYellowChecking();
                case TypeTask.PieceGreen:
                    return new PieceGreenChecking();
                case TypeTask.PieceBlue:
                    return new PieceBlueChecking();
                case TypeTask.PieceOrange:
                    return new PieceOrangeChecking();
                case TypeTask.BoosterBomb:
                    return new BoosterBombChecking();
                case TypeTask.BoosterLine:
                    return new BoosterLineChecking();
                case TypeTask.BoosterFly:
                    return new BoosterFlyChecking();
                case TypeTask.BoosterAny:
                    return new BoosterAnyChecking();
                case TypeTask.BlockOver_Wax:
                    return new BlockOverWaxChecking();
                case TypeTask.BlockUnder_Slime:
                    return new BlockUnderSlimeChecking();
                case TypeTask.PieceAcorn:
                    return new PieceAcornChecking();
                case TypeTask.BlockOverChestWood:
                    return new BlockOverChestWoodChecking();
                case TypeTask.PiecePumpkin:
                    return new PieceCandyChecking();
                case TypeTask.BlockOverBox:
                    return new BlockOverBoxChecking();
                case TypeTask.BlockOverJelly:
                    return new BlockOverJellyChecking();
                case TypeTask.BlockUnderBoardWood:
                    return new BlockUnderBoardWoodChecking();
                case TypeTask.BlockOverHoney:
                    return new BlockOverHoneyChecking();
                case TypeTask.BlockPieceChain:
                    return new BlockPieceChainChecking();
                case TypeTask.BlockPieceIce:
                    return new BlockPieceIceChecking();
            }

            return new BoardObjectNullChecking();
        }
    }
}
