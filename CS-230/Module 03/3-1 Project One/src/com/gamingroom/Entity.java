package com.gamingroom;

/**
 * Base class containing attributes and behaviors shared by
 * games, teams, and players.
 */

public class Entity {

    private long id;
    private String name;

    /**
     * Default constructor.
     */
    protected Entity() {
    }

    /**
     * Initialized constructor with the following arguements:
     * @param id unique identifier
     * @param name entity name
     */
    protected Entity(long id, String name) {
        this.id = id;
        this.name = name;
    }

    /**
     * @return the entity id
     */ 
    public long getId() {
        return id;
    }

    /**
     * @return the entity name
     */
    public String getName() {
        return name;
    }

    // toString Override for debug and output
    @Override
    public String toString() {
        return "Entity [id=" + id + ", name=" + name + "]";
    }
}
