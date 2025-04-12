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
    }
}
