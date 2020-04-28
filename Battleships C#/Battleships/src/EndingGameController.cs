
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
//using System.Data;
using System.Diagnostics;
using SwinGameSDK;

/// <summary>
/// The EndingGameController is responsible for managing the interactions at the end
/// of a game.
/// </summary>

static class EndingGameController
{

	/// <summary>
	/// Draw the end of the game screen, shows the win/lose state
	/// </summary>
	public static void DrawEndOfGame()
	{
		UtilityFunctions.DrawField(GameController.ComputerPlayer.PlayerGrid, GameController.ComputerPlayer, true);
		UtilityFunctions.DrawSmallField(GameController.HumanPlayer.PlayerGrid, GameController.HumanPlayer);
		Rectangle rect = new Rectangle();
		rect.Width = SwinGame.ScreenWidth();
		rect.Height = SwinGame.ScreenHeight();
		rect.X = 0;
		rect.Y = 250;
		if (GameController.HumanPlayer.IsDestroyed) {
			//SwinGame.DrawTextLines("YOU LOSE!", Color.White, Color.Transparent, GameResources.GameFont("ArialLarge"), FontAlignment.AlignCenter, 0, 250, SwinGame.ScreenWidth(), SwinGame.ScreenHeight());           
			SwinGame.DrawText("YOU LOSE!", Color.White, Color.Transparent, GameResources.GameFont("CourierLarge"), FontAlignment.AlignCenter, rect);           
            //SwinGame.DrawText("YOU LOSE!", Color.White, GameResources.GameFont("ArialLarge"), 0, 250);           
		} else {
			SwinGame.DrawText("-- WINNER! --", Color.White, Color.Transparent, GameResources.GameFont("Courier"), FontAlignment.AlignCenter, rect);

		}
	}

	/// <summary>
	/// Handle the input during the end of the game. Any interaction
	/// will result in it reading in the highsSwinGame.
	/// </summary>
	public static void HandleEndOfGameInput()
	{
		if (SwinGame.MouseClicked(MouseButton.LeftButton) || SwinGame.KeyTyped(KeyCode.ReturnKey) || SwinGame.KeyTyped(KeyCode.EscapeKey)) {
			HighScoreController.ReadHighScore(GameController.HumanPlayer.Score);
			GameController.EndCurrentState();
		}
	}

}
