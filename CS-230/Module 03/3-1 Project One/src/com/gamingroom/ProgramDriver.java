package com.gamingroom;

/**
 * Application start-up program
 * 
 * @author coce@snhu.edu
 */
public class ProgramDriver {
	
	/**
	 * The one-and-only main() method
	 * 
	 * @param args command line arguments
	 */
	public static void main(String[] args) {
		
		// use another class to prove there is only one instance
		SingletonTester tester = new SingletonTester();
		tester.testSingleton();
		
		GameService service = GameService.getInstance();
		
		System.out.println("\nAbout to test initializing game data...");
		
		// initialize with some game data
		Game game1 = service.addGame("Game #1");
		Game game2 = service.addGame("Game #2");
		Game duplicateGame = service.addGame("Game #1");

		System.out.println(game1);
		System.out.println(game2);

		Team team1 = game1.addTeam("Team #1");
		Team team2 = game1.addTeam("Team #2");
		Team duplicateTeam = game1.addTeam("Team #1");

		System.out.println(team1);
		System.out.println(team2);

		Player player1 = team1.addPlayer("Player #1");
		Player player2 = team1.addPlayer("Player #2");
		Player duplicatePlayer = team1.addPlayer("Player #1");

		System.out.println(player1);
		System.out.println(player2);
		
		System.out.println("Duplicate game prevented: "
			+ (game1 == duplicateGame)
		);
		System.out.println("Duplicate team prevented: "
			+ (team1 == duplicateTeam)
		);
		System.out.println("Duplicate player prevented: "
			+ (player1 == duplicatePlayer)
		);
	}
}
