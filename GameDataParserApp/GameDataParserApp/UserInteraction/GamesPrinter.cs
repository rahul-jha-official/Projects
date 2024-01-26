﻿using GameDataParserApp.Model;

namespace GameDataParserApp.UserInteraction;

public class GamesPrinter : IGamesPrinter
{
    private readonly IUserInteractor _userInteractor;
    public GamesPrinter(IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor;            
    }
    public void Print(List<VideoGame> videoGames)
    {
        _userInteractor.PrintMessage(Environment.NewLine + "Loaded games are:");
        foreach (var game in videoGames)
        {
            _userInteractor.PrintMessage(game.ToString());
        }
    }
}
