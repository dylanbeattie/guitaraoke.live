using System.Text.RegularExpressions;
var songlist = Path.Combine("..", "_includes", "song-list.md");
foreach(var line in File.ReadAllLines(songlist)) {
    var (ok, artist, title) = ReadInfo(line);
    if (! ok) continue;
    var filename = Normalize($"{artist} {title}");
    var filePath = Path.Combine("..", "_songs", filename + ".txt");
    if (File.Exists(filePath)) continue;
    Console.WriteLine(filePath);
    var lines = new[] {
        "---",
        $"artist: {artist}",
        $"title: {title}",
        "---"
    };
    File.WriteAllLines(filePath, lines);
}

string Normalize(string input) {
    var result = Regex.Replace(input, "[^A-Z0-9a-z ]*", "");
    result = Regex.Replace(result, " +", "-");
    return result.ToLower();
}
(bool, string, string) ReadInfo(string line) {
    var trimmed = line.Trim(' ', '*', '-');
    var tokens = trimmed.Split(" - ");
    if (tokens.Length == 2) return (true, tokens[0], tokens[1]);
    return (false, null, null);
}