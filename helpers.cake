IEnumerable<string> GetFrameworks(string s) {
    return s.Split(',', ';').Select(fr => fr.Trim());
}

List<NuSpecContent> GetContent(IEnumerable<string> frameworks, DirectoryPath libDir, string pattern = null) {
    return frameworks.SelectMany(f => new[] { 
        new NuSpecContent() { Source = libDir + "/" + f + (pattern ?? "/*") + ".dll", Target = "lib/" + f},
        new NuSpecContent() { Source = libDir + "/" + f + (pattern ?? "/*") + ".xml", Target = "lib/" + f}
    })
    .Select(c => {
        c.Source = c.Source.Trim('.', '/');
        return c;
    }).ToList();
}