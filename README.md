Certainly! Here's a GitHub README for your T-REX game project. It explains the purpose, features, how to use it, and credits.

---

# T-REX version 1

Welcome to T-REX 10.5, a fun and challenging game where you control a T-Rex to avoid obstacles and score points! This project is implemented in C# using Windows Forms, providing an interactive gaming experience.

## Features

### Game Setup
- **Form1**: Main menu to start the game or view high scores.
- **Form2**: Enter player name before starting the game.
- **Form3**: View and manage high scores stored in a local database.
- **Form4**: The game interface where the T-Rex runs and jumps to avoid obstacles.

### Gameplay Mechanics
- **Jumping Mechanism**: Control the T-Rex to jump over obstacles by pressing the spacebar.
- **Score Tracking**: Track your score as you successfully avoid obstacles.
- **Increasing Difficulty**: Obstacle speed increases as your score progresses.
- **Restart Option**: Press 'R' to restart the game after game over.

### Database Integration
- **Local Database**: Stores player names and their scores using SQL Server Express.
- **Save Scores**: Automatically saves the player's score to the database upon game over.

## Usage

1. **Clone the repository**:

   ```bash
   git clone https://github.com/your-username/t-rex-10.5.git
   ```

2. **Set Up Database**:
   - Ensure SQL Server Express is installed.
   - Modify `connectionString` in `Form3.cs` and `Form4.cs` to point to your local database.

3. **Compile and Run the Program**:
   - Open the project in Visual Studio.
   - Build and run the solution (`F5` or Debug > Start Debugging).

4. **Navigate the Game**:
   - **Main Menu (Form1)**: Choose between starting the game or viewing high scores.
   - **Player Name Input (Form2)**: Enter your name before starting the game.
   - **High Scores (Form3)**: View scores from previous players.
   - **Game Interface (Form4)**: Control the T-Rex, avoid obstacles, and see your score.

5. **Enjoy the Game**:
   - Have fun running and jumping with the T-Rex!
   - Challenge yourself to beat your own high score and those of others.

## Credits

- **Developer**: [ABDUR RAFAY](https://github.com/abdurrafay)
