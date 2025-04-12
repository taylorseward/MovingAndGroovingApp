using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MovingAndGroovingApp.Models;

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
    }
}
