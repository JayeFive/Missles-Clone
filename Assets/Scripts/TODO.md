TODO LIST

1. Missile Physics
  1. Sine wave oscillations to simulate homing over correction (IMPEMENTED)
  2. Final gameplay testing for each missile.
2. Gameplay
  1. Add new types of missiles
	* Differentiate medium missile into gray(slow) and blue(slightly faster) (IMPLEMENTED, TESTING 9/21)
    * Long-fast missile (IMPLEMENTED)
	* Tiny slow missiles meant for barraging(IMPLEMENTED)
	* Crazy red missile
	* Super crazy gold missile
	* Potentially more gameplay testing on the original to find more types
  2. Missile random spawner. Should get more difficult over time
  3. Bonus star spawner
     * Spawn randomly from array of bonus patterns (single, line, diamond) (IMPLEMENTED, TESTING 9/3)
	 * New shapes -- Five pointed star, lines of 3 along arbitrary vectors
	 * Bonus star collision adds one star to the UI (IMPLEMENTED, TESTING 8/30)
  4. Power-up spawner
	 * Spawn less often than stars randomly from array of power-ups, no world overlap
  5. Missile and bonus/powerup offscreen position indicators (IMPLEMENTED, TESTING 8/30)
     * Make indicators rotate to point offscreen correctly (IMPLEMENTED)
  6. Missle collision with airplane
  7. Scoring
	 * Missile to missile collisions add bonus points (IMPLEMENTED)
3. UI
  1. Intro screen
  2. Game over screen and restart functionality
  3. Pause button functionality
4. Bugs
  1. Rename all classes and cases where I named things 'Missles' (oops) (IMPLEMENTED)
  2. Refactor everything