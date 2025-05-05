using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ActivityTrackerApp.Models;
using Microsoft.JSInterop;

namespace ActivityTrackerApp.Services
{
    public class LocalStorageService
    {
        private readonly IJSRuntime _jsRuntime;
        private const string UserKey = "users";
        private const string ActivityKey = "activities";

        public LocalStorageService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<User> GetUserAsync(string username)
        {
            var users = await GetUsersAsync();
            return users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<User> CreateUserAsync(string username)
        {
            var users = await GetUsersAsync();
            var newUser = new User
            {
                Id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1,
                Username = username
            };
            users.Add(newUser);
            await SaveUsersAsync(users);
            return newUser;
        }

        public async Task<List<Activity>> GetUserActivitiesAsync(int userId)
        {
            var activities = await GetActivitiesAsync();
            return activities.Where(a => a.UserId == userId).ToList();
        }

        public async Task<Activity> SaveActivityAsync(Activity activity)
        {
            var activities = await GetActivitiesAsync();
            if (activity.Id == 0)
            {
                activity.Id = activities.Count > 0 ? activities.Max(a => a.Id) + 1 : 1;
                activities.Add(activity);
            }
            else
            {
                var index = activities.FindIndex(a => a.Id == activity.Id);
                if (index != -1)
                {
                    activities[index] = activity;
                }
            }
            await SaveActivitiesAsync(activities);
            return activity;
        }

        private async Task<List<User>> GetUsersAsync()
        {
            var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", UserKey);
            return string.IsNullOrEmpty(json) 
                ? new List<User>() 
                : JsonSerializer.Deserialize<List<User>>(json);
        }

        private async Task SaveUsersAsync(List<User> users)
        {
            var json = JsonSerializer.Serialize(users);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", UserKey, json);
        }

        private async Task<List<Activity>> GetActivitiesAsync()
        {
            var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", ActivityKey);
            return string.IsNullOrEmpty(json) 
                ? new List<Activity>() 
                : JsonSerializer.Deserialize<List<Activity>>(json);
        }

        private async Task SaveActivitiesAsync(List<Activity> activities)
        {
            var json = JsonSerializer.Serialize(activities);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", ActivityKey, json);
        }
    }
}
