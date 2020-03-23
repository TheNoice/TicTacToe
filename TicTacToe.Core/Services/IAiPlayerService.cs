﻿using TicTacToe.Core.Domain;
using TicTacToe.Core.Models;

namespace TicTacToe.Core.Services
{
    public interface IAiPlayerService
    {
        Position MakeTurn(GameStatus currentGameStatus);
    }
}