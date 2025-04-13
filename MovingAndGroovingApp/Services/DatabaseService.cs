using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MovingAndGroovingApp.Models;
using MovingAndGroovingApp.Services;

namespace MovingAndGroovingApp.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "MovingAndGrooving.db3");
            // debug db path
            Console.WriteLine($"Database path: {dbPath}");
            _database = new SQLiteAsyncConnection( dbPath );
            InitializeDatabase().ConfigureAwait( false );
        }

        // Initialize Database
        private async Task InitializeDatabase()
        {
            try
            {
                await _database.CreateTableAsync<WorkoutLog>();
                await _database.CreateTableAsync<User>();
                await _database.CreateTableAsync<Team>();
                await _database.CreateTableAsync<Milestone>();
                await _database.CreateTableAsync<CompetitionSettings>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing database: {ex.Message}");
            }
        }

        // WorkoutLog Methods
        public async Task<List<WorkoutLog>> GetWorkoutAsync()
        {
            return await _database.Table<WorkoutLog>().ToListAsync();
        }
        public async Task<WorkoutLog> GetWorkoutByIdAsync(int Id)
        {
            return await _database.Table<WorkoutLog>().Where(x => x.Id == Id).FirstOrDefaultAsync();
        }
        public async Task AddWorkoutAsync(WorkoutLog workoutLog)
        {
            try
            {
                await _database.InsertAsync(workoutLog);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding workout: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateWorkoutAsync(WorkoutLog workoutLog)
        {
            await _database.UpdateAsync(workoutLog);
        }
        public async Task DeleteWorkoutAsync(WorkoutLog workoutLog)
        {
            await _database.DeleteAsync(workoutLog);
        }

        // user
        public Task<User> GetCurrentUserAsync()
        {
            var currentUserId = SessionManager.GetCurrentUserId();
            if (currentUserId.HasValue)
            {
                return _database.Table<User>().Where(u => u.Id == currentUserId.Value).FirstOrDefaultAsync();
            }
            return Task.FromResult(UserService.Instance.CurrentUser);
        }
        public Task<User> GetUserAsync(string username, string password)
        {
            return _database.Table<User>().Where(u => u.UserName == username && u.Password == password).FirstOrDefaultAsync();


        }

        public Task<int> SaveUserAsync(User user)
        {
            return _database.InsertAsync(user);
        }

        // Team
        // Get all teams
        public async Task<List<Team>> GetAllTeamsAsync()
        {
            return await _database.Table<Team>().ToListAsync();
        }

        // Get a team by ID
        public async Task<Team> GetTeamByIdAsync(int id)
        {
            return await _database.Table<Team>().Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        // Add a new team
        public async Task AddTeamAsync(Team team)
        {
            try
            {
                await _database.InsertAsync(team);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding team: {ex.Message}");
                throw;
            }
        }

        // Update an existing team
        public async Task UpdateTeamAsync(Team team)
        {
            try
            {
                await _database.UpdateAsync(team);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating team: {ex.Message}");
                throw;
            }
        }

        // Delete a team
        public async Task DeleteTeamAsync(Team team)
        {
            try
            {
                await _database.DeleteAsync(team);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting team: {ex.Message}");
                throw;
            }
        }

        // Join a team (Add a user to the team)
        public async Task JoinTeamAsync(Team team, User user)
        {
            try
            {
                // Assuming the User table has a TeamId column to associate the user with the team
                user.TeamId = team.Id;
                await _database.UpdateAsync(user);

                // Optionally, you can also update the team's member list or a separate table for users in teams.
                // E.g., you can create a UserTeams table to track users and their teams.

                Console.WriteLine($"User {user.UserName} joined team {team.TeamName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error joining team: {ex.Message}");
                throw;
            }
        }

        // Optionally, you could create a method to get users by their team id, if needed for displaying members.
        public async Task<List<User>> GetUsersByTeamIdAsync(int teamId)
        {
            return await _database.Table<User>().Where(u => u.TeamId == teamId).ToListAsync();
        }

    }
}
