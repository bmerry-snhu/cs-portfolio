package com.gamingroom;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

/**
 * A simple class to hold information about a game
 * 
 * <p>
 * Notice the overloaded constructor that requires
 * an id and name to be passed when creating.
 * Also note that no mutators (setters) defined so
 * these values cannot be changed once a game is
 * created.
 * </p>
 * 
 * @author coce@snhu.edu
 *
 */
public class Game extends Entity {
	
	private List<Team> teams = new ArrayList<Team>();

	/**
	 * Constructor with an identifier and name
	 */
	public Game(long id, String name) {
		super(id, name);
	}

	public Team addTeam(String name) {
		Iterator<Team> iterator = teams.iterator();
		
		while (iterator.hasNext()) {
			Team team = iterator.next();

			if (team.getName().equalsIgnoreCase(name)) {
				return team;
			}
		}
		
		Team team = new Team(GameService.getInstance().getNextTeamId(), name);
		teams.add(team);
		return team;
	}

	@Override
	public String toString() {
		
		return "Game [id=" + getId() + ", name=" + getName() + "]";
	}

}
