using System.Linq;
using Microsoft.JSInterop;
using UniConnect.Data;
using UniConnect.Modals;

public static class ChatBotBridge
{
    public static AppDbContext _db;

    public static void Configure(AppDbContext db)
    {
        _db = db;
    }
    [JSInvokable]
    public static string SearchLostFoundItems(string userMessage)
    {
        if (string.IsNullOrWhiteSpace(userMessage) || _db == null)
            return "❌ Could not process the message.";

        string msg = userMessage.ToLower();
        var items = _db.LostFoundItems
            .OrderByDescending(i => i.PostedAt)
            .ToList();

        var matches = items
            .Where(i => msg.Contains("lost") || msg.Contains("found") || msg.Contains("did anyone") || msg.Contains("has anyone"))
            .Where(i => msg.Contains(i.Title.ToLower()) || msg.Contains(i.Description.ToLower()))
            .ToList();

        if (!matches.Any())
        {
            var fallbackMatches = items
                .Where(i => userMessage.Contains(i.Title, StringComparison.OrdinalIgnoreCase) || userMessage.Contains(i.Description, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!fallbackMatches.Any())
                return "🔍 No matching lost or found items were reported.";

            matches = fallbackMatches;
        }

        return "🧾 Matching Lost/Found Reports:<br>" + string.Join("<br>", matches.Select(i => $"- {i.Title} ({i.Type}) at {i.Location} on {i.Date:dd MMM}"));
    }
    [JSInvokable]
    public static string SearchEventInfo(string userMessage)
    {
        if (string.IsNullOrWhiteSpace(userMessage) || _db == null)
            return "❌ Could not process the message.";

        string msg = userMessage.ToLower();

        var events = _db.Events
            .Where(e => e.Date >= DateTime.Today)
            .OrderBy(e => e.Date)
            .ToList();

        var matchedEvents = events
            .Where(e =>
                msg.Contains(e.Title.ToLower()) ||
                msg.Contains(e.Description.ToLower()) ||
                msg.Contains(e.Category.ToLower()) ||
                msg.Contains(e.Name.ToLower()) ||
                msg.Contains(e.Faculty.ToLower()) ||
                msg.Contains(e.Location.ToLower())
            )
            .ToList();

        if (!matchedEvents.Any())
            return "📭 No matching events found.";

        return "📅 Matching Upcoming Events:<br>" + string.Join("<br>", matchedEvents.Select(e =>
            $"- {e.Title} ({e.Category}) on {e.Date:dd MMM} at {e.Location} – by {e.Faculty}"
        ));
    }


    [JSInvokable]
    public static string GetLostFoundItems()
    {
        var items = _db.LostFoundItems
            .OrderByDescending(i => i.PostedAt)
            .Take(5)
            .Select(i => $"- {i.Title}: {i.Description}")
            .ToList();

        return items.Any() ? string.Join("<br>", items) : "No lost & found items found.";
    }

    [JSInvokable]
    public static string GetEventTypes()
    {
        var types = _db.Events
            .Select(e => e.Category)
            .Distinct()
            .ToList();

        return types.Any() ? "Available event categories:<br>" + string.Join("<br>", types) : "No events found.";
    }
    [JSInvokable]
    public static string GetUpcomingEvents()
    {
        var upcoming = _db.Events
            .Where(e => e.Date >= DateTime.Today)
            .OrderBy(e => e.Date)
            .Take(5)
            .Select(e => $"- {e.Title} on {e.Date:dd MMM yyyy} at {e.Location}")
            .ToList();

        return upcoming.Any() ? string.Join("<br>", upcoming) : "No upcoming events.";
    }


}
